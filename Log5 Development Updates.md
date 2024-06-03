# Log 5: Development Update

## Background sprites & generation

The background now proceedually spawns as the player moves upwards aswell as despawns when far away. It works the same as the platform managing.

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

A bug we've noticed with this is that the player can stand on the edge of a platform and not be able to jump. While this bug is 'active' the player wil have the jumping sprite active. So for some reason you aren't grounded althrough you're standing on the platform. This is probably because of a misalligned collider.

![image](https://github.com/Esben-Andreas-Madsen/GMD1_Ascendia/assets/91538845/f76ea705-e69a-487e-9756-2e69ce08b1ca)


## Platform tracking & UI

The game is now able to track how many floors the player have progressed upwards. 
For now it is only displayed in the console as there are still some minor tweaks needed in order for it to have the desired effect. It currently counts up based on the interaction with the box collider on the platforms, as well as tracking the y-distance the played has traveled. </br>
![image](https://github.com/Esben-Andreas-Madsen/GMD1_Ascendia/assets/102215807/98e6d141-a6bd-4796-8e8f-89b3f5fefe29)

There currently also is a thing present in the game, in which, the player can gain a +1 to their floor tracker without actually touching said platform. The counter will not increase when that specific platform is actually touched again, but it is a slight way the player is able to technically increase their score by +1 without actually engaging directly with the platform. This is currently in the main game and something we are debating on how to deal with even though it is barely noticeable for the player base.





