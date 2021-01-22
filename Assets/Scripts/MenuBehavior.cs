using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBehavior : MonoBehaviour
{
    private GameObject mainMenu;
    private GameObject startButton;
    private GameObject restartButton;
    private GameObject sideMenu;
    private ClueBehavior controller;
    private bool started = false;
    // Start is called before the first frame update
    void Start()
    {
        
            Debug.Log("Hello");
            mainMenu = GameObject.Find("MainMenu");
            startButton = GameObject.Find("MainMenu/StartGameBtn");
            restartButton = GameObject.Find("MainMenu/RestartGameBtn");
            sideMenu = GameObject.Find("SideMenu");
            restartButton.SetActive(false);
            mainMenu.SetActive(false);
        controller = GameObject.Find("GameHandler").GetComponent<ClueBehavior>();
        if(mainMenu == null || sideMenu == null)
        {
            throw new NullReferenceException("No Menu found");
        }
        if(startButton == null || restartButton == null)
        {
            throw new NullReferenceException("No Button found");
        }
    }

    public void StartGame()
    {
        GameChange(true);
        controller.StartGame();
            
        
    }

    public void GameChange(bool playing)
    {
        Text text1 = startButton.transform.Find("Text").gameObject.GetComponent<Text>();
        restartButton.SetActive(playing);
    if (text1 != null)
    {
        if (playing)
        {
            text1.text = "Beende Spiel";

        }
        else
        {
            text1.text = "Starte Spiel";
        }
    }


    }

    public void EndGame()
    {
        GameChange(false);
        controller.EndGame();

    }

    public void OnStartEndClick()
    {
        started = !started;
        if(started)
        {
            StartGame();
        } else
        {
            EndGame();
        }
    }

    public void OnBackClicked()
    {
        sideMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void Close()
    {
        Application.Quit();
    }
}
