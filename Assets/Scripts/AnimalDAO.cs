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
        private const String KEY_ID = "animal_id";
        private const String KEY_ANIMAL_NAME = "animal_name";
        private const String KEY_PICTURE =  "picture_name";
        private const String KEY_DISCRIPTION = "discription";
        private const String KEY_NUMBER = "number";
        private const String KEY_ENCLOSURE = "enclosure_id";
        private const String REFERENZ_TABLE = "enclosure";
       
        public AnimalDAO() : base()
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ( " +
                    KEY_ID + " INT PRIMARY KEY, " +
                    KEY_ANIMAL_NAME + " TEXT, " +
                    KEY_PICTURE + " TEXT, " +
                    KEY_DISCRIPTION + " TEXT," +
                    KEY_NUMBER + " INT, " +
                    KEY_ENCLOSURE + " INT, FOREIGN KEY ( " + KEY_ENCLOSURE + " ) REFERENCES " +
                    REFERENZ_TABLE + "( " + KEY_ENCLOSURE + " ))";
            dbcmd.ExecuteNonQuery();
        }

        public void addData(Animal animal)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "INSERT INTO " + TABLE_NAME +
                    " ( " +
                    KEY_ID + ", " +
                    KEY_ANIMAL_NAME + ", " +
                    KEY_PICTURE + ", " +
                    KEY_DISCRIPTION + ", " +
                    KEY_NUMBER + ", " + 
                    KEY_ENCLOSURE + " ) " +
                    "VALUES ( '" +
                    animal.Id + "', '" +
                    animal.Name + "', '" +
                    animal.PictureName + "', '" +
                    animal.Discription + "', '" +
                    animal.Number + "', '" +
                    animal.EnclosureName.Name + "' )";
            dbcmd.ExecuteNonQuery();
        }

        public void addData(Animal animal, string enclosure)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "INSERT INTO " + TABLE_NAME +
                  " ( " +
                  KEY_ID + ", " +
                  KEY_ANIMAL_NAME + ", " +
                  KEY_PICTURE + ", " +
                  KEY_DISCRIPTION + ", " +
                  KEY_NUMBER + ", " +
                  KEY_ENCLOSURE + " ) " +
                  "VALUES ( '" +
                  animal.Id + "', '" +
                  animal.Name + "', '" +
                  animal.PictureName + "', '" +
                  animal.Discription + "', '" +
                  animal.Number + "', '" +
                  enclosure + "' )";
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
                "DELETE FROM " + TABLE_NAME + " WHERE " + KEY_ANIMAL_NAME + " = '" +
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
                "SELECT * FROM " + TABLE_NAME + " WHERE " + KEY_ANIMAL_NAME +
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

        public IDataReader getDataByIDJoin(int id)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "SELECT  " + TABLE_NAME + ".*, " + REFERENZ_TABLE + ".* FROM " + TABLE_NAME + 
                "INNER JOIN " + REFERENZ_TABLE + " ON "+ REFERENZ_TABLE + "." + KEY_ENCLOSURE + 
                " = " + TABLE_NAME + "." + KEY_ENCLOSURE +  " WHERE " + KEY_ID +
                " = '" + id + "' )";
            return dbcmd.ExecuteReader();
        }

        public IDataReader getDatabyEnclosure(int enclosure_id)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + TABLE_NAME + " WHERE " + KEY_ENCLOSURE +
                " = '" + enclosure_id + "' )";
            return dbcmd.ExecuteReader();
        }

        public static Animal getAnimalFromReader(IDataReader reader, int index)
        {
            return new Animal(reader[index].ToString(), reader[++index].ToString(), reader[++index].ToString(), reader[++index].ToString(), reader[++index].ToString());

        }
    }
}
