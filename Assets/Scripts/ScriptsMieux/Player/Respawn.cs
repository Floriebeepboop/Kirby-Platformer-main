using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Vector3 respawnPoint;
    private Rigidbody2D rb2D;
    public void Awake()
    {
        respawnPoint = new Vector3(0, 0.2f, -2);
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fire"))
        {
            StartCoroutine(RespawnTimer());
        }
    }

    IEnumerator RespawnTimer()
    {
        rb2D.velocity = Vector2.zero;
       yield return new WaitForSeconds(3);

        transform.position = respawnPoint;
        Debug.Log("Respawn");
    }

}