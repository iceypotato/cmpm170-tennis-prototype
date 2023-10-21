using Godot;

public partial class Ball : Area2D
{
	private const int DefaultSpeed = 100;
	private Vector2 DefaultDirection;

	public Vector2 Direction;

	private Vector2 _initialPos;
	public double Speed = DefaultSpeed;

	public override void _Ready()
	{
		string name = Name.ToString().ToLower();
		switch (name)
		{
			case "ball":
				DefaultDirection = Vector2.Left;
				break;
			case "ball2":
				DefaultDirection = Vector2.Right;
				break;
		}

		Direction = DefaultDirection;
		_initialPos = Position;
	}

	public override void _Process(double delta)
	{
		Speed += delta * 2;
		Position += (float) (Speed * delta) * Direction;
	}

	public void Reset()
	{
		Direction = DefaultDirection;
		Position = _initialPos;
		Speed = DefaultSpeed;
	}
}
