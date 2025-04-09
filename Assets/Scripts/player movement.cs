using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class playermovement : MonoBehaviour
{

    Animator ani;
    //access animator 
    SpriteRenderer spri;
    // access player sprite renderer

    public float speed = 2;
    //speed of jump
    
    public int attack = 0;
    //if attack add to streak

    public UnityEvent<int> Hit;
    //hit/attack events
    public UnityEvent<int> KillStreak;
    //kill streak screen
    public UnityEvent<int> EndScreen;
    //end screen

    public TextMeshProUGUI killstreakwords;
    //show streak wording as pop up
   

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        //access animator
        spri = GetComponent<SpriteRenderer>();
        //access player sprite renderer
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            ani.SetTrigger("attack");
            //when left mouse is clicked, set trigger to do attack animation
            attack++;
            //add to streak
            Hit.Invoke(attack);
            Debug.Log("Damage Dealt!");
        }

        if (attack == 4)
        { 
            Debug.Log("Attack Streak!");
            //kill streak is working
            killstreakwords.enabled = true;
        }

        if (attack == 8)
        {
            Debug.Log("Enemy Defeated!");
            EndScreen.Invoke(attack);
            //show that the player won
            attack = 0;
            //reset
        }

        if (attack > 4)
        {
            killstreakwords.enabled = false;
            //make words disappear after attacking again
        }
    }


   
}
