using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** <author> Selina Wernike</author>
 * <summary>Class that controls the ralley part of the application.
 * Displays clues</summary>
 **/
public class ClueBehavior : MonoBehaviour
{
    private Animal currentTarget;
    private const int MAX_POINTS = 7;
     private GameObject[] clues;
    private string currentClue = "";
    private int points = 0;
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
        if (clues == null)
        {
            clues = GameObject.FindGameObjectsWithTag("Clue");
        }
        // load Animal Clue List from Database
        // Shuffle Clues and Animals
    }
    /**
     * <summary>Ends the game and sets class back to default</summary>
     **/
    public void EndGame()
    {
        points = 0;
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

    public void nextClue()
    {

    }
}
