using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DataBank
{
    public class AnimalDAO : ISQLiteHelper
    {
        private const string Tag = "Riz: AnimalDAO:\t";

        private const String TABLE_NAME = "animal";
        private const String KEY_ANIMAL_NAME = "animal_name";
        private const String KEY_PICTURE =  "picture_name";
        private const String KEY_DISCRIPTION = "discription";
        private const String KEY_ENCLOSURE = "enclosure_name";
        private const String REFERENZ_TABLE = "enclosure";
       
        public AnimalDAO() : base()
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS" + TABLE_NAME + " ( " +
                    KEY_ANIMAL_NAME + "TEXT PRIMARY KEY, " +
                    KEY_PICTURE + "TEXT, " +
                    KEY_DISCRIPTION + "TEXT," +
                    KEY_ENCLOSURE + "TEXT, FOREIGN KEY ( " + KEY_ENCLOSURE+ " ) REFERENCES " +
                    REFERENZ_TABLE + "( " + KEY_ENCLOSURE + " )";
            dbcmd.ExecuteNonQuery();
        }

        public void addData(Animal animal)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "INSERT INTO " + TABLE_NAME +
                    " ( " +
                    KEY_ANIMAL_NAME + ", " +
                    KEY_PICTURE + ", " +
                    KEY_DISCRIPTION + " ) " +
                    "VALUES ( '" +
                    animal.Name + "', '" +
                    animal.PictureName + "', '" +
                    animal.Discription + "', '" +
                    animal.EnclosureName + "' )";
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
                "SELECT * FROM " + TABLE_NAME + "WHERE " + KEY_ANIMAL_NAME +
                " = '" + Name + "' )";
            return dbcmd.ExecuteReader();
        }
    }
}
