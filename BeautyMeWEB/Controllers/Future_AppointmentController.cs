using BeautyMe;
using BeautyMeWEB.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace BeautyMeWEB.Controllers
{
    public class Future_AppointmentController : ApiController
    {
        // GET: Future_Appointment
        [HttpGet]
        [Route("api/Future_Appointment/AllFuture_Appointment")]
        public HttpResponseMessage GetAllFuture_Appointment()
        {
            BeautyMeDBContext db = new BeautyMeDBContext();
            List<Future_AppointmentDTO> AllFuture_Appointment = db.Future_Appointment.Select(x => new Future_AppointmentDTO
            {
                Future_appointment_number = x.Future_appointment_number,
                AddressStreet = x.AddressStreet,
                AddressHouseNumber = x.AddressHouseNumber,
                AddressCity = x.AddressCity,
                Appointment_status = x.Appointment_status,
                Client_ID_number = x.Client_ID_number,
                Type_treatment_Number = x.Type_treatment_Number,
                Number_appointment = x.Number_appointment
            }).ToList();
            if (AllFuture_Appointment != null)
                return Request.CreateResponse(HttpStatusCode.OK, AllFuture_Appointment);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound);
        }




        // Post: api/Post
        [HttpPost]
        [Route("api/Future_Appointment/NewFuture_Appointment/{Client_ID_number}/{Type_treatment_Number}/{Number_appointmentt}")]
        public HttpResponseMessage PostNewFuture_Appointment(string Client_ID_numberr, string Type_treatment_Numberr, string Number_appointmentt, [FromBody] Future_AppointmentDTO x)
        {
            BeautyMeDBContext db = new BeautyMeDBContext();
            Future_Appointment newFuture_Appointment = new Future_Appointment()
            {
                Future_appointment_number = x.Future_appointment_number,
                AddressStreet = x.AddressStreet,
                AddressHouseNumber = x.AddressHouseNumber,
                AddressCity = x.AddressCity,
                Appointment_status = x.Appointment_status,
                Client_ID_number = Client_ID_numberr,
                Type_treatment_Number = Type_treatment_Numberr,
                Number_appointment = Number_appointmentt
            };
            if (newFuture_Appointment != null)
            {
                db.Future_Appointment.Add(newFuture_Appointment);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "new Future_Appointment added to the dataBase");
            }
            else
                return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        // Delete: api/Delete
        [HttpDelete]
        [Route("api/Future_Appointment/CanceleFuture_Appointment")]
        public IHttpActionResult DeleteCanceleFuture_Appointment([FromBody] Future_AppointmentDTO x)
        {
            BeautyMeDBContext db = new BeautyMeDBContext();
            {
                if (x == null)  // בדיקת תקינות ה-DTO שהתקבל
                {
                    return BadRequest("הפרטים שהתקבלו אינם תקינים.");
                }

                Future_Appointment CanceleFuture_Appointment = db.Future_Appointment.Find(x.Number_appointment);   // חיפוש הרשומה המתאימה לפי המזהה שלה
                if (CanceleFuture_Appointment == null)
                {
                    return NotFound();
                }

                db.Future_Appointment.Remove(CanceleFuture_Appointment);   // מחיקת הרשומה מבסיס הנתונים

                db.SaveChanges();

                return Ok("הנתונים נמחקו בהצלחה.");  // החזרת תשובה מתאימה לפי המצב
            }
        }
    }
}