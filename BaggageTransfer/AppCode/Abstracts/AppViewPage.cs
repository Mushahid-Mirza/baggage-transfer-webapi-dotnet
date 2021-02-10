using BaggageTransfer.AppCode.BLL;
using BaggageTransfer.Controllers;
using BaggageTransfer.Factories;
using BaggageTransfer.Helpers; 
using BaggageTransfer.SettingsHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace BaggageTransfer.Abstracts
{
    public abstract class AppViewPage<TModel> : WebViewPage<TModel>
    {  
        protected AppUserPrincipal CurrentUser
        {
            get
            {
                return new AppUserPrincipal(this.User as ClaimsPrincipal);
            }
        }

        protected string Direction
        {
            get
            {
                return CookiesHelper.GetCookie(Constants.Keys.CurrentCultureDirectionCookieKey);
            }
        }

        protected string Locale
        {
            get
            {
                return CookiesHelper.GetCookie(Constants.Keys.CurrentCultureCookieKey);
            }
        }

        protected string LocaleName
        {
            get
            {
                return LanguageHelper.GetLanguages().FirstOrDefault(c => c.Locale == Locale)?.Name;
            }
        }

        protected string Theme
        {
            set
            {
                Session["Theme"] = value;
                Layout = ThemeHelper.GetTheme(value);
            }
        }

        protected string LogoUrl
        {
            get
            {
                return Url.Content(AppConfig.LogoRelativeURL);
            }
        }

        public string GetGraphics(string path)
        {
            return Url.Content(AppConfig.GetContentGraphics("Graphics", Session["Theme"].ToString()) + "/" + path);
        }


        protected static string Language(string key)
        {
            return LanguageHelper.GetKey(key);
        }

        protected static string Language(string key, string locale)
        {
            return LanguageHelper.GetKey(key, locale);
        }

        protected static IHtmlString ScriptRender(string bundleName)
        {
            return Scripts.Render($"~/Script_{bundleName}");// + ThemeHelper.GetCurrentBundleVersion());
        }

        protected static IHtmlString StyleRender(string theme)
        {
            return Styles.Render($"~/Theme_{theme}");// + ThemeHelper.GetCurrentBundleVersion());
        }

        protected static string CompareAndGet(string text, string compareText, string returnText)
        {
            return text.Equals(compareText) ? returnText : "";
        }

        protected static bool isFromApp(HttpRequestBase request)
        {
            bool formCriteria = request.Form["isRequestFromApp"] != null && request.Form["isRequestFromApp"] == "true";
            bool queryCrietera = request.QueryString["isRequestFromApp"] != null && request.QueryString["isRequestFromApp"] == "true";
            return formCriteria || queryCrietera;
        }
    }

    public abstract class AppViewPage : AppViewPage<dynamic>
    {
    }
}
