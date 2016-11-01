using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GridView_SQLite.mDatabase
{
    class Constants
    {
        //COLUMNS
        public static String ROW_ID = "id";
        public static String NAME = "name";

        //DB PROPERTIES
        public static String DB_NAME = "c_DB";
        public static String TB_NAME = "c_TB";
        public static int DB_VERSION = 1;

        //CREATE TABLE
        public static String CREATE_TB = "CREATE TABLE c_TB(id INTEGER PRIMARY KEY AUTOINCREMENT,"
            + "name TEXT NOT NULL);";

        //DROP TB
        public static String DROP_TB = "DROP TABLE IF EXISTS " + TB_NAME;







    }
}