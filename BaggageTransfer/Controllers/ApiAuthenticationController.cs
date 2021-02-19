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
using System.Web;
using Microsoft.Owin.Security;
using System.Web.Http.Cors;

namespace BaggageTransfer.Controllers
{
    [RoutePrefix("api/auth")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ApiAuthenticationController : ApiController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ApiAuthenticationController()
        {
        }

        public ApiAuthenticationController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

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

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IHttpActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { FullName = model.FullName, PhoneNumber = model.PhoneNumber, UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                    return Ok();
                }
                return InternalServerError();
            } else
            {
                return BadRequest();
            }
        }

        [Authorize]
        //[AllowAnonymous]
        [HttpGet]
        [Route("get-user")]
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
                        fullname = user.FullName,
                        address = user.Address,
                        aadhar = user.AadharUrl,
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
