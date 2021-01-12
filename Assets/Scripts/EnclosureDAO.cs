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
        private const String KEY_NAME = "name";
        private const String KEY_LAT =  "lat";
        private const String KEY_LNG =  "lng";
        private const String KEY_DISTANCE =  "distance";

        public EnclosureDAO() : base()
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS" + TABLE_NAME + " ( " +
                    KEY_NAME + "TEXT PRIMARY KEY, " +
                    KEY_LAT + "DOUBLE, " +
                    KEY_LNG + "DOUBLE," +
                    KEY_DISTANCE + "DOUBLE )";
            dbcmd.ExecuteNonQuery();
        }

        public void addData(Enclosure enclosure)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "INSERT INTO " + TABLE_NAME +
                    " ( " +
                    KEY_NAME + ", " +
                    KEY_LAT + ", " +
                    KEY_LNG + ", " +
                    KEY_DISTANCE + ") " +
                    "VALUES ( '" +
                    enclosure.Name + "', '" +
                    enclosure.Lat + "', '" +
                    enclosure.Lng + "', '" +
                    enclosure.Distance + "' )";
            dbcmd.ExecuteNonQuery();
        }

        public override IDataReader getAllData()
        {
            return base.getAllData();
        }

        public override IDataReader getDataByName(string Name)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + TABLE_NAME + "WHERE " + KEY_NAME +
                " = '" + Name + "' )";
            return dbcmd.ExecuteReader();
        }
    }
}
