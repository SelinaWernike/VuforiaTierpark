using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enclosure 
{
    private int id;
    private string name;
    private double lat;
    private double lng;
    private double distance;
    private Animal[] animals;

    public Enclosure()
    {

    }
    public Enclosure(int id,string name, double lat, double lng, double distance)
    {
        this.id = id;
        this.name = name;
        this.lat = lat;
        this.lng = lng;
        this.distance = distance;
    }

    public Enclosure(string id, string name, string lat, string lng, string distance)
    {
        this.id = Int32.Parse(id);
        this.name = name;
        this.lat = Double.Parse(lat);
        this.lng = Double.Parse(lng);
        this.distance = Double.Parse(distance);
    }

    public Enclosure(int id, string name, double lat, double lng, double distance, Animal[] animals)
    {
        this.id = id;
        this.name = name;
        this.lat = lat;
        this.lng = lng;
        this.distance = distance;
        this.animals = animals;
    }

    public string Name { get => name; set => name = value; }
    public double Lat { get => lat; set => lat = value; }
    public double Lng { get => lng; set => lng = value; }
    public double Distance { get => distance; set => distance = value; }
    public Animal[] Animals { get => animals; set => animals = value; }
    public int Id { get => id; set => id = value; }

    public override string ToString()
    {
        return "[ Name: " + name + ", Lat: " + lat + ", Lng: " + lng  + " ]";
    }
}
