using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enclosure 
{
    private string name;
    private double lat;
    private double lng;
    private double distance;
    private Animal[] animals;

    public string Name { get => name; set => name = value; }
    public double Lat { get => lat; set => lat = value; }
    public double Lng { get => lng; set => lng = value; }
    public double Distance { get => distance; set => distance = value; }
    public Animal[] Animals { get => animals; set => animals = value; }
}
