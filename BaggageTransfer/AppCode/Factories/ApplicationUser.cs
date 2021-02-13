using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BaggageTransfer.Factories
{
    public class ApplicationUser : IdentityUser
    {
        public string DeviceId { get; set; }
         
        public string FullName { get; set; }
         
        public string AadharUrl { get; set; }

        public string Address { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            //// Add custom user claims here
            //var identity = new List<Claim>();
            //identity.Add(new Claim("", ""));

            //userIdentity.AddClaims(identity);

            return userIdentity;
        }
    }
}