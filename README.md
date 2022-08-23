# EcsLiteDoors

The test task was performed according to [these](https://docs.google.com/document/d/1huX_UQjfb0f4OxgBPL4UXwpWuFNWQexld0mJrop7N8M/edit) requirements. Total time spent 22 hours.

## Server-side systems

Systems to be run on a server-side (as well as client-side):
- Initialiation:
  - `InitButtonsAndDoorsSystem`
  - `InitPlayerSystem`
- Update logic
  - `MoveSystem`
  - `CircleCollisionsSystem`  
  - `OpenDoorSystem`

__NOTE:__ The simulation on the server's side requires some input, that is currently implemented only for the client side.


## Client-side systems

Systems that directly or indirectly depends on Unity (client-side use only). 
- Initialization. Applies changes from the ECS to the Unity game objects hierarchy:
  - `InitButtonAndDoorViewsSystem`
  - `InitPlayerViewSystem`
- Input. Gets input from Unity:
  - `InputSystem`
- Updates. Applies changes from the ECS to the Unity game objects hierarchy:
  - `UnityApplyDoorSystem`
  - `UnityApplyTransformSystem`

## Components

- Server required (core logic simulation):
  - `Button`
  - `CircleCollider`
  - `Collision`
  - `Door`
  - `Movable`
  - `MoveCommand`
  - `Transform2D`
- May be placed on a server (doesn't depends on Unity), but doesn't required for logic simulation:
  - `PlayerInputConsumer`
  - `Colorized`
  - `Name`
- Unity mediator:
  - `ViewWrapper`
