using Godot;
using System;

public class HealthBar : HBoxContainer
{
    [Export] public float maxHealth = 10f;
    public float currentHealth;

    

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

        //healthProgress.Value = currentHealth;
    }
}
