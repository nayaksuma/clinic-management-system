using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinic.WEB.DBConnect
{
    public class GlobalData
    {
        public static string GetConnectionString()
        {
            return "Data Source=.\\sqlexpress;Initial Catalog=ClinicDB;Integrated Security=True;";
        }
    }
}