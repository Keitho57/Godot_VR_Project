#extends Node
#
#
## Variables
#var progress_bar
#var fill_duration = 5
#var fill_timer
#
## Called when the node enters the scene tree for the first time.
#func _ready():
#	# Get a reference to the progress bar node.
#	progress_bar = $TextureProgress
#
#	# Connect the timer's "timeout" signal to a function that updates the progress bar.
#	fill_timer = $Timer
#	fill_timer.connect("timeout", self, "on_fill_timer_timeout")
#
## Function that is called when the timer's "timeout" signal is emitted.
#func on_fill_timer_timeout():
#	# Update the progress bar's value based on the elapsed time.
#	var elapsed_time = fill_timer.get_time_left()
#	var fill_progress = 1 - elapsed_time / fill_duration
#	progress_bar.set_value(fill_progress)
