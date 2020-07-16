using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.Models
{
    public class CMSIndexLoader
    {
        

        public CMSIndexPageModel PageLoad()
        {
            CMSIndexPageModel page = new CMSIndexPageModel();
            page.Header_H1 = "Online Grocery";
            page.Header_P1_Welcome = "Welcome to our online grocery. Get the best quality products delivered to your door. We get our products from local farmers and producers. Try our offer and become member of our family.";
            page.About_1_H3 = "Quality product";
            page.About_1_Text = "CONFERMATA LA DATA DI USCITA DEL 16 LUGLIO! ⚡ Per i nuovi charms Pandora Harry Potter! Non li troverete né online né alla vendita al pubblico nei negozi prima di giovedì, ma ci sono già! Potete chiamare nei negozi e chiedere conferma!";
            page.About_1_Img_Path = @"~/other_images/about_quality.jpg";

            page.About_2_H3 = "Trusted suppliers";
            page.About_2_Text = "CONFERMATA LA DATA DI USCITA DEL 16 LUGLIO! ⚡ Per i nuovi charms Pandora Harry Potter! Non li troverete né online né alla vendita al pubblico nei negozi prima di giovedì, ma ci sono già! Potete chiamare nei negozi e chiedere conferma!";
            page.About_2_Img_Path = @"~/other_images/supliers.jpg";

            page.About_3_H3 = "Organic";
            page.About_3_Text = "CONFERMATA LA DATA DI USCITA DEL 16 LUGLIO! ⚡ Per i nuovi charms Pandora Harry Potter! Non li troverete né online né alla vendita al pubblico nei negozi prima di giovedì, ma ci sono già! Potete chiamare nei negozi e chiedere conferma!";
            page.About_3_Img_Path = @"~/other_images/organic_about.jpg";

            page.Contact_H3 = "Lets get in touch";
            page.Contact_P = "Leave us review or advice";

            page.Contact_Phone_1 = "+44 569458423";
            page.Contact_Phone_2 = "+44 548625987";

            page.Contact_Email_1 = "onlinegrocery@gmail.com";
            page.Contact_Email_2 = "organicnetwork@gmail.com";

            page.Contact_Address_Street = "11 High Road";
            page.Contact_Address_Postcode = "N64 LT";
            page.Contact_Address_City = "London";

            page.ContactFormToggler = true;

            return page;

        }
    }
}
