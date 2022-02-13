using Godot;
using System;

public class PlayerMovement : RigidBody2D
{
	[Export] public int speed = 200;
	[Export] public float health = 5.0f;
	[Signal] protected delegate void PlayerDeath();
	[Signal] public delegate void PlayerDamaged();
	public Vector2 newVelocity = new Vector2();
	public bool isPaused = false;
	public AnimatedSprite PlayerSprite;
	private AudioStreamPlayer2D combatAudioPlayer;
	private AudioStreamPlayer2D generalAudioPlayer;
	private bool PlayerHurtFinished = false;
	private void _on_EnemyBody_PlayerDamaged(float DamageTaken)
	{
		PlayerSprite.Play("Hurt Anim");
		health -= DamageTaken;
		//GD.Print("Damage Taken Successfully");
		EmitSignal("PlayerDamaged");
	}

	private void _on_AnimatedSprite_animation_finished()
	{
		if (PlayerSprite.Animation == "Hurt Anim")
		{
			if(this.LinearVelocity.Length()>= 20.0)
			{
				PlayerSprite.Play("walking");
			}
			else
				PlayerSprite.Play("default");
		}
	}

	// Scene Variables
	PackedScene bulletScene;
	Control DeathMenu;
	Node2D PlayerManager;

	public override void _Ready()
	{
		PlayerSprite = GetNode<AnimatedSprite>("AnimatedSprite");
		bulletScene = GD.Load<PackedScene>("res://Scenes/Bullet.tscn");
		DeathMenu = GetNode<Control>("/root/World/Death/Control");
		PlayerManager = GetParent<Node2D>();

		Connect("PlayerDeath", DeathMenu, "PlayerDeath");
		Connect("PlayerDamaged", PlayerManager, "_on_PlayerDamaged");
		var area = GetNode<Area2D>("PlayerHitBox");
		area.Connect("area_entered", this, "OnCollision");
		area.Connect("body_entered", this, "OnCollision");

		//audio
		combatAudioPlayer = GetNode<AudioStreamPlayer2D>("CombatAudioPlayer");
		generalAudioPlayer = GetParent().GetNode<AudioStreamPlayer2D>("GeneralAudioPlayer");
	}

	public void GetInput()
	{
		if (!isPaused) {
			LookAt(GetGlobalMousePosition());
			newVelocity = new Vector2();

			if (Input.IsActionPressed("right"))
				newVelocity.x += 1;

			if (Input.IsActionPressed("left"))
				newVelocity.x -= 1;

			if (Input.IsActionPressed("down"))
				newVelocity.y += 1;

			if (Input.IsActionPressed("up"))
				newVelocity.y -= 1;

			newVelocity = newVelocity.Normalized() * speed;
		}
	}

	public override void _PhysicsProcess(float delta)
	{
		if (health <= 0.0f)
		{
			EmitSignal(nameof(PlayerDeath));
		}
		else {
			GetInput();
			this.LinearVelocity = newVelocity;
			if (newVelocity.Length() >= 20.0)
			{
				PlayerSprite.Play("walking");
			}
			else
				PlayerSprite.Play("default");
		}
	}
	// Handles input, used to fire bullet when left mouse button is clicked
	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseEvent) {
			if (mouseEvent.ButtonIndex == (int)ButtonList.Left && mouseEvent.Pressed) {
				Bullet bullet = (Bullet)bulletScene.Instance();
				bullet.Position = Position;
				bullet.Rotation = Rotation;
				GetParent().AddChild(bullet);
				GetTree().SetInputAsHandled();

				//play audio
				combatAudioPlayer.Stream = GD.Load<AudioStream>("res://Audio/Shoot_SFX_1.wav");
				combatAudioPlayer.Play();
			}
		}
	}
	protected void OnCollision(Node with)
	{
		if(with.Name == "MonsterBulletArea2D")
		{
			GD.Print("Bullet hit");
			combatAudioPlayer.Stream = GD.Load<AudioStream>("res://Audio/Slime_Projectile.wav");
			combatAudioPlayer.Play();
			_on_EnemyBody_PlayerDamaged(1.0f);
		}

		if(with.IsInGroup("Door")){
			GD.Print("Door collided");
			generalAudioPlayer.Stream = GD.Load<AudioStream>("res://Audio/Door_SFX.wav");
			generalAudioPlayer.Play();
		}
	}
}








