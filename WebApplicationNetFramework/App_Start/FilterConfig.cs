﻿using System.Web;
using System.Web.Mvc;

namespace WebApplicationNetFramework
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());  //all app even Home is login restricted exept controllers with [AllowAnonymous]
        }
    }
}
