using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    public class SmsSendController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        //
        // GET: /SmsSend/
        public ActionResult Index()
        {
            return View();
        }

        int counter = 1;

        [HttpPost]
        public int SmsSending(SmsSend dto) // which = 1 for admissin 2 for payment 3 for attendance
        {
            try
            {
                if (counter > 1)
                {
                    return 0;
                }

                counter++;
                if (dto.SmsType == 1)
                {
                    int count = 0;
                    var clients = db.StudentResigtrations.ToList();
                    foreach (var client in clients)
                    {
                        if (!string.IsNullOrEmpty(dto.Message) && !string.IsNullOrEmpty(client.PhoneNumber))
                        {
                            ++count;
                            SMSSend(dto.Message, client.PhoneNumber);
                        }
                      }

                      return count > 0 ? 1 : 0;
                    }

                if (!string.IsNullOrEmpty(dto.Message) && !string.IsNullOrEmpty(dto.PhoneNumber))
                {
                    SMSSend(dto.Message, dto.PhoneNumber);
                    return 1;
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        static void SMSSend(string messsage, string number)
        {

            String userid = "01781098775"; //Your Login ID
            String password = "Badsha2020#"; //Your Password
            //Recipient Phone Number multiple number must be separated by comma
            String message = System.Uri.EscapeUriString(messsage);

            // Create a request using a URL that can receive a post.   
            WebRequest request = WebRequest.Create("http://66.45.237.70/api.php");
            // Set the Method property of the request to POST.  
            request.Method = "POST";
            // Create POST data and convert it to a byte array.  
            string postData = "username=" + userid + "&password=" + password + "&number=" + number + "&message=" + message;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.  
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.  
            request.ContentLength = byteArray.Length;
            // Get the request stream.  
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.  
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.  
            dataStream.Close();
            // Get the response.  
            WebResponse response = request.GetResponse();
            // Display the status.  
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.  
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.  
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.  
            string responseFromServer = reader.ReadToEnd();
            // Display the content.  
            Console.WriteLine(responseFromServer);
            // Clean up the streams.  
            reader.Close();
            dataStream.Close();
            response.Close();

        }

	}
}