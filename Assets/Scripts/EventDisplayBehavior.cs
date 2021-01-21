using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using DataBank;
using System;

public class EventDisplayBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    List<Event> events = new List<Event>();
    private GridManager grid;
    // Start is called before the first frame update
    void Start()
    {
        EventDAO eventDAO = new EventDAO();
        grid = this.GetComponent<GridManager>();
        try
        {
            IDataReader data = eventDAO.getAllData();
            while(data.Read())
            {
                events.Add(EventDAO.getEventfromReader(data));
            }
        } catch(SyntaxErrorException e)
        {
            Debug.Log("Cant find Data in Event Table" + e.StackTrace);
        } finally
        {
            eventDAO.close();
        }
        DisplayEvent();
    }

    private void DisplayEvent()
    {
        if(grid != null && events.Count > 0 && prefab != null)
        {
            int maxDisplay = grid.getMaxItemCount();
            if(maxDisplay > events.Count)
            {
                maxDisplay = events.Count;
            }
            for(int i = 0; i < maxDisplay; i++)
            {
                GameObject display = Instantiate(prefab, Vector3.zero, Quaternion.identity,this.transform);
                display.transform.GetChild(0).GetComponent<TextMesh>().text = events[i].Name;
                Vector2 latLng = new Vector2((float)events[i].Lat, (float)events[i].Lng);
                display.transform.GetChild(1).GetComponent<TextMesh>().text = Math.Round(latLng.magnitude,3).ToString();
                display.transform.GetChild(2).GetComponent<TextMesh>().text = events[i].Time.ToString("t");
                grid.addObject(display);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
