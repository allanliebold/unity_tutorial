A 2D platformer game made in Unity. 

PlayerController.cs - This script handles input and player character movement, behavior, collision detection, and sprite appearance and animation. The isGrounded value, determined by a groundCheck object, is used to allow the player to jump only if the value is true. The player cannot jump while already in the air (although a double jump feature may be added, which would allow the player to jump one time in the air.) Coming into contact with an object that contains a DamagePlayer script causes the player to be knocked back. During this time the player is also briefly invincible to prevent them from taking unavoidable repeat damage. 

LevelManager.cs - Contains various game data such as player health, coins, and lives, as well as the UI displays for each. Controls the Game Over screen and respawning the player character on death. 
