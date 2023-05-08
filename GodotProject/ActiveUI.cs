using Godot;
using System;

public class ActiveUI : Label  
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	[Export(PropertyHint.Enum, "coin,wood,gold,sword")]
	
//	[Export]
	public static string Value="";
	 
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		

	
	}

 // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{ Text = Value;
		if (Global.interactionTimer == -1)
		{ 
			Visible = false;
			// Update the label text every frame
		
		}
		else
		{
			Visible = true;
			
		}
	}
	
}
