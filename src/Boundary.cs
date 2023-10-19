using Godot;
using System;

public partial class Boundary : Area2D
{
    public void OnAreaEntered(Area2D area)
    {
        if (area is Ball ball)
        {
            ball.Reset();
        }
    }
}
