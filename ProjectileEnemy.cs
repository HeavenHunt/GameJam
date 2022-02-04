using Godot;
using System;

public class ProjectileEnemy : BaseEnemy
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(float delta)
	{
		// Raycast pointed toward player, if it reaches the player without hitting anything
		// Larger Detection Bubble that has maximum sight distance
		// when slime gets within a certain range of player, it will begin firing at them
		// it will retreat if the player gets too close, but it will continue firing as long as the player is within line of sight
	}
}
