using Godot;

public partial class Walls : Area2D
{
	[Export]
	private int _bounceDirection = 1;

	public void OnAreaEntered(Area2D area)
	{
		if (area is Ball ball)
		{
			ball.Direction = new Vector2(-ball.Direction.X, ball.Direction.Y).Normalized();
		}
	}
}
