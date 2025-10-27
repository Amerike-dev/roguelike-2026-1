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

  class Collectable {
    + string name
    + float boost
  }

  class CatfishOil {

  }

  class TunaFlakes {

  }

  class TroutFin {

  }

  class Remoras {

  }

  Collectable <|-- CatfishOil
  Collectable <|-- TunaFlakes
  Collectable <|-- TroutFin
  Collectable <|-- Remoras

  class Weapon {
    - Weapons scriptable
    + getName string
    + Weapon(Weapons scriptable)
    + virtual UseWeapon()

  }

  class WeaponType {
    <<enum>>
    Range
    MidRange
    Melee
    Special
  }

  Weapons *-- WeaponType : utiliza

  class ArticSlap {

  }

  class OneLumaFork {

  }

  class Guerrilla {

  }

  class GoldenClaw {

  }

  class FeatherOfFreedom {

  }

  class PenguinClap {

  }

  Weapon <|-- ArticSlap
  Weapon <|-- OneLumaFork
  Weapon <|-- Guerrilla
  Weapon <|-- GoldenClaw
  Weapon <|-- FeatherOfFreedom
  Weapon <|-- PenguinClap

  Class Weapons : ScriptableObject{
    + string weaponName
    + int cooldown
    + int damage
    + int range
    + int damp
    + WeaponType weaponType
  
  }
