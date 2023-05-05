using Godot;
using System;

public class Buyable : Node, Gazeable
{
	
	private bool interacting = false;

	[Export]
	public int cost = 10;

	[Export]
	public float lookTime = 1;
	
	public float currentLookTime;

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

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		
	}
}
