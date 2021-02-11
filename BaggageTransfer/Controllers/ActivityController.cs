using BaggageTransfer.Models;
using BaggageTransfer.Models.EntityModels;
using BaggageTransfer.Models.ViewModels.RequestVM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace BaggageTransfer.Controllers
{
    [RoutePrefix("api/activities")]
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
                fiveHoursBefore.AddHours(-5);


                DateTime fiveHoursAfter = DateTime.Now;
                fiveHoursAfter.AddHours(5);

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

                    var filteredQuery = await context.UserEnquireis.Where(x => user.Id != x.UserId && x.RequestType == requestType &&
                                                x.ActiveTill > fiveHoursBefore &&
                                                x.ActiveTill < fiveHoursAfter).ToListAsync();

                    var usersMatchingInOneKm = filteredQuery.Where(x => 
                                                ((12742 * SqlFunctions.Asin(SqlFunctions.SquareRoot(SqlFunctions.Sin(((SqlFunctions.Pi() / 180) * (x.StartLat - startLat)) / 2) * SqlFunctions.Sin(((SqlFunctions.Pi() / 180) * (x.StartLat - startLat)) / 2) +
                                                            SqlFunctions.Cos((SqlFunctions.Pi() / 180) * startLat) * SqlFunctions.Cos((SqlFunctions.Pi() / 180) * (x.StartLat)) *
                                                                SqlFunctions.Sin(((SqlFunctions.Pi() / 180) * (x.StartLong - startLon)) / 2) * SqlFunctions.Sin(((SqlFunctions.Pi() / 180) * (x.StartLong - startLon)) / 2)))) <= 0.01)

                                                  &&
                                                ((12742 * SqlFunctions.Asin(SqlFunctions.SquareRoot(SqlFunctions.Sin(((SqlFunctions.Pi() / 180) * (x.EndLat - endLat)) / 2) * SqlFunctions.Sin(((SqlFunctions.Pi() / 180) * (x.EndLat - endLat)) / 2) +
                                                            SqlFunctions.Cos((SqlFunctions.Pi() / 180) * endLat) * SqlFunctions.Cos((SqlFunctions.Pi() / 180) * (x.EndLat)) *
                                                                SqlFunctions.Sin(((SqlFunctions.Pi() / 180) * (x.EndLong - endLon)) / 2) * SqlFunctions.Sin(((SqlFunctions.Pi() / 180) * (x.EndLong - endLon)) / 2)))) <= 0.01))

                                                .OrderBy(x => ((12742 * SqlFunctions.Asin(SqlFunctions.SquareRoot(SqlFunctions.Sin(((SqlFunctions.Pi() / 180) * (x.StartLat - startLat)) / 2) * SqlFunctions.Sin(((SqlFunctions.Pi() / 180) * (x.StartLat - startLat)) / 2) +
                                                            SqlFunctions.Cos((SqlFunctions.Pi() / 180) * startLat) * SqlFunctions.Cos((SqlFunctions.Pi() / 180) * (x.StartLat)) *
                                                                SqlFunctions.Sin(((SqlFunctions.Pi() / 180) * (x.StartLong - startLon)) / 2) * SqlFunctions.Sin(((SqlFunctions.Pi() / 180) * (x.StartLong - startLon)) / 2))))));
 
                    var list = usersMatchingInOneKm.ToList();

                    responseObj.Data = list;

                    var icon = requestType == RequestType.Travel ? " scooter" : " bag";

                    if (list.Count > 0)
                    {
                        var s = list.Count > 1 ? "s" : "";

                        responseObj.Message = "You have " + list.Count + " user" + s + " nearby, click on the circled "  + icon + " icons in the map to requst them";
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
                    date.AddHours(model.ActiveTillHours);
                    date.AddMinutes(model.ActiveTillMinutes);

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
                    responseObj.Message = "You'll be visible for nearby users for next " + model.ActiveTillHours  + " hour " + s1 + " and " + model.ActiveTillMinutes + " minute" + s2;
                    return Ok(responseObj);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
