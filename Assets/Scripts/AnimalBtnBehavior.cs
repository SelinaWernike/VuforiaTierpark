using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimalBtnBehavior : MonoBehaviour,IPointerClickHandler
{
    private Animal animal;
    private EnclosureInfoBehavior enclosureInfo;

    public Animal Animal { get => animal; set => animal = value; }
    public EnclosureInfoBehavior EnclosureInfo { get => enclosureInfo; set => enclosureInfo = value; }

    public void OnClick()
    {
        if(enclosureInfo != null)
        {
           
            if(enclosureInfo != null)
            {
                enclosureInfo.setAnimal(animal);
               
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click: " + animal);
    }
}
