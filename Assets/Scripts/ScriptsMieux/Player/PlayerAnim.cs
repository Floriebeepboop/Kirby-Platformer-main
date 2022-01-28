using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator anim;//on reccupere l'animator associé au joueur


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Run()//si on court on active l'anim de run
    {
        anim.SetBool("run", true);
    }

    public void MoveOnCanceled() // move = 0;
    {
        anim.SetBool("run", false);
    }

    public void OnJump()//
    {
        anim.SetBool("Jump", true);
    }

    public void NotJump()
    {

         anim.SetBool("Jump", false);

    }

    public void RespawnTimer()//animation de respawn du joueur 
    {
        anim.SetBool("isOnFire", false);//le feu(piege) se désactive
    }

}
