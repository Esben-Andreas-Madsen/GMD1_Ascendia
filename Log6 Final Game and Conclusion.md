# Log 6: Final Update

## New Features

#### Sound Effects

The Game now has 3 sound effects that play whenever you:  
- Select a button option
- Jump in-game
- Fall to your death

#### Boulder Encounters

Occasionally the player will now stumble upon a boulder falling down.  
It acts as an obstacle you have to avoid, but it can only block you from progressing up.  
It has AI movements but to make it less annoying for the player it doesn't move a lot.  
 
#### Difficulty Balance

You can now die more easily. The Death Zone is only the distance of rougly 5 platforms below the Player. Before it was between 8-10 platforms, which felt a little to easy at times.

#### Prettier Menus

We did some detailing for the menus. They're now prettier and fit the theme better.  


#### Respawn Menu

If you die you can select respawn or exit to return to main menu.  


## Known bugs/issues

#### Jumping
Player suspended in jump animation while being on the edge of a platform resulting in being unable to jump from that spot. This is mostly noticeable on the smallest of platforms but is generally not that noticeable when playing the game fast as intended.  
![image](https://github.com/Esben-Andreas-Madsen/GMD1_Ascendia/assets/102215807/1d28d315-afdb-44e8-8b67-1ece2ed1fe10)

#### Settings
After entering the game and quitting back to the menu the settings will be locked in the original setup before entering the game. So in order to change the volume or disable it altogether, it is necessary to close the game and boot it back up.  
![image](https://github.com/Esben-Andreas-Madsen/GMD1_Ascendia/assets/102215807/f3948e05-104d-4a61-83ab-6ccb3315b971)

#### Platform safety
It was intended that every 100th platform should cover from wall to wall in order to create a safety net and also signify a change in the theme layout. However, these platforms will appear sometimes ~10 ish platforms earlier and will only cover 80-90% of the actual game arena.

#### Jumping through platforms
It is possible to jump through the platforms and spam the jump button and then interact with the collider to jump before actually hitting the platform with the player model's feet. This was originally something we considered a bug, but thought it felt natural to the state of the gameplay and kept it as a feature.






