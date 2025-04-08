using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{

    Animator ani;
    //access animator 
    SpriteRenderer spri;
    // access player sprite renderer
    public float speed = 2;
    //speed of jump
    public bool Jump = true;
    //if player is able to jump
    public bool attack = false;

    public float j;
    public AnimationCurve curve;
    public Transform top;
    public Transform bottom;




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

        float upward = Input.GetAxis("Vertical");
        //go vertical
        ani.SetFloat("jump up", Mathf.Abs(upward));

        if (Input.GetMouseButtonDown(0))
        {
            ani.SetTrigger("attack");
            //when left mouse is clicked, set trigger to do attack animation
            Jump = false;
            attack = true;
            //cannot jump while attacking
        }


       
        if(Jump == true)
        {
           if (Input.GetKeyDown(KeyCode.Space))
            {
                ani.SetTrigger("jump");
                Jump = true;
                attack = false;
                //transform.position += transform.up * upward * speed * Time.deltaTime;
                //transform.position = Vector2.Lerp(bottom.position, top.position, curve.Evaluate(j));
                Debug.Log("pressed space");
            }
            
        }
    }


    public void GotHurt()
    {
        ani.SetTrigger("hurt");
        Jump = false;
    }

   
}
