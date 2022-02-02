using Godot;
using System;

public class HurtButton : Button
{
    [Signal]
    public delegate void Hurt(float damage);

    [Export]
    public float damageDealt = 1f;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        this.Connect("pressed",this,"take_damage");
    }

    void take_damage(){
        this.EmitSignal("Hurt",damageDealt);
    }
}
