using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
        private CultureInfo info = CultureInfo.CreateSpecificCulture("en-US");


        public EventDAO() : base()
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ( " +
                    KEY_ID + " INT PRIMARY KEY, " +
                    KEY_NAME + " TEXT NOT NULL, " +
                    KEY_TIME + " TEXT NOT NULL," +
                    KEY_DISTANCE + " DOUBLE, " +
                    KEY_LAT + " DOUBLE, " +
                    KEY_LNG + " DOUBLE )";
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
                    KEY_DISTANCE + ",  " +
                    KEY_LAT + ", " +
                    KEY_LNG + " )" +
                    "VALUES ( '" +
                    ev.Id + "', '" +
                    ev.Name + "', '" +
                    ev.Time.ToString("HH:mm:ss.f") + "', '" +
                    ev.Distance.ToString(info) + "', '" +
                    ev.Lat.ToString(info) + "', '" +
                    ev.Lng.ToString(info) + "' )";
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

        public override void deleteAllData()
        {
            base.deleteAllData(TABLE_NAME);
        }
        public override IDataReader getAllData()
        {
            return base.getAllData(TABLE_NAME);
        }

        public override IDataReader getDataByID(int id)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + TABLE_NAME + "WHERE " + KEY_ID +
                " = '" + id + "' ORDER BY " + KEY_TIME;
            return dbcmd.ExecuteReader();
        }

        public override IDataReader getDataByName(string Name)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + TABLE_NAME + "WHERE " + KEY_NAME +
                " = '" + Name + "' ORDER BY " + KEY_TIME;
            return dbcmd.ExecuteReader();
        }

        public static Event getEventfromReader(IDataReader reader)
        {
            return new Event(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(),reader[5].ToString());
        }
      
    }
}
