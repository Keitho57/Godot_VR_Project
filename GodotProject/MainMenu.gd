extends Node2D


export var mainGameScreen: PackedScene


func _on_NewExperienceButton_button_up():
	get_tree().change_scene(mainGameScreen.resource_path)
