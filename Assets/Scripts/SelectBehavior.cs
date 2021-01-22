using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataBank;
using System.Data;
using Mono.Data.Sqlite;

public class SelectBehavior : MonoBehaviour
{
    [SerializeField]
    private string name = "";
    private Enclosure enclosure;

    public Enclosure Enclosure { get => enclosure; set => enclosure = value; }

    // Start is called before the first frame update
    void Start()
    {
        getEnclosure();
        getAnimalsformEnclosure(enclosure.Id);
    }

    private void getEnclosure()
    {
        EnclosureDAO ownEnclosure = new EnclosureDAO();
        try
        {
            IDataReader data = ownEnclosure.getDataByName(name);
            if (data.Read())
            {
                enclosure = EnclosureDAO.getEnclosureFromReader(data, 0);
            }
            data.Close();
        }
        catch (SqliteException e)
        {
            Debug.Log("Couldn't find Enclosure: " + name + "\n " + e.StackTrace);
        }
        finally
        {
            ownEnclosure.close();
        }
    }

    private void getAnimalsformEnclosure(int id)
    {
        List<Animal> animals = new List<Animal>();
        AnimalDAO animalDAO = new AnimalDAO();
        try
        {
            Debug.Log(id);
            IDataReader data = animalDAO.getDatabyEnclosure(id);
            while (data.Read())
            {
                Debug.Log("Animals from Table exist ");
                animals.Add(AnimalDAO.getAnimalFromReader(data, 0));
                enclosure.Animals = animals.ToArray();

            }

        }
        catch (SqliteException e)
        {
            Debug.Log("Couldn't find Enclosure: " + name + "\n " + e.StackTrace);

        }
        finally
        {
            animalDAO.close();
        }
    }

}
