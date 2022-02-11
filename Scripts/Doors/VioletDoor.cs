using Godot;
using System;

public class VioletDoor : Area2D
{
    bool doorClosed = true;
    protected void _on_Area2D_body_entered(PhysicsBody2D body) {
        if (body.Name.Contains("Player")) {
            if (Player_Manager.VioletKey && doorClosed) {
                GetNode<AnimatedSprite>("/root/World/Map/Map/Violet").Play();
                GetNode<StaticBody2D>("/root/World/Map/Map/Violet/StaticBody2D").QueueFree();
                doorClosed = false;
            }
        }
    }
}
