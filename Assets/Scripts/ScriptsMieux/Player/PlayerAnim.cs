using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Run()//move = obj.ReadValue<float>(); spriteRenderer.flipX = (move< 0);
    {
        anim.SetBool("run", true);
    }

    public void MoveOnCanceled() // move = 0;
    {
        anim.SetBool("run", false);
    }

    public void OnJump()
    {
        anim.SetBool("Jump", true);
    }

    void Update()
    {

        anim.SetBool("Jump", false);
        

    }

    public void RespawnTimer()
    {
        anim.SetBool("isOnFire", false);
    }

    public void OnDie()
    {

    }

}
