using Godot;
using System;

public class Player_Manager : Node2D
{
	[Export] public const float maxHealth = 5.0f;
	public float currentHealth;
	[Signal] public delegate void UpdateHealth(float healthCurrent, float healthMax);
	[Signal] public delegate void AddKey(Node key);
	[Signal] protected delegate void PlayerDeath();
	private AudioStreamPlayer2D audioPlayer;
	Control DeathMenu;
	public static bool BlueKey { get; set; }
	public static bool GreenKey { get; set; }
	public static bool RedKey { get; set; }
	public static bool TealKey { get; set; }
	public static bool VioletKey { get; set; }
	public static bool YellowKey { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//stats
		currentHealth = maxHealth;
		Connect("UpdateHealth",GetNode<Control>("/root/World/UI_CanvasLayer/Control"),"_on_Player_UpdateHealth");
		Connect("AddKey",GetNode<Control>("/root/World/UI_CanvasLayer/Control"),"_on_Player_AddKey");
		EmitSignal("UpdateHealth",currentHealth,maxHealth);
		BlueKey = false;
		GreenKey = false;
		RedKey = false;
		TealKey = false;
		VioletKey = false;
		YellowKey = false;

		DeathMenu = GetNode<Control>("/root/World/Death/Control");
		Connect("PlayerDeath", DeathMenu, "PlayerDeath");

		//audio
		audioPlayer = GetNode<AudioStreamPlayer2D>("GeneralAudioPlayer");
	}

	public void _on_PlayerBody_body_entered(Node body){
		if (body.IsInGroup("Key")){
			//emit signal and play audio
			EmitSignal("AddKey", body);
			audioPlayer.Stream = GD.Load<AudioStream>("res://Audio/Obtain_Key_Item.wav");
			audioPlayer.Play();

			if (body.Name.Contains("Blue")) {
				BlueKey = true;
			}
			if (body.Name.Contains("Green")) {
				GreenKey = true;
			}
			if (body.Name.Contains("Red")) {
				RedKey = true;
			}
			if (body.Name.Contains("Teal")) {
				TealKey = true;
			}
			if (body.Name.Contains("Violet")) {
				VioletKey = true;
			}
			if (body.Name.Contains("Yellow")) {
				YellowKey = true;
			}
			body.QueueFree();
		}
	}

	public void _on_PlayerDamaged(){
		GD.Print("_on_PlayerDamaged called!");
		TakeDamage(0.5f);
	}

	public void TakeDamage(float damage){
		currentHealth -= damage;
		if (currentHealth < 0) {
			currentHealth = 0;
			EmitSignal(nameof(PlayerDeath));
			currentHealth = maxHealth;
		}
		
		EmitSignal("UpdateHealth",currentHealth, maxHealth);

		//play audio
		audioPlayer.Stream = GD.Load<AudioStream>("res://Audio/hurt_sound.wav");
		audioPlayer.Play();
	}

}



