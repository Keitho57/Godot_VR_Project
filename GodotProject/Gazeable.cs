using Godot;
using System;

public interface Gazeable
{
    void onGaze(float delta);

    void endGaze(float delta);
}
