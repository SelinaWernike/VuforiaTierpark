using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoMenuBehavior : MonoBehaviour
{
    private Animal animal;
    private GameObject text;
    private GameObject image;
    private Text name;

    private void Start()
    {
        if(text == null || image == null || name == null)
        {
            text = this.transform.Find("TextBox/Text").gameObject;
            image = this.transform.Find("AnimalImage").gameObject;
            name = this.transform.Find("AnimalName").gameObject.GetComponent<Text>();
            this.gameObject.SetActive(false);
        }
    }

    public void DisplayAnimal(Animal animal)
    {
        this.animal = animal;
        text.GetComponent<Text>().text = animal.Discription + "\nAnzahl Tiere: " + animal.Number;
        image.GetComponent<Image>().material = animal.Picture;
        name.text = animal.Name;
    }
}
