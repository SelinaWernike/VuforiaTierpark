using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DataBank {
    public class EnclosureDAO : ISQLiteHelper
    {
        private const string Tag = "Riz: EnclosureDAO:\t";

        private const String TABLE_NAME = "enclosure";
        private const String KEY_ID = "enclosure_id";
        private const String KEY_NAME = "enclosure_name";
        private const String KEY_LAT =  "lat";
        private const String KEY_LNG =  "lng";
        private const String KEY_DISTANCE =  "distance";

        public EnclosureDAO() : base()
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ( " +
                    KEY_ID + " INT PRIMARY KEY, " +
                    KEY_NAME + " TEXT, " +
                    KEY_LAT + " DOUBLE, " +
                    KEY_LNG + " DOUBLE, " +
                    KEY_DISTANCE + " DOUBLE )";
            dbcmd.ExecuteNonQuery();
        }

        public void addData(Enclosure enclosure)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "INSERT INTO " + TABLE_NAME +
                    " ( " +
                    KEY_ID + ", " +
                    KEY_NAME + ", " +
                    KEY_LAT + ", " +
                    KEY_LNG + ", " +
                    KEY_DISTANCE + ") " +
                    "VALUES ( '" +
                    enclosure.Id + "', '" +
                    enclosure.Name + "', '" +
                    enclosure.Lat + "', '" +
                    enclosure.Lng + "', '" +
                    enclosure.Distance + "' )";
            dbcmd.ExecuteNonQuery();
        }

        public override void deleteDataById(int id)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "DELETE FROM " + TABLE_NAME + " WHERE " + KEY_ID + " = '" +
                id + "'";
            dbcmd.ExecuteNonQuery();
        }
       

        public override void deleteDataByName(string Name)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "DELETE FROM " + TABLE_NAME + " WHERE " + KEY_NAME + " = '" +
                Name + "'";
            dbcmd.ExecuteNonQuery();
        }

        public override void deleteAllData()
        {
            base.deleteAllData(TABLE_NAME);
        }

        public override IDataReader getAllData()
        {
            return base.getAllData(TABLE_NAME);
        }

        public override IDataReader getDataByName(string Name)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + TABLE_NAME + " WHERE " + KEY_NAME +
                " = '" + Name + "' )";
            return dbcmd.ExecuteReader();
        }

        public override IDataReader getDataByID(int id)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + TABLE_NAME + " WHERE " + KEY_ID +
                " = '" + id + "' )";
            return dbcmd.ExecuteReader();
        }

        public override IDataReader getNumOfRows()
        {
            return base.getNumOfRows(TABLE_NAME);
        }

        public static Enclosure getEnclosureFromReader(IDataReader reader, int index)
        {
            return new Enclosure(reader[index].ToString(), reader[++index].ToString(), reader[++index].ToString(), reader[++index].ToString(),reader[++index].ToString());
        }
    }
}
