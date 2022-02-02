using Godot;
using System;

public class PlayerMovement : RigidBody2D
{
	[Export] public int speed = 200;
	[Export] public float health = 5.0f;
	public Vector2 newVelocity = new Vector2();
	private void _on_EnemyBody_PlayerDamaged(float DamageTaken)
	{
		health -= DamageTaken;
		GD.Print("Damage Taken Successfully");
	}

	public void GetInput()
	{
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

	public override void _PhysicsProcess(float delta)
	{
		if (health <= 0.0f)
		{
			QueueFree();
		}
		GetInput();
		this.LinearVelocity = newVelocity;
	}
}

