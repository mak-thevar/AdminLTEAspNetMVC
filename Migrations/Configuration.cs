namespace AspMVCAdminLTE.Migrations
{
    using AspMVCAdminLTE.Entity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AspMVCAdminLTE.Repository.RepositoryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Repository.RepositoryContext context)
        {
            //  This method will be called after migrating to the latest version.
            if (context.Users.Count() > 0)
            {
                return;
            }
            context.Users.AddRange(BuildUserList());
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {

                throw;
            }
        }

        private IEnumerable<User> BuildUserList()
        {
            var users = new List<User>
             {
               new User
               {
                   FirstName = "Super",
                   LastName = "Admin",
                   UserName = "sadmin",
                   Email = "superadmin@gmail.com",
                   Mobile = "0000000000",
                   Password = Utils.Encryption.HashString("pwd@1234"),
                   UserRole = Entity.Enums.UserRole.Admin
               }
           };
            return users;
        }
    }
}
