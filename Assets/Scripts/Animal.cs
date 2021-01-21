using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Animal
{
    private int id;
    private string name;
    private Material picture;
    private string discription;
    private string pictureName;
    private int number;
    private Enclosure enclosureName;
    private Clue[] clues;

    public Animal(int id, string name, string pictureName, string discription, int number, Enclosure enclosure)
    {
        this.id = id;
        this.Name = name;
        this.PictureName = pictureName;
        this.Picture = Resources.Load<Material>(pictureName);
        this.Discription = discription;
        this.number = number;
        enclosureName = enclosure;
        
    }

    public Animal(int id, string name, string discription, string pictureName, int number)
    {
        this.id = id;
        this.name = name;
        this.discription = discription;
        this.pictureName = pictureName;
        this.Picture = Resources.Load<Material>(pictureName);
        this.number = number;
    }

    public Animal(string id, string name, string pictureName, string discription, string number, Enclosure enclosure)
    {
        this.id = Int32.Parse(id);
        this.name = name;
        this.pictureName = pictureName;
        this.Picture = Resources.Load<Material>(pictureName);
        this.discription = discription;
        this.number = Int32.Parse(number);
        this.enclosureName = enclosure;
    }

    public Animal(string id, string name, string pictureName, string discription, string number)
    {
        this.id = Int32.Parse(id);
        this.name = name;
        this.pictureName = pictureName;
        this.picture = Resources.Load<Material>(pictureName);
        this.discription = discription;
        this.number = Int32.Parse(number);
    }

    public string Name { get => name; set => name = value; }
    public Material Picture { get => picture; set => picture = value; }
    public string Discription { get => discription; set => discription = value; }
    public Clue[] Clues { get => clues; set => clues = value; }
    public string PictureName { get => pictureName; set => pictureName = value; }
    public Enclosure EnclosureName { get => enclosureName; set => enclosureName = value; }
    public int Number { get => number; set => number = value; }
    public int Id { get => id; set => id = value; }

    public bool compare(Animal animal)
    {
        if(name.CompareTo(animal.Name) == 0)
        {
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        string output = "[ Name: " + name + ", Picture:"+ pictureName + ", Discription:" + discription + ", Number: " + number + " ]";
        if(enclosureName != null)
        {
            output = output + enclosureName.ToString();
        }
        return output;
            
    }
}
