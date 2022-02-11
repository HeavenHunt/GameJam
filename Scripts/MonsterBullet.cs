using Godot;
using System;

public class MonsterBullet : Bullet
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var area = GetNode<Area2D>("MonsterBulletArea2D");
		area.Connect("area_entered", this, "OnCollision");
		area.Connect("body_entered", this, "OnCollision");
	}

	new protected void OnCollision(Node with)
	{
		if (with.Name != "EnemyBody" && with.Name != "BulletArea2D" && with.Name != "DetectionArea" && with.Name != "HitBox")
		{
			GD.Print(with.Name);
			if (with.Name == "PlayerBody")
			{
				QueueFree();
			}

		}
	}
	//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	//  public override void _Process(float delta)
	//  {
	//      
	//  }
}
