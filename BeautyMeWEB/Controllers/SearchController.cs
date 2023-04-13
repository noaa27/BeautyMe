using BeautyMe;
using BeautyMeWEB.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using System.Data.Entity;

namespace BeautyMeWEB.Controllers
{
    public class SearchController : ApiController
    {
        // GET: Search
        [HttpGet]
        [Route("api/Search/Searchh")]
        public HttpResponseMessage GetSearchh([FromBody] SearchDTO x)
        {
            if (x.Is_client_house == null && x.gender == null)
            {
                BeautyMeDBContext db = new BeautyMeDBContext();
                int number_treatment = db.Type_Treatment.FirstOrDefault(i => i.Name == x.NameTreatment).Type_treatment_Number;
                List<AppointmentDTO> SearchListForType_treatment = db.Appointment.Include(a => a.Appointment_can_give_treatment) // כדי לקבל את פרטי סוג הטיפול של התור
                                                                           .Include(a => a.Business) // כדי לקבל את פרטי העסק של התור
                                                                           .Where(a => a.Business.AddressCity == x.AddressCity && a.Appointment_can_give_treatment.Any(t => t.Type_treatment_Number == number_treatment))
                                                                           .Select(a => new AppointmentDTO
                                                                           {
                                                                               Number_appointment = a.Number_appointment,
                                                                               Date = a.Date,
                                                                               Start_time = a.Start_time,
                                                                               End_time = a.End_time,
                                                                               Is_client_house = a.Is_client_house,
                                                                               Business_Number = a.Business_Number,
                                                                           })
                                                                           .ToList(); //נוצרה רשימה של תורים לפי סוג הטיפול הרצוי והעיר
                return Request.CreateResponse(HttpStatusCode.OK, SearchListForType_treatment);
            }
            if (x.Is_client_house != null && x.gender == null)
            {
                BeautyMeDBContext db = new BeautyMeDBContext();
                int number_treatment = db.Type_Treatment.FirstOrDefault(i => i.Name == x.NameTreatment).Type_treatment_Number;
                List<AppointmentDTO> SearchListForType_treatment = db.Appointment.Include(a => a.Appointment_can_give_treatment) // כדי לקבל את פרטי סוג הטיפול של התור
                                                                           .Include(a => a.Business) // כדי לקבל את פרטי העסק של התור
                                                                           .Where(a => a.Business.AddressCity == x.AddressCity && a.Appointment_can_give_treatment.Any(t => t.Type_treatment_Number == number_treatment) && a.Is_client_house == x.Is_client_house)
                                                                           .Select(a => new AppointmentDTO
                                                                           {
                                                                               Number_appointment = a.Number_appointment,
                                                                               Date = a.Date,
                                                                               Start_time = a.Start_time,
                                                                               End_time = a.End_time,
                                                                               Is_client_house = a.Is_client_house,
                                                                               Business_Number = a.Business_Number,
                                                                           })
                                                                           .ToList(); //נוצרה רשימה של תורים לפי סוג הטיפול הרצוי, העיר והאם רצו בבית הלקוח או בבית העסק
                return Request.CreateResponse(HttpStatusCode.OK, SearchListForType_treatment);
            }
            if (x.Is_client_house == null && x.gender != null)
            {
                BeautyMeDBContext db = new BeautyMeDBContext();
                int number_treatment = db.Type_Treatment.FirstOrDefault(i => i.Name == x.NameTreatment).Type_treatment_Number;
                List<AppointmentDTO> SearchListForType_treatment = db.Appointment.Include(a => a.Appointment_can_give_treatment) // כדי לקבל את פרטי סוג הטיפול של התור
                                                                           .Include(a => a.Business) // כדי לקבל את פרטי העסק של התור
                                                                           .Include(a => a.Business.Professional) // כדי לקבל את פרטי בעל העסק
                                                                           .Where(a => a.Business.AddressCity == x.AddressCity && a.Appointment_can_give_treatment.Any(t => t.Type_treatment_Number == number_treatment)
                                                                                    && a.Business.Professional.gender == x.gender)
                                                                           .Select(a => new AppointmentDTO
                                                                           {
                                                                               Number_appointment = a.Number_appointment,
                                                                               Date = a.Date,
                                                                               Start_time = a.Start_time,
                                                                               End_time = a.End_time,
                                                                               Is_client_house = a.Is_client_house,
                                                                               Business_Number = a.Business_Number,
                                                                           })
                                                                           .ToList(); //נוצרה רשימה של תורים לפי סוג הטיפול הרצוי, העיר ומין בעל העסק הרצוי
                return Request.CreateResponse(HttpStatusCode.OK, SearchListForType_treatment);
            }
            else //if (x.Is_client_house != null && x.gender != null)
            {
                BeautyMeDBContext db = new BeautyMeDBContext();
                int number_treatment = db.Type_Treatment.FirstOrDefault(i => i.Name == x.NameTreatment).Type_treatment_Number;
                List<AppointmentDTO> SearchListForType_treatment = db.Appointment.Include(a => a.Appointment_can_give_treatment) // כדי לקבל את פרטי סוג הטיפול של התור
                                                                           .Include(a => a.Business) // כדי לקבל את פרטי העסק של התור
                                                                           .Include(a => a.Business.Professional) // כדי לקבל את פרטי בעל העסק
                                                                           .Where(a => a.Business.AddressCity == x.AddressCity && a.Appointment_can_give_treatment.Any(t => t.Type_treatment_Number == number_treatment)
                                                                                    && a.Is_client_house == x.Is_client_house && a.Business.Professional.gender == x.gender)
                                                                           .Select(a => new AppointmentDTO
                                                                           {
                                                                               Number_appointment = a.Number_appointment,
                                                                               Date = a.Date,
                                                                               Start_time = a.Start_time,
                                                                               End_time = a.End_time,
                                                                               Is_client_house = a.Is_client_house,
                                                                               Business_Number = a.Business_Number,
                                                                           })
                                                                           .ToList(); //נוצרה רשימה של תורים לפי סוג הטיפול הרצוי, העיר, האם רצו בבית הלקוח או בבית העסק, ומין בעל העסק הרצוי
                return Request.CreateResponse(HttpStatusCode.OK, SearchListForType_treatment);
            }
        }
    }
}


////public string NameTreatment;
////public string AddressCity;
////public string? gender; 
////public string? Is_client_house;
///


//    BeautyMeDBContext db = new BeautyMeDBContext();
//    string number_treatment;
//    //string number_treatment = db.Type_Treatment.Type_treatment_Number.Where(i => i.Name == NameTreatment).single....;
//    string queryForAppointment = "select *" +
//                                    "from Appointment a join Appointment_can_give_treatment ac on a.Number_appointment = ac.Number_appointment" +
//                                    "join Business b on a.Business_Number = b.Business_Number" +
//                                    $"where b.AddressCity = {x.AddressCity} and ac.Type_treatment_Number = {number_treatment}";
//    // הגדרת פרמטרים עבור השאילתה
//    SqlCommand command = new SqlCommand(queryForAppointment, db);
//    //command.Parameters.AddWithValue("@City", city);
//    //command.Parameters.AddWithValue("@TreatmentType", treatmentType);

//    // קריאה למסד הנתונים וקבלת התוצאות
//    SqlDataReader reader = command.ExecuteReader();

//    // עבודה עם התוצאות ויצירת רשימת התורים המתאימים
//    while (reader.Read())
//    {
//        Treatment appointment = new Treatment();
//        appointment.ID = Convert.ToInt32(reader["מספר_תור"]);
//        appointment.Date = Convert.ToDateTime(reader["תאריך_תור"]);
//        appointment.City = reader["עיר"].ToString();
//        appointment.TreatmentType = reader["שם_סוג_טיפול"].ToString();

//        appointments.Add(appointment);
//    }
//    if (x.gender == null && x.Is_client_house == null)
//    {
//        AppointmentDTO SearchListForType_treatment = db.Treatment_for_appointment.Where(a => a.Type_treatment_Number == number_treatment) && db.Business.Where(i => i.AddressCity == x.AddressCity)
//            .Select(x => new AppointmentDTO
//            {
//                Number_appointment = x.Number_appointment,
//                Date = x.Date,
//                Start_time = x.Start_time,
//                End_time = x.End_time,
//                Is_client_house = x.Is_client_house,
//                Business_Number = x.Business_Number,
//            }).ToList(); // נוצרה רשימה של תורים לפי הסוג טיפול הרצוי.
//    }
//    AppointmentDTO SearchListForType_treatment = db.Treatment_for_appointment.Where(a => a.Type_treatment_Number == number_treatment).Select(x => new AppointmentDTO
//    {
//        Number_appointment = x.Number_appointment,
//        Date = x.Date,
//        Start_time = x.Start_time,
//        End_time = x.End_time,
//        Is_client_house = x.Is_client_house,
//        Business_Number = x.Business_Number,
//    }).ToList(); // נוצרה רשימה של תורים לפי הסוג טיפול הרצוי.

//    AppointmentDTO SearchListForCity =
//        return Request.CreateResponse(HttpStatusCode.OK, c1);
//    else
//        return Request.CreateResponse(HttpStatusCode.NotFound);
//}



//    BeautyMeDBContext db = new BeautyMeDBContext();
//    string number_treatment;
//    //string number_treatment = db.Type_Treatment.Type_treatment_Number.Where(i => i.Name == NameTreatment).single....;
//    if (x.gender == null && x.Is_client_house == null)
//    {
//        AppointmentDTO SearchListForType_treatment = db.Treatment_for_appointment.Where(a => a.Type_treatment_Number == number_treatment) && db.Business.Where(i => i.AddressCity == x.AddressCity)
//            .Select(x => new AppointmentDTO
//        {
//            Number_appointment = x.Number_appointment,
//            Date = x.Date,
//            Start_time = x.Start_time,
//            End_time = x.End_time,
//            Is_client_house = x.Is_client_house,
//            Business_Number = x.Business_Number,
//        }).ToList(); // נוצרה רשימה של תורים לפי הסוג טיפול הרצוי.
//    }
//    AppointmentDTO SearchListForType_treatment = db.Treatment_for_appointment.Where(a => a.Type_treatment_Number == number_treatment).Select(x => new AppointmentDTO
//    {
//        Number_appointment = x.Number_appointment,
//        Date = x.Date,
//        Start_time = x.Start_time,
//        End_time = x.End_time,
//        Is_client_house = x.Is_client_house,
//        Business_Number = x.Business_Number,
//    }).ToList(); // נוצרה רשימה של תורים לפי הסוג טיפול הרצוי.

//    AppointmentDTO SearchListForCity = 
//        return Request.CreateResponse(HttpStatusCode.OK, c1);
//    else
//        return Request.CreateResponse(HttpStatusCode.NotFound);
//}


//    // GET: Search
//    [HttpGet]
//    [Route("api/Search/{NameTreatment}")]
//    public HttpResponseMessage Get(string NameTreatment, [FromBody]string bussinesCity)
//    {
//        BeautyMeDBContext db = new BeautyMeDBContext();
//        string number_treatment;
//        //string number_treatment = db.Type_Treatment.Type_treatment_Number.Where(i => i.Name == NameTreatment).single....;
//        SearchDTO SearchList = db.Treatment_for_appointment.Where(x => x.Type_treatment_Number == number_treatment).Select(a => new ClientDTO
//        {
//            password = a.password,
//            ID_number = a.ID_number,
//            Last_name = a.Last_name,
//            First_name = a.First_name
//        }).FirstOrDefault();
//        if (c1 != null)
//            return Request.CreateResponse(HttpStatusCode.OK, c1);
//        else
//            return Request.CreateResponse(HttpStatusCode.NotFound);
//}