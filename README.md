# Jm_GP05
게임 프로그래밍 수업 HW5 레포지토리입니다.

## Objectieves
 Improve the Game AI and Visual Effects in Your Shooting Game
 
## Tasks
- Extend game from HW4 project
- Visual Effects
• Introduce new visual effects in the Scene
• Introduce new visual effects for the player or enemies
• The visual effects must be created using Shader Graph, Particle System, or Visual Effect Graph
• Please use at least two methods mentioned above for your visual effects
– Game AI
• Improve the FSM for enemies
	– The enemies should aim to kill the player or destroy the main base
• Introduce new features of your own design
	– It’s acceptable to extend the game logic or add more features

## Requirements
– Avoid using external assets when creating new visual effects
• It is acceptable to use external textures of materials
– Avoid replicating methods used in the textbook to create 
visual effects for objects featured in the textbook
• Do not utilize the shader graph for creating water effects
• If you intend to create a waterfall or bone fire effect, refrain from using the Shuriken particle system
• For rain effects, use methods other than the visual effect graph
– There will be no penalties for Korean presentation
	• All slides must be written in English
– Ensure that your FSM must be different from the one presented in the textbook


##Add Effect
Burning LoseBase(Bonfire effect)
With visual effect graph

Explosion Effect1 – Enemy destroy effect
Using particle system

Explosion Effect2 – Player destroy effect
Using particle system


## Game AI
-States
 GoToBase : The enemy is moving towards the base.
 AttackBase : The enemy is attacking the base.
 RangeAttack : The enemy is attacking the player within a specified range. 

-Transitions
 GoToBase -> RangeAttack : When the enemy detects the player.
 GoToBase -> AttackBase : When the enemy reaches the base.
 RangeAttack -> GoToBase : After attacking for 2 seconds, or if the player moves out of range.







