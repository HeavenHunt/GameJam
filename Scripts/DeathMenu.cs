using Godot;
using System;

public class DeathMenu : Control
{
	public bool isPaused = false;
	[Signal] protected delegate void AllowPauseMenu();
	private Control pauseMenu;
	private AudioStreamPlayer deathSound;

	public override void _Ready() {
		pauseMenu = GetNode<Control>("/root/World/Pause/Control");
		Connect("AllowPauseMenu", pauseMenu, "AllowPauseMenu");

		//audio
		deathSound = GetNode<AudioStreamPlayer>("DeathAudio");
		deathSound.Stream = GD.Load<AudioStream>("res://Audio/death_sound.wav");
	}

	public void SetIsPaused(bool value) {
		isPaused = value;
		GetTree().Paused = isPaused; 
		Visible = isPaused;
		deathSound.Play();
	}

	private void PlayerDeath() {
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
