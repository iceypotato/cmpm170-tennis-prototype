using Godot;
using System;

public partial class leftpaddle : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		ProcessInput();
	}

	private void ProcessInput()
	{
		if (Input.GetActionStrength("left paddle move up") > 0)
		{
			this.Position += new Vector2(0, -2);
		}
		if (Input.GetActionStrength("left paddle move down") > 0)
		{
			this.Position += new Vector2(0, 2);
		}
		
	}

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("left paddle move up"))
		{
			this.Position += new Vector2(0, 10);
		}
	}

	public void OnAreaEntered(Area2D area)
	{
		
	}
}
