using Godot;
using System;

public class StartMenu : Control
{
    Control Credits, Controls;

    public override void _Ready()
    {
        Credits = GetNode<Control>("/root/StartMenu/Credits");
        Controls = GetNode<Control>("/root/StartMenu/Controls");
    }
    public void Start_Button_Pressed() {
        GetTree().ChangeScene("res://Scenes/World.tscn");
    }
    public void Quit_Button_Pressed() {
		GetTree().Quit();
	}
    public void Credits_Button_Pressed() {
        Credits.Visible = true;
    }

    public void Controls_Button_Pressed() {
        Controls.Visible = true;
    }

    public void Back_Button_Pressed() {
        Credits.Visible = false;
        Controls.Visible = false;
    }
}
