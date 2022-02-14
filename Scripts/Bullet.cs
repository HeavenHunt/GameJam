using Godot;
using System;

public class Bullet : Node2D
{
	public float Range = 300;
	protected float distanceTravelled = 0;

	public override void _Ready()
	{
		var area = GetNode<Area2D>("BulletArea2D");
		area.Connect("area_entered", this, "OnCollision");
		area.Connect("body_entered", this, "OnCollision");
	}

	public override void _Process(float delta)
	{
		float speed = 650;
		float moveAmount = speed * delta;
		Position += Transform.x.Normalized() * moveAmount;
		distanceTravelled += moveAmount;
		if (distanceTravelled > Range) {
			QueueFree();
		}
	}

	protected void OnCollision(Node with) {

		if (with.Name != "PlayerBody" && with.Name != "BulletArea2D" && with.Name != "DetectionArea") {
			GD.Print(with.Name);
			if(with.Name == "HitBox")
			{
				QueueFree();
			}
		}
	}
}
