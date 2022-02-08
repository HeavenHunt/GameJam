using Godot;
using System;

public class DeathMenu : Control
{
	public bool isPaused = false;
	public DeathMenu() {
		isPaused = false;
	}

	public bool GetIsPaused() {
		return isPaused;
	}

	public void SetIsPaused(bool value) {
		isPaused = value;
		GetTree().Paused = isPaused; 
		Visible = isPaused;
	}

	public void PlayerDeath() {
		SetIsPaused(true);
	}

	public void Restart_Button_Pressed() {
		SetIsPaused(false);
		GetTree().ReloadCurrentScene();
	}

	public void Quit_Button_Pressed() {
		GetTree().Quit();
	}
}
