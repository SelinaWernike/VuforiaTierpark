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
    [SerializeField]
    private int characterCount;

    private List<GameObject> allElements = new List<GameObject>();

    public void addObject(GameObject gridElement)
    {

        
        allElements.Add(gridElement);
        gridElement.transform.localRotation = Quaternion.identity;
            
      
        for(int i = 0; i < allElements.Count; i++)
        {
            allElements[i].transform.localPosition = new Vector3(x_start + (x_space * (i % colum_space)), 0.02f, z_start + (-z_space * (i / colum_space)));
        }
    }

    public void deleteAll()
    {
        foreach(Transform child in this.transform) {
            GameObject.Destroy(child.gameObject);
            allElements.Clear();
        }
    }

    public int getMaxItemCount()
    {
        return row_space * colum_space;
    }

    public string FormatText(string text)
    {
        int index = characterCount;
        int border = 0;
        while(index < text.Length)
        {
            for(int i = index;i >= border; i--)
            {
                if(text[i].CompareTo(' ') == 0)
                {
                    text = text.Insert(i, "\n");
                    border = i + 2;
                    index = border + characterCount;
                    break;
                }
                if(i == border)
                {
                    text = text.Insert(i, "-\n");
                    index += characterCount + 3;
                    break;
                }
            }
        }

        return text;
    }
}
