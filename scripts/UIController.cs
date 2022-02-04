using Godot;
using System;

public class UIController : Control
{
    private TextureProgress healthProgress;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        healthProgress = GetNode<TextureProgress>("/root/World/Control/UI_Container/HealthBar/HealthProgress");
    }

    public void _on_Player_UpdateHealth(float healthCurrent, float healthMax){
        healthProgress.MaxValue = healthMax;
        healthProgress.Value = healthCurrent;
    }
}
