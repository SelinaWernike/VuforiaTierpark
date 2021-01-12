using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clue 
{
    private int id;
    private string animalName;
    //references Animal
    private string singleClue;

    public string AnimalName { get => animalName; set => animalName = value; }
    public string SingleClue { get => singleClue; set => singleClue = value; }
    public int Id { get => id; set => id = value; }
}
