using Godot;
using System;

public class YellowDoor : Area2D
{
    bool doorClosed = true;
    protected void _on_Area2D_body_entered(PhysicsBody2D body) {
        if (body.Name.Contains("Player")) {
            if (Player_Manager.YellowKey && doorClosed) {
                GetNode<AnimatedSprite>("/root/World/Map/Map/Yellow").Play();
                GetNode<StaticBody2D>("/root/World/Map/Map/Yellow/StaticBody2D").QueueFree();
                doorClosed = false;
            }
        }
    }
}
