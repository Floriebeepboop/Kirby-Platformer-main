using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity : Rigidbody
{
    public Speed speed;
    private new Rigidbody2D rb2D;
    public MaxSpeed maxspeed;
    private float move;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var isRunning = Mathf.Abs(rb2D.velocity.x);
        if (isRunning < maxspeed.maxspeed)
        {
            rb2D.AddForce(new Vector2(speed.speed * move, 0));
        }
    }
}
