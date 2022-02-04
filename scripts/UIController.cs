using Godot;
using System;

public class UIController : Control
{
    private TextureProgress healthProgress;
    private HBoxContainer keyContainer;
    private PackedScene keyScene;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        healthProgress = GetNode<TextureProgress>("UI_Container/HealthBar/HealthProgress");
        keyContainer = GetNode<HBoxContainer>("UI_Container/KeyContainer");
        keyScene = (PackedScene)GD.Load("res://scenes/Keys/Key_UI.tscn");
    }

    public void _on_Player_UpdateHealth(float healthCurrent, float healthMax){
        healthProgress.MaxValue = healthMax;
        healthProgress.Value = healthCurrent;
    }

    public void _on_Player_AddKey(Node key){
        //print pickup
        GD.Print("Picked up " + key.Name + "!");

        //create new Key_UI
        TextureRect keyToAdd = (TextureRect)keyScene.Instance();

        //set proper Texture
        if (key.IsInGroup("Key_Blue")){
            keyToAdd.Texture = (Texture)GD.Load("res://assets/art/Key_Blue.png");
        }
        else if (key.IsInGroup("Key_Green")){
            keyToAdd.Texture = (Texture)GD.Load("res://assets/art/Key_Green.png");
        }
        else if (key.IsInGroup("Key_Purple")){
            keyToAdd.Texture = (Texture)GD.Load("res://assets/art/Key_Purple.png");
        }
        else if (key.IsInGroup("Key_Red")){
            keyToAdd.Texture = (Texture)GD.Load("res://assets/art/Key_Red.png");
        }
        else if (key.IsInGroup("Key_Teal")){
            keyToAdd.Texture = (Texture)GD.Load("res://assets/art/Key_Teal.png");
        }
        else if (key.IsInGroup("Key_Yellow")){
            keyToAdd.Texture = (Texture)GD.Load("res://assets/art/Key_Yellow.png");
        }
        
        keyContainer.AddChild(keyToAdd);
    }
}
