# Log 4: Development Update

## Main menu

There is now a basic main menu present in the game. This offers a play button functionality as well as an instructions guide, which displays the controls of the game. Pressing the play button boots up the game but there is currently no way of returning to the menu without exiting the game.
The controls are displayed solely with keyboard mapping for now and has sprites in conjunction with the text.

There are now also a settings options present in the menu. Currently it has the ability to control the volume of the music or disable it entirely altogether depending on preferences.
There are plans in the next update to add sound effects to the game (besides the main theme) and add options similar to the ones for the main theme.

Here is an image of the current menu: <br>
![image](https://github.com/Esben-Andreas-Madsen/GMD1_Ascendia/assets/91538845/736c6128-fb52-42e5-ae0f-2e2f45408b7d)



The menu at the moment is focused on functionality over looks, but will be expanded upon to be more aesthetic as soon as the functionality is in place.

### Highscores & Store
(These menu features will be added in a future update)

## Music

As mentioned briefly in the above segment there is now music in the game. It is a main theme which persists through the menu and into the game. The music will start over from scratch if the player disables and then enables the music again at a later point in the settings menu. The music also loops/repeats itself as soon as it is finished so the player can keep enjoying the tune. The following script is how the music persists between the switching of main menu to the game:

```
public static MusicPersist instance;

    void Awake()
    {
        if (instance != null)
        Destroy(gameObject);

        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
       

    }
```

## Platform Manager

We've implemented a platform manager which keeps track of platforms.

![image](https://github.com/Esben-Andreas-Madsen/GMD1_Ascendia/assets/91538845/f2630c8d-4b3d-431e-a5c7-bff114193162)

It spawns the platforms with a set distance in front of the Player as they traverse upwards, while also deleting platforms below for better performance.
This is done by keeping track of platforms in an array where once the array is full, each index y-position is checked and the lowest is destroyed. Very nice :)

```
    void RemoveLowestPlatform()
    {
        float lowestYPos = float.MaxValue;
        int lowestPlatformIndex = -1;

        // Find the lowest platform
        for (int i = 0; i < maxPlatforms; i++)
        {
            if (platforms[i] != null && platforms[i].transform.position.y < lowestYPos)
            {
                lowestYPos = platforms[i].transform.position.y;
                lowestPlatformIndex = i;
            }
        }

        // Remove the lowest platform
        if (lowestPlatformIndex != -1)
        {
            Destroy(platforms[lowestPlatformIndex]);
            platforms[lowestPlatformIndex] = null;
        }
    }
```

## More Sprites

Several custom made sprites have been added for the purpose of both gameplay and to display controls of the game in the menu.

Another sprite for jumping.

![image](https://github.com/Esben-Andreas-Madsen/GMD1_Ascendia/assets/91538845/ffa325e1-fe91-4edc-9bb9-5587cd39232e)
