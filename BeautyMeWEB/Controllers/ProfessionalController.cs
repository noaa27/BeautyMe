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
    public class ProfessionalController : ApiController
    {
        // GET: Professional
        [HttpGet]
        [Route("api/Professional/AllProfessional")]
        public HttpResponseMessage GetAllProfessional()
        {
            BeautyMeDBContext db = new BeautyMeDBContext();
            List<ProfessionalDTO> AllProfessionals = db.Professional.Select(x => new ProfessionalDTO
            {
                ID_number = x.ID_number,
                First_name = x.First_name,
                Last_name = x.Last_name,
                birth_date = x.birth_date,
                phone = x.phone,
                Email = x.Email,
                AddressStreet = x.AddressStreet,
                AddressHouseNumber = x.AddressHouseNumber,
                AddressCity = x.AddressCity,
                password = x.password
            }).ToList();
            if (AllProfessionals != null)
                return Request.CreateResponse(HttpStatusCode.OK, AllProfessionals);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // GET: api/Professional/OneProfessional
        [HttpGet]
        [Route("api/Professional/OneProfessional")]
        public HttpResponseMessage GetOneProfessional([FromBody] SearchPeopleDTO v)
        {
            BeautyMeDBContext db = new BeautyMeDBContext();
            ProfessionalDTO oneProfessional = db.Professional.Where(a => a.ID_number == v.id_number && a.password == v.password).Select(x => new ProfessionalDTO
            {
                ID_number = x.ID_number,
                First_name = x.First_name,
                Last_name = x.Last_name,
                birth_date = x.birth_date,
                phone = x.phone,
                Email = x.Email,
                AddressStreet = x.AddressStreet,
                AddressHouseNumber = x.AddressHouseNumber,
                AddressCity = x.AddressCity,
                password = x.password
            }).FirstOrDefault();
            if (oneProfessional != null)
                return Request.CreateResponse(HttpStatusCode.OK, oneProfessional);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound);
        }


        // Post: api/Post
        [HttpPost]
        [Route("api/Professional/NewProfessional")]
        public HttpResponseMessage PostNewProfessional([FromBody] Professional value)
        {
            BeautyMeDBContext db = new BeautyMeDBContext();
            Professional newProfessional = new Professional();
            newProfessional = value;
            if (newProfessional != null)
            {
                db.Professional.Add(newProfessional);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "new Professional added to the dataBase");
            }
            else
                return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}