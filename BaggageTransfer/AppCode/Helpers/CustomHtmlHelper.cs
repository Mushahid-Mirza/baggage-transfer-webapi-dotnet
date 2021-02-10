using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaggageTransfer.AppCode.Helpers
{
    public static class CustomHtmlHelper
    {
        public static dynamic GetPageViewBag(this HtmlHelper html)
        {
            if (html == null || html.ViewContext == null)
            {
                return html.ViewBag;
            }

            ControllerBase controller = html.ViewContext.Controller;

            while (controller.ControllerContext.IsChildAction)  //traverse hierachy to get root controller
            {
                controller = controller.ControllerContext.ParentActionViewContext.Controller;
            }

            return controller.ViewBag;
        }
    }
}