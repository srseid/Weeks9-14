using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knight : MonoBehaviour
{
    Animator animator;
    SpriteRenderer sr;
    public AudioSource audioSource;
    public AudioClip ac;
    public float speed = 2;
    public bool canRun = true;


    
    //public AnimationCurve ani;
    //public float t;
    //public Transform knightPos;
    //public Transform squarePos;



    void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
       
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");

        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       

        sr.flipX = (direction < 0);
        //flip sr when using left arrow
        animator.SetFloat("movement", Mathf.Abs(direction));
        //call movement in animator
        //switch to run animation when direction is not 0

        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("attack");
            //when left mouse clicked set trigger for attack in animator
            canRun = false;
            //cannot run until full animation is done
        }

        if (canRun == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                transform.position = mouse;
            }
            //transform.position += transform.right * direction * speed * Time.deltaTime;
            transform.Translate(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0, 0);
            transform.Translate(0, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0);
            //move player
        }
    }

    public void AttackHasFinished()
    {
        Debug.Log("Ready to run again");
        canRun = true;
        //added event to animation
        //void is linked to last frame of attack animation
    }

    public void FootstepSound()
    {
        
            audioSource.PlayOneShot(ac);
      
    }
}
