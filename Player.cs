using Godot;
using System;

public class Player : KinematicBody2D
{
	
	Vector2 direction;
	float movementSpeed=500;
	float gravity = 90;
	float maxFallSpeed = 1000;
	float jumpForce = 1000;
	float minFallSpeed = 5;

	public override void _Ready()
	{
		
	}

    public override void _PhysicsProcess(float delta)
    {
		direction.y += gravity;
		if(direction.y > maxFallSpeed){
			direction.y = maxFallSpeed;
		}

		if(IsOnFloor()){
			direction.y = minFallSpeed;
		}

		if(IsOnFloor() && Input.IsActionJustPressed("jump")){
			direction.y =-jumpForce;
		}

		direction.x = Input.GetActionStrength("move_right")-Input.GetActionStrength("move_left");
		direction.x *= movementSpeed;
		direction = MoveAndSlide(direction, Vector2.Up);
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }

}
