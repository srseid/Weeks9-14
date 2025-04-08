using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

public class knifemove : MonoBehaviour
{
    
   

    float knifeMoveLeft;

    Coroutine knifeSwinging;
    IEnumerator swing;
   
    //swing
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
    IEnumerator MoveKnife()
    {
        while (true)
        {
            swing = MoveLeft();
            yield return StartCoroutine(swing);
        } 
       
    }


    IEnumerator MoveLeft()
    {
        if (p < speed && movement == true)
        {

            p += Time.deltaTime;
            transform.Rotate(0, 0, (20 / speed) * Time.deltaTime);
        }
        else { 
            //move clockwise
            transform.Rotate(0, 0, -(50 / speed) * Time.deltaTime);
            yield return null;
            movement = false;
        }
        
    }


    public void StopKnifeMovement()
    {
        StopCoroutine(knifeSwinging);
        StopCoroutine(swing);
    }
   
}
