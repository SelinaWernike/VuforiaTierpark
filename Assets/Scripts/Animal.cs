using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal
{
    private string name;
    private Material picture;
    private string discription;
    private string pictureName;
    private string enclosureName;
    private Clue[] clues;

    public Animal(string name, string pictureName, string discription, Clue[] clues)
    {
        this.Name = name;
        this.Picture = Resources.Load<Material>(pictureName);
        this.Discription = discription;
        this.Clues = clues;
    }

    public string Name { get => name; set => name = value; }
    public Material Picture { get => picture; set => picture = value; }
    public string Discription { get => discription; set => discription = value; }
    public Clue[] Clues { get => clues; set => clues = value; }
    public string PictureName { get => pictureName; set => pictureName = value; }
    public string EnclosureName { get => enclosureName; set => enclosureName = value; }

    public bool compare(Animal animal)
    {
        if(name.CompareTo(animal.Name) == 0)
        {
            return true;
        }
        return false;
    }
}
