using Godot;
using System;

public class Doors : Area2D
{
    bool doorClosed = true;
    Area2D SpawnBox;
    CollisionShape2D SpawnCollider;
    PackedScene MeleeEnemy, ProjectileEnemy;
    RandomNumberGenerator rng = new RandomNumberGenerator();
    string doorColor = "";

    public override void _Ready()
    {
        MeleeEnemy = GD.Load<PackedScene>("res://Scenes/MeleeEnemy.tscn");
        ProjectileEnemy = GD.Load<PackedScene>("res://Scenes/ProjectileEnemy.tscn");
        setDoorColor();
    }
    protected void _on_Area2D_body_entered(PhysicsBody2D body) {
        if (body.Name.Contains("Player")) {
            switch (doorColor) {
            case "Blue":
                if (Player_Manager.BlueKey && doorClosed) {
                    GetNode<AnimatedSprite>("/root/World/Map/Map/Blue").Play();
                    GetNode<StaticBody2D>("/root/World/Map/Map/Blue/StaticBody2D").QueueFree();
                    doorClosed = false;
                    CallDeferred("spawnMeleeEnemies", 5);
                }
                break;
            case "Green":
                if (Player_Manager.GreenKey && doorClosed) {
                    GetNode<AnimatedSprite>("/root/World/Map/Map/Green").Play();
                    GetNode<StaticBody2D>("/root/World/Map/Map/Green/StaticBody2D").QueueFree();
                    doorClosed = false;
                    CallDeferred("spawnMeleeEnemies", 3);
                    CallDeferred("spawnProjectileEnemies", 3);
                }
                break;
            case "Red":
                if (Player_Manager.RedKey && doorClosed) {
                    GetNode<AnimatedSprite>("/root/World/Map/Map/Red").Play();
                    GetNode<StaticBody2D>("/root/World/Map/Map/Red/StaticBody2D").QueueFree();
                    doorClosed = false;
                    CallDeferred("spawnMeleeEnemies", 4);
                }
                break;
            case "Teal":
                if (Player_Manager.TealKey && doorClosed) {
                    GetNode<AnimatedSprite>("/root/World/Map/Map/Teal").Play();
                    GetNode<StaticBody2D>("/root/World/Map/Map/Teal/StaticBody2D").QueueFree();
                    doorClosed = false;
                    CallDeferred("spawnMeleeEnemies", 6);
                    CallDeferred("spawnProjectileEnemies", 6);
                }
                break;
            case "Violet":
                if (Player_Manager.VioletKey && doorClosed) {
                    GetNode<AnimatedSprite>("/root/World/Map/Map/Violet").Play();
                    GetNode<StaticBody2D>("/root/World/Map/Map/Violet/StaticBody2D").QueueFree();
                    doorClosed = false;
                    spawnBoss();
                }
                break;
            case "Yellow":
                if (Player_Manager.YellowKey && doorClosed) {
                    GetNode<AnimatedSprite>("/root/World/Map/Map/Yellow").Play();
                    GetNode<StaticBody2D>("/root/World/Map/Map/Yellow/StaticBody2D").QueueFree();
                    doorClosed = false;
                    CallDeferred("spawnMeleeEnemies", 4);
                }
                break;
        }
        }
    }

    private void spawnMeleeEnemies(int numEnemies) {
        // Get Center of Collider
        Vector2 centerPos = SpawnCollider.Position + SpawnBox.Position;
        RectangleShape2D rectangle = (RectangleShape2D)SpawnCollider.Shape;
        Vector2 size = rectangle.Extents;

        for (int i = 0; i < numEnemies; i++) {
            Vector2 positionInArea = new Vector2((rng.Randi() % size.x) - (size.x/2) + centerPos.x, (rng.Randi() % size.y) - (size.y/2) + centerPos.y);
            Node spawn = MeleeEnemy.Instance();
            spawn.GetNode<RigidBody2D>("EnemyBody").Position = positionInArea;
            SpawnBox.AddChild(spawn);
        }
    }

    private void spawnProjectileEnemies(int numEnemies) {
        // Get Center of Collider
        Vector2 centerPos = SpawnCollider.Position + SpawnBox.Position;
        RectangleShape2D rectangle = (RectangleShape2D)SpawnCollider.Shape;
        Vector2 size = rectangle.Extents;

        for (int i = 0; i < numEnemies; i++) {
            Vector2 positionInArea = new Vector2((rng.Randi() % size.x) - (size.x/2) + centerPos.x, (rng.Randi() % size.y) - (size.y/2) + centerPos.y);
            Node spawn = ProjectileEnemy.Instance();
            spawn.GetNode<RigidBody2D>("EnemyBody").Position = positionInArea;
            SpawnBox.AddChild(spawn);
        }
    }

    private void spawnBoss() {

    }

    private void setDoorColor() {
        string spawnNodePath = "";
        string spawnColliderNodePath = "";

        if (this.GetParent().Name.Contains("Blue")) {
            doorColor = "Blue";
            spawnNodePath = "/root/World/Spawners/Blue/SpawnBox";
            spawnColliderNodePath = "/root/World/Spawners/Blue/SpawnBox/SpawnArea";
        }
        else if (this.GetParent().Name.Contains("Green")) {
            doorColor = "Green";
            spawnNodePath = "/root/World/Spawners/Green/SpawnBox";
            spawnColliderNodePath = "/root/World/Spawners/Green/SpawnBox/SpawnArea";
        }
        else if (this.GetParent().Name.Contains("Red")) {
            doorColor = "Red";
            spawnNodePath = "/root/World/Spawners/Red/SpawnBox";
            spawnColliderNodePath = "/root/World/Spawners/Red/SpawnBox/SpawnArea";
        }
        else if (this.GetParent().Name.Contains("Teal")) {
            doorColor = "Teal";
            spawnNodePath = "/root/World/Spawners/Teal/SpawnBox";
            spawnColliderNodePath = "/root/World/Spawners/Teal/SpawnBox/SpawnArea";
        }
        else if (this.GetParent().Name.Contains("Violet")) {
            doorColor = "Violet";
            spawnNodePath = "/root/World/Spawners/Violet/SpawnBox";
            spawnColliderNodePath = "/root/World/Spawners/Violet/SpawnBox/SpawnArea";
        }
        else if (this.GetParent().Name.Contains("Yellow")) {
            doorColor = "Yellow";
            spawnNodePath = "/root/World/Spawners/Yellow/SpawnBox";
            spawnColliderNodePath = "/root/World/Spawners/Yellow/SpawnBox/SpawnArea";
        }
        GD.Print(doorColor);
        
        SpawnBox = GetNode<Area2D>(spawnNodePath);
        SpawnCollider = GetNode<CollisionShape2D>(spawnColliderNodePath);
    }
}
