using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Sprint_13_mvc.Models;

[assembly: OwinStartupAttribute(typeof(Sprint_13_mvc.Startup))]
namespace Sprint_13_mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }


        // In this method we will create default User roles and Admin user for login   
        private void createRolesandUsers()
        {
            Models.ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            if (!roleManager.RoleExists("Administrator"))
            {

                //Maak rol administrator aan   
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Administrator";
                roleManager.Create(role);

                //Maak gebruiker aan
                var user = new ApplicationUser();
                user.UserName = "DeJong";
                user.Email = "dejong@gmail.com";

                string userPWD = "Dejong13!";

                var chkUser = UserManager.Create(user, userPWD);

                //Zet rol als Administrator
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Administrator");

                }
            }

            // creating Creating Manager role    
            if (!roleManager.RoleExists("Bezoeker"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Bezoeker";
                roleManager.Create(role);

            }
        }
    }
}
