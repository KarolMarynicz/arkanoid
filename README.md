# Arkanoid
Simple implementation of well known game "Arkanoid". Made with Unity 2019.3.14f.

### Project Structure

- Assets
  - **Game** (assets for global use across all scenes)
  - **Gameplay** (assets for gameplay scene)
    - **Resources** (folder for sprites, prefabs, materials)
    - **Scripts** (folder for scripts used in Gameplay Scene)
      - **Board** (folder for scripts used to create game board)
      - **Pause** (folder for scripts used to create pause and pause menu during gameplay)
      - **Save** (folder for scripts used to create save system)
  - **Menu** (assets for Main Menu scene)
    - **Scripts** (folder for scripts used in Menu Scene)
  - **Result** (assets for Result scene)
    - **Scripts** (folder for scripts used in Result Scene)
  
Each script has been set in C# namespace coresponding to it's place in project structure.

### Features

- **Basic gameplay of "Arkanoid" game** - one paddle, one ball and set of boxes to destroy with ball.
- **Save system** - you can find save button after ESC click during Gameplay (file in json format).
- **Multiply controls** - you can control your paddle using WASD/Arrows or with your mouse.
