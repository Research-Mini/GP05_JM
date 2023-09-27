# Jm_GP04
게임 프로그래밍 수업 HW4 레포지토리입니다.
## Scene
– Used the environment from my HW3 project
– Created PhysicsObject within the Scene as additional obstacles.
– Demonstrated examples of Static Collider, Trigger Collider,     Dynamic Collider, Kinematic Collider, and Kinematic Trigger Collider using cubes.
## Main Character
– Implemented physics-based movements 
	Using AddRelativeForce(), AddRelativeTorque()

## Main Base
– Created a trigger object for the player’s base
## Game Manager
– Evaluate win or lose conditions via custom events
– Include scene transitions such as win scene or lose scene
	=>I changed the WaveSpawner to GameManager in the previous HW3.

– I made 3 new feature in assignment 4
Installed walls set as Static Colliders around the game map.
Applied Rigidbody and Capsule Collider to the enemy.
Applied a Box Collider and Trigger to the WaterBlock_50m object, and removed the Use Gravity from the Rigidbody. This setup detects collisions when the player falls into the lake, and after a delay of 1 second, it transitions to the LoseScene.





