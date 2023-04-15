using BeautyMe;
using BeautyMeWEB.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using System.Data.Entity;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using System.Data.Entity.Infrastructure;

namespace BeautyMeWEB.Controllers
{
    public class Appointment_can_give_treatmentController : ApiController
    {
        // GET: api/Appointment_can_give_treatmentController/All_the_treatments_appointment_can_give
        [HttpGet]
        [Route("api/Appointment_can_give_treatmentController/All_the_treatments_appointment_can_give")]
        public HttpResponseMessage GetAll_the_treatments_appointment_can_give([FromBody] Appointment_can_give_treatmentDTO v)
        {
            BeautyMeDBContext db = new BeautyMeDBContext();
            List<Appointment_can_give_treatmentDTO> all_the_treatments_appointment_can_give = db.Appointment_can_give_treatment.Where(a => a.Number_appointment == v.Number_appointment).Select(x => new Appointment_can_give_treatmentDTO
            {
                number = x.number,
                Type_treatment_Number = x.Type_treatment_Number,
                Number_appointment = x.Number_appointment,

            }).ToList();
            if (all_the_treatments_appointment_can_give != null)
                return Request.CreateResponse(HttpStatusCode.OK, all_the_treatments_appointment_can_give);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // Post: api/Post
        [HttpPost]
        [Route("api/Appointment_can_give_treatment/NewAppointment_can_give_treatment")]
        public HttpResponseMessage PostNewAppointment_can_give_treatment([FromBody] Appointment_can_give_treatmentDTO x)
        {
            try
            {
                BeautyMeDBContext db = new BeautyMeDBContext();
                Appointment_can_give_treatment newAppointment_can_give_treatment = new Appointment_can_give_treatment()
                {
                    Type_treatment_Number = x.Type_treatment_Number,
                    Number_appointment = x.Number_appointment, 
                };
                db.Appointment_can_give_treatment.Add(newAppointment_can_give_treatment);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "new Appointment_can_give_treatment added to the dataBase");
            }
            catch (DbUpdateException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occurred while adding new Appointment_can_give_treatment to the database: " + ex.InnerException.InnerException.Message);
            }
        }
    }
}