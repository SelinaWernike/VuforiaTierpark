using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueDisplayBehavior : MonoBehaviour
{
    private Animal representation;
    private ClueBehavior controller;

    public Animal Representation { get => representation; set => representation = value; }

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("GameHandler").GetComponent<ClueBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TargetFound()
    {
        if(representation != null && controller != null)
        {
            controller.CheckSolution(representation);
        }
    }
}
