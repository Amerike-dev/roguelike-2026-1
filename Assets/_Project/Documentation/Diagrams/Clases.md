classDiagram
  class Player {
    + float baseSpeed
    + float humidity
    + enum playerCondition { Normal, Disness, Poison }
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