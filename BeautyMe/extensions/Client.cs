//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BeautyMe
//{
//    [MetadataType()]
//    public partial class Client
//    {
//    }

//    public class ClientMetaData
//    {
//        //public static bool IsIdNumberUnique(string idNumber)
//        //{
//        //    BeautyMeDBContext db = new BeautyMeDBContext();
//        //    string id_number = db.Client.FirstOrDefault(i => i.ID_number == idNumber).ID_number;
//        //    if (id_number == null) // אם אין ת.ז כזה בטבלת לקוחות ייחזור TRUE
//        //    {
//        //        return true;
//        //    }
//        //    return false;
//        //}
//        [Required(ErrorMessage = "ID number is required")]
//        [RegularExpression(@"^\d{9}$", ErrorMessage = "ID number should be composed of 9 digits")]
//        public string ID_number;
//        //{
//        //    set {
//        //            if (IsIdNumberUnique(ID_number) == true)
//        //            {
//        //                 value;
//        //            }
//        //            else
//        //            {
//        //                throw new Exception("ID number already exists in database");
//        //            }
//        //        }
//        //    }
//        //}
//        public string First_name;
//        public string Last_name;
//        [Range(18, int.MaxValue, ErrorMessage = "Age must be over 18")]
//        public int Age
//        {
//            get
//            {
//                DateTime today = DateTime.Today;
//                int age = today.Year - birth_date.Year;
//                if (birth_date > today.AddYears(-age))
//                    age--;
//                return age;
//            }
//        }
//        public System.DateTime birth_date;
//        public string gender;
//        public string phone;
//        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format")]
//        public string Email;
//        public string AddressStreet;
//        public string AddressHouseNumber;
//        public string AddressCity;
//        public string password;

//    }
//}
