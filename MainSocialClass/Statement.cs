using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSocialClass
{
    public class Statement
    {
       
        public string Email { get; set; }      
        public string AccountNumber { get; set; }
        public string PinToken { get; set; }
        public string BeginDate { get; set; }
        public string EndDate { get; set; }
        public string statusMessage { get; set; }
        public string statusCode { get; set; }
        public int Period { get; set; }
    }
}
