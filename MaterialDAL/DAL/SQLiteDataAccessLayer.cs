using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialDAL.DAL
{
    class SQLiteDataAccessLayer
    {
        static string sql = @"Data Source =StoreManagerDB.db; Version = 3 ;";
        SQLiteConnection sqlConnection;
        //******//
        // Singleton design pattern
        //هذا التابع الباني يقوم بتهيئة الاتصال لقاعدة البيانات
        private SQLiteDataAccessLayer()
        {
            sqlConnection = new SQLiteConnection(sql);
        }
        private static SQLiteDataAccessLayer instance = null;
        public static SQLiteDataAccessLayer getInstance()
        {
            // إذا لم يتم إنشاء غرض من قبل فقم بإنشاء غرض أو استخدم الغرض المنشأ مسبقاً
            if (instance == null) instance = new SQLiteDataAccessLayer();
            return instance;
        }
        //تابع لفتح الانصال
        private void Open()
        {
            if (sqlConnection.State != ConnectionState.Open)
                sqlConnection.Open();
        }
        //تابع لإغلاق الانصال
        private void Close()
        {
            if (sqlConnection.State == ConnectionState.Open)
                sqlConnection.Close();
        }
        //تابع لجلب البيانات
        public DataTable selectData(string query)
        {
            Open();

            SQLiteCommand sqlcmd = new SQLiteCommand();
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = query;
            sqlcmd.Connection = sqlConnection;


            SQLiteDataAdapter da = new SQLiteDataAdapter(sqlcmd);
            DataTable dt = new DataTable();

            Close();

            da.Fill(dt);
            return dt;

        }
        //تابع لإضافة و تعديل و حذف بيانات من قاعدة البيانات
        public void executeCommand(string query)
        {
            Open();

            SQLiteCommand sqlcmd = new SQLiteCommand();
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = query;
            sqlcmd.Connection = sqlConnection;

            sqlcmd.ExecuteNonQuery();

            Close();
        }

        //تابع لإضافة و تعديل و حذف بيانات من قاعدة البيانات
        public List<string> executeReturnValue(string query)
        {
            Open();

            SQLiteCommand sqlcmd = new SQLiteCommand();
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = query;
            sqlcmd.Connection = sqlConnection;


            SQLiteDataAdapter da = new SQLiteDataAdapter(sqlcmd);
            DataTable dt = new DataTable();

            Close();

            da.Fill(dt);

            List<string> rowResult = new List<string>();
            // On all tables' rows
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                rowResult.Add(dt.Rows[0][i].ToString());
            }

            return rowResult;
        }
    }
}
