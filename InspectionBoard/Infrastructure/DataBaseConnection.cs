using InspectionBoard.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace InspectionBoard.Infrastructure
{
    static class DataBaseConnection
    {
       public static ApplicationContext application;
        static DataBaseConnection() {
            application = new ApplicationContext();
        }
    }
}
