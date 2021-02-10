using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.EntityFramework;
using System.Data.Entity;

namespace BaggageTransfer.Factories
{ 
    [DbConfigurationType(typeof(MySqlEFConfiguration))] 
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext()
            : base("DefaultConnection")
        {
        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
    }
}
