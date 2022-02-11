using Godot;
using System;

public class ProjectileEnemy : BaseEnemy
{
	PackedScene MonsterBulletScene;
	
	public override void _Ready()
	{
		
		base._Ready();
		MonsterBulletScene = GD.Load<PackedScene>("res://Scenes/MonsterBullet.tscn");
		
	}


	public override void _PhysicsProcess(float delta)
	{
		base._PhysicsProcess(delta);
		if (AnimSprite.Animation == "default")
		{
			if (AttackReady && PlayerFound)
			{
				//Fires bullet at player while they are within range and attack is off of cooldown
				AttackPlayer();
				this.LookAt(Player.Position);
			}
			else if (PlayerFound)
			{
				LinearVelocity = Player.Position - this.Position;
				Position += LinearVelocity.Clamped(5.0f) * delta * MovementSpeed;
				this.LookAt(Player.Position);

			}
			// Larger Detection Bubble that has maximum sight distance
			// when slime gets within a certain range of player, it will begin firing at them
			// it will retreat if the player gets too close, but it will continue firing as long as the player is within line of sight
		}
	}
	protected override void _on_EnemyBody_body_entered(Node body)
	{
		
	}

	protected override void _on_EnemyBody_body_exited(Node body)
	{

	}

	protected override void AttackPlayer()
	{
		MonsterBullet monsterbullet = (MonsterBullet)MonsterBulletScene.Instance();
		monsterbullet.Position = this.Position;
		monsterbullet.Rotation = this.Rotation;
		GetParent().AddChild(monsterbullet);
		AttackCooldown.Start(TimeBetweenAttacks);
		AttackReady = false;
		//EmitSignal(nameof(PlayerDamaged), AttackPower);
	}

	protected override void _on_Timer_timeout()
	{
		AttackReady = true;
		GD.Print("Timer Elapsed");
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
