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

namespace BeautyMeWEB.Controllers
{
    public class Business_can_give_treatmentController : ApiController
    {
        // GET: Business_can_give_treatment
        [HttpGet]
        [Route("api/Business_can_give_treatment/AllTreatmentOfBusiness")]
        public HttpResponseMessage GetAllTreatmentOfBusiness()
        {
            BeautyMeDBContext db = new BeautyMeDBContext();
            List<Business_can_give_treatmentDTO> AllTreatmentOfBusiness = db.Business_can_give_treatment.Select(x => new Business_can_give_treatmentDTO
            {
                Type_treatment_Number = x.Type_treatment_Number,
                Category_Number = x.Category_Number,
                Business_Number = x.Business_Number,
                Price = x.Price,
                Treatment_duration = x.Treatment_duration,
            }).ToList();
            if (AllTreatmentOfBusiness != null)
                return Request.CreateResponse(HttpStatusCode.OK, AllTreatmentOfBusiness);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // Post: api/Post
        [HttpPost]
        [Route("api/Business_can_give_treatment/PostNewTreatmentOfBussines")]
        public HttpResponseMessage PostNewTreatmentOfBussines([FromBody] Business_can_give_treatmentDTO x)
        {
            BeautyMeDBContext db = new BeautyMeDBContext();
            Business_can_give_treatment newBusiness = new Business_can_give_treatment()
            {
                Type_treatment_Number = x.Type_treatment_Number,
                Category_Number = x.Category_Number,
                Business_Number = x.Business_Number,
                Price = x.Price,
                Treatment_duration = x.Treatment_duration,
            };
            if (newBusiness != null)
            {
                db.Business_can_give_treatment.Add(newBusiness);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "new Business added to the dataBase");
            }
            else
                return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}


//// Post: api/Post
//[HttpPost]
//[Route("api/Business_can_give_treatment/PostNewTreatmentOfBussines/{Business_Number}/{Type_treatment_Number}/{Category_Number}")]
//public HttpResponseMessage PostNewTreatmentOfBussines(string Business_Numberr, string Type_treatment_Numberr, string Category_Numberr, [FromBody] Business_can_give_treatmentDTO x)
//{
//    BeautyMeDBContext db = new BeautyMeDBContext();
//    Business_can_give_treatment newBusiness = new Business_can_give_treatment()
//    {
//        Type_treatment_Number = x.Type_treatment_Number,
//        Category_Number = x.Category_Number,
//        Business_Number = x.Business_Number,
//        Price = x.Price,
//        Treatment_duration = x.Treatment_duration,
//    };
//    if (newBusiness != null)
//    {
//        db.Business_can_give_treatment.Add(newBusiness);
//        db.SaveChanges();
//        return Request.CreateResponse(HttpStatusCode.OK, "new Business added to the dataBase");
//    }
//    else
//        return Request.CreateResponse(HttpStatusCode.NoContent);
//}