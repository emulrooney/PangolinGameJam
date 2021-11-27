# Pangolin Game Jam Project

[Play the GameJam version.](https://emulrooney.github.io/assets/content/pangolinWebGL/)

![Screenshot of Pangolin Dinner](https://raw.githubusercontent.com/dog-eared/PangolinGameJam/master/Screenshot.png)

Project for Mohawk College Game Jam #1, April 2018. Finished game had to somehow incorporate either the given sprite or 3D model of a pangolin. 

## Updates
**December 16 2019**
* Sky now tints as levels progress; we wanted this in the original version but it didn't make it before.
* Multiplier now lasts long enough to be useful; it's pretty easy to get to x3 and x4, but you have to be **fast** to get x5 and above.
* Restart button moved over to not overlap character.
* Fixed bug on 3rd level where tongue went directly into the earth.
* Tweaked level boundaries; shouldn't see edges of level off screen and ants should stay closer to centre.
* Winning no longer shows a weird black void.

### Game Rules:
1.) Player presses down button to drop the pangolin's tongue.

2.) Player can use WASD to control the tongue to navigate the ant colony.

3.) Pressing up forces the tongue to retract fully, as does touching a wall.

4.) You get extra points for touching multiple ants at once.

5.) The level is complete when you get all the ants.

6.) If you run out of time, the game is over.


### Work by:

[Porsche Le](https://github.com/PorscheLe7) - audio design, main menu

[Evan Mulrooney](https://emulrooney.github.io) - tongue mechanics, level management, ant movement 

[Jess Nguyen](https://github.com/Jess-Nguy) - timer, audio management

[William Nguyen](https://github.com/itzwilleh) - level design, tilemaps, main menu 

### Things that were cut:

**Powerups, ~~day/night cycle~~** - we just couldn't get them working in time for presentations. We had the code, but not enough time. **Update Dec 2019: Added day turning to night as levels progress.**

**Spitball Powerup** - intent was something to freeze ants in place

**Ants Screaming in Fear** 

**Pangolin Movement** - we originally considered having the player move the pangolin between different ant nests, but was too far outside our core game loop to be feasible

