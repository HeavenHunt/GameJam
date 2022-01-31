using Godot;
using System;

public class BaseEnemy : RigidBody2D
{
	public int Health;
	public float AttackPower;
	public float AttackSpeed;
	public float MovementSpeed = 1.0f;
	public Navigation2D navigation2D;
	public Node2D[] NavPoint;
	public Vector2[] path;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		LinearVelocity = GetLocalMousePosition();
		Position += LinearVelocity.Clamped(100.0f) * delta * MovementSpeed;

		//path = navigation2D.GetSimplePath(NavPoint[0].Position, NavPoint[1].Position, true);
		//this.LinearVelocity = path[0];

	}
}
