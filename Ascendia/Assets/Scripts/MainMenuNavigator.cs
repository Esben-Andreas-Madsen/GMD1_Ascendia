using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuNavigator : MonoBehaviour
{

    public GameObject mainMenu, settingsMenu, highScoreMenu, instrucMenu;


    public GameObject mainMenuFirstButton, settingsMenuFirstButton, highScoreButton, instrucButton, menuCloseButton;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    public void OpenSettings()
    {
        settingsMenu.SetActive(true);

        // clear objects to ensure no issues
        EventSystem.current.SetSelectedGameObject(null);

        // select correct object
        EventSystem.current.SetSelectedGameObject(settingsMenuFirstButton);
    }


    public void OpenHighscore()
    {
        highScoreMenu.SetActive(true);

        // clear objects to ensure no issues
        EventSystem.current.SetSelectedGameObject(null);

        // select correct object
        EventSystem.current.SetSelectedGameObject(highScoreButton);
    }


    public void OpenInstructions()
    {
        instrucMenu.SetActive(true);

        // clear objects to ensure no issues
        EventSystem.current.SetSelectedGameObject(null);

        // select correct object
        EventSystem.current.SetSelectedGameObject(instrucButton);

    }

    public void CloseCurrentMenu()
    {
        instrucMenu.SetActive(false);

        // clear objects to ensure no issues
        EventSystem.current.SetSelectedGameObject(null);

        // select correct object
        EventSystem.current.SetSelectedGameObject(menuCloseButton);
    }

}
