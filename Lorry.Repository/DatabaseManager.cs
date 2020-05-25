using System;
using System.Collections.Generic;
using System.Text;

namespace Lorry.Repository
{
    internal class DatabaseManager
    {
        private static readonly Lorry.Database.LorryContext databaseContext;

        // Initialize and open the database connection
        static DatabaseManager()
        {
            databaseContext = new Lorry.Database.LorryContext();
        }

        // Provide an accessor to the database
        public static Lorry.Database.LorryContext Instance
        {
            get
            {
                return databaseContext;
            }
        }
    }
}
