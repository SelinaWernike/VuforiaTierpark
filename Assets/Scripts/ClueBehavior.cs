using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using DataBank;
using System.Data;


/** <author> Selina Wernike</author>
 * <summary>Class that controls the ralley part of the application.
 * Displays clues</summary>
 **/
public class ClueBehavior : MonoBehaviour
{
    private Animal currentTarget;
    private const int MAX_POINTS = 7;
     private DisplayTextBehavior[] clues;
    private Clue[] currentClues;
    private string currentClue = "";
    private int points = 0;
    private DateTime startTime;
    private double highScore = 0;
    private int multiplier = 0;
    // private Animal[] allRalleyPoints; 
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /**
     * <summary>Start and sets up the Game</summary>
     **/
    public void StartGame()
    {
        startTime = DateTime.Now;
        UnityEngine.Random.InitState((int)startTime.TimeOfDay.TotalSeconds);
        if (clues == null)
        {
            GameObject[] cluedisplays = GameObject.FindGameObjectsWithTag("ClueMenu");
            clues = new DisplayTextBehavior[cluedisplays.Length];
            for(int i = 0; i < clues.Length;i++)
            {
                clues[i] = cluedisplays[i].GetComponent<DisplayTextBehavior>();
            }
        }
    }
    /**
     * <summary>Ends the game and sets class back to default</summary>
     **/
    public void EndGame()
    {
        highScore = multiplier * startTime.Subtract(DateTime.Now).TotalMinutes;
        points = 0;
        currentClue = null;
        currentTarget = null;
        currentClues = new Clue[0];
    }

    /**
     * <summary>Checks if an input matches the requestet animal. If thaths the case 
     * adds pont to the score. If MAX_POINTS are reached the game is won</summary>
     * <param name="solution"> Object of found Target</param>
     **/
    public void CheckSolution(Animal solution)
    {
        if(solution.compare(currentTarget))
        {
            points++;
            multiplier += 5 - currentClues.Length;

        }
        //Check if Animal is the same
        if(points >= MAX_POINTS)
        {
            WinGame();
        }
    }

    public void WinGame()
    {
        //Winscreen
        EndGame();
    }

    public void getClues(Animal animal)
    {
        ClueDAO cdao = new ClueDAO();
        IDataReader reader = cdao.getDataByAnimalID(currentTarget.Id);
        cdao.close();
        List<Clue> clues = new List<Clue>();
        while (reader.Read())
        {
            Clue newClue = new Clue(reader[0 ].ToString(),reader[1].ToString(), animal);
            clues.Add(newClue);
        }
        currentClues = clues.ToArray();
        
    }

    public void nextClue()
    {
        if(currentClue.Length >= 1)
        {
        int rand = UnityEngine.Random.Range(0, currentClues.Length - 1);
        currentClue = currentClues[rand].SingleClue;
            Clue[] cluesToCome = new Clue[currentClue.Length - 1];
            int index = 0;
            for(int i = 0; i < cluesToCome.Length;i++)
            {
                if(i == rand)
                {
                    index++;
                }
                cluesToCome[i] = currentClues[index];
            }
            currentClues = cluesToCome;
        }
        

    }

    public void nextAnimal()
    {
        AnimalDAO adao = new AnimalDAO();
        IDataReader rowReader = adao.getNumOfRows();
        int rows = Int32.Parse(rowReader[0].ToString());
        IDataReader reader = adao.getDataByID((int)UnityEngine.Random.Range(1, 10));
        adao.close();
        reader.Read();
        currentTarget = new Animal(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(),
            new Enclosure(reader[5].ToString(), reader[6].ToString(),reader[7].ToString(), reader[8].ToString(), reader[9].ToString()));

    }
}
