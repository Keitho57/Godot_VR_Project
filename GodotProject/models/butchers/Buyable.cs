using Godot;
using System;

public class Buyable : Node, Gazeable
{
	
	private bool interacting = false;

	[Export]
	public int cost = 10;
  
  [Export(PropertyHint.Enum, "coin,wood,gold")]
	public string type = "coin";
  
  [Export]
	public float lookTime = 1;
	
	public float currentLookTime;
  
	public bool active = true;
	public static float cooldown = 10;
	public float currentCooldown = cooldown;

	public void onGaze(float delta)
	{
		interacting = true;

		currentLookTime = Math.Max(currentLookTime - delta, 0);

		// Update UI
		Global.interactionTimer = currentLookTime / lookTime;
	}

	public void endGaze(float delta)
	{
		interacting = false;

		currentLookTime = lookTime;

		// Update UI
		Global.interactionTimer = -1;
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Global.buyableNodes.Add(this);
		
		GD.Print(Global.buyableNodes.Count);

		currentLookTime = lookTime;
	}
	
	public void transaction()
	{
		if (cost > 0 && type != "coin" && Global.inventory[type] >= cost)
		{
			Global.inventory["coin"] += cost;
		}
		Global.inventory[type] = Math.Max(Global.inventory[type] - cost, 0);
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
