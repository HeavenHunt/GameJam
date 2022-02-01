using Godot;
using System;

public class BaseEnemy : RigidBody2D
{
	[Export] public RigidBody2D Player;
	public int Health;
	public float AttackPower;
	public float AttackSpeed;
	public float MovementSpeed = 1.0f;
	public bool PlayerFound = false;


	private void _on_DetectionArea_body_entered(object body)
	{
		if (body == Player) ;
		{
			PlayerFound = true;
		}

		GD.Print(body.ToString());
	}
	//private void _on_DetectionArea_body_exited(object body)
	//{

	//	PlayerFound = false;
	//}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Player = GetNode<RigidBody2D>("/root/Root/Player/PlayerBody");
	}

	// called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(float delta)
	{
		if (PlayerFound == true)
		{
			LinearVelocity = Player.Position - this.Position;
		}
		else
		{
			LinearVelocity = GetLocalMousePosition();
			Position += LinearVelocity.Clamped(100.0f) * delta * MovementSpeed;
		}
		//path = navigation2D.GetSimplePath(NavPoint[0].Position, NavPoint[1].Position, true);
		//this.LinearVelocity = path[0];

	}
}






