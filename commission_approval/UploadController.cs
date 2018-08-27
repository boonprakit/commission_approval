using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace commission_approval
{
	public class UploadController : ApiController
	{
		// GET api/<controller>
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<controller>/5
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<controller>
		public void Post([FromBody]string value)
		{
			System.Diagnostics.Debug.WriteLine("Upload ctrl");
			if (HttpContext.Current.Request.Files.AllKeys.Any())
			{
				// Get the uploaded image from the Files collection
				var httpPostedFile = HttpContext.Current.Request.Files["file"];
				System.Diagnostics.Debug.WriteLine("Found file");

				if (httpPostedFile != null)
				{
					System.Diagnostics.Debug.WriteLine("start writing file");
					// Validate the uploaded image(optional)

					// Get the complete file path
					string fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/fileupload"), httpPostedFile.FileName.Split('\\').Last());

					System.Diagnostics.Debug.WriteLine(fileSavePath);
					// Save the uploaded file to "UploadedFiles" folder
					httpPostedFile.SaveAs(fileSavePath);
				}
			}
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/<controller>/5
		public void Delete(int id)
		{
		}
	}
}