# Log 4: Development Update

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

Another sprite for jumping.

![image](https://github.com/Esben-Andreas-Madsen/GMD1_Ascendia/assets/91538845/ffa325e1-fe91-4edc-9bb9-5587cd39232e)
