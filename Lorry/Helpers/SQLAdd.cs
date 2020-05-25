using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lorry
{
    class SQLAdd
    {
        public class AddtoSQL
        {
            public static void SaveInfo(string fullname)
            {
                try
                {
                    // Query.  
                    string query = "INSERT INTO [Register] ([fullname])" +
                                    " Values ('" + fullname + "')";

                    // Execute.  
                    SQLExecute.executeQuery(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
