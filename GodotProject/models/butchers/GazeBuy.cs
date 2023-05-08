using Godot;
using System;

public class GazeBuy : Camera
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	private Vector2 rayPoint;

	private Node last;
	
	Node target;
	public static float lookTime = 5;
	public static float currentLookTime = lookTime;
	bool lLock = false;
	//TextureProgress progressBar;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		rayPoint = new Vector2(OS.WindowSize.x / 2, OS.WindowSize.y / 2);
		//progressBar = GetNode<TextureProgress>("TextureProgress");
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.

	public override void _Process(float delta)
	{
		var from = ProjectRayOrigin(rayPoint);
		var to = from + ProjectRayNormal(rayPoint) * 5;

		var rayCollisions = GetWorld().DirectSpaceState.IntersectRay(from, to);
		
		if (rayCollisions != null && rayCollisions.Contains("collider"))
		{
			target = (Node) rayCollisions["collider"];
			//GD.Print(target.GetType());
			
			if (target is Gazeable)
			{
				((Gazeable) target).onGaze(delta);
			}

			if (last != target && last is Gazeable)
			{
				((Gazeable) last).endGaze(delta);
			}

			// if (Global.buyableNodes.Contains(target) && ((Buyable) target).active)
			// {
			// 	currentLookTime = Math.Max(currentLookTime - delta, 0);
			// 	if (currentLookTime == 0 && !lLock)
			// 	{
			// 		lLock = true;
			// 		((Buyable) target).transaction();
			// 		// int cost = ((Buyable) target).cost;
			// 		// string type = ((Buyable) target).type;
			// 		// Global.inventory[type] -= cost;
					
			// 		// Global.buyableNodes.Remove(target);

			// 		// target.GetParent().RemoveChild(target);
			// 	}
			// }
			// if (Global.buyableNodes.Contains(target))
			// {
			// 	currentLookTime = Math.Max(currentLookTime - delta, 0);
			// 	// Update the value of the TextureProgress node based on the currentLookTime variable
			// 	//progressBar.Value = (int)(currentLookTime / lookTime * progressBar.MaxValue);
			// 	if (currentLookTime == 0 && !lLock)
			// 	{
			// 		lLock = true;
			// 		int cost = ((Buyable) target).cost;
			// 		Global.balance -= cost;
					
			// 		Global.buyableNodes.Remove(target);

			// 		target.GetParent().RemoveChild(target);
			// 	}
			// }
			// else
			// {
			// 	target = null;
			// 	currentLookTime = lookTime;
			// 	lLock = false;
			// 	// Reset the value of the TextureProgress node
			// 	//progressBar.Value = 0;
			// }
			last = target;
		}
		else
		{
			target = null;

			if (last != null && last is Gazeable)
			{
				((Gazeable) last).endGaze(delta);
			}

			currentLookTime = lookTime;
			lLock = false;

			last = null;
			//progressBar.Value = 0;
		}
	}
}

//extends MeshInstance
//
//
//# Declare member variables here. Examples:
//# var a = 2
//# var b = "text"
//
//
//# Called when the node enters the scene tree for the first time.
//func _ready():
//	pass # Replace with function body.
//
//
//# Called every frame. 'delta' is the elapsed time since the previous frame.
//func _process(delta):
//
//	var camera = get_viewport().get_camera()
//
//
//	translate(Vector3.FORWARD)

