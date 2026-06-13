# Overview

This project focuses on designing and implementing a real-time 2D game environment from scratch to master the core principles of event-driven programming, architectural game loops, and dynamic state management. As a software engineer, the goal is to deepen technical proficiency in structural C# design patterns, memory allocation optimization, and programmatic visual rendering pipelines while working with robust multi-platform frameworks.

The software is an arcade-style, top-down 2D resource gathering simulation. Players control a blue character entity navigating a structured grid landscape with the objective of securing gold resource ore nodes that spawn dynamically across random coordinates. When the player successfully collides with a node, the game logic instantly purges the resource from the active coordinate map, increments the player's secure inventory tracking state, and calculates a fresh, non-overlapping vector coordinate to deploy the next node. The user interface features an advanced Heads-Up Display (HUD) nested inside a translucent, styled container tray, showcasing a real-time sine-wave pulsing animation that visually scales the text over runtime intervals.

### How to Play
* **Move Up/Down/Left/Right:** Use the keyboard **Arrow Keys** (or **WASD**).
* **Objective:** Drive the blue player model directly into the gold squares to collect them.
* **Collect Resources:** Each successful collision adds +10 Gold to your active inventory.
* **Exit the Game:** Press the **Escape (Esc)** key at any point to close the application session gracefully.

The purpose of developing this software is to engineering-test the end-to-end data pipelines involved in interactive user-input processing and real-time bounding-box collision matrix mapping (`Rectangle.Intersects`). Building this application provides practical mastery over the continuous execution lifecycle—specifically balancing deterministic input updates with hardware-independent frame rendering updates via game delta time tracking.

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

* **Item 1:** Implement an autonomous enemy AI pathfinding system (such as an A* Algorithm) to chase the player and introduce a risk-management state loop.
* **Item 2:** Migrate from pure programmatic texture rendering to loading custom sprite sheets and custom pixel-art texture animations via the MonoGame Content Pipeline.
* **Item 3:** Introduce a localized SQLite data-persistence layer or local JSON file storage mechanism to save and track the player's lifetime highest score records across execution sessions.
