using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventDemo : MonoBehaviour
{
    public RectTransform burger;

    public UnityEvent OnTimerFinished;
    public float timerLength = 2;
    public float t;

    private void Update()
    {
        t += Time.deltaTime;
        if (t < timerLength)
        {
            OnTimerFinished.Invoke();
            t = 0;
        }
        //if(t < timerLength)
        //{
        //    t += Time.deltaTime;
            
        //}
        //else
        //{
        //    OnTimerFinished.Invoke();
        //}
    }
    public void MouseJustEntered()
    {
        Debug.Log("Mouse just entered me");

        burger.localScale = Vector3.one * 1.2f;
    }


    public void MouseJustExited()
    {
        Debug.Log("Mouse just exited");
        burger.localScale = Vector3.one;
    }


}