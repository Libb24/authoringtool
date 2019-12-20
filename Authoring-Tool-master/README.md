# Authoring-Tool Developing Branch

This branch is the main branch for development during summer 2019.

## Dev Env
- Unity 2018.4.2f1 LTS
  - VRTK 3.3.0
  - Oculus (Desktop) 1.36.0
  - Oculus (Android) 1.36.0
  - Windows Mixed Reality 1.0.11
  - SteamVR 1.2.3 (from github)
  - OpenVR 1.0.5
  - Package Manager UI 2.0.7
  - TextMesh Pro 1.4.1
  - Windows Mixed Reality 1.0.11
- Visual Studio 2019

## How this works (Currently)
- On startup, two menus are loaded. Currently only Menu1 is functional
- The script loader (loadObj) is set as inactive
- Menu1 enables the selection of various resources as evident from the respective scripts
- When an object (A button overlayed with texture/name) is clicked, it creates a gameobject from the prefabs along with a menu to set values
- Once save is clicked, it is outputted to the script inside the persistent data path
- When load is pressed, objLoader is set to active, Menus are destroyed and objects are loaded according to the script from the prefabs 
