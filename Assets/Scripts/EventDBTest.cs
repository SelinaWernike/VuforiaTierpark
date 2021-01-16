using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataBank;
using System.Data;
using System;

public class EventDBTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ISQLiteHelper helper = new ISQLiteHelper();
        helper.DropTable("clues");
        helper.DropTable("animal");
        helper.DropTable("enclosure");
        helper.close();


        EnclosureDAO enclosureDB = new EnclosureDAO();
        Debug.Log("Created Enclosure DB");
        Enclosure test1 = new Enclosure(1,"Test Gehege", 0.0, 0.0, 23.5);
        enclosureDB.addData(test1);
        enclosureDB.close();

        AnimalDAO animalDB = new AnimalDAO();
        Animal test2 = new Animal(1,"testAnimal", "Test Test", "test", 0, test1);
        animalDB.addData(test2);
        animalDB.close();

        ClueDAO clueDB = new ClueDAO();
        clueDB.addData(new Clue(1, test2, "teste"));
        clueDB.close();





        EventDAO eventDAO2 = new EventDAO();
        System.Data.IDataReader reader = eventDAO2.getAllData();

        int fieldCount = reader.FieldCount;
        List<Event> myList = new List<Event>();
        while(reader.Read())
        {
            Event ev = new Event(reader[0].ToString(),
                                            reader[1].ToString(),
                                            reader[2].ToString(),
                                            reader[3].ToString(),
                                            reader[4].ToString(),
                                            reader[5].ToString());
            Debug.Log(ev);
            myList.Add(ev);
        }

        EnclosureDAO enclosureDAO1 = new EnclosureDAO();
        System.Data.IDataReader reader1 = enclosureDAO1.getAllData();

        List<Enclosure> listEnclosure = new List<Enclosure>();
        while(reader1.Read())
        {
            Enclosure en = new Enclosure(reader1[0].ToString(),
                                        reader1[1].ToString(),
                                        reader1[2].ToString(),
                                        reader1[3].ToString(),
                                        reader1[4].ToString());
            Debug.Log(en);
            listEnclosure.Add(en);
        }

        AnimalDAO animalDAO1 = new AnimalDAO();
        System.Data.IDataReader reader2 = animalDAO1.getAllData();
        List<Animal> animalList = new List<Animal>();
        int index = 0;

        while(reader2.Read())
        {
            Animal a = new Animal(reader2[0].ToString(),
                                reader2[1].ToString(),
                                reader2[2].ToString(),
                                reader2[3].ToString(),
                                reader2[4].ToString(),
                                listEnclosure.ToArray()[index]);
            Debug.Log(a);
            animalList.Add(a);
        }

        index = 0;
        ClueDAO clueDAO1 = new ClueDAO();
        System.Data.IDataReader reader3 = clueDAO1.getAllData();
        List<Clue> clueList = new List<Clue>();
        while (reader3.Read())
        {
            Clue c = new Clue(reader3[0].ToString(),
                                reader3[1].ToString(),
                                animalList.ToArray()[index]);

            Debug.Log(c);
            clueList.Add(c);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
