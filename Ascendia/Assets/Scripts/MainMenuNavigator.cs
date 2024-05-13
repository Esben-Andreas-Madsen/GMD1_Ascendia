using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuNavigator : MonoBehaviour
{

    public GameObject mainMenu, settingsMenu;

    public GameObject mainMenuFirstButton, settingsMenuFirstButton, settingsClosedButton;



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

    public void CloseSettings()
    {
        settingsMenu.SetActive(false);

        // clear objects to ensure no issues
        EventSystem.current.SetSelectedGameObject(null);

        // select correct object
        EventSystem.current.SetSelectedGameObject(settingsClosedButton);
    }
}
