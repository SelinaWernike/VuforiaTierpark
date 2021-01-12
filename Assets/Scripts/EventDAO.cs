using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnityEngine;
namespace DataBank {
    public class EventDAO : ISQLiteHelper
    {
        private const string Tag = "Riz: EventDAO:\t";

        private const String TABLE_NAME = "event";
        private const String KEY_ID = "id";
        private const String KEY_NAME = "name";
        private const String KEY_TIME =  "time";
        private const String KEY_DISTANCE = "distance";
        private const String KEY_LAT = "lat";
        private const String KEY_LNG = "lng";

        public EventDAO() : base()
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ( " +
                    KEY_ID + " INT PRIMARY KEY, " +
                    KEY_NAME + " TEXT NOT NULL, " +
                    KEY_TIME + " DATETIME NOT NULL," +
                    KEY_LAT + " DOUBLE, " +
                    KEY_LNG + " DOUBLE, " +
                    KEY_DISTANCE + " DOUBLE )";
            dbcmd.ExecuteNonQuery();
        }

        public void addData(Event ev)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "INSERT INTO " + TABLE_NAME +
                    " ( " +
                    KEY_ID + ", " +
                    KEY_NAME + ", " +
                    KEY_TIME + ", " +
                    KEY_LAT + ",  " +
                    KEY_LNG + ", " +
                    KEY_DISTANCE + " )" +
                    "VALUES ( '" +
                    ev.Id + "', '" +
                    ev.Name + "', '" +
                    ev.Time.ToString("yyyy-MM-dd HH:m:ss") + "', '" +
                    ev.Lat + "', '" +
                    ev.Lng + "', '" +
                    ev.Distance + "' )";
            dbcmd.ExecuteNonQuery();
        }

        public override IDataReader getAllData()
        {
            return base.getAllData(TABLE_NAME);
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
