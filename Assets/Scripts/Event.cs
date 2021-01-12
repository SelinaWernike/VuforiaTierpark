using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Event
{
    private int id;
    private string name;
    private DateTime time;
    private double distance;
    private double lat;
    private double lng;

    public Event(int id, string name, DateTime time, double distance, double lat, double lng)
    {
        this.id = id;
        this.name = name;
        this.time = time;
        this.distance = distance;
        this.lat = lat;
        this.lng = lng;
    }

    public string Name { get => name; set => name = value; }
    public DateTime Time { get => time; set => time = value; }
    public double Distance { get => distance; set => distance = value; }
    public double Lat { get => lat; set => lat = value; }
    public double Lng { get => lng; set => lng = value; }
    public int Id { get => id; set => id = value; }
}
    

