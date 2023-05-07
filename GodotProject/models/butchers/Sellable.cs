using Godot;
using System;

public class Sellable : StaticBody, Gazeable
{
	
	private bool interacting = false;

	[Export]
	public int value = 1;

	[Export(PropertyHint.Enum, "coin,wood,gold")]
	public string type = "coin";

	[Export]
	public float lookTime = 1;
	
	public float currentLookTime;
	public bool active = true;
	public static float cooldown = 1;
	public float currentCooldown = cooldown;

	public void transaction()
	{
		Global.inventory["coin"] += Global.inventory[type] * value;
		Global.inventory[type] = 0;

		active = false;
	}

	public bool canAfford()
	{
		return Global.inventory[type] > 0;
	}

	public void onGaze(float delta)
	{	
		BuyStatusUI.status = $"Sell {type} for {value} each";

		if (canAfford() && active)
		{
			interacting = true;

			currentLookTime = Math.Max(currentLookTime - delta, 0);

			if (currentLookTime == 0 && active)
			{
				transaction();
				active = false;

				// Update UI
				Global.interactionTimer = -1;
			}
			else
			{
				// Update UI
			Global.interactionTimer = currentLookTime / lookTime;
			}
		}
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

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		if (!active)
		{

			currentCooldown = Math.Max(currentCooldown - delta, 0);

			if (currentCooldown == 0)
			{
				var children = GetChildren();

				foreach (var child in children)
				{
					if (child is AnimationPlayer)
					{
						RemoveChild((Node)child);
						GD.Print("b");
					}
				}

				currentCooldown = cooldown;
				active = true;
			} 
		}
	}
}
