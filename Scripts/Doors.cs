using Godot;
using System;

public class Doors : Area2D
{
	bool doorClosed = true;
	Area2D SpawnBox;
	CollisionShape2D SpawnCollider;
	PackedScene MeleeEnemy, ProjectileEnemy, BossEnemy, GreenKey, RedKey, TealKey, VioletKey, YellowKey;
	RandomNumberGenerator rng = new RandomNumberGenerator();
	Node KeyHolder;
	string doorColor = "";

	public override void _Ready()
	{
		MeleeEnemy = GD.Load<PackedScene>("res://Scenes/MeleeEnemy.tscn");
		ProjectileEnemy = GD.Load<PackedScene>("res://Scenes/ProjectileEnemy.tscn");
		BossEnemy = GD.Load<PackedScene>("res://Scenes/Boss.tscn");
		GreenKey = GD.Load<PackedScene>("res://Scenes/Keys/Key_Green.tscn");
		RedKey = GD.Load<PackedScene>("res://Scenes/Keys/Key_Red.tscn");
		TealKey = GD.Load<PackedScene>("res://Scenes/Keys/Key_Teal.tscn");
		VioletKey = GD.Load<PackedScene>("res://Scenes/Keys/Key_Violet.tscn");
		YellowKey = GD.Load<PackedScene>("res://Scenes/Keys/Key_Yellow.tscn");
		KeyHolder = GetNode("/root/World/Keys");
		setDoorColor();
	}
	protected void _on_Area2D_body_entered(PhysicsBody2D body) {
		if (body.Name.Contains("Player")) {
			switch (doorColor) {
			case "Blue":
				if (Player_Manager.BlueKey && doorClosed) {
					GetNode<AnimatedSprite>("/root/World/Map/Map/Blue").Play();
					GetNode<StaticBody2D>("/root/World/Map/Map/Blue/StaticBody2D").QueueFree();
					GetNode<Area2D>("/root/World/Map/Map/Blue/Area2D").QueueFree();
					doorClosed = false;
					CallDeferred("spawnMeleeEnemies", 5);
					CallDeferred("spawnKey");
				}
				break;
			case "Green":
				if (Player_Manager.GreenKey && doorClosed) {
					GetNode<AnimatedSprite>("/root/World/Map/Map/Green").Play();
					GetNode<StaticBody2D>("/root/World/Map/Map/Green/StaticBody2D").QueueFree();
					GetNode<Area2D>("/root/World/Map/Map/Green/Area2D").QueueFree();
					doorClosed = false;
					CallDeferred("spawnMeleeEnemies", 3);
					CallDeferred("spawnProjectileEnemies", 3);
					CallDeferred("spawnKey");
				}
				break;
			case "Red":
				if (Player_Manager.RedKey && doorClosed) {
					GetNode<AnimatedSprite>("/root/World/Map/Map/Red").Play();
					GetNode<StaticBody2D>("/root/World/Map/Map/Red/StaticBody2D").QueueFree();
					GetNode<Area2D>("/root/World/Map/Map/Red/Area2D").QueueFree();
					doorClosed = false;
					CallDeferred("spawnMeleeEnemies", 4);
					CallDeferred("spawnKey");
				}
				break;
			case "Teal":
				if (Player_Manager.TealKey && doorClosed) {
					GetNode<AnimatedSprite>("/root/World/Map/Map/Teal").Play();
					GetNode<StaticBody2D>("/root/World/Map/Map/Teal/StaticBody2D").QueueFree();
					GetNode<Area2D>("/root/World/Map/Map/Teal/Area2D").QueueFree();
					doorClosed = false;
					CallDeferred("spawnMeleeEnemies", 6);
					CallDeferred("spawnProjectileEnemies", 6);
					CallDeferred("spawnKey");
				}
				break;
			case "Violet":
				if (Player_Manager.VioletKey && doorClosed) {
					GetNode<AnimatedSprite>("/root/World/Map/Map/Violet").Play();
					GetNode<StaticBody2D>("/root/World/Map/Map/Violet/StaticBody2D").QueueFree();
					GetNode<Area2D>("/root/World/Map/Map/Violet/Area2D").QueueFree();
					doorClosed = false;
					CallDeferred("spawnBoss");
				}
				break;
			case "Yellow":
				if (Player_Manager.YellowKey && doorClosed) {
					GetNode<AnimatedSprite>("/root/World/Map/Map/Yellow").Play();
					GetNode<StaticBody2D>("/root/World/Map/Map/Yellow/StaticBody2D").QueueFree();
					GetNode<Area2D>("/root/World/Map/Map/Yellow/Area2D").QueueFree();
					doorClosed = false;
					CallDeferred("spawnMeleeEnemies", 4);
					CallDeferred("spawnKey");
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
		Vector2 centerPos = SpawnCollider.Position + SpawnBox.Position;
		RectangleShape2D rectangle = (RectangleShape2D)SpawnCollider.Shape;
		Vector2 size = rectangle.Extents;
		Vector2 positionInArea = new Vector2((rng.Randi() % size.x) - (size.x/2) + centerPos.x, (rng.Randi() % size.y) - (size.y/2) + centerPos.y);
		Node spawn = BossEnemy.Instance();
		spawn.GetNode<RigidBody2D>("EnemyBody").Position = positionInArea;
		SpawnBox.AddChild(spawn);
	}

	private void spawnKey() {
		RigidBody2D Key;
		if (doorColor == "Blue") {
			Key = (RigidBody2D)GreenKey.Instance();
			Key.Position = new Vector2(1100, 400);
			KeyHolder.AddChild(Key);
		}
		if (doorColor == "Green") {
			Key = (RigidBody2D)YellowKey.Instance();
			Key.Position = new Vector2(1500, -350);
			KeyHolder.AddChild(Key);
		}
		if (doorColor == "Yellow") {
			Key = (RigidBody2D)RedKey.Instance();
			Key.Position = new Vector2(1400, 800);
			KeyHolder.AddChild(Key);
		}
		if (doorColor == "Red") {
			Key = (RigidBody2D)TealKey.Instance();
			Key.Position = new Vector2(750, -200);
			KeyHolder.AddChild(Key);
		}
		if (doorColor == "Teal") {
			Key = (RigidBody2D)VioletKey.Instance();
			Key.Position = new Vector2(3600, 300);
			KeyHolder.AddChild(Key);
		}
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
