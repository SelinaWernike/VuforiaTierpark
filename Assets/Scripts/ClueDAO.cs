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

        private const String TABLE_NAME = "Clues";
        private const String KEY_ID = "id";
        private const String KEY_NAME = "animal_name";
        private const String KEY_CLUE = "clue";
        private const String REFERENZ_TABLE = "animal";

        private String[] COLUMS = new string[] { KEY_NAME, KEY_CLUE };

        public ClueDAO() : base()
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS" + TABLE_NAME + " ( " +
                    KEY_ID + "INT PRIMARY KEY, " +
                    KEY_NAME + " TEXT, " + KEY_CLUE + " TEXT, FOREIGN KEY ( " + KEY_NAME + " ) REFERENCES " +
                    REFERENZ_TABLE + "( " + KEY_NAME + " )";
            dbcmd.ExecuteNonQuery();
        }

        public void addData(Clue clue)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "INSERT INTO" + TABLE_NAME +
                " ( " + KEY_ID + ", " +
                KEY_NAME + ", " +
                KEY_CLUE + " ) " +
                "VALUES ( '" +
                clue.Id + "', '" +
                clue.AnimalName + "', '" +
                clue.SingleClue + "' )";
            dbcmd.ExecuteNonQuery();
        }

        public override IDataReader getDataByName(string Name)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + TABLE_NAME + " WHERE " +
                KEY_NAME + " = '" + Name + "'";
            return dbcmd.ExecuteReader();
        }

        public override IDataReader getAllData()
        {
            return base.getAllData(TABLE_NAME);
        }

      
    }
}
