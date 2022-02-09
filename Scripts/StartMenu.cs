using Godot;
using System;

public class StartMenu : Control
{
    public void Start_Button_Pressed() {
        GetTree().ChangeScene("res://Scenes/World.tscn");
    }
    public void Quit_Button_Pressed() {
		GetTree().Quit();
	}
}
