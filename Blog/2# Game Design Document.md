# Game Design Document

## Executive Summary

### Title
**Gym Blaster**

### Game Concept
This is a course project showing the skillset acquired during the course GMD1.

The main idea of the game stems from classic titles such as **Bomberman**, **Dyna Blaster**, and **Megablast**. Gym Blaster follows similar mechanics, with a twist: planting dumbbells or other gym equipment instead of bombs.

### Genre
Top-down 2D arcade action.

### Target Audience
Students, teachers, or any group of 2–4 people looking for a fast-paced, immediate-reward action game.

### Project Scope
Small, single-screen levels with short play sessions (3–5 minutes).

---

## Gameplay

### Objectives
**Single-player:**
Find one creatine container and one whey protein container hidden behind destructible walls, equipment, or other tiles.

**Multiplayer:**
Eliminate other players.

### Obstacles
- Other players and AI-controlled bots
- AI-controlled enemies in the form of fitness girls. Once they pass the player, the player is eliminated.

There are two enemy types:
- One slightly slower than the player but able to pass through walls
- One slightly faster than the player but unable to pass through walls

### Game Progression
**Single-player:**
The game consists of three levels with increasing difficulty. Each level accumulates enemies and provides more power to the player through collected power-ups. The player becomes stronger by gathering creatine and whey protein.

**Multiplayer:**
A leaderboard is shown after each round. The winner is the player who wins a set number of rounds (e.g. three).

### In-game GUI
- Start single-player game
- Start two-player game (with selectable number of rounds)
- Exit game

### HUD
- Time left to end the round

---

## Game Elements

Each level map is a grid of **20 × 16 tiles** with a gym/fitness theme.

### Tile Types
**Indestructible tiles:**
- Floor
- Hard wall
- Bench
- Big rack
- Pipes

**Destructible tiles:**
- Soft wall
- Treadmill
- Weight racks
- Stack of weights
- Radio
- Trash bins
- Lockers

Power-ups are hidden behind destructible tiles.

### Power-ups
- **Creatine:** Increases explosion range
- **Whey protein:** Allows planting more dumbbells/barbells simultaneously
- **Barbell:** Temporarily enables explosions to extend fully across the map both horizontally and vertically

### Characters
- Multiplayer supports up to four player characters (guys with different hat colors)
- Two enemy characters (fitness girls with different hat colors) that function as distraction-based enemies

**Single-player theme:**
The player collects creatine and whey protein to progress through levels and eventually become a successful bodybuilder.

### Losing Condition
In single-player mode, the game is lost if five minutes pass without collecting both creatine and whey protein.

---

## Mechanics

Players can plant a dumbbell or barbell, move away, and after four seconds it slams into the floor or equipment, destroying destructible tiles and creating space to move.

Some destroyed tiles reveal hidden power-ups.

The slam emits a shockwave that:
- Destroys destructible tiles
- Eliminates enemies
- Eliminates other players

Dumbbells and barbells always emit their shockwave four seconds after being planted.

---

## Assets

- Four player character sprites (guys with different hat colors)
- Two enemy character sprites (fitness girls with different hat colors)
- Gym-themed tiles and environment objects
- Visual effects for slams and shockwaves
- Sound effects for placing weights, explosions, and destruction

---

## Milestones

### 1. Core
- First-level grid with indestructible tiles and floor
- Minimum five destructible tiles
- One player with a simple sprite (no animation)
- Player movement
- Ability to place a weight
- Weight slams after four seconds
- Slam breaks destructible tiles
- Collectable power-ups
- Collecting both creatine and whey protein leads to a win
- Game exits to the main menu

### 2. Adding animation and sounds
-	Player (walking, planting a weight, being eliminated).
-	Dumbbell/Barbell waiting for a slam (explosion).
-	Background music. (3 rhythmic tracks in a loop)

### 3. Polishing
-  Add 2 levels,
-  add other players,
-  add enemies.

---

## Feature Development

The game has the potential to expand with:
- Additional levels
- More enemy types
- More weights to slam
- Larger variety of environment tiles
- Additional power-ups
- A stamina system that regenerates over time and limits how many weights a player can place
- Power-up facilities (e.g. bench press or squat rack) to consume creatine and whey protein. Otherwise, the consumables will be limited to only work with 50% efficiency.
