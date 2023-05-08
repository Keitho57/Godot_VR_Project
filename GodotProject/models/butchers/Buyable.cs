using Godot;
using System;

public class Buyable : StaticBody, Gazeable
{
	
	private bool interacting = false;
	[Export]
	public string name = "";
	[Export]
	public int cost = 10;
	[Export]
	public string description = "";

	[Export(PropertyHint.Enum, "coin,wood,gold")]
	public string type = "coin";
	
	[Export]
	public float lookTime = 1;
	
	public float currentLookTime;
	public bool active = true;
	public static float cooldown = 10;
	public float currentCooldown = cooldown;

	private Vector3 initialScale;

	public void transaction()
	{
		if (cost > 0 && type != "coin")
		{
			switch (type)
			{
				case "gold":
					Global.inventory["coin"] += 5;
					break;
				default:
					Global.inventory["coin"] += cost;
					break;
			}
		}
		Global.inventory[type] -= cost;
		active = false;

		
	}

	public bool canAfford()
	{
		return Global.inventory[type] >= cost;
	}

	public void onGaze(float delta)
	{
		if(cost<0){ 
			
			ActiveUI.Value= $"Gathering {(name)}";}
			
	else if(cost == 100){ActiveUI.Value= $"The King needs this road built peasant! {(name)}!";
		
	}else{
		ActiveUI.Value= $"Buying {(name)} : \n + {(description)} \n ";
	}
		
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
//public void inspect(float delta)
//	{
//		if(onGaze)
//	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Global.buyableNodes.Add(this);
		
		GD.Print(Global.buyableNodes.Count);

		currentLookTime = lookTime;

		initialScale = Scale * 1;
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		if (!active)
		{
			Scale = initialScale * (1 - currentCooldown / cooldown);

			currentCooldown = Math.Max(currentCooldown - delta, 0);

			if (currentCooldown == 0)
			{
				Scale = initialScale;
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
