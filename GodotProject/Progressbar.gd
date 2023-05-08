extends TextureProgress

# Variables
var min_value = 0
var max_value = 100

# Called when the node enters the scene tree for the first time.
func _ready():
	set_min_value(min_value)
	set_max_value(max_value)
	set_value(min_value)

# Sets the minimum value of the progress bar.
func set_min_value(value):
	min_value = value
	set_min(0)
	set_max(max_value - min_value)
	set_value(get_value())

# Sets the maximum value of the progress bar.
func set_max_value(value):
	max_value = value
	set_min(0)
	set_max(max_value - min_value)
	set_value(get_value())

# Sets the current value of the progress bar.
func set_value(value):
	super.set_value(value - min_value)

# Gets the current value of the progress bar.
func get_value():
	return super.get_value() + min_value
