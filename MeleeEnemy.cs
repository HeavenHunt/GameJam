using Godot;
using System;

public class MeleeEnemy : BaseEnemy
{
	private void _on_EnemyBody_body_entered(object body)
	{
		if (body == Player)
		{
			GD.Print("Attack Distance Reached");
			InAttackRange = true;
		}

	}

	private void _on_EnemyBody_body_exited(object body)
	{
		if (body == Player)
		{
			InAttackRange = false;
		}
	}

	protected override void AttackPlayer()
	{
		EmitSignal(nameof(PlayerDamaged), AttackPower);
		GD.Print("Health Reduced");
		AttackCooldown.Start(TimeBetweenAttacks);
		AttackReady = false;
	}
	private void _on_Timer_timeout()
	{
		AttackReady = true;
	}
	private void _on_DetectionArea_body_entered(object body)
	{
		if (body == Player) ;
		{
			PlayerFound = true;
		}
		GD.Print(body.ToString());
	}
	private void _on_DetectionArea_body_exited(object body)
	{
		GD.Print("Got Away");
		PlayerFound = false;
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		AttackCooldown = GetNode<Timer>("/root/World/MeleeEnemy/EnemyBody/AttackTimer");
	}

	// called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(float delta)
	{
		while (AttackReady == true && InAttackRange == true)
		{
			AttackPlayer();
		}
		if (PlayerFound == true)
		{
			this.LookAt(Player.Position);
			LinearVelocity = Player.Position - this.Position;
		}
		else
		{
			//replace with patrol/idle code
			//this.LookAt(GetLocalMousePosition());
			LookAt(GetGlobalMousePosition());
			Position += LinearVelocity.Clamped(100.0f) * delta * MovementSpeed;
		}
	}
}
