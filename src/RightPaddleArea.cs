using Godot;
using System;

public partial class RightPaddleArea : Area2D
{
	private bool _playerHit = false;
	private double _hitTime = 0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		ProcessInput( delta);
		if(_playerHit){
			_hitTime += delta;
			if(_hitTime > 0.05){
				_playerHit = false;
				_hitTime = 0;
			}
		}
	}

	private void ProcessInput(double delta)
	{
		if( Input.GetActionStrength("right paddle hit") > 0){

			GD.Print("player intend hit");
			_playerHit = true;
			_hitTime = delta;
		}
		
	}

	public void OnAreaEntered(Area2D area)
	{
		GD.Print("zone collision");
		if (area is Ball ball && _playerHit)
		{
			GD.Print("hit");
			// Assign new direction
			ball.Direction = new Vector2(1, 0);
			GD.Print(ball.Direction);
		} 
	}
}
