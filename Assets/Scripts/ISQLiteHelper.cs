using System;
using System.Linq;
using System.Text;
using Mono.Data.Sqlite;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataBank
{
public class ISQLiteHelper 
{
        private const string Tag = "Riz: SqliteHeler:\t";
        private const string db_name = "tierpark_db";
        public string db_connection_string;
        public IDbConnection db_connection;

        public ISQLiteHelper()
        {
            db_connection_string = "URI=file:" + Application.persistentDataPath + "/" + db_name;
            Debug.Log("connection_string" + db_connection_string);
            db_connection = new SqliteConnection(db_connection_string);
            db_connection.Open();
        }

        ~ISQLiteHelper()
        {
            db_connection.Close();
        }

        public virtual IDataReader getDataByID(int id)
        {
            Debug.Log("Not ywt implemented");
            throw null;
        }
        public virtual IDataReader getDataByName(string Name)
        {
            Debug.Log("Not ywt implemented");
            throw null;
        }


        public virtual void deleteDataById(int id)
        {
            Debug.Log("Not ywt implemented");
            throw null;
        }
        public virtual void deleteDataByName(string Name)
        {
            Debug.Log("Not ywt implemented");
            throw null;
        }

        public virtual IDataReader getAllData()
        {
            Debug.Log("Not ywt implemented");
            throw null;
        }

        public virtual void deleteAllData()
        {
            Debug.Log("Not ywt implemented");
        }

        public virtual IDataReader getNumOfRows()
        {
            Debug.Log("Not ywt implemented");
            throw null;
        }

        //helper functions
        public IDbCommand getDbCommand()
        {
            return db_connection.CreateCommand();
        }

        public IDataReader getAllData(string table_name)
        {
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + table_name;
            IDataReader reader = dbcmd.ExecuteReader();
            return reader;
        }

        public void deleteAllData(string table_name)
        {
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText = "DROP TABLE IF EXISTS " + table_name;
            dbcmd.ExecuteNonQuery();
        }

        public IDataReader getNumOfRows(string table_name)
        {
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "SELECT COALESCE(MAX(id)+1, 0) FROM " + table_name;
            IDataReader reader = dbcmd.ExecuteReader();
            return reader;
        }

        public void DropTable(string tableName)
        {
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText = "DROP TABLE " + tableName;
            dbcmd.ExecuteNonQuery();
        }

        public void close()
        {
            db_connection.Close();
        }
    }

}
