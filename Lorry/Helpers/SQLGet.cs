using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;
using System.Windows;
using System.Windows.Documents;

namespace Lorry.Helpers
{
    public class SQLGet
    {
        public static string query = string.Empty;

        public class GetfromSQL
        {
            public static void GetInfo(string table)
            {
                try
                {
                    // Query.  
                    string query = "SELECT * FROM" + WDWGet.windowName +
                                   "WHERE(ABS(CAST(BINARY_CHECKSUM(*) *RAND()) as int)) % 100) < 10";

                    // Execute.  
                    SQLExecute.executeQuery(query);

                    //return query;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
