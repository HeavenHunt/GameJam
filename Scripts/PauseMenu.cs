using Godot;
using System;

public class PauseMenu : Control
{
	private bool isPaused = false;

	public bool GetIsPaused() {
		return isPaused;
	}

	public void SetIsPaused(bool value) {
		isPaused = value;
		GetTree().Paused = isPaused; 
		Visible = isPaused;
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event.IsActionPressed("pause")) {
			SetIsPaused(!GetIsPaused());
		}
	}

	public void Resume_Button_Pressed() {
		SetIsPaused(false);
	}
	
	public void Restart_Button_Pressed() {
	 GetTree().
	}

	public void Quit_Button_Pressed() {
		GetTree().Quit();
	}
}



