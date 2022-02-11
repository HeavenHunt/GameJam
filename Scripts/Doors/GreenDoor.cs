using Godot;
using System;

public class GreenDoor : Node
{
    public void _on_Area2D_body_entered(PhysicsBody2D body) {
        if (body.Name.Contains("Player")) {
            if (Player_Manager.GreenKey) {
                GetNode<AnimatedSprite>("Green").Play();
            }
        }
    }
}
