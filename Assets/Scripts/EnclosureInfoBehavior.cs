using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnclosureInfoBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    const float RADIUS = 0.05f;
    const float MAX_DISTANCE_X = 0.152f;
    const float MAX_DISTANCE_Y = 0.21226f / 2f;
    private Vector3 startVector = new Vector3(0f,0.001f,0f);
    private GameObject enclosurePlane;
    private TextMesh enclosureName;
    private GameObject animalPicture;
    private GameObject animalTextbox;
    private TextMesh distance;
    private Enclosure currentEnclosure;
    private Animal currentAnimal;
    // Start is called before the first frame update
    void Start()
    {
        enclosurePlane = GameObject.Find("EnclosurePlane");
        enclosurePlane.SetActive(false);
        Debug.Log("StartVector: " + startVector);
    }

    public void OnSelection(Transform target)
    {
       
        Enclosure enclosure = target.gameObject.GetComponent<SelectBehavior>().Enclosure;
        if(currentEnclosure == null || enclosure.CompareTo(currentEnclosure) == false)
        {
            currentEnclosure = enclosure;
            enclosurePlane.transform.localPosition = target.localPosition - new Vector3(target.localScale.x * 5 + RADIUS, 0, 0);
        
            setInformation(enclosure, 0);
            if(enclosure.Animals != null && enclosure.Animals.Length > 0)
            {
                setAnimal(enclosure.Animals[0]);

            } else
            {
                SetDefault();
            }
            enclosurePlane.SetActive(true);
            
        } else
        {
            enclosurePlane.SetActive(false);
            currentEnclosure = null;
        }
        
        
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
        enclosureName.text =  enclosure.Name;
        distance.text = "Lat: " + enclosure.Lat + " Lnt: " + enclosure.Lng;
        GridManager grid =  enclosurePlane.transform.Find("AnimalTextbox").gameObject.GetComponent<GridManager>();
        grid.deleteAll();
        
        if(enclosure.Animals != null)
        {

            foreach(Animal animal in enclosure.Animals) {

                GameObject animalBtn = Instantiate(prefab, Vector3.zero, Quaternion.identity,animalTextbox.transform);
                AnimalBtnBehavior btn = animalBtn.GetComponent<AnimalBtnBehavior>();
                btn.Animal = animal;
                btn.EnclosureInfo = this;
                GameObject textChild = animalBtn.transform.GetChild(0).gameObject;
                TextMesh text = textChild.GetComponent<TextMesh>();
                text.text = animal.Name;
                if(grid)
                {
                    Debug.Log("Found grid Object");
                    grid.addObject(animalBtn);
                }
            }
        } else
            {
                SetDefault();
            }
        


    }

    public void setAnimal(Animal animal)
    {
        if (animalPicture == null)
        {
            animalPicture = enclosurePlane.transform.Find("AnimalPicture").gameObject;

        }
        if(animal.Picture != null)
        {
            MeshRenderer renderer = animalPicture.GetComponent<MeshRenderer>();
            renderer.material = animal.Picture;
        }
        currentAnimal = animal;
        
        
    }

    public void SetDefault()
    {
        if (animalPicture == null)
        {
            animalPicture = enclosurePlane.transform.Find("AnimalPicture").gameObject;
        }
        MeshRenderer renderer = animalPicture.GetComponent<MeshRenderer>();
        renderer.material = Resources.Load<Material>("DefaultAMaterial");
        currentAnimal = null;
    }
    
}
