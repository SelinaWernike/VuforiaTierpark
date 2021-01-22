using System.Collections;
using System.Data;
using System.Collections.Generic;
using UnityEngine;
using DataBank;
using Mono.Data.Sqlite;

public class ClueDisplayBehavior : MonoBehaviour
{
    [SerializeField]
    private string name = "";
    private Animal representation;
    private ClueBehavior controller;
   

    public Animal Representation { get => representation; set => representation = value; }

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("GameHandler").GetComponent<ClueBehavior>();
            AnimalDAO animalDAO = new AnimalDAO();
        try
        {
            IDataReader reader = animalDAO.getDataByNameJoin(this.name);
            if (reader.Read())
            {
                representation = AnimalDAO.getAnimalEnclosureFromReader(reader, 0);
            }
        } catch(SqliteException e)
        {
            Debug.Log(e.StackTrace);
        } finally
        {
            animalDAO.close();
        }
    }
    public void TargetLost()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(1).gameObject.SetActive(false);
    }

    public void TargetFound()
    {
        if(representation != null && controller != null)
        {
            if(controller.CheckSolution(representation))
            {
                this.transform.GetChild(0).gameObject.SetActive(true);
            } else
            {
                this.transform.GetChild(1).gameObject.SetActive(true);
            }
        }
    }
}
