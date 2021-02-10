using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaggageTransfer.AppCode.Models
{
    public class WebsiteVisitor
    {
        public static string CookieKey = "$u_$v_^c";

        public string SessionId { get; set; }

        public string IpAddress { get; set; }

        public string UrlReferrer { get; set; }

        public string EnterUrl { get; set; }

        public string UserAgent { get; set; }

        public string UniqueInfo { get; set; }

        public string CookieValue { get; set; }

        public DateTime SessionStarted { get; set; }

        public WebsiteVisitor()
        {
        }

        public WebsiteVisitor(HttpContext context, string cookieValue)
        {
            this.UpdateInfo(context, cookieValue);
        }

        public void UpdateInfo(HttpContext context, string cookieValue)
        {

            if (context != null && context.Request != null && context.Session != null)
            {
                this.SessionId = context.Session.SessionID;

                this.SessionStarted = DateTime.UtcNow;

                this.UserAgent = context.Request.UserAgent ?? String.Empty;

                this.IpAddress = context.Request.UserHostAddress;

                this.CookieValue = cookieValue;
                  
                this.UniqueInfo = this.IpAddress.Replace(" ", "") + this.UserAgent.Replace(" ", "") + cookieValue;

                if (context.Request.UrlReferrer != null)
                {
                    this.UrlReferrer = String.IsNullOrWhiteSpace(context.Request.UrlReferrer.OriginalString) ? "" : context.Request.UrlReferrer.OriginalString;
                }

                this.EnterUrl = String.IsNullOrWhiteSpace(context.Request.Url.OriginalString) ? "" : context.Request.Url.OriginalString;
            }
        }
    }

    public class SiteTrackingContainer
    {
        public static readonly List<WebsiteVisitor> Visitors = new List<WebsiteVisitor>();
    }
}

//-------------------------------------------------------------

/*
 * this.UserAgent = String.IsNullOrEmpty(context.Request.UserAgent) ? "" : context.Request.UserAgent;
 */

//if (context.Request.IsAuthenticated)
//{
//    this.AuthUser = context.User.Identity.Name;
//    if (!String.IsNullOrEmpty(context.Request.ServerVariables["REMOTE_USER"]))
//        this.AuthUser = context.Request.ServerVariables["REMOTE_USER"];
//    else if (!String.IsNullOrEmpty(context.Request.ServerVariables["AUTH_USER"]))
//        this.AuthUser = context.Request.ServerVariables["AUTH_USER"];
//} 
//-------------------------------------------------------------
