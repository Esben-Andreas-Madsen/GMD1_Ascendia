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

![image](https://github.com/Esben-Andreas-Madsen/GMD1_Ascendia/assets/91538845/9baaf4f3-a425-4220-8061-90e167a77068)

![image](https://github.com/Esben-Andreas-Madsen/GMD1_Ascendia/assets/91538845/26eb7eac-e8e0-47eb-9239-5717075d2b87)

## Player animation

With the sprite from last blog post the player now changes sprite based on whether they're touching the ground or not.

![image](https://github.com/Esben-Andreas-Madsen/GMD1_Ascendia/assets/91538845/e706c521-da74-47b8-b721-bcf8d247abeb)





