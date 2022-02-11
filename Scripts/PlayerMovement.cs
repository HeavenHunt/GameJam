using Godot;
using System;

public class PlayerMovement : RigidBody2D
{
	[Export] public int speed = 200;
	[Export] public float health = 5.0f;
	[Signal] protected delegate void PlayerDeath();
	public Vector2 newVelocity = new Vector2();
	public bool isPaused = false;
	public AnimatedSprite PlayerSprite;
	private bool PlayerHurtFinished = false;
	private bool bulletFired = true;
	private void _on_EnemyBody_PlayerDamaged(float DamageTaken)
	{
		PlayerSprite.Play("Hurt Anim");
		health -= DamageTaken;
		GD.Print("Damage Taken Successfully");
	}

	private void _on_AnimatedSprite_animation_finished()
	{
		if (PlayerSprite.Animation == "Hurt Anim")
		{
			PlayerSprite.Play("default");
		}
	}

	// Scene Variables
	PackedScene bulletScene;
	Control DeathMenu;

	public override void _Ready()
	{
		PlayerSprite = GetNode<AnimatedSprite>("AnimatedSprite");
		bulletScene = GD.Load<PackedScene>("res://Scenes/Bullet.tscn");
		DeathMenu = GetNode<Control>("/root/World/Death/Control");
		Connect("PlayerDeath", DeathMenu, "PlayerDeath");
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
			health = 5.0f;
		}
		else {
			GetInput();
			this.LinearVelocity = newVelocity;
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
			}
		}
	}
}


