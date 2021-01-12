using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    [SerializeField] private string selectTag = "Selectable";
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                var selection = hit.transform.gameObject;
                if(selection.CompareTag(selectTag))
                {
                if (selection != null)
                {
                        EnclosureInfoBehavior handler = this.gameObject.GetComponent<EnclosureInfoBehavior>();
                        if(handler != null)
                        {
                            handler.OnSelection(selection.transform);
                        } else
                        {
                            throw new NullReferenceException("Can't find Component");
                        }
                }

                }
            }

        }
    }
}
