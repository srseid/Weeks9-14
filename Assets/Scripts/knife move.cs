using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

public class knifemove : MonoBehaviour
{
    public Transform rotate;
    public Transform squarePos;
    public Transform knifePos;
    public UnityEvent<int> tooClose;
    public AudioSource audiosource;
    public AudioClip clip;

    float knifeMoveLeft;
    float knifeMoveRight;

    Coroutine knifeSwinging;
    Coroutine swingingKnife;
    IEnumerator swing;

    public BoxCollider2D square;
    public BoxCollider2D knife;
    public BoxCollider2D triangle;

    float oneSwing;
    public float speed = 2;
    public float p = 0;
    // Start is called before the first frame update
    void Start()
    {
            knifeSwinging = StartCoroutine(MoveKnife());
    }

    private void Update()
    {
        Vector3 squarePosition = transform.position;
        Vector3 knifePosition = transform.position;
        //if (squarePosition <= knifePosition)
        {
         //   swingingKnife = StartCoroutine(MoveKnife2());
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
            swing = MoveRight();
            yield return StartCoroutine(swing);
        }
    }

    IEnumerator MoveLeft()
    {
        if (p < speed)
        {
            p += Time.deltaTime;
            rotate.Rotate(0, 0, -(50 / speed) * Time.deltaTime);
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
            rotate.Rotate(0, 0, (50 / speed) * Time.deltaTime);
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
