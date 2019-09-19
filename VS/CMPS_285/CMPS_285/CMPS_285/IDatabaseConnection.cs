using System;
using System.Collections.Generic;
using System.Text;

namespace CMPS_285
{
    public interface IDatabaseConnection
    {
        SQLite.SQLiteConnection DbConnection();
    }
}
