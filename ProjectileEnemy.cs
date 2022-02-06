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
		base._Ready();
		if(Player == null)
		{
			Player = GetNode<RigidBody2D>("/root/World/Player/PlayerBody");
		}
		//SightLine = GetNode<RayCast2D>("/root/World/ProjectileEnemy/EnemyBody/RayCast2D");
		AttackCooldown = GetNode<Timer>("/root/World/ProjectileEnemy/EnemyBody/AttackTimer");
		
	}

  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(float delta)
	{
		
		// Raycast pointed toward player, if it reaches the player without hitting anything
		// Larger Detection Bubble that has maximum sight distance
		// when slime gets within a certain range of player, it will begin firing at them
		// it will retreat if the player gets too close, but it will continue firing as long as the player is within line of sight
	}
	protected override void _on_EnemyBody_body_entered(object body)
	{
		//base._on_EnemyBody_body_entered(body);
	}

	protected override void _on_EnemyBody_body_exited(object body)
	{
		//base._on_EnemyBody_body_exited(body);
	}

	protected override void AttackPlayer()
	{
		if(InAttackRange == true)
		{

		}
		//base.AttackPlayer();
	}

	protected override void _on_Timer_timeout()
	{
		//base._on_Timer_timeout();
	}

	protected override void _on_DetectionArea_body_entered(object body)
	{
		base._on_DetectionArea_body_entered(body);
	}

	protected override void _on_DetectionArea_body_exited(object body)
	{
		base._on_DetectionArea_body_exited(body);
	}
}
