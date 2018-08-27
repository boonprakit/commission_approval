using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;

public class Commission
{
	public string id { get; set; }

	public string marketing_firstname { get; set; }
	public string marketing_lastname { get; set; }
	public string marketing_id { get; set; }
	public string marketing_team { get; set; }

	public string customer_firstname { get; set; }
	public string customer_lastname { get; set; }
	public string customer_bank_id { get; set; }
	public string customer_id { get; set; }

	public string percent_option_1 { get; set; }
	public string percent_option_2 { get; set; }
	public string percent_option_3 { get; set; }
	public string percent_option_4 { get; set; }

	public string note_text { get; set; }
	public string note_file { get; set; }

	public string boss_1_comment { get; set; }
	public string boss_2_comment { get; set; }

	public string percent_option_1_first_comment { get; set; }
	public string percent_option_2_first_comment { get; set; }
	public string percent_option_3_first_comment { get; set; }
	public string percent_option_4_first_comment { get; set; }

	public string percent_option_1_second_comment { get; set; }
	public string percent_option_2_second_comment { get; set; }
	public string percent_option_3_second_comment { get; set; }
	public string percent_option_4_second_comment { get; set; }

	public string boss_1_done { get; set; }
	public string boss_2_done { get; set; }
}

namespace commission_approval
{
	public class CommissionController : ApiController
	{

		// กรณีมี username และ password ให้เพิ่ม User ID=username;password=password;
		// Example	: "Server=SMNODAME; Database=commission_approval; User ID=username;password=password; Integrated Security=True";

		string	constr = "Server=SMNODAME; Database=commission_approval; Integrated Security=True";

		string	host = "http://localhost:49919";
		string	email_from = "boonprakitchaikaew@gmail.com";

		string email_to_boss1 = "veeraphat.ph@countrygroup.co.th";
		string email_to_boss2 = "thanachote.th@countrygroup.co.th";

		string email_to_opar1 = "pornthip.ru@countrygroup.co.th";
		string email_to_opar2 = "netchanok.pu@country.group.co.th";

		string email_server = "smtp.gmail.com";
		int		email_server_port = 587;
		string	email_username = "boonprakitchaikaew@gmail.com";
		string	email_password = "xxxx"; 
		

		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<controller>/5
		public Commission Get(string id)
		{
			SqlConnection con = new SqlConnection(constr);
			con.Open();
			string QueryString = "select * from commission where id = '" + id + "'";
			SqlCommand cmd = new SqlCommand(QueryString, con);
			SqlDataReader reader = cmd.ExecuteReader();
			Commission data = new Commission();
			while (reader.Read())
			{
				data.id = reader["id"].ToString();
				data.marketing_firstname = reader["marketing_firstname"].ToString();
				data.marketing_lastname = reader["marketing_lastname"].ToString();
				data.marketing_id = reader["marketing_id"].ToString();
				data.marketing_team = reader["marketing_team"].ToString();

				data.customer_firstname = reader["customer_firstname"].ToString();
				data.customer_lastname = reader["customer_lastname"].ToString();
				data.customer_bank_id = reader["customer_bank_id"].ToString();
				data.customer_id = reader["customer_id"].ToString();

				data.percent_option_1 = reader["percent_option_1"].ToString();
				data.percent_option_2 = reader["percent_option_2"].ToString();
				data.percent_option_3 = reader["percent_option_3"].ToString();
				data.percent_option_4 = reader["percent_option_4"].ToString();

				data.note_text = reader["note_text"].ToString();
				data.note_file = reader["note_file"].ToString();

				data.boss_1_comment = reader["boss_1_comment"].ToString();
				data.boss_2_comment = reader["boss_2_comment"].ToString();

				data.percent_option_1_first_comment = reader["percent_option_1_first_comment"].ToString();
				data.percent_option_2_first_comment = reader["percent_option_2_first_comment"].ToString();
				data.percent_option_3_first_comment = reader["percent_option_3_first_comment"].ToString();
				data.percent_option_4_first_comment = reader["percent_option_4_first_comment"].ToString();

				data.percent_option_1_second_comment = reader["percent_option_1_second_comment"].ToString();
				data.percent_option_2_second_comment = reader["percent_option_2_second_comment"].ToString();
				data.percent_option_3_second_comment = reader["percent_option_3_second_comment"].ToString();
				data.percent_option_4_second_comment = reader["percent_option_4_second_comment"].ToString();

				data.boss_1_done = reader["boss_1_done"].ToString();
				data.boss_2_done = reader["boss_2_done"].ToString();
			}
			return data;
		}


		// POST api/<controller>
		public void Post(Commission data)
		{
			System.Diagnostics.Debug.WriteLine("start writing to db");
			System.Diagnostics.Debug.WriteLine(data.id);
			SqlConnection con = new SqlConnection(constr);
			con.Open();
			string QueryString = "INSERT INTO commission " +
				"(id, marketing_firstname, marketing_lastname, marketing_id, marketing_team, " +
				"customer_firstname, customer_lastname, customer_bank_id, customer_id, " +
				"percent_option_1, percent_option_2, percent_option_3, percent_option_4, " +
				"note_text, note_file) " +
				"VALUES(@var1, " +
				"@var2, @var3, @var4, @var5, " +
				"@var6, @var7, @var8, @var9, " +
				"@var10, @var11, @var12, @var13, " +
				"@var14, @var15); ";
			SqlCommand cmd = new SqlCommand(QueryString, con);
			cmd.Parameters.AddWithValue("@var1", data.id);

			cmd.Parameters.AddWithValue("@var2", data.marketing_firstname);
			cmd.Parameters.AddWithValue("@var3", data.marketing_lastname);
			cmd.Parameters.AddWithValue("@var4", data.marketing_id);
			cmd.Parameters.AddWithValue("@var5", data.marketing_team);

			cmd.Parameters.AddWithValue("@var6", data.customer_firstname);
			cmd.Parameters.AddWithValue("@var7", data.customer_lastname);
			cmd.Parameters.AddWithValue("@var8", data.customer_bank_id);
			cmd.Parameters.AddWithValue("@var9", data.customer_id);

			cmd.Parameters.AddWithValue("@var10", data.percent_option_1);
			cmd.Parameters.AddWithValue("@var11", data.percent_option_2);
			cmd.Parameters.AddWithValue("@var12", data.percent_option_3);
			cmd.Parameters.AddWithValue("@var13", data.percent_option_4);

			cmd.Parameters.AddWithValue("@var14", data.note_text);
			cmd.Parameters.AddWithValue("@var15", data.note_file);
			cmd.ExecuteNonQuery();
			string token_user_1 = "56A3A95FE33D878A471DAF6BC9319";
			string token_user_2 = "37F5BDACD55CAAD7751CDB6EEFA39";
			MailMessage mailMessage = new MailMessage();
			mailMessage.From = new MailAddress(email_from);
			mailMessage.To.Add(new MailAddress(email_to_boss1));

			// Specify the email body
			mailMessage.IsBodyHtml = true;

			string html = File.ReadAllText(Path.Combine(HttpContext.Current.Server.MapPath("~"), "email.html"));
			html = html.Replace("__marketing_firstname__", data.marketing_firstname);
			html = html.Replace("__marketing_lastname__", data.marketing_lastname);
			html = html.Replace("__marketing_id__", data.marketing_id);
			html = html.Replace("__marketing_team__", data.marketing_team);

			html = html.Replace("__customer_firstname__", data.customer_firstname);
			html = html.Replace("__customer_lastname__", data.customer_lastname);
			html = html.Replace("__customer_bank_id__", data.customer_bank_id);
			html = html.Replace("__customer_id__", data.customer_id);

			html = html.Replace("__percent_option_1__", data.percent_option_1);
			html = html.Replace("__percent_option_2__", data.percent_option_2);
			html = html.Replace("__percent_option_3__", data.percent_option_3);
			html = html.Replace("__percent_option_4__", data.percent_option_4);

			html = html.Replace("__note_text__", data.note_text);
			html = html.Replace("__note_file__", host + "/fileupload/" + data.note_file);

			string html_user_1 = html.Replace("__link_here__", host + "/#/approve/" + data.id +"/"+ token_user_1);
			html_user_1 = html_user_1.Replace("__boss_name__", "ดร.วีรพัฒน์ เพชรคุปต์ ประธารเจ้าหน้าที่บริหาร");
			mailMessage.Body = html_user_1;
		
			mailMessage.Subject = "แบบคำร้องขอค่าคอมมิสชัน";
			
			SmtpClient smtpClient = new SmtpClient(email_server, email_server_port);

			smtpClient.Credentials = new System.Net.NetworkCredential()
			{
				UserName = email_username,
				Password = email_password
			};
			smtpClient.EnableSsl = true;
			smtpClient.Send(mailMessage);

			// for user 2
			string html_user_2 = html.Replace("__link_here__", host + "/#/approve/" + data.id + "/" + token_user_2);
			html_user_2 = html_user_2.Replace("__boss_name__", "นายธนโชติ รุ่งสิทธิวัฒน์");
			mailMessage.To.Clear();
			mailMessage.Headers.Remove("to");
			mailMessage.To.Add(new MailAddress(email_to_boss2));
			mailMessage.Body = html_user_2;
			smtpClient.Send(mailMessage);
		}

		// PUT api/<controller>/5
		public void Put(string id, Commission data)
		{
			System.Diagnostics.Debug.WriteLine("start updating to db");
			System.Diagnostics.Debug.WriteLine(id);
			SqlConnection con = new SqlConnection(constr);
			con.Open();
			string QueryString = "UPDATE commission " +
				"SET percent_option_1_first_comment = @var1," +
				"    percent_option_2_first_comment = @var2," +
				"    percent_option_3_first_comment = @var3," +
				"    percent_option_4_first_comment = @var4," +
				"    boss_1_comment = @var5," +

				"    percent_option_1_second_comment = @var6," +
				"    percent_option_2_second_comment = @var7," +
				"    percent_option_3_second_comment = @var8," +
				"    percent_option_4_second_comment = @var9," +
				"    boss_2_comment = @var10," +

				"    boss_1_done = @var11," +
				"    boss_2_done = @var12" +

				"    WHERE id = @var13";
			SqlCommand cmd = new SqlCommand(QueryString, con);
			cmd.Parameters.AddWithValue("@var1", data.percent_option_1_first_comment);
			cmd.Parameters.AddWithValue("@var2", data.percent_option_2_first_comment);
			cmd.Parameters.AddWithValue("@var3", data.percent_option_3_first_comment);
			cmd.Parameters.AddWithValue("@var4", data.percent_option_4_first_comment);
			cmd.Parameters.AddWithValue("@var5", data.boss_1_comment);

			cmd.Parameters.AddWithValue("@var6", data.percent_option_1_second_comment);
			cmd.Parameters.AddWithValue("@var7", data.percent_option_2_second_comment);
			cmd.Parameters.AddWithValue("@var8", data.percent_option_3_second_comment);
			cmd.Parameters.AddWithValue("@var9", data.percent_option_4_second_comment);
			cmd.Parameters.AddWithValue("@var10", data.boss_2_comment);

			cmd.Parameters.AddWithValue("@var11", data.boss_1_done);
			cmd.Parameters.AddWithValue("@var12", data.boss_2_done);

			cmd.Parameters.AddWithValue("@var13", id);

			cmd.ExecuteNonQuery();
			if (data.boss_1_done == "true" && data.boss_2_done == "true")
			{
				MailMessage mailMessage = new MailMessage();
				mailMessage.From = new MailAddress(email_from);
				mailMessage.To.Add(new MailAddress(email_to_opar1));
				mailMessage.To.Add(new MailAddress(email_to_opar2));

				// Specify the email body
				mailMessage.IsBodyHtml = true;

				string html = File.ReadAllText(Path.Combine(HttpContext.Current.Server.MapPath("~"), "email_to_manager.html"));
				html = html.Replace("__marketing_firstname__", data.marketing_firstname);
				html = html.Replace("__marketing_lastname__", data.marketing_lastname);
				html = html.Replace("__marketing_id__", data.marketing_id);
				html = html.Replace("__marketing_team__", data.marketing_team);

				html = html.Replace("__customer_firstname__", data.customer_firstname);
				html = html.Replace("__customer_lastname__", data.customer_lastname);
				html = html.Replace("__customer_bank_id__", data.customer_bank_id);
				html = html.Replace("__customer_id__", data.customer_id);

				html = html.Replace("__percent_option_1__", data.percent_option_1);
				html = html.Replace("__percent_option_2__", data.percent_option_2);
				html = html.Replace("__percent_option_3__", data.percent_option_3);
				html = html.Replace("__percent_option_4__", data.percent_option_4);

				html = html.Replace("__note_text__", data.note_text);
				html = html.Replace("__note_file__", host + "/fileupload/" + data.note_file);

				html = html.Replace("__boss_1_comment__", data.boss_1_comment);
				html = html.Replace("__boss_2_comment__", data.boss_2_comment);

				html = html.Replace("__percent_option_1_approve__", data.percent_option_1_second_comment == "true" && data.percent_option_1_second_comment == "true" ? "อนุมัติ" : "ไม่อนุมัติ");
				html = html.Replace("__percent_option_2_approve__", data.percent_option_2_second_comment == "true" && data.percent_option_2_second_comment == "true" ? "อนุมัติ" : "ไม่อนุมัติ");
				html = html.Replace("__percent_option_3_approve__", data.percent_option_3_second_comment == "true" && data.percent_option_3_second_comment == "true" ? "อนุมัติ" : "ไม่อนุมัติ");
				html = html.Replace("__percent_option_4_approve__", data.percent_option_4_second_comment == "true" && data.percent_option_4_second_comment == "true" ? "อนุมัติ" : "ไม่อนุมัติ");

				html = html.Replace("__link_here__", host + "/#/feedback/" + data.id);
				mailMessage.Body = html;
				// Specify the email Subject
				mailMessage.Subject = "ผลการร้องขอค่าคอมมิสชัน";

				// Specify the SMTP server name and post number
				SmtpClient smtpClient = new SmtpClient(email_server, email_server_port);
				// Specify your gmail address and password

				smtpClient.Credentials = new System.Net.NetworkCredential()
				{
					UserName = email_username,
					Password = email_password
				};
				//  smtpClient.Credentials = CredentialCache.DefaultNetworkCredentials;
				// Gmail works on SSL, so set this property to true
				smtpClient.EnableSsl = true;
				// Finall send the email message using Send() method
				smtpClient.Send(mailMessage);
			}
		}

		// DELETE api/<controller>/5
		public void Delete(int id)
		{
		}
	}
}