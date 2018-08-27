using System;
using System.Web;
using System.Web.Http;

namespace commission_approval.App_Start
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{

			config.MapHttpAttributeRoutes();
			config.Formatters.XmlFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("multipart/form-data"));
			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			// configure additional webapi settings here..
		}
	}
}
