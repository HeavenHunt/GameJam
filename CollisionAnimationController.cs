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
				AnimatedSprite _Door = GetNode<AnimatedSprite>("/root/World/BlueDoor");
				Area2D DoorCollision = GetNode<Area2D>("/root/World/BlueDoor/Door");
				DoorCollision.QueueFree();
				_Door.Play("New Anim");
			}
			
		}
		if(area.IsInGroup("Door2"))
		{
			if(Global.key2_pickedUp == true)
			{
				AnimatedSprite _Door = GetNode<AnimatedSprite>("/root/World/VioletDoor");
				Area2D DoorCollision = GetNode<Area2D>("/root/World/VioletDoor/Door2");
				DoorCollision.QueueFree();
				_Door.Play("default");
			}
		}
		if(area.IsInGroup("Door3"))
		{
			if(Global.key3_pickedUp == true)
			{
				AnimatedSprite _Door = GetNode<AnimatedSprite>("/root/World/GreenDoor");
				Area2D DoorCollision = GetNode<Area2D>("/root/World/GreenDoor/Door3");
				DoorCollision.QueueFree();
				_Door.Play("default");
			}
		}
		if(area.IsInGroup("Door4"))
		{
			if(Global.key4_pickedUp == true)
			{
				AnimatedSprite _Door = GetNode<AnimatedSprite>("/root/World/RedDoor");
				Area2D DoorCollision = GetNode<Area2D>("/root/World/RedDoor/Door4");
				DoorCollision.QueueFree();
				_Door.Play("default");
			}
		}
		if(area.IsInGroup("Door5"))
		{
			if(Global.key5_pickedUp == true)
			{
				AnimatedSprite _Door = GetNode<AnimatedSprite>("/root/World/GoldDoor");
				Area2D DoorCollision = GetNode<Area2D>("/root/World/GoldDoor/Door5");
				DoorCollision.QueueFree();
				_Door.Play("default");
			}
		}
		if(area.IsInGroup("Door6"))
		{
			if(Global.key6_pickedUp == true)
			{
				AnimatedSprite _Door = GetNode<AnimatedSprite>("/root/World/TealDoor");
				Area2D DoorCollision = GetNode<Area2D>("/root/World/TealDoor/Door6");
				DoorCollision.QueueFree();
				_Door.Play("default");
			}
		}
	}

	private void _on_BlueDoor_animation_finished()
	{
		AnimatedSprite _Door = GetNode<AnimatedSprite>("/root/World/BlueDoor");
		_Door.Stop();
		_Door.SetFrame(4); //This sets the last frame of the animation to be the final state, otherwise animation finishes and returns to closed state
	}
	
	private void _on_VioletDoor_animation_finished()
	{
		AnimatedSprite _Door = GetNode<AnimatedSprite>("/root/World/VioletDoor");
		_Door.Stop();
		_Door.SetFrame(4);
	}
	
	private void _on_GreenDoor_animation_finished()
	{
		AnimatedSprite _Door = GetNode<AnimatedSprite>("/root/World/GreenDoor");
		_Door.Stop();
		_Door.SetFrame(4);
	}
	
	private void _on_RedDoor_animation_finished()
	{
		AnimatedSprite _Door = GetNode<AnimatedSprite>("/root/World/RedDoor");
		_Door.Stop();
		_Door.SetFrame(4);
	}

	private void _on_GoldDoor_animation_finished()
	{
		AnimatedSprite _Door = GetNode<AnimatedSprite>("/root/World/GoldDoor");
		_Door.Stop();
		_Door.SetFrame(4);	
	}

	private void _on_TealDoor_animation_finished()
	{
		AnimatedSprite _Door = GetNode<AnimatedSprite>("/root/World/TealDoor");
		_Door.Stop();
		_Door.SetFrame(4);
	}

}
