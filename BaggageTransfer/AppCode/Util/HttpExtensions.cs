using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaggageTransfer.Util
{
    public static class HttpExtensions
    {
        public static string GetAbsolutePathWithQuery(this HttpRequestBase request)
        {
            return GetAbsolutePathWithQuery(request.Url);
        }

        public static string GetAbsolutePathWithQuery(this Uri requestUrl)
        {
            return  requestUrl.AbsolutePath + requestUrl.Query;
        }

        public static string GetReturnUrl(this HttpRequestBase request, string fallBackUrl)
        {
            return  "/" + request.QueryString["returnUrl"] != null ? request.QueryString["returnUrl"] : fallBackUrl; 
        }
    }
}