using Godot;
using System;

public class Player : Node2D
{
    [Export] public float maxHealth = 10f;
    public float currentHealth;

    private UIController uiController;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //references
        uiController = GetNode<UIController>("/root/World/Control");

        //stats
        currentHealth = maxHealth;
    }

    public void _on_RigidBody2D_body_entered(Node body){
        GD.Print(body.Name);
        if (body.Name == "Enemy")
            TakeDamage(1f);
        if (body.Name == "Key"){
            GD.Print("Picked up " + body.Name + "!");

            //TODO
            //uiController.UpdateKeys()

            body.QueueFree();
        }
    }

    public void _on_HurtButton_pressed() {
        //GD.Print("HurtButton pressed!");
        TakeDamage(1f);
    }

    public void TakeDamage(float damage){
        currentHealth -= damage;
        if (currentHealth < 0)
            currentHealth = 0;

        
        //observer.PlayerHealthUpdate(currentHealth);
    }

}
