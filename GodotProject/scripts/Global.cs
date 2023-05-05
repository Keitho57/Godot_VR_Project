using Godot;
using System;
using System.Collections.Generic;

public class Global : Node
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	
	public static List<Node> buyableNodes = new List<Node>();
	
	public static int balance = 120;

	public static float interactionTimer = -1;
	
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
