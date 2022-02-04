using Godot;
using System;

public class BaseEnemy : RigidBody2D
{
	public RigidBody2D Player;
	//public int Health;
	[Export] public float AttackPower = 1.0f;
	[Export] public float MovementSpeed = 1.0f;
	public bool PlayerFound = false;
	public bool InAttackRange = false;
	public Timer AttackCooldown;
	public bool AttackReady = true;
	[Export] public float TimeBetweenAttacks = 0.5f;
	[Signal] protected delegate void PlayerDamaged(float DamageTaken);
	protected void _on_EnemyBody_body_entered(object body)
	{
		if (body == Player)
		{
			GD.Print("Attack Distance Reached");
			InAttackRange = true;
		}

	}

	protected void _on_EnemyBody_body_exited(object body)
	{
		if (body == Player)
		{
			InAttackRange = false;
		}
	}

	protected virtual void AttackPlayer() { }
	protected void _on_Timer_timeout()
	{
		AttackReady = true;
	}
	protected void _on_DetectionArea_body_entered(object body)
	{
		if (body == Player) ;
		{
			PlayerFound = true;
		}
		GD.Print(body.ToString());
	}
	protected void _on_DetectionArea_body_exited(object body)
	{
		GD.Print("Got Away");
		PlayerFound = false;
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Player = GetNode<RigidBody2D>("/root/World/Player/PlayerBody");
		GD.Print(Player.ToString());
	}

	// called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(float delta){ }
}



