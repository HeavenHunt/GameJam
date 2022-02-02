using Godot;
using System;

public class Enemy : RigidBody2D
{
	public float MovementSpeed = 1.0f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		LinearVelocity = GetLocalMousePosition();
		Position += LinearVelocity.Clamped(100.0f) * delta * MovementSpeed;
	}

}
