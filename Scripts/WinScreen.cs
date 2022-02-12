using Godot;
using System;

public class WinScreen : Control
{
	public bool isPaused = false;
	[Signal] protected delegate void AllowPauseMenu();
	private Control pauseMenu;

	public override void _Ready() {
		pauseMenu = GetNode<Control>("/root/World/Pause/Control");
		Connect("AllowPauseMenu", pauseMenu, "AllowPauseMenu");
	}

	public void SetIsPaused(bool value) {
		isPaused = value;
		GetTree().Paused = isPaused; 
		Visible = isPaused;
	}

	private void PlayerWon() {
		SetIsPaused(true);
		EmitSignal(nameof(AllowPauseMenu), false);
	}

	public void Restart_Button_Pressed() {
		SetIsPaused(false);
		EmitSignal(nameof(AllowPauseMenu), true);
		GetTree().ReloadCurrentScene();
	}

	public void Quit_Button_Pressed() {
		GetTree().Quit();
	}
}
