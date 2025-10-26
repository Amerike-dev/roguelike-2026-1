classDiagram
class MapComponent {
+Generate() void
+Display() void
}

    class MapComposite {
        -List<MapComponent> _children
        +Add(MapComponent) void
        +Remove(MapComponent) void
        +Generate() void
        +Display() void
    }

    class Map {
        -string name
        -Vector2Int size
        +Generate() void
        +Display() void
        +GetRoomByType(RoomType): Room
    }

    class MapController {
        -Map currentMap
        +GenerateDungeon() void
        +ResetDungeon() void
        +LoadRoom(Room) void
        +GetAvailableRoomTypes(): List<RoomType>
    }

    class Room {
        -string name
        -RoomType type
        -float probability
        -int maxAppearances
        -int enemyCount
        -Vector2Int size
        +Generate() void
        +Display() void
    }

    class Enemy {
        -string name
        -int health
        -RoomType area
        +Spawn(Vector3) void
    }

    class Item {
        -string name
        -string effect
        +Spawn(Vector3) void
    }

    %% Relations
    MapComponent <|-- MapComposite
    MapComposite <|-- Map
    MapComponent <|-- Room
    MapController --> Map
    Room --> Enemy
    Room --> Item
