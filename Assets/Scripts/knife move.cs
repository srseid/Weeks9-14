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
    //swing

    //public AnimationCurve ani;
    public BoxCollider2D square;
    public BoxCollider2D knife;
    public BoxCollider2D triangle;

    float oneSwing;
    public float speed = 2;
    //speed of knife
    public float p = 0;
    //time.deltatime

    // Start is called before the first frame update
    void Start()
    {
            knifeSwinging = StartCoroutine(MoveKnife());
        //start movement
    }

    private void Update()
    {
        
       
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
            swing = MoveRight();
            yield return StartCoroutine(swing);
        }
    }

    IEnumerator MoveLeft()
    {
        if (p < speed)
        {
            p += Time.deltaTime;
            transform.Rotate(0, 0, -(50 / speed) * Time.deltaTime);
           // rotate.Rotate = Vector2.Lerp(leftRest.position, rightRest.position, ani.Evaluate(p));
            yield return null;

            //move clockwise
        }
        else
        {
            if (audiosource.isPlaying == false)
            {
                audiosource.PlayOneShot(clip);
            }
        }
    }
    IEnumerator MoveRight()
    {
        while (p < speed) { 
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
    }
   
}
