using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataBank;
using System;

public class EventDBTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventDAO eventDB = new EventDAO();
        Debug.Log("Created DB");

        eventDB.addData(new Event(2,"Test", new DateTime(2020,1,12,09,53,6),34.34,0.6767,4.343434));
        eventDB.close();
        Debug.Log("Added Entry");

        EventDAO eventDAO2 = new EventDAO();
        System.Data.IDataReader reader = eventDAO2.getAllData();

        int fieldCount = reader.FieldCount;
        List<Event> myList = new List<Event>();
        while(reader.Read())
        {
            Event ev = new Event(Int32.Parse(reader[0].ToString()),
                                            reader[1].ToString(),
                                            DateTime.Parse(reader[2].ToString()),
                                            Double.Parse(reader[3].ToString()),
                                            Double.Parse(reader[4].ToString()),
                                            Double.Parse(reader[5].ToString()));
            Debug.Log("id: " + ev.Id);
            myList.Add(ev);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
