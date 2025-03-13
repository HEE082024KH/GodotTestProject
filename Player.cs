using Godot;
using System;

public partial class Player : Area2D
{
  [Export] public int Speed = 0; // How fast the player will move (pixels/sec)

  private Vector2 _screenSize; // Size of the game window

  public override void _Ready()
  {
    _screenSize = GetViewport().GetVisibleRect().Size;
  }
  public override void _Process(float delta)
  {
    var velocity = new Vector2(); // The player's movement vector
    if (Input.IsActionPressed("ui_right"))
    {
      velocity.X += 1;
    }

    if (Input.IsActionPressed("ui_left"))
    {
      velocity.X -= 1;
    }

    if (Input.IsActionPressed("ui_down"))
    {
      velocity.Y += 1;
    }

    if (Input.IsActionPressed("ui_up"))
    {
      velocity.Y -= 1;
    }

    var animationSpite = (AnimatedSprite2D)GetNode("AnimatedSprite2D");
    if (velocity.Length() > 0)
    {
      velocity = velocity.Normalized() * Speed;
      animationSpite.Play();
    }
    else
    {
      animationSpite.Stop();
    }
  }

}
