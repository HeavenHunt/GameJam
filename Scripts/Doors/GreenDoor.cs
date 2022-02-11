using Godot;
using System;

public class GreenDoor : Area2D
{
    bool doorClosed = true;
    protected void _on_Area2D_body_entered(PhysicsBody2D body) {
        if (body.Name.Contains("Player")) {
            if (Player_Manager.GreenKey && doorClosed) {
                GetNode<AnimatedSprite>("/root/World/Map/Map/Green").Play();
                GetNode<StaticBody2D>("/root/World/Map/Map/Green/StaticBody2D").QueueFree();
                doorClosed = false;
            }
        }
    }
}
