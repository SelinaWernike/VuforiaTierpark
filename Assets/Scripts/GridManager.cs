using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    private float x_start,z_start;
    [SerializeField]
    private float spacing;
    [SerializeField]
    private int row_space, colum_space;
    [SerializeField]
    private float x_space, z_space;

    private List<GameObject> allElements = new List<GameObject>();

    public void addObject(GameObject gridElement)
    {
        gridElement  = Instantiate(gridElement, Vector3.zero,Quaternion.Euler(90,0,0));
        gridElement.transform.parent = this.transform;
        gridElement.transform.localScale = Vector3.one;
            
        allElements.Add(gridElement);
      
        for(int i = 0; i < allElements.Count; i++)
        {
            allElements[i].transform.localPosition = new Vector3(x_start + (x_space * (i % colum_space)), 0.02f, z_start + (-z_space * (i / colum_space)));
        }
    }
}
