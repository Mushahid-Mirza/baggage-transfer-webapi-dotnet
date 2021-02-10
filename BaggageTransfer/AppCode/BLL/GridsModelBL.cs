using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaggageTransfer.AppCode.BLL
{
    public class GridsModelBL
    {
        internal static object GetGridModel<T>(IQueryable<T> query, Func<IQueryable<T>, object, object> func, object model)
        {
            return func.DynamicInvoke(query, model); 
        }
    }
}