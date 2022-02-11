using Godot;
using System;

public class BlueDoor : Area2D
{
    bool doorClosed = true;
    protected void _on_Area2D_body_entered(PhysicsBody2D body) {
        if (body.Name.Contains("Player")) {
            if (Player_Manager.BlueKey && doorClosed) {
                GetNode<AnimatedSprite>("/root/World/Map/Map/Blue").Play();
                GetNode<StaticBody2D>("/root/World/Map/Map/Blue/StaticBody2D").QueueFree();
                doorClosed = false;
            }
        }
    }
}
