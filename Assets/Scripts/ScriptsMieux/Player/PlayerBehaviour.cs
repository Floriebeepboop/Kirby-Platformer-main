using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private PlayerAnim anim;
    private SpriteRenderer spriteRenderer;
    private new Rigidbody2D rb2D;
    private Controls ctrl;
    public LayerMask ground;
    public Jumpforce JumpforceValue;
    private bool isGrounded = false;
    private float move;


    void Awake()
    {
        GetComponent<BoxCollider2D>();//
        rb2D = GetComponent<Rigidbody2D>();//
        spriteRenderer = GetComponent<SpriteRenderer>();//
        anim = GetComponent<PlayerAnim>();//
    }

   /* private void OnEnable() // on appell les controls liés aux imputs
    {
        ctrl = new Controls();
        ctrl.Enable();
        ctrl.Main.Move.performed += MoveOnPerformed;
        ctrl.Main.Move.canceled += MoveOnCanceled;
        ctrl.Main.Jump.performed += JumpOnPerformed;
    }*/

    public void MoveOnPerformed(InputAction.CallbackContext obj)
    {
        move = obj.ReadValue<float>();//on get 
        spriteRenderer.flipX = (move < 0);

        anim.Run();//joue l'anim depuis le script PlayerAnim
    }

    /*public void MoveOnCanceled(InputAction.CallbackContext obj)
    {
        move = 0;
        anim.MoveOnCanceled();//joue l'anim depuis le script PlayerAnim
    }*/

    public void JumpOnPerformed(InputAction.CallbackContext obj)
    {

        if (isGrounded)
        {
            isGrounded = false;
            rb2D.AddForce(new Vector2(0, JumpforceValue.jumpForce), ForceMode2D.Impulse);//si isgrounded est faux on ajoute une force au rigidbody pour sauter

            anim.OnJump();//joue l'anim depuis le script PlayerAnim
        }

    }

    void Update()//dansJump
    {

        if (isGrounded)
        {
            isGrounded = true;
            anim.NotJump();
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }


}


