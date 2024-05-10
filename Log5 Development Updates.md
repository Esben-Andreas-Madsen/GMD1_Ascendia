# Log 5: Development Update

## Background sprites & generation

The background now proceedually spawns as the player moves upwards aswell and despawns when far away. It works the same as the platform managing.

```
    void DespawnBackgrounds()
    {
        for (int i = spawnedBackgrounds.Count - 1; i >= 0; i--)
        {
            if (player.position.y - spawnedBackgrounds[i].transform.position.y >= despawnYDistance)
            {
                Destroy(spawnedBackgrounds[i]);
                spawnedBackgrounds.RemoveAt(i);
            }
        }
    }
```

We might have to scale these up or look into preserving pixel art quality since they look blurry in-game. Something about pixels per unit might resolve it.

![image](https://github.com/Esben-Andreas-Madsen/GMD1_Ascendia/assets/91538845/9baaf4f3-a425-4220-8061-90e167a77068)

![image](https://github.com/Esben-Andreas-Madsen/GMD1_Ascendia/assets/91538845/26eb7eac-e8e0-47eb-9239-5717075d2b87)

## Player animation

With the sprite from last blog post the player now changes sprite based on whether they're touching the ground or not.

```
    [SerializeField] private SpriteRenderer spriteRenderer;

    public Sprite groundedSprite;
    public Sprite jumpingSprite; 

```
```
        if (isGrounded)
        {
            spriteRenderer.sprite = groundedSprite;
        }
        else
        {
            spriteRenderer.sprite = jumpingSprite;
        }
```


![image](https://github.com/Esben-Andreas-Madsen/GMD1_Ascendia/assets/91538845/e706c521-da74-47b8-b721-bcf8d247abeb)

## Platform tracking & UI

The game is now able to track how many floors the player have progressed upwards. 
For now it is only displayed in the console as there are still some minor tweaks needed in order for it to have the desired effect. It currently counts up based on the interaction with the box collider on the platforms, however there are still some bugs due to the functionality of the script. </br>
![image](https://github.com/Esben-Andreas-Madsen/GMD1_Ascendia/assets/102215807/98e6d141-a6bd-4796-8e8f-89b3f5fefe29)

- If the player goes through the bottom of the box collider it will count as +2 floors instead of 1.
- If the player falls down an x-amount of floors the floor counter will not decrease.
- The UI isn't currently being shown to the player since it isn't following the camera correctly.



By the full release of the game we plan to have sorted these issues and will make tweaks to the functionality so the player doesn't experience any mishaps in a potential new highscore!





