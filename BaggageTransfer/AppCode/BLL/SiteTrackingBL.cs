//using BaggageTransfer.AppCode.DAL;
//using BaggageTransfer.AppCode.Models;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web;

//namespace BaggageTransfer.AppCode.BLL
//{
//    public static class SiteTrackingBL
//    {
//        public static long TotalUserOnline = 0;

//        public static void AddVisitor(WebsiteVisitor visitor)
//        {
//            using (var context = new PIEntities())
//            {
//                if (SiteTrackingContainer.Visitors.Count(i => i.UniqueInfo == visitor.UniqueInfo) < 1)
//                {
//                    SiteTrackingContainer.Visitors.Add(visitor);

//                    UpdateWebsiteVisitor(visitor, context);
//                }

//                HitCounterBL.AddCount(visitor.IpAddress, context);
//            }
//        }

//        public static void UpdateWebsiteVisitor(WebsiteVisitor visitor)
//        {
//            using (var context = new PIEntities())
//            {
//                UpdateWebsiteVisitor(visitor, context);
//            }
//        }

//        public static void UpdateWebsiteVisitor(WebsiteVisitor visitor, PIEntities context)
//        {
//            VisitorsTrackingRecord model = context.VisitorsTrackingRecords.Where(i => i.UniqueInfo.Equals(visitor.UniqueInfo) && null != visitor.UniqueInfo && !"".Equals(visitor.UniqueInfo.Trim())).FirstOrDefault();

//            if (model == null)
//            {
//                context.VisitorsTrackingRecords.Add(new VisitorsTrackingRecord
//                {
//                    EnterUrl = visitor.EnterUrl,
//                    IpAddress = visitor.IpAddress,
//                    SessionId = visitor.SessionId,
//                    SessionStarted = visitor.SessionStarted,
//                    UniqueInfo = visitor.UniqueInfo,
//                    UserAgent = visitor.UserAgent,
//                    UrlReferrer = visitor.UrlReferrer,
//                    CookieValue = visitor.CookieValue
//                });

//                context.SaveChanges();
//            }
//            else
//            {
//                model.IpAddress = visitor.IpAddress;

//                model.UniqueInfo = model.IpAddress.Replace(" ", "") + model.UserAgent.Replace(" ", "") + model.CookieValue;

//                context.VisitorsTrackingRecords.Attach(model);

//                context.Entry(model).State = EntityState.Modified;

//                context.SaveChanges();
//            }
//        }

//        public static void InitializeVisitorsTrackingRecord()
//        {
//            using (var context = new PIEntities())
//            {
//                InitializeVisitorsTrackingRecord(context);
//            }
//        }

//        public static async void InitializeVisitorsTrackingRecord(PIEntities context)
//        {
//            if (SiteTrackingContainer.Visitors.Count <= 0)
//            {
//                var list = await GetSiteTrackingList();

//                foreach (var item in list)
//                {
//                    SiteTrackingContainer.Visitors.Add(item);
//                }
//            }
//        }

//        private static async Task<List<WebsiteVisitor>> GetVisitorsList(PIEntities context)
//        {
//            return await context.VisitorsTrackingRecords.Select(model => new WebsiteVisitor
//            {
//                EnterUrl = model.EnterUrl,
//                IpAddress = model.IpAddress,
//                SessionId = model.SessionId,
//                SessionStarted = model.SessionStarted,
//                UniqueInfo = model.UniqueInfo,
//                UserAgent = model.UserAgent,
//                UrlReferrer = model.UrlReferrer,
//                CookieValue = model.CookieValue

//            }).ToListAsync();
//        }

//        private static async Task<List<WebsiteVisitor>> GetSiteTrackingList()
//        {
//            using (var context = new PIEntities())
//            {
//                return await GetVisitorsList(context);
//            }
//        }

//        public static long GetTotalVisitors()
//        {
//            using (var context = new PIEntities())
//            {
//                return GetTotalVisitors(context);
//            }
//        }

//        public static long GetTotalVisitors(PIEntities context)
//        {
//            return context.VisitorsTrackingRecords.Count();
//        }
//    }
//}