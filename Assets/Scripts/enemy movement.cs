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

    public AudioSource aus;
    public AudioClip crit;

    public bool scratch = false;

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

        if (scratch==false)
        {
            plyr.Hit.AddListener(fine);

            Debug.Log("hi");
        }
    }

    
       
    
   
    private void hurt(int attack)
    {
        
        enani.SetTrigger("enemy hurt");
        //show hurt animation
        Debug.Log("ouch!");
        scratch = true;
    }

    private void die(int attack)
    {
        enani.SetBool("dead", true);
        //show death 
        scratch = false;
    }

    private void fine(int attack)
    {
        aus.PlayOneShot(crit);
        
    }
}
