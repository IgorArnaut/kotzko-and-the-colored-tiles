# Kotzko and the Colored Tiles #

The game is made as a project for a term paper in college. The game is about a guy who going trough a dungeon. The game is mainly inspired by a cutscene from Toby Fox' game Undertale, in which skeletons named Sans and Papyrus created a trap that involved tiles where each color had their attribute, e.g. red tile not being passable and yellow tile electrocuting the player, but this time I have expanded these tiles more.

## Gameplay ##

Most of the time you are in an dungeon in outer space. This is one part of the game and has a top down view. You can use terminals which give you information, step on tiles which affect you, open chests which give you gems, power-ups or hearts, and open gates to go trough the dungeon.
The other part is a 2D sideview arena in which you fight enemies and is minimally inspired by Tales games.

### Tiles ###

There are seven tiles and each of them causes it's own effect on the player. They are:
* `#E62E2E` Red tile - can't be passed.
* `#E68A2E` Orange tile - slows down the player and makes him oscillate into orange until the player steps out. Also, once player enters water after stepping out of the orange tile, he dies.
* `#E6C72E` Yellow tile - electrocutes the player and damages him.
* `#6BE62E` Green tile - teleports the player into the enemy arena when being stepped on.
* `#8A2EE6` Purple tile - speeds up the player for a certain duration and makes him oscillate into purple.
* `#E65CE5` Pink tile - heals the player when being stepped on.
* `#262626` Black tile - oscilates between the black and white. Instantly kills the player when it is black, so the player should walk on it while it's white.
