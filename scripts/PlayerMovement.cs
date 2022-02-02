using Godot;
using System;

public class PlayerMovement : RigidBody2D
{
    [Export] public int speed = 200;

    public Vector2 newVelocity = new Vector2();

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
        GetInput();
        this.LinearVelocity = newVelocity;
    }
}
