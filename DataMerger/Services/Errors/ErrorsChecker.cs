using DataMerger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMerger.Services.Errors
{
    public static class ErrorsChecker
    {
        public static void CheckErrors(List<XmlUser> xmlUsers)
        {
            //Check if wrong phNumber for user 
            var userWithEmptyPhNum = xmlUsers.Where(p => p.Username == "FDUMPLETONM");
            List<string> phoneTypes = new List<string>
            {
                "phone1", "phone2", "phone3"
            };

            //if phone number is empty
            //var emptyPhoneNumber = xmlUsers.Where(p => p.Phone.PhoneNumber == "");

            //if username is empty
            var emptyUserName = xmlUsers.Where(p => p.Username == "");

            //if phone type is empty
            //var emptyPhoneType = xmlUsers.Where(p => p.Phone.Type == "");

            //is there any phoneType which doesn't match to pattern "phoneX" where X is 
            //a number accepted types in list phoneTypes
            //var emptyPhoneType2 = xmlUsers.Where(p => phoneTypes.Contains(p.Phone.Type));
        }
    }
}
