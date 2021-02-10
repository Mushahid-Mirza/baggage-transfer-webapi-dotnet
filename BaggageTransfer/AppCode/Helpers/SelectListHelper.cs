using BaggageTransfer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaggageTransfer.AppCode.Helpers
{
    public static class SelectListHelper
    {
        public static List<SelectListItem> ToSelectList(this List<OListItem> oList)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach (var item in oList)
            {
                selectList.Add(new SelectListItem()
                {
                    Text = item.Text,
                    Value = item.Value,
                    Selected = item.Selected,
                    Disabled = item.Disabled
                });
            }

            return selectList;
        }
    }
}