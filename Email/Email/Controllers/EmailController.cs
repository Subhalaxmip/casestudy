using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Email.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Form(string receiverEmail, string Subject, string message)
        {

            try
            {
                  if (ModelState.IsValid)
                  {
                    var senderemail = new MailAddress("appcarwasher39@gmail.com", "Carwasher");
                    var receiveremail = new MailAddress(receiverEmail, "Receiver");

                    var password = "Demo12345";
                    var Sub = Subject;
                    var body = message;

                    var stamp = new SmtpClient
                    {
                        Host = "Smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderemail.Address, password)


                    };

                    
                  }

            }
            catch(Exception)
            {
                ViewBag.Error = "There are some problems in sending email";
            }

            return View();
        }
    }
}