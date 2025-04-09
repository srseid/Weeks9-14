using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

public class knifemove : MonoBehaviour
{
    float knifeMoveLeft;
    //ability to rotate centre of rotation
    Coroutine knifeSwinging;
    //star and stop knife swinging
    IEnumerator swing;
    //swing
    public float speed = 0.5f;
    //speed of knife
    public float p = 0;
    //time.deltatime

    void Start()
    {
        knifeSwinging = StartCoroutine(MoveKnife());
        //initiate movement
    }
    IEnumerator MoveKnife()
    {
        while (true)
        {
            swing = MoveLeft();
            //move knife
            yield return StartCoroutine(swing);
        } 
       
    }

    IEnumerator MoveLeft()
    {
        if (p < speed)
        {
            p += Time.deltaTime;
            transform.Rotate(0, 0, (20 / speed) * Time.deltaTime);
            //move clockwise
        }
        else { 
            //move counter clockwise at start
            transform.Rotate(0, 0, -(50 / speed) * Time.deltaTime);
            yield return null;
        }
        
    }


    public void StopKnifeMovement()
    {
        StopCoroutine(knifeSwinging);
        StopCoroutine(swing);
        //stop moving when enemy dies
    }
   
    public void StartKnifeMovement()
    {
        StartCoroutine(MoveKnife());
        //start moving again after pressing button
    }
}
