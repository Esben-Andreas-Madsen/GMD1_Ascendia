# Game Design Document

## Executive summary

Our game concept is based on an existing game called Icy Tower, which is a 2D platformer about jumping upwards in a castle-like environment.
The genres is something of a Casual Platformer and is targeted towards younger people. It could fit well under the Facebook games tab (A version actually already exists there). Its purpose is to keep alive the simplicity and replayability that Flash games used to have.

### Gameplay

- Traverse the Tower (height ascension increases scores)
- Combo-meter (Combo increases speed of Player and the overall score)
- Platforms based on height / floor. Every 50th floor will have a platform that stretches from wall to wall and every 100th floor will changes the level design (colour of platforms & background)
- Collectibles / Achievements / Unlockables
- Floor-tracker UI (or on the platforms)
- Speed up (platforms stay for less time)

### Mechanics

- Jumping
- Building momentum
- Platforms falling
- Building combo
- Wall bouncing

### Game Elements

- The Tower (Level, consists of walls and platforms)
- Platforms
- Main Character (and skins)
- Collectibles (this is a feature, which may not be implemented. Player model skins will be available either throughout higher scores returning some amount of currency to the player, which in return can be used in the "store" or in-game collectibles. These collectibles could help with adding risk vs. reward into the game. The player could risk their run / possible new highscore in return for a new player skin.

We are going by the base of the original Icy Tower aswell as include additions.
![image](https://github.com/Esben-Andreas-Madsen/GMD1_Icy-Tower/assets/91538845/d42b4147-1ac7-4fb4-9f5a-e59fd681b81b)


### Assets

- Music
- Sound effects (jumping, combo, falling, floor milestone, highscore, content unlocked, ui-interaction, floor specific / environmental noises, tower UI changes based on amount of traversed floors e.g every 100 floors)
- 2D
- Character Models for the skins

## Milestones

### Early Milestones:

- Movement & Game Arena (simplified version of the tower)
- Player + Objects interacting (collision etc)
- Platforms (stationary and hardcoded at first)
- Visible Score (solely based on floors progressed / height of tower reached in first edition)

### Later Milestones

- Some sort of enemy or danger encounter to improve difficulty. It could be lazers, birds or the like. If possible and fitting we could use some AI movements here.
- Progressive theme changes. Certain platform levels could include specific encounters to that area. It can be indicated by changing the sprites.
- Maybe a boss portal that takes the player to a different scene where they fight a boss that has random moves. Here we could include move indicators so that you can learn what's coming by playing repeatedly. We're thinking of a megaman-inspired type boss battle.
