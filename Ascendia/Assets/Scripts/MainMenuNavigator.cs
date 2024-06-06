using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;
using UnityEngine.EventSystems;
using static System.Net.Mime.MediaTypeNames;

public class MainMenuNavigator : MonoBehaviour
{

    public GameObject mainMenu, settingsMenu, highScoreMenu, instrucMenu;


    public GameObject mainMenuFirstButton, settingsMenuFirstButton, highScoreButton, instrucButton, menuCloseButton;



    
    void Start()
    {
        
    }

    
    void Update()
    {
       
        
    }

    public void OpenSettings()
    {
        settingsMenu.SetActive(true);

       
        EventSystem.current.SetSelectedGameObject(null);

        
        EventSystem.current.SetSelectedGameObject(settingsMenuFirstButton);
    }


    public void OpenHighscore()
    {
        highScoreMenu.SetActive(true);

        
        EventSystem.current.SetSelectedGameObject(null);

        
        EventSystem.current.SetSelectedGameObject(highScoreButton);
    }


    public void OpenInstructions()
    {
        instrucMenu.SetActive(true);

        // clear objects
        EventSystem.current.SetSelectedGameObject(null);

        // select object
        EventSystem.current.SetSelectedGameObject(instrucButton);

    }

    public void CloseCurrentMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        
        EventSystem.current.SetSelectedGameObject(menuCloseButton);
    }

    public void QuitGame()
    {
        UnityEngine.Application.Quit();
    }

}
