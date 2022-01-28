using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Trap : MonoBehaviour
{
   //public bool fireIsTrigger = false;
    private Animator trapAnim;
    public Jumpforce JumpforceValue;
    public Speed speed;
    private void Start()
    {
        GetComponent<BoxCollider2D>().isTrigger = true; //setting boxcollider trigger by default
        trapAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag( "Player"))//on regarde" si il y a collision entre l'object qui porte le tag "player" et le collider du trap
        {
            //fireIsTrigger = true;
            trapAnim.SetBool("isOnFire", true);
            Debug.Log($"{name}Triggered");//affiche dans la console si jamais c'est bien trigger
            JumpforceValue.jumpForce = 0;//on reset la jumpforce a 0, stop la '' glissade '' ?
            speed.speed = 0;//on avance plus
        }
        else
        {
  
            trapAnim.SetBool("isOnFire", false);//n'active pas  le bool ddans l'animator
        }
       
    }

}
/*
 * le jeu est lancé
 * {
 *      on recupere le component collider du feu qui est trigger/activé par défaut
 *      on recupere l'animator du feu
 * }
 * quand le collider du joueur touche le collider du feu
 * {
 *  le feu s'active
 *      lancer l'animation du feu qui explose
 *  si il ne se passe rien
 *  {
 *  l'animation ne se lance pas 
 * }
 */

