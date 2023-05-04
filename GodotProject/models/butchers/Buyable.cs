using Godot;
using System;

public class Buyable : Node
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	[Export]
	public int cost = 10;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Global.buyableNodes.Add(this);
		
		GD.Print(Global.buyableNodes.Count);
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
