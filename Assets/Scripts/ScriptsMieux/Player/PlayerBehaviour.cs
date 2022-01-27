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
    [SerializeField] private float jumpForce;
    private bool isGrounded = false;
    private float move;


    void Awake()
    {
        GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<PlayerAnim>();
    }

    private void OnEnable()
    {
        ctrl = new Controls();
        ctrl.Enable();
        ctrl.Main.Move.performed += MoveOnPerformed;
        ctrl.Main.Move.canceled += MoveOnCanceled;
        ctrl.Main.Jump.performed += JumpOnPerformed;
    }

    private void MoveOnPerformed(InputAction.CallbackContext obj)
    {
        move = obj.ReadValue<float>();
        spriteRenderer.flipX = (move < 0);

        anim.Run();//joue l'anim depuis le script PlayerAnim
    }

    private void MoveOnCanceled(InputAction.CallbackContext obj)
    {
        move = 0;
        anim.MoveOnCanceled();//joue l'anim depuis le script PlayerAnim
    }

    private void JumpOnPerformed(InputAction.CallbackContext obj)
    {

        if (isGrounded)
        {
            isGrounded = false;
            rb2D.AddForce(new Vector2(0,jumpForce), ForceMode2D.Impulse);

            anim.OnJump();//joue l'anim depuis le script PlayerAnim
        }

    }
}


