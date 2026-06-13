# Overview

This project focuses on designing and implementing a real-time 2D game environment from scratch to master the core principles of event-driven programming, architectural game loops, and dynamic state management. As a software engineer, the goal is to deepen technical proficiency in structural C# design patterns, memory allocation optimization, and programmatic visual rendering pipelines while working with robust multi-platform frameworks.

The software is an arcade-style, top-down 2D survival and resource-gathering simulation. It features a localized finite state machine splitting the application into an initial username authentication phase and an active gameplay loop. Players input an alphanumeric pilot handle to clear the login state and enter a structured grid arena. In the arena, players control a blue character entity with the primary objective of collecting randomly spawning gold ore nodes while evading an autonomous crimson chaser entity. 

When the player successfully collides with a resource node, the game engine updates the active state variables, increments the global score tracking system, and uses a random coordinate allocation algorithm to relocate the node. Collecting 30 Gold triggers a difficulty scaling mechanic that increments the game level and boosts the speed variables of the chaser entity. If the chaser intercepts the player, a system fail-state is triggered, resetting the session metrics back to Level 1. The user interface features an advanced multi-layered Heads-Up Display (HUD) nested inside a translucent, styled container tray, showcasing a real-time sine-wave pulsing animation that visually scales the score metrics over running clock cycles.

### How to Play
* **Login Screen:** Type your player username using alphabetical keys and press **Enter** to initialize the game loop. Use **Backspace** to correct errors.
* **Move Up/Down/Left/Right:** Use the keyboard **Arrow Keys** (or **WASD**) to drive the blue player entity.
* **Objective:** Collect the gold squares while running away from the crimson enemy chaser block.
* **Leveling Up:** Every 30 Gold collected advances the game to the next **Level** and permanently speeds up the enemy chaser.
* **Fail State:** Getting caught by the crimson chaser resets your Level, current Gold, and Total Score back to baseline.
* **Exit the Game:** Press the **Escape (Esc)** key at any point to close the application session gracefully.

The purpose of developing this software is to engineering-test the end-to-end data pipelines involved in interactive keyboard text buffering, real-time bounding-box collision matrix mapping (`Rectangle.Intersects`), and AI pathfinding trajectories. Building this application provides practical mastery over the continuous execution lifecycle—specifically balancing deterministic input state validation with hardware-independent frame rendering updates via game delta time tracking.

[Software Demo Video](http://youtube.link.goes.here)

# Development Environment

The software was architected and compiled inside a cross-platform workspace leveraging the following engineering tools:
* **Visual Studio Code (VS Code):** Used as the primary Integrated Development Environment (IDE) for structural codebase management.
* **C# Dev Kit (Microsoft):** Leveraged for deep solution exploring, language syntax evaluation, and compilation tasks.
* **MonoGame for VS Code & Content Builder Extensions:** Utilized to bridge framework compilation targets and orchestrate pipeline compilation assets.
* **Git & GitHub:** Integrated for local version control tracking and remote distribution management.

### Programming Languages & Libraries
* **C# (.NET 8.0 SDK):** The primary structural programming language utilized for object-oriented logic implementation.
* **MonoGame Framework (DesktopGL Core):** An open-source, low-level framework used to handle graphical hardware acceleration, input hardware pooling, window lifecycles, and core rendering pipelines.

# Useful Websites

* [Official MonoGame Documentation](https://docs.monogame.net/)
* [Microsoft Learn: C# Guide](https://learn.microsoft.com/en-us/dotnet/csharp/)
* [RB Whitaker's MonoGame Tutorials](http://monogame.net/documentation/?page=Tutorials)

# Future Work

* **Item 1:** Upgrade the basic linear tracking vector of the enemy to an advanced grid-based pathfinding system (such as an A* Algorithm) to safely handle obstacle and wall navigation.
* **Item 2:** Migrate from pure programmatic texture rendering to loading custom sprite sheets and custom pixel-art texture animations via the MonoGame Content Pipeline.
* **Item 3:** Introduce a localized SQLite data-persistence layer or local JSON file storage mechanism to save and track the player's lifetime highest score records across execution sessions.
