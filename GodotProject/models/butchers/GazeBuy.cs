using Godot;
using System;

public class GazeBuy : Camera
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	private Vector2 rayPoint;
	
	Node target;
	public static float lookTime = 5;
	public static float currentLookTime = lookTime;
	bool lLock = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		rayPoint = new Vector2(OS.WindowSize.x / 2, OS.WindowSize.y / 2);
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		var from = ProjectRayOrigin(rayPoint);
		var to = from + ProjectRayNormal(rayPoint) * Far;

		var rayCollisions = GetWorld().DirectSpaceState.IntersectRay(from, to);
		
		if (rayCollisions != null && rayCollisions.Contains("collider"))
		{
			target = (Node) rayCollisions["collider"];
			//GD.Print(target.GetType());
			
			if (Global.buyableNodes.Contains(target) && ((Buyable) target).active)
			{
				currentLookTime = Math.Max(currentLookTime - delta, 0);
				if (currentLookTime == 0 && !lLock)
				{
					lLock = true;
					((Buyable) target).transaction();
					// int cost = ((Buyable) target).cost;
					// string type = ((Buyable) target).type;
					// Global.inventory[type] -= cost;
					
					// Global.buyableNodes.Remove(target);

					// target.GetParent().RemoveChild(target);
				}
			}
			else
			{
				target = null;
				currentLookTime = lookTime;
				lLock = false;
			}
		}
		else
		{
			target = null;
			currentLookTime = lookTime;
			lLock = false;
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

