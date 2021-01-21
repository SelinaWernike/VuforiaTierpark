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
    private const int MAX_POINTS = 3;

    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private GameObject winScreen;
    private MenuBehavior menu;
    private GameObject[] displays;
    private Clue[] displayedClues;
    private int currentIndex = -1;
    private List<Clue> currentClues = new List<Clue>();
    private DateTime startTime;
    private List<int> usedAnimals = new List<int>();

    private Animal currentTarget;
    private string currentClue = "";
    private int points = 0;
    private int multiplier = 0;

    private double highScore = 0;

    void Start()
    {
        if(menu == null)
        {
            UnityEngine.Random.InitState((int)startTime.TimeOfDay.TotalSeconds);
            menu = GameObject.Find("MenuHandler").GetComponent<MenuBehavior>();
        }
    }

    /**
     * <summary>Start and sets up the Game</summary>
     **/
    public void StartGame()
    {
        startTime = DateTime.Now;
        highScore = 0;
        currentIndex = -1;
        if (displays == null)
        {
            displays = GameObject.FindGameObjectsWithTag("ClueMenu");
        }
        nextAnimal();
    }
    /**
     * <summary>Ends the game and sets class back to default</summary>
     **/
    public void EndGame()
    {
        points = 0;
        currentClue = null;
        currentTarget = null;
        displayedClues = null;
        currentIndex = -1;
        currentClues.Clear();
        deleteDisplay();
    }

    /**
     * <summary>Checks if an input matches the requestet animal. If thaths the case 
     * adds pont to the score. If MAX_POINTS are reached the game is won</summary>
     * <param name="solution"> Object of found Target</param>
     **/
    public bool CheckSolution(Animal solution)
    {
        if(currentTarget != null)
        {
            bool correct = solution.compare(currentTarget);
            if (correct)
            {
                points++;
                multiplier += displayedClues.Length - currentClues.Count;
            if(points >= MAX_POINTS)
                {
                    WinGame();
                    Debug.Log("You Win");
                } else
                {
                    nextAnimal();
                }
                Debug.Log("Points: " + points);
                return correct;
            }

        }
        return false;
    }

    public void WinGame()
    {
        highScore = multiplier / DateTime.Now.Subtract(startTime).TotalMinutes;
        winScreen.SetActive(true);
        winScreen.GetComponent<WinScreenBehavior>().DisplayHighScore(highScore);
        menu.EndGame();
    }

    public void getClues(Animal animal)
    {
        deleteDisplay();
        currentClues.Clear();
        ClueDAO cdao = new ClueDAO();
        IDataReader reader = cdao.getDataByAnimalID(currentTarget.Id);
        while (reader.Read())
        {
            Clue newClue = new Clue(reader[0].ToString(),reader[1].ToString(), animal);
            Debug.Log(newClue);
            currentClues.Add(newClue);
        }
        displayedClues = new Clue[currentClues.Count];
        reader.Close();
        cdao.close();
        if(currentClues.Count <= 0)
        {
            nextAnimal();
        }
    }

    public void nextClue()
    {
        if(displayedClues != null && (currentIndex + 1) < displayedClues.Length)
        {
            currentIndex++;
            if(displayedClues[currentIndex] == null)
            {
                int rand = UnityEngine.Random.Range(0, currentClues.Count);
                currentClue = currentClues[rand].SingleClue;
                displayedClues[currentIndex] = currentClues[rand];
                currentClues.RemoveAt(rand);

            } else
            {
                currentClue = displayedClues[currentIndex].SingleClue;
            }

            displayClue();
        }
        
        

    }

    public void previousClue()
    {
        if(displayedClues != null && (currentIndex - 1) >= 0)
        {
            currentIndex--;
            currentClue = displayedClues[currentIndex].SingleClue;
            displayClue();
        }
    }

    private void displayClue()
    {
        if(displays != null && displays.Length > 0)
        {
            for (int i = 0; i < displays.Length; i++)
            {
                GridManager grid = displays[i].GetComponent<GridManager>();
                grid.deleteAll();
                GameObject text = Instantiate(prefab, Vector3.zero, Quaternion.identity, displays[i].transform);
                text.transform.GetChild(0).GetComponent<TextMesh>().text = grid.FormatText(currentClue);
                grid.addObject(text);
            }
        }
    }

    private void deleteDisplay()
    {
        if (displays != null && displays.Length > 0)
        {
            for (int i = 0; i < displays.Length; i++)
            {
                displays[i].GetComponent<GridManager>().deleteAll();
            }
        }
    }

    public void nextAnimal()
    {
        AnimalDAO adao = new AnimalDAO();
        IDataReader rowReader = adao.getNumOfRows();
        int rows = Int32.Parse(rowReader[0].ToString());
        Debug.Log("There are:" + rows);
        rowReader.Close();
        IDataReader reader = adao.getDataByIDJoin(generateRandom(rows));
        reader.Read();
        currentTarget = AnimalDAO.getAnimalEnclosureFromReader(reader, 0);
        reader.Close();
        adao.close();

        Debug.Log(currentTarget);
        currentIndex = -1;
        getClues(currentTarget);
        nextClue();

    }

    private int generateRandom(int rows)
    {
        if(usedAnimals.Count >= rows)
        {
            usedAnimals.Clear();
        }
        int random = (int)UnityEngine.Random.Range(1, rows + 1);
       while(usedAnimals.Contains(random))
        {
            random = (int)UnityEngine.Random.Range(1, rows + 1);
        }
        usedAnimals.Add(random);
        return random;
    }
}
