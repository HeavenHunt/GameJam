using Godot;
using System;

public class MonsterBullet : Node2D
{
	public float Range = 300;
	protected float distanceTravelled = 0;
	protected Sprite sprite;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if(GetParent().Name == "BossBody")
		{
			sprite.Texture = GD.Load<Texture>("res://Images/EatYourHeartOutSephiroth4x.png");
		}
		var area = GetNode<Area2D>("MonsterBulletArea2D");
		area.Connect("area_entered", this, "OnCollision");
		area.Connect("body_entered", this, "OnCollision");
	}

	protected void OnCollision(Node with)
	{
		if (with.Name != "EnemyBody" && with.Name != "BulletArea2D" && with.Name != "DetectionArea" && with.Name != "HitBox" && with.Name!= "BossBody")
		{
			GD.Print(with.Name);
			if (with.Name == "PlayerBody")
			{
				QueueFree();
			}

		}
	}
	public override void _Process(float delta)
	{
		
		float speed = 500;
		float moveAmount = speed * delta;
		Position += Transform.x.Normalized() * moveAmount;
		distanceTravelled += moveAmount;
		if (distanceTravelled > Range)
		{
			QueueFree();
		}
	}
}
