using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnclosureInfoBehavior : MonoBehaviour
{
    const float RADIUS = 0.05f;
    const float MAX_DISTANCE_X = 0.152f;
    const float MAX_DISTANCE_Y = 0.21226f / 2f;
    private Vector3 startVector = new Vector3(0f,0.001f,0f);
    private GameObject enclosurePlane;
    private TextMesh enclosureName;
    private GameObject animalPicture;
    private GameObject animalTextbox;
    private TextMesh distance;
    // Start is called before the first frame update
    void Start()
    {
        enclosurePlane = GameObject.Find("EnclosurePlane");
        enclosurePlane.SetActive(false);
        Debug.Log("StartVector: " + startVector);


    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnSelection(Transform target)
    {
        if(Mathf.Abs(target.localPosition.y) + target.localScale.x * 5  + RADIUS < MAX_DISTANCE_X )
        {
            enclosurePlane.transform.localPosition =  target.localPosition + new Vector3(target.localScale.x * 5 - target.localPosition.x + RADIUS, 0.001f, 0f);
        } else
        {
            enclosurePlane.transform.localPosition = target.localPosition - new Vector3(target.localScale.x * 5 - target.localPosition.x + RADIUS, 0.001f, 0);
            
        }
        /*
        Enclosure enclosure = target.gameObject.GetComponent<SelectBehavior>().Enclosure;
        setInformation(enclosure, 0);
        */
        Debug.Log("New Position:" + enclosurePlane.transform.localPosition);
        enclosurePlane.SetActive(true);
        Animal katta = new Animal(1,"Katta", "KattaMaterial", "An Animal", 2);
        Enclosure kattaEnclosure = new Enclosure();
        kattaEnclosure.Name = "Katta Gehege";
        kattaEnclosure.Lat = 12.0;
        kattaEnclosure.Lng = 45.0;
        Animal[] array = new Animal[] { katta };
        kattaEnclosure.Animals = array;
        setInformation(kattaEnclosure, 0);
    }

    public void OnDeselection()
    {
        enclosurePlane.SetActive(false);
    }

    public void setInformation(Enclosure enclosure, int index)
    {
        if(animalPicture == null || enclosureName == null || animalTextbox == null || distance == null)
        {
         animalPicture = enclosurePlane.transform.Find("AnimalPicture").gameObject;
         enclosureName = enclosurePlane.transform.Find("Name").gameObject.GetComponent<TextMesh>();
         animalTextbox = enclosurePlane.transform.Find("AnimalTextbox").gameObject;
         distance = enclosurePlane.transform.Find("Distance").gameObject.GetComponent<TextMesh>();

        }


        MeshRenderer renderer = animalPicture.GetComponent<MeshRenderer>();
        renderer.material = enclosure.Animals[index].Picture;
        enclosureName.text =  enclosure.Name;
        distance.text = "Lat: " + enclosure.Lat + " Lnt: " + enclosure.Lng;
        // Add Something for every Animal


    }

    
}
