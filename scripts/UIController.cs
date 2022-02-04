using Godot;
using System;

public class UIController : Control
{
    private TextureProgress healthProgress;
    private HBoxContainer keyContainer;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        healthProgress = GetNode<TextureProgress>("UI_Container/HealthBar/HealthProgress");
        keyContainer = GetNode<HBoxContainer>("UI_Container/KeyContainer");

    }

    public void _on_Player_UpdateHealth(float healthCurrent, float healthMax){
        healthProgress.MaxValue = healthMax;
        healthProgress.Value = healthCurrent;
    }

    public void _on_Player_AddKey(Node key){
        //index 2 should be the last node of a Key scene, hopefully :T
        GD.Print("Picked up " + key.Name + "!");
        TextureRect keyTexture = key.GetChild<TextureRect>(key.GetChildCount()-1);
        TextureRect keyToAdd = new TextureRect();
        keyToAdd.Texture = keyTexture.Texture;
        GD.Print("Target: " + keyTexture.GetRect());
        GD.Print("1: " + keyToAdd.GetRect());
        //keyToAdd.Expand = true;
        keyToAdd.RectSize = new Vector2(32, 32);
        GD.Print("2: " + keyToAdd.GetRect());
        keyContainer.AddChild(keyToAdd);
        GD.Print("3: " + keyToAdd.GetRect());
        keyToAdd.RectSize = new Vector2(32, 32);
        GD.Print("4: " + keyToAdd.GetRect());
    }
}
