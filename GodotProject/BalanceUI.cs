using Godot;
using System;

public class BalanceUI : Label
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	[Export(PropertyHint.Enum, "coin,wood,gold")]
	public string type = "coin";
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		Text = Global.inventory[type] + "";
	}
}
