using Godot;
using System;

public class Player : Node2D
{
    [Export] public float maxHealth = 10f;
    public float currentHealth;

    //private ProgressBar healthProgress;
    private PlayerObserver observer;
    //private HBoxContainer keyContainer;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //health and healthbar
        currentHealth = maxHealth;
        healthProgress = GetNode<ProgressBar>("/root/World/Control/UI_Container/HealthBar/HealthProgress");
        healthProgress.MaxValue = maxHealth;
        healthProgress.Value = maxHealth;

        //key UI
        keyContainer = GetNode<HBoxContainer>("/root/World/Control/UI_Container/KeyUI/KeyContainer");
    }

    public void addObserver(PlayerObserver playerObserver){
        observer = playerObserver;
    }

    public void _on_RigidBody2D_body_entered(Node body){
        GD.Print(body.Name);
        if (body.Name == "Enemy")
            TakeDamage(1f);
        if (body.Name == "Key"){
            GD.Print("Picked up " + body.Name + "!");

            //keyContainer.AddChild((Node)GD.Load("res://PurpleKey.tscn"));

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

        healthProgress.Value = currentHealth;
        //observer.PlayerHealthUpdate(currentHealth);
    }

}
