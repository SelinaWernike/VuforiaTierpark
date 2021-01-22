using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DataBank{
    public class ClueDAO : ISQLiteHelper
    {
        private const string Tag = "Riz: ClueDAO:\t";

        private const String TABLE_NAME = "clue";
        private const String KEY_ID = "id";
        private const String KEY_ANIMAL_ID = "animal_id";
        private const String KEY_CLUE = "clue";
        private const String REFERENZ_TABLE = "animal";

        private String[] COLUMS = new string[] { KEY_ANIMAL_ID, KEY_CLUE };

        public ClueDAO() : base()
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ( " +
                    KEY_ID + " INT PRIMARY KEY, " +
                    KEY_CLUE + " TEXT NOT NULL, " + KEY_ANIMAL_ID + " INT, FOREIGN KEY ( " + KEY_ANIMAL_ID + " ) REFERENCES " +
                    REFERENZ_TABLE + "( " + KEY_ANIMAL_ID + " ))";
            dbcmd.ExecuteNonQuery();
        }

        public void addData(Clue clue)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "INSERT INTO " + TABLE_NAME +
                " ( " + KEY_ID + ", " +
                KEY_ANIMAL_ID + ", " +
                KEY_CLUE + " ) " +
                "VALUES ( '" +
                clue.Id + "', '" +
                clue.AnimalName.Id + "', '" +
                clue.SingleClue + "' )";
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

        public override IDataReader getDataByID(int id)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + TABLE_NAME + " WHERE " +
                KEY_ID + " = " + id;
            return dbcmd.ExecuteReader();
        }

        public IDataReader getDataByAnimalID(int animal_id)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + TABLE_NAME + " WHERE " +
                KEY_ANIMAL_ID + " = " + animal_id;
            Debug.Log(dbcmd.CommandText);
            return dbcmd.ExecuteReader();
        }

        public override IDataReader getAllData()
        {
            return base.getAllData(TABLE_NAME);
        }

        public override IDataReader getNumOfRows()
        {
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "SELECT COALESCE(MAX(" + KEY_ID + ")+1, 0) FROM " + TABLE_NAME;
            IDataReader reader = dbcmd.ExecuteReader();
            return reader;
        }

        public static Clue writeClueFromReader(IDataReader reader)
        {
            Clue clue = new Clue(reader[0].ToString(),reader[1].ToString());
            Debug.Log(clue);
            
            return clue;
        }


    }
}
