using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rigidbody : MonoBehaviour
{
    public new Rigidbody2D rb2D;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    //public abstract void Move(Vector2 direction);
}
