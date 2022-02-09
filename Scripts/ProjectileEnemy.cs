using Godot;
using System;

public class ProjectileEnemy : BaseEnemy
{
	PackedScene MonsterBulletScene;
	
	public override void _Ready()
	{
		
		base._Ready();
		MonsterBulletScene = GD.Load<PackedScene>("res://Scenes/MonsterBullet.tscn");
		AttackCooldown = GetNode<Timer>("/root/World/ProjectileEnemy/EnemyBody/AttackTimer");
	}


	public override void _PhysicsProcess(float delta)
	{
		base._PhysicsProcess(delta);
		while (AttackReady == true && InAttackRange == true)
		{
			//Fires bullet at player while they are within range and attack is off of cooldown
			AttackPlayer();

		}
		if (PlayerFound == true && InAttackRange == false)
		{
			LinearVelocity = Player.Position - this.Position;
			Position += LinearVelocity.Clamped(5.0f) * delta * MovementSpeed;
			this.LookAt(Player.Position);
			
		}
		// Larger Detection Bubble that has maximum sight distance
		// when slime gets within a certain range of player, it will begin firing at them
		// it will retreat if the player gets too close, but it will continue firing as long as the player is within line of sight
	}
	protected override void _on_EnemyBody_body_entered(Node body)
	{
		
	}

	protected override void _on_EnemyBody_body_exited(Node body)
	{

	}

	protected override void AttackPlayer()
	{
		//EmitSignal(nameof(PlayerDamaged), AttackPower);
		//GD.Print("Health Reduced");
		//AttackCooldown.Start(TimeBetweenAttacks);
		//AttackReady = false;
		MonsterBullet monsterbullet = (MonsterBullet)MonsterBulletScene.Instance();
		monsterbullet.Position = Position;
		monsterbullet.Rotation = Rotation;
		GetParent().AddChild(monsterbullet);
		//base.AttackPlayer();
	}
	
	protected override void _on_Timer_timeout()
	{
		AttackReady = true;
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
