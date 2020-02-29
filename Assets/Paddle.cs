using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Rigidbody2D body;
    private Vector2 change;
    private Vector2 currentPos;
    public bool isComputer;
    private Rigidbody2D ball;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        currentPos = body.position;
        ball = GameObject.Find("Ball").GetComponent<Rigidbody2D>();


        if(!isComputer)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isComputer)
        {
            change.y = Input.GetAxisRaw("Mouse Y") + currentPos.y;
            currentPos.y = change.y;
            change.x = currentPos.x;
            body.MovePosition(change);
        }

        else if (Mathf.Abs(ball.position.y) - currentPos.y > .05)
        {
            Vector2 newPos = new Vector2(currentPos.x, currentPos.y + (ball.position.y - currentPos.y));
            body.MovePosition(newPos);
        }

        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        body.velocity = Vector2.zero;
    }
}
