using Godot;
using System;

public class Buyable : Node
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	[Export]
	public int cost = 10;

	[Export(PropertyHint.Enum, "coin,wood,gold")]
	public string type = "coin";

	public bool active = true;
	public static float cooldown = 10;
	public float currentCooldown = cooldown;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Global.buyableNodes.Add(this);
		
		GD.Print(Global.buyableNodes.Count);
	}
	
	public void transaction()
	{
		Global.inventory[type] -= cost;
		active = false;
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		if (!active)
		{
			currentCooldown = Math.Max(currentCooldown - delta, 0);

			if (currentCooldown == 0)
			{
				currentCooldown = cooldown;
				active = true;
			} 
		}
	}
}
