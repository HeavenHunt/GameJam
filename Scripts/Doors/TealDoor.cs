using Godot;
using System;

public class TealDoor : Node
{
    public void _on_Area2D_body_entered(PhysicsBody2D body) {
        if (body.Name.Contains("Player")) {
            if (Player_Manager.TealKey) {
                GetNode<AnimatedSprite>("Teal").Play();
            }
        }
    }
}
