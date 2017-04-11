using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

using System.IO;
using System.Diagnostics;
using System.Configuration;

namespace MainSocialClass
{
    public static class Utility
    {
        public static bool numberchecker(string i)
        {
            try
            {
                int checkstringtoseeifitsallnumbers = int.Parse(i);
                return true;
            }
            catch
            { return false; }

        }

        public static IEnumerable<SelectListItem> getOperator()
        {

            IList<SelectListItem> items = new List<SelectListItem> {

                    new SelectListItem{Text = "Visafone", Value = "1"},
                    new SelectListItem{Text = "MTN", Value = "5"},
                    new SelectListItem{Text = "Etisalat", Value = "2"},
                    new SelectListItem{Text = "Airtel", Value = "3"},
                    new SelectListItem{Text = "GLO", Value = "4"},                    

                };
            return items;
        }

        public static IEnumerable<SelectListItem> getPeriods()
        {

                     IList<SelectListItem> items = new List<SelectListItem> {

                    new SelectListItem{Text = "Today", Value = "0"},
                    new SelectListItem{Text = "Last Week", Value = "-7"},
                    new SelectListItem{Text = "Last Month", Value = "-30"},
                    new SelectListItem{Text = "Last Two Month", Value = "-60"},
                    new SelectListItem{Text = "Last Three Month", Value = "-90"},                    

                };
            return items;
        }

    }
}
