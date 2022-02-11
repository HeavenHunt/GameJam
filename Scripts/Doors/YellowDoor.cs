using Godot;
using System;

public class YellowDoor : Node
{
    public void _on_Area2D_body_entered(PhysicsBody2D body) {
        if (body.Name.Contains("Player")) {
            if (Player_Manager.YellowKey) {
                GetNode<AnimatedSprite>("Yellow").Play();
            }
        }
    }
}
