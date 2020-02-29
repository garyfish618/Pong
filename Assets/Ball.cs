using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private bool hasStarted;
    private Rigidbody2D ball;
    public int initialSpeed;
    private float ballSpeed;
    public float ballIncSpeed;



    // Start is called before the first frame update
    void Start()
    {
        hasStarted = false;
        ball = GetComponent<Rigidbody2D>();
        ballSpeed = initialSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1") && !hasStarted)
        {

            float direction = Random.Range(-1, 1);
            Vector2 initialForce = new Vector2();

            if (direction > 0)
            {
                initialForce.x = initialSpeed;
                initialForce.y = 0;
            }

            else
            {
                initialForce.x = -(initialSpeed);
                initialForce.y = 0;
            }

            ball.AddForce(initialForce);
            ball.gravityScale = 0.5F;

            hasStarted = true;
        }

        //if (Mathf.Abs(ball.velocity.x) != ballSpeed || Mathf.Abs(ball.velocity.y) != ballSpeed && hasStarted) {
        //    Vector2 currentDirection = new Vector2();

        //    if (ball.velocity.x < 0)
        //    {
        //        currentDirection.x = -(ballSpeed);
        //    }

        //    else if (ball.velocity.y < 0) {

        //        currentDirection.y = -(ballSpeed);
        //    }

        //    else if (ball.velocity)
        //    else
        //    {
        //        currentDirection.x = initialSpeed;
        //    }

        //    currentDirection.y = ball.velocity.y;

        //    ball.velocity = currentDirection;
        //}

        if (hasStarted)
        {
            Vector2 currentDirection = new Vector2();

            currentDirection.x = ball.velocity.x < 0 ? -(ballSpeed) : ballSpeed;
            currentDirection.y = ball.velocity.y < 0 ? -(ballSpeed) : ballSpeed;

            ball.velocity = currentDirection;
        }

        
    }

    void OnCollisionEnter2D(Collision2D col) {
        if ( col.gameObject.name == "Paddle1" || col.gameObject.name == "Paddle2" ) {
            ballSpeed += ballIncSpeed;
        }    
    
    }

}
