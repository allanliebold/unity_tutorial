A 2D platformer game made in Unity. 

PlayerController.cs - This script handles input and player character movement, behavior, collision detection, and sprite appearance and animation. The isGrounded value, determined by a groundCheck object, is used to allow the player to jump only if the value is true. The player cannot jump while already in the air (although a double jump feature may be added, which would allow the player to jump one time in the air.) Coming into contact with an object that contains a DamagePlayer script causes the player to be knocked back. During this time the player is also briefly invincible to prevent them from taking unavoidable repeat damage. 

LevelManager.cs - Contains various game data such as player health, coins, and lives, as well as the UI displays for each. Controls the Game Over screen and respawning the player character on death. It also contains an array that stores all objects that will be reset whenever the player respawns. 

CheckPointController - Assigns and updates the current checkpoint when the player character touches a checkpoint object. This becomes the respawn point where the player will appear after dying. 

LevelEnd.cs - Loads the next specified scene when the player character comes into contact with an object with this script attached. 

Reset.cs - Attached to an object that can be collected or destroyed, if the object should reappear whenever the player respawns. These objects are located and added to an array in the LevelManager script.
