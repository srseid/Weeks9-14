using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

public class knifemove : MonoBehaviour
{
    
    public Transform leftRest;
    //left restriction for knife
    public Transform rightRest;
    //right restriction for knife
    public UnityEvent<int> tooClose;
    // alerts that you're too close to the knife
    public AudioSource audiosource;
    public AudioClip clip;
    //use sound

    float knifeMoveLeft;
    float knifeMoveRight;

    Coroutine knifeSwinging;
    Coroutine swingingKnife;
    IEnumerator swing;
    IEnumerator swing2;
    //swing

    //public AnimationCurve ani;
    public BoxCollider2D knife;
  

    float oneSwing;

    public float speed = 0.5f;
    //speed of knife
    public float p = 0;
    //time.deltatime

    public bool movement = true;

    void Start()
    {
        knifeSwinging = StartCoroutine(MoveKnife());
        //start movement
    }

    private void Update()
    {
        if (movement == false)
        {
            swingingKnife = StartCoroutine(MoveKnife2());
        }
    }


    IEnumerator MoveKnife()
    {
        while (true)
        {
            swing = MoveLeft();
            yield return StartCoroutine(swing);
        } 
       
    }


    IEnumerator MoveKnife2()
    {
        while (true)
        {
            swing2 = MoveRight();
            yield return StartCoroutine(swing2);
        }
    }


    IEnumerator MoveLeft()
    {
        if (p < speed && movement == true)
        {

            p += Time.deltaTime;
            transform.Rotate(0, 0, (20 / speed) * Time.deltaTime);
            // rotate.Rotate = Vector2.Lerp(leftRest.position, rightRest.position, ani.Evaluate(p));
        }
        else { 
            //move clockwise
            transform.Rotate(0, 0, -(50 / speed) * Time.deltaTime);
            yield return null;
            movement = false;
        }
        //if (audiosource.isPlaying == false)
        //{
        //    audiosource.PlayOneShot(clip);
        //}
    }


    IEnumerator MoveRight()
    {
        while (p < speed && movement==false)
        {
            p += Time.deltaTime;
            transform.Rotate(0, 0, (50 / speed) * Time.deltaTime);
            yield return null;
            //move counter clockwise
        }
    }

    public void StopKnifeMovement()
    {
        StopCoroutine(knifeSwinging);
        StopCoroutine(swing);
        StopCoroutine(swingingKnife);
        StopCoroutine(swing2);
    }
   
}
