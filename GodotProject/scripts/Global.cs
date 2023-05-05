using Godot;
using System;
using System.Collections.Generic;

public class Global : Node
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	
	public static List<Node> buyableNodes = new List<Node>();

	public static float interactionTimer = -1;

	public static Dictionary<string,int> inventory = new Dictionary<string,int>(){
		{ "coin", 100},
		{ "wood", 0},
		{ "gold", 0}
	};
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
