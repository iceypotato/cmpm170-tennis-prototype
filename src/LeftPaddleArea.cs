using Godot;
using System;

public partial class LeftPaddleArea : Area2D
{
	private bool _touchingWall = false;
	private bool _playerHit = false;
	private double _hitTime = 0;
	private bool _inArea;
	private Ball _ball;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		ProcessInput(delta);
		if (_playerHit)
		{
			_hitTime += delta;
			if (_hitTime > 1.0)
			{
				_playerHit = false;
				_hitTime = 0;
			}
		}
	}

	private void ProcessInput(double delta)
	{
		if (Input.GetActionStrength("left paddle hit") > 0 && _inArea && !_playerHit)
		{
			GD.Print("player intend hit");
			_playerHit = true;
			_hitTime = delta;
			_ball.Speed += 30;

			var low = -0.5;
			var hi = 0.5;
			var range = hi - low;
			_ball.Direction = new Vector2(_ball.Direction.X, (float)(new Random().NextDouble() * range + low)).Normalized();
		}
	}

	public void OnAreaEntered(Area2D area)
	{

		GD.Print("left paddle collision");
		if (area is Ball ball)
		{
			GD.Print("hit");
			// Assign new direction
			
			_ball = ball;
			_inArea = true;
		}
	}
	
	public void OnAreaExited(Area2D area)
	{
		if (area is Ball ball)
		{
			_inArea = false;
		}
	}
}
