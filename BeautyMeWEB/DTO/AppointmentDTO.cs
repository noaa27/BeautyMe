using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeautyMeWEB.DTO
{
    public class AppointmentDTO
    {
        public int Number_appointment;
        public System.DateTime Date;
        public System.TimeSpan Start_time;
        public System.TimeSpan End_time;
        public string Is_client_house;
        public int Business_Number;
    }
}


