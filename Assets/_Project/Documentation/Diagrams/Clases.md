```mermaid
classDiagram
  class Player {
    + float baseSpeed
    + float humidity
    + PlayerCondition playerCondition
    + Weapon currentWeapon
    + bool invertInput
    + List<Collectable> collectables
    + float permanentCollectableSpeed
    + float bossWeaponSpeedModifier
    - Rigidbody2D rb
    
    + Player(Rigidbody2D rb, float baseSpeed = 5f, float humidity = 200f, PlayerCondition initialCondition = PlayerCondition.Normal, List<Collectable> initialCollectables = null)
    + PlayerMovement(float horizontalInput, float verticalInput)
    + float ChangeSpeed()
  }

  class PlayerCondition {
    <<enum>>
    Normal
    Dizzy
    Poison
  }

  Player *-- PlayerCondition : utiliza