using Godot;
using System;

public class PauseMenu : Control
{
	private bool isPaused = false;
	private bool allowPause = true;
	private AudioStreamPlayer pauseSound;

	public override void _Ready(){
		pauseSound = GetNode<AudioStreamPlayer>("PauseAudio");
		pauseSound.Stream = GD.Load<AudioStream>("res://Audio/Pause_Game_SFX.wav");
	}

	public bool GetIsPaused() {
		return isPaused;
	}

	public void SetIsPaused(bool value) {
		isPaused = value;
		GetTree().Paused = isPaused; 
		Visible = isPaused;
		pauseSound.Play();
	}

	public void AllowPauseMenu(bool value) {
		isPaused = !value;
		GetTree().Paused = !value;
		allowPause = value;
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event.IsActionPressed("pause") && allowPause) {
			SetIsPaused(!GetIsPaused());
		}
	}

	public void Resume_Button_Pressed() {
		SetIsPaused(false);
	}
	
	public void Restart_Button_Pressed() {
		SetIsPaused(false);
		GetTree().ReloadCurrentScene();
	}

	public void Quit_Button_Pressed() {
		GetTree().Quit();
	}
}



