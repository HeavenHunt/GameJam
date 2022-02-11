using Godot;
using System;

public class RedDoor : Area2D
{
    bool doorClosed = true;
    protected void _on_Area2D_body_entered(PhysicsBody2D body) {
        if (body.Name.Contains("Player")) {
            if (Player_Manager.RedKey && doorClosed) {
                GetNode<AnimatedSprite>("/root/World/Map/Map/Red").Play();
                GetNode<StaticBody2D>("/root/World/Map/Map/Red/StaticBody2D").QueueFree();
                doorClosed = false;
            }
        }
    }
}
