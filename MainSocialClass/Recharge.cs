using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSocialClass
{
    public class Recharge
    {
        public string GSMNumber { get; set; }
        public decimal RechargeAmount { get; set; }
        public string AccountNumber { get; set; }
        public string PinToken { get; set; }
        public int Operator { get; set; }
        public string Type { get; set; }
        public string statusMessage { get; set; }
        public string statusCode { get; set; }

    }
}
