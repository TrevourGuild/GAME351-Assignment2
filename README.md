# GAME351-Assignment2

## Project Overview

This project was created in Unity as part of Game 351 Assignment 2. The goal of the project was to create a futuristic racing game called F-Zero: Cross-Country, showcasing scripting, camera knowledge, framerate independance, and basic audio/particle systems.

The environment includes:
- A terrain with hills and texturing
- A hovercraft with a follow camera
- Three different options for the hovercraft with varying abilities
- The ability to toggle between different hovercraft versions using number keys (1, 2, and 3) and the "C" key.
- The ability to add lasers to a vehicle, with one vehicle ready to fire them
- Realistic audio and bloom efects for the vehicles. 

---

# Implemented Features

## Driving A Hovercraft
- "A", "D" keys turn the hovercraft
- "W", "S" keys accelerate the hovercraft
- Tilting code to guide the hovercraft along the terrain
- Third person height locked camera system with Cinemachine, with integrated camera switching
- 

## Three Car Types
- Three different hovercraft that are visually distinct
- Each hovercraft has different stats (speed, cornering ability, etc)
- Framerate independance
- Ability for programmers to modify the hovercraft rates in the inspector

## Hovercraft Levitation
- Levitation code for the hovercraft including tilting code for hills
- An idle animation (not using the animation systems) to simulate the engine running

## Toggling Between Cars
- Player has the ability to cycle between cars with the "C" key
- A camera system with integrated cinemachine virtual cameras to keep the active car in the center of the screen
- Cycling through the cars loops through the car list

---

# Choice Components Implemented

The following optional/creative components were implemented:

- Laser-Firing Car: Hovercraft #1 (the starting hovercraft and accessible through pressing "1" or cycling with "C") can fire lasers when the spacebar is pressed.
- Laser bolts are spawned and destroyed dynamically

- More realistic Effects: Hovercraft engine sounds that change pitch dependent on vehicle speed
- Emission effects to make the hovercraft engine and tron-like features glow.

---

# Assets Used

The following assets/packages were used in this project:

| Asset Folder | Purpose |
|---|---|
| `Hovercraft_Engine_Sound` | Add sound to the engine that can be pitched up and down |
| `HoverCraft` | Meshes and collisions for the hovercrafts |
| `field sounds` | Ambient background |
| `Land Speeder` | Additional hovercraft sounds |

---

# Controls

| Key | Action |
|---|---|
| WASD | Move Hovercraft | Rotate Hovercraft |
| "1", "2", "3" | Select a specific hovercraft |
| "C" | Cycle through hovercraft options |
| "spacebar" | Shoot Lazer |

---

# Installation Procedure

1. Clone or download the project repository from GitHub.

2. Alternatively, click the **Download ZIP** option from the GitHub repository page.

3. Extract the ZIP folder if downloaded as a ZIP file.

4. Open Unity Hub.

5. Add the project folder to Unity Hub.

6. Open the project using Unity version:

```text
Unity 2021.3.5f1
```

7. Open the main scene located at:

```text
Assets/Scenes/Cross Country Scene
```

8. Press the Play button in the Unity Editor to run the project.

---

# Rendering Pipeline

This project uses Unity's:

## Built-in Render Pipeline

The Built-in Render Pipeline was used for rendering, lighting, and materials throughout the environment.

---

# Additions

The following additions were made beyond the base requirements:

- A dynamic cinemachine camera system
- 1, 2, 3 keys selecting specific vehicles
- Basic post processing  

---

# Omissions

The following features were simplified or omitted:

- Lasers were simplified to particles instead of cylinders 

---

# Known Issues / Errata

- Idle animation may play if speed is not fast enough and hovercraft is over flat ground

---

# Unity Version

Developed using:

```text
Unity 2021.3.5f1
```

---

# Authors

- Joshua Page
- Trevour Soldner Guild
- Nathan Nieto

University of Arizona  
Game 351
