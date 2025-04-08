using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playermovement : MonoBehaviour
{

    Animator ani;
    //access animator 
    SpriteRenderer spri;
    // access player sprite renderer

    public float speed = 2;
    //speed of jump
    public float j;

    public bool Jump = true;
    //if player is able to jump


    public int attack = 0;
    //if attack add to streak
    public UnityEvent<int> KillStreak;
    //kill streak screen

    public AudioSource audiosource;
    public AudioClip clip;
    //use sound





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

        //float upward = Input.GetAxis("Vertical");
        //go vertical
        //ani.SetFloat("jump up", Mathf.Abs(upward));

        if (Input.GetMouseButtonDown(0))
        {
            ani.SetTrigger("attack");
            //when left mouse is clicked, set trigger to do attack animation
            Jump = false;
            //don't allow jump
            attack++;
            //add to streak
            Debug.Log("Your damaging the enemy!");
        }

        if(attack > 4)
        {
            Debug.Log("Kill Streak!");
            //kill streak is working
            KillStreak.Invoke(attack);
            //make all things in event happen
            
            
            audiosource.PlayOneShot(clip);
            // play sound when player kills enemy
        }


        if (Jump == true)
        {
           if (Input.GetKeyDown(KeyCode.Space))
            {
                ani.SetTrigger("jump");
                Jump = true;
                
                //transform.position += transform.up * upward * speed * Time.deltaTime;
                //transform.position = Vector2.Lerp(bottom.position, top.position, curve.Evaluate(j));
                Debug.Log("pressed space");
            }
            
        }
    }


    public void GotHurt()
    {
        ani.SetTrigger("hurt");
        //got hurt
        Jump = false;
        //don't jump while hurt
    }

   
}
