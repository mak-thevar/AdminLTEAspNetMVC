using AspMVCAdminLTE.App_Start;
using AspMVCAdminLTE.Providers;
using AspMVCAdminLTE.Repository;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

[assembly: OwinStartup(typeof(AspMVCAdminLTE.Startup))]

namespace AspMVCAdminLTE
{
    public class Startup
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            HttpConfiguration config = new HttpConfiguration();
            var container = AutofacConfig.RegisterComponents();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //AutoMapperConfig.Configure();

            ConfigureOAuth(app);

            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            // Database.SetInitializer(new MigrateDatabaseToLatestVersion<RepositoryContext, Migrations.Configuration>());
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(90),
                Provider = new TokenAuthProvider(new RepositoryWrapper(new RepositoryContext()))
                //RefreshTokenProvider = new RefreshTokenProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(OAuthBearerOptions);
        }
    }
}