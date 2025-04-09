using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class enemymovement : MonoBehaviour
{
    Animator enani;
    //access animator 
    SpriteRenderer enspri;
    // access player sprite renderer
  
    public playermovement plyr;

    public playermovement criticalHit;

    public playermovement norm;

    // Start is called before the first frame update
    void Start()
    {
        enani = GetComponent<Animator>();
        //access animator
        enspri = GetComponent<SpriteRenderer>();
        //access player sprite renderer

        criticalHit.EndScreen.AddListener(die);
        //play death animation when end screen pops up

        plyr.Hit.AddListener(hurt);
        //show enemy was hit

        norm.Normal.AddListener(fine);
    }

   
    private void hurt(int attack)
    {
        enani.SetTrigger("enemy hurt");
        //show hurt animation
        Debug.Log("ouch!");
    }

    private void die(int attack)
    {
        enani.SetBool("dead", true);
        //show death 
    }

    private void fine(int attack)
    {
        enani.SetBool("dead", false);
        //don't do death animation when reset
    }
}
