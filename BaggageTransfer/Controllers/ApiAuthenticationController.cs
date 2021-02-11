using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using BaggageTransfer.Factories;
using BaggageTransfer.Models;

namespace BaggageTransfer.Controllers
{
    [RoutePrefix("api/auth")]
    public class ApiAuthenticationController : ApiController
    {

        public readonly RoleManager<IdentityRole> roleManager;
        public readonly ApplicationSignInManager signInManager;

        [Authorize]
        [HttpGet]
        public IHttpActionResult GetSuggestion(string search)
        {
            List<String> obj = null;
            return Json(obj);
        }

        [HttpPost]
        public IHttpActionResult Logout()
        {
            if (User.Identity.IsAuthenticated)
            {

            }
            return Ok();
        }

        [Authorize]
        //[AllowAnonymous]
        [HttpGet]
        [Route("getuser")]
        public IHttpActionResult GetUser()
        {
            var identity = (ClaimsIdentity)User.Identity;
            using (var app = new ApplicationDbContext())
            {
                var roles = identity.Claims
                        .Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
                var LogTime = identity.Claims
                            .FirstOrDefault(c => c.Type == "LoggedOn").Value;


                try
                {
                    var user = app.Users.Where(i => i.Email == User.Identity.Name).FirstOrDefault();

                    return Ok(new
                    {
                        id = user.Id,
                        username = user.Email,
                        role = "staff",
                    });
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }

        }

    }
}
