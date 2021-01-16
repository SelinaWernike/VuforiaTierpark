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

    public Event(string id, string name, string time, string distance, string lat, string lng)
    {
        this.id = Int32.Parse(id);
        this.name = name;
        this.time = DateTime.Parse(time);
        this.distance = Double.Parse(distance);
        this.lat = Double.Parse(lat);
        this.lng = Double.Parse(lng);
    }

    public string Name { get => name; set => name = value; }
    public DateTime Time { get => time; set => time = value; }
    public double Distance { get => distance; set => distance = value; }
    public double Lat { get => lat; set => lat = value; }
    public double Lng { get => lng; set => lng = value; }
    public int Id { get => id; set => id = value; }

    public override string ToString()
    {
        return "[ Name: " + name + ", Time" + time.ToString() + ", Lat: " + lat + ", Lng: " + lng + " ]";
    }
}
    

