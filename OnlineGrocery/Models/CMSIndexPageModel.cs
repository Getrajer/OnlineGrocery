using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public class CMSIndexPageModel
    {
        public int Id { get; set; }

        //Header variables
        public string Header_H1 { get; set; }
        public string Header_P1_Welcome { get; set; }

        //About
        public string About_1_H3 { get; set; }
        public string About_1_Img_Path { get; set; }
        public string About_1_Text { get; set; }

        public string About_2_H3 { get; set; }
        public string About_2_Img_Path { get; set; }
        public string About_2_Text { get; set; }

        public string About_3_H3 { get; set; }
        public string About_3_Img_Path { get; set; }
        public string About_3_Text { get; set; }

        //Contact Form
        public string Contact_H3 { get; set; }
        public string Contact_P { get; set; }

        public string Contact_Phone_1 { get; set; }
        public string Contact_Phone_2 { get; set; }

        public string Contact_Email_1 { get; set; }
        public string Contact_Email_2 { get; set; }

        public string Contact_Address_Street { get; set; }
        public string Contact_Address_Postcode { get; set; }
        public string Contact_Address_City { get; set; }

        /// <summary>
        /// If true then user can use contact form / if false contact form is not visiable
        /// </summary>
        public bool ContactFormToggler { get; set; }
    }
}
