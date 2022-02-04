using Godot;
using System;

public class KeyCollision : Area2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
public override void _Process(float delta)
{
	
}

private void _on_KeyHitbox_area_entered(Area2D area)
{
	if(area.IsInGroup("Key1"))
	{
		Global.key1_pickedUp = true;
		area.QueueFree();
	}
	if(area.IsInGroup("Key2"))
	{
		Global.key2_pickedUp = true;
		area.QueueFree();
	}
	if(area.IsInGroup("Key3"))
	{
		Global.key3_pickedUp = true;
		area.QueueFree();
	}
	if(area.IsInGroup("Key4"))
	{
		Global.key4_pickedUp = true;
		area.QueueFree();
	}
	if(area.IsInGroup("Key5"))
	{
		Global.key5_pickedUp = true;
		area.QueueFree();
	}
	if(area.IsInGroup("Key6"))
	{
		Global.key6_pickedUp = true;
		area.QueueFree();
	}
	if(area.IsInGroup("Door1"))
	{
		if(Global.key1_pickedUp == true)
		{
			GD.Print("Hello?");
			area.QueueFree();
		}
		
	}
	if(area.IsInGroup("Door2"))
	{
		if(Global.key2_pickedUp == true)
			area.QueueFree();
	}
	if(area.IsInGroup("Door3"))
	{
		if(Global.key3_pickedUp == true)
			area.QueueFree();
	}
	if(area.IsInGroup("Door4"))
	{
		if(Global.key4_pickedUp == true)
			area.QueueFree();
	}
	if(area.IsInGroup("Door5"))
	{
		if(Global.key5_pickedUp == true)
			area.QueueFree();
	}
	if(area.IsInGroup("Door6"))
	{
		if(Global.key6_pickedUp == true)
			area.QueueFree();
	}
}
}
