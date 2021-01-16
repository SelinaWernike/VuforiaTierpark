using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using DataBank;

public class EventDisplayBehavior : MonoBehaviour
{
    List<Event> events = new List<Event>();
    // Start is called before the first frame update
    void Start()
    {
        EventDAO eventDAO = new EventDAO();
        try
        {
            IDataReader data = eventDAO.getAllData();
            while(data.Read())
            {
                events.Add(EventDAO.getEventfromReader(data));
            }
        } catch(SyntaxErrorException e)
        {
            Debug.Log("Cant find Data in Event Table");
        } finally
        {
            eventDAO.close();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
