using BaggageTransfer.Factories;
using BaggageTransfer.Models;
using BaggageTransfer.Models.EntityModels;
using BaggageTransfer.Models.ViewModels.RequestVM;
using BaggageTransfer.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BaggageTransfer.Controllers
{
    [RoutePrefix("api/activities")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ActivityController : ApiController
    {

        [Route("find-users")]
        [HttpPost]
        public async Task<IHttpActionResult> FindUsers(FindUserRquestVM model)
        {
            try
            {
                var responseObj = new ReturnObject<object>();

                float startLat = model.Start[0];
                float endLat = model.Destination[0];

                DateTime fiveHoursBefore = DateTime.Now;
                fiveHoursBefore = fiveHoursBefore.AddHours(-5);


                DateTime fiveHoursAfter = DateTime.Now;
                fiveHoursAfter = fiveHoursAfter.AddHours(5);

                float startLon = model.Start[1];
                float endLon = model.Destination[1];

                using (var context = new ApplicationDbContext())
                {
                    var user = context.Users.Where(i => i.Email == model.UserId).FirstOrDefault();
                    if (user == null)
                    {
                        return BadRequest();
                    }

                    RequestType requestType = model.ReqquestType == "travel" ? RequestType.Travel : RequestType.Baggage;

                    var filteredQuery = await context.UserEnquireis.Where(x => user.Id != x.UserId &&
                                                x.ActiveTill > DateTime.Now &&
                                                x.ActiveTill < fiveHoursAfter).ToListAsync();

                    var usersMatchingInOneKm = filteredQuery.Where(x =>
                                                //((12742 * Math.Asin(Math.Sqrt(Math.Sin(((Math.PI / 180) * (x.StartLat - startLat)) / 2) * Math.Sin(((Math.PI / 180) * (x.StartLat - startLat)) / 2) +
                                                //            Math.Cos((Math.PI / 180) * startLat) * Math.Cos((Math.PI / 180) * (x.StartLat)) *
                                                //                Math.Sin(((Math.PI / 180) * (x.StartLong - startLon)) / 2) * Math.Sin(((Math.PI / 180) * (x.StartLong - startLon)) / 2)))) <= 1)

                                                //  &&
                                                ((12742 * Math.Asin(Math.Sqrt(Math.Sin(((Math.PI / 180) * (x.EndLat - endLat)) / 2) * Math.Sin(((Math.PI / 180) * (x.EndLat - endLat)) / 2) +
                                                            Math.Cos((Math.PI / 180) * endLat) * Math.Cos((Math.PI / 180) * (x.EndLat)) *
                                                                Math.Sin(((Math.PI / 180) * (x.EndLong - endLon)) / 2) * Math.Sin(((Math.PI / 180) * (x.EndLong - endLon)) / 2)))) <= 1))

                                                .OrderBy(x => ((12742 * Math.Asin(Math.Sqrt(Math.Sin(((Math.PI / 180) * (x.StartLat - startLat)) / 2) * Math.Sin(((Math.PI / 180) * (x.StartLat - startLat)) / 2) +
                                                            Math.Cos((Math.PI / 180) * startLat) * Math.Cos((Math.PI / 180) * (x.StartLat)) *
                                                                Math.Sin(((Math.PI / 180) * (x.StartLong - startLon)) / 2) * Math.Sin(((Math.PI / 180) * (x.StartLong - startLon)) / 2))))));

                    var list = usersMatchingInOneKm.ToList();

                    responseObj.Data = list;

                    var icon = requestType == RequestType.Travel ? " scooter" : " bag";

                    if (list.Count > 0)
                    {
                        var s = list.Count > 1 ? "s" : "";

                        responseObj.Message = "You have " + list.Count + " user" + s + " nearby, click on the circled " + icon + " icons in the map to requst them";
                    }
                    else
                    {
                        responseObj.Message = "We couldn't find any active user nearby currently, you ";
                    }
                }
                return Ok(responseObj);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("upload-aadhar")]
        public async Task<IHttpActionResult> ProfileImagePostAsync()
        {
            System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;

            var responseObj = new ReturnObject<string>();
            string[] extensions = { ".jpg", ".jpeg", ".gif", ".bmp", ".png" };

            var res = Utilities.UploadFile(hfc[0], new FileUploadSettings
            {
                FileType = FileType.Image,
                MaxSize = 200,
                StoragePath = "~/Storage/Uploads/Images/"
            });

            responseObj.IsSuccess = res.IsSuccess;
            responseObj.Message = res.Message;

            if (res.IsSuccess)
            {

                var userEmail = Request.GetOwinContext().Request.User.Identity.Name;

                using (var context = new ApplicationDbContext())
                {
                    var user = context.Users.Where(i => i.Email == userEmail).FirstOrDefault();
                    user.AadharUrl = res.Name;
                    context.Users.Attach(user);
                    context.Entry(user).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                }

                return Ok(responseObj);
            }

            return Ok(responseObj);
        }

        [Route("add-enquiry")]
        [HttpPost]
        public async Task<IHttpActionResult> AddEnquiry([FromBody] EnquiryRequestVM model)
        {
            try
            {
                var responseObj = new ReturnObject<object>();
                using (var context = new ApplicationDbContext())
                {
                    var user = context.Users.Where(i => i.Email == model.UserId).FirstOrDefault();
                    if (user == null)
                    {
                        return BadRequest();
                    }
                    DateTime date = DateTime.Now;
                    date = date.AddHours(model.ActiveTillHours);
                    date = date.AddMinutes(model.ActiveTillMinutes);

                    context.UserEnquireis.Add(new UserEnquiry()
                    {
                        RequestType = model.RequestType == "travel" ? RequestType.Travel : RequestType.Baggage,
                        ActiveTill = date,
                        EndLat = model.EndGeo[0],
                        EndLong = model.EndGeo[1],
                        StartLat = model.StartGeo[0],
                        StartLong = model.StartGeo[1],
                        UserId = user.Id
                    });

                    await context.SaveChangesAsync();
                    responseObj.IsSuccess = true;
                    var s1 = model.ActiveTillHours > 1 ? "s" : "";
                    var s2 = model.ActiveTillMinutes > 1 ? "s" : "";
                    responseObj.Message = "You'll be visible for nearby users for next " + model.ActiveTillHours + " hour " + s1 + " and " + model.ActiveTillMinutes + " minute" + s2;
                    return Ok(responseObj);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("save-user-details")]
        public async Task<IHttpActionResult> SaveUserDetails([FromBody] SaveUserRequestVM request)
        {
            try
            {
                var res = new ReturnObject<dynamic>();

                var userEmail = Request.GetOwinContext().Request.User.Identity.Name;

                using (var context = new ApplicationDbContext())
                {
                    var user = await context.Users.Where(i => i.Email == userEmail).FirstOrDefaultAsync();
                    user.PhoneNumber = request.PhoneNumber;
                    user.FullName = request.FullName;
                    user.Address = request.Address;
                    user.DateOfBirth = request.DateOfBirth;
                    user.PhoneNumber = request.PhoneNumber;

                    context.Users.Attach(user);
                    context.Entry(user).State = EntityState.Modified;
                    await context.SaveChangesAsync();

                    res.IsSuccess = true;
                    res.Message = "Saved Successfully";

                    return Ok(res);
                }

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("get-user-details")]
        public async Task<IHttpActionResult> GetUserDetails()
        {

            try
            {
                var res = new ReturnObject<dynamic>();

                var userEmail = Request.GetOwinContext().Request.User.Identity.Name;

                using (var context = new ApplicationDbContext())
                {
                    var user = await context.Users.Where(i => i.Email == userEmail)
                        .Select(item => new
                        {
                            FullName = item.FullName,
                            UserEmail = item.UserName,
                            Email = item.Email,
                            UserId = item.Id,
                            UserName = item.UserName,
                            PhoneNumber = item.PhoneNumber,
                            Address = item.Address,
                            AadharUrl = item.AadharUrl,
                            DateOfBirth = item.DateOfBirth
                        }).FirstOrDefaultAsync();



                    res.IsSuccess = true;

                    res.Data = user;

                    return Ok(res);

                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("get-bookings")]
        public async Task<IHttpActionResult> GetBookings()
        {

            try
            {
                var res = new ReturnObject<object>();

                var userEmail = Request.GetOwinContext().Request.User.Identity.Name;

                using (var context = new ApplicationDbContext())
                {
                    var user = await context.Users.Where(i => i.Email == userEmail).FirstOrDefaultAsync();

                    var userBookings = await context.BaggageRequests
                            .Where(i => i.RequesterEnquiry != null &&
                                        i.RequesterEnquiry.UserId == user.Id)
                            .Include("RequesterEnquiry").Include(i => i.RequesterEnquiry.User)
                            .ToListAsync();

                    var userTravels = await context.BaggageRequests
                            .Where(i => i.MoverEnquiry != null &&
                                        i.MoverEnquiry.UserId == user.Id)
                            .Include("MoverEnquiry").Include(i => i.MoverEnquiry.User)
                            .ToListAsync();

                    res.Data = new
                    {
                        Bookings = userBookings,
                        userTravels = userTravels
                    };

                    return Ok(res.Data);

                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        //public async Task<IHttpActionResult> GetNotifications()
        //{
        //    using (var context = new ApplicationDbContext())
        //    {
        //        conte
        //    }
        //}
    }
}
