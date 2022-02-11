using Godot;
using System;

public class Player_Manager : Node
{
	[Export] public float maxHealth = 10f;
	public float currentHealth;
	[Signal] public delegate void UpdateHealth(float healthCurrent, float healthMax);
	[Signal] public delegate void AddKey(Node key);

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
	}

	public void _on_PlayerBody_body_entered(Node body){
		//GD.Print("_on_PlayerBody_body_enter called!");
		if (body.IsInGroup("Enemy"))
			TakeDamage(1f);
		if (body.IsInGroup("Key")){
			EmitSignal("AddKey", body);
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

	public void TakeDamage(float damage){
		currentHealth -= damage;
		if (currentHealth < 0)
			currentHealth = 0;

		EmitSignal("UpdateHealth",currentHealth, maxHealth);
	}

}
