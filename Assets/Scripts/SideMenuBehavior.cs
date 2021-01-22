using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMenuBehavior : MonoBehaviour
{
    
   public GameObject mainMenu;
    // Start is called before the first frame update
    void Awake()
    {
        /*mainMenu = GameObject.Find("MainMenu");
        if(mainMenu == null)
        {
            throw new NullReferenceException("No Menu found");
        } */
        
    } 

   public void OnClick()
    {
        if(mainMenu != null)
        {
            mainMenu.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
