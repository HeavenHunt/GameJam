using Godot;
using System;

public class HealthBar : HBoxContainer
{
    [Export] public float maxHealth = 10f;
    public float currentHealth;

    private ProgressBar healthProgress;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        currentHealth = maxHealth;
        healthProgress = GetNode<ProgressBar>("HealthProgress");
        healthProgress.MaxValue = maxHealth;
        healthProgress.Value = maxHealth;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        
    }

    public void _on_HurtButton_pressed() {
        TakeDamage(1f);
    }

    public void TakeDamage(float damage){
        currentHealth -= damage;
        if (currentHealth < 0)
            currentHealth = 0;

        healthProgress.Value = currentHealth;
    }
}
