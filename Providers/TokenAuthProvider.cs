using AspMVCAdminLTE.Entity;
using AspMVCAdminLTE.Repository;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspMVCAdminLTE.Providers
{
    public class TokenAuthProvider : OAuthAuthorizationServerProvider
    {
        private User user = null;
        private IRepositoryWrapper _repoWrapper;

        public TokenAuthProvider(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            context.AdditionalResponseParameters.Add("UserId", this.user.Id);
            context.AdditionalResponseParameters.Add("Firstname", this.user.FirstName);
            context.AdditionalResponseParameters.Add("Lastname", this.user.LastName);
            context.AdditionalResponseParameters.Add("Username", this.user.UserName);
            return base.TokenEndpoint(context);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var user = _repoWrapper.User.ValidateUser(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("invalid_grant", "Provided username and password is incorrect");
                return;
            }
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Role, user.UserRole.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            identity.AddClaim(new Claim("Mobile", user.Mobile));
            identity.AddClaim(new Claim("Id", user.Id.ToString()));
            this.user = user;
            context.Validated(identity);
        }
    }
}