using System;
using System.Collections.Generic;
using UnityEngine;

public class Clue 
{
    private int id;
    private Animal animalName;
    //references Animal
    private string singleClue;


    public Clue(int id, Animal animalName, string singleClue)
    {
        this.id = id;
        this.animalName = animalName;
        this.singleClue = singleClue;
    }
    public Clue(string id, string singleClue)
    {
        this.id = Int32.Parse(id);
        this.singleClue = singleClue;
    }

    public Clue(string id, string singleClue, Animal animalName)
    {
        this.id = Int32.Parse(id);
        this.animalName = animalName;
        this.singleClue = singleClue;
    }

    public Animal AnimalName { get => animalName; set => animalName = value; }
    public string SingleClue { get => singleClue; set => singleClue = value; }
    public int Id { get => id; set => id = value; }
   
    public override string  ToString()
    {
        return "[ Id: " + id + ", Animal Name: " + animalName + ", SingleClue: " + singleClue + " ]";
    }
}
