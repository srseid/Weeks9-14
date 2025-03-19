using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KitClock : MonoBehaviour
{
    public Transform hourHand;
    public Transform minuteHand;

    public float timeAnHourTakes = 5;

    public float t;
    public int hour = 0;

    public UnityEvent<int> OnTheHour;

    Coroutine clockIsRunning;
    IEnumerator doingOneHourOfMovement;

    void Start()
    {
        clockIsRunning = StartCoroutine(MoveTheClock());
    }

    IEnumerator MoveTheClock()
    {
        //start coroutine in coroutine
        //has to have yield return 
        while(true)
        {
            doingOneHourOfMovement = MoveTheClockHandsOneHour();
            yield return StartCoroutine(doingOneHourOfMovement);
        }
    }
    void Update()
    {
        //t += Time.deltaTime;

        //if (t > timeAnHourTakes)
        //{
        //    t = 0;
        //    OnTheHour.Invoke();

        //    hour++;
        //    if (hour == 12)
        //    {
        //        hour = 0;
            //}
        //}
    }

    IEnumerator MoveTheClockHandsOneHour()
    {
        t = 0;
        while(t< timeAnHourTakes)
        {
            t += Time.deltaTime;
            minuteHand.Rotate(0, 0, -(360 / timeAnHourTakes) * Time.deltaTime);
            hourHand.Rotate(0, 0, -(30 / timeAnHourTakes) * Time.deltaTime);
            yield return null;
            //checks if while statement is still true when back in place
        }
        hour++;
        if(hour == 13)
        {
            hour = 1;
        }
        OnTheHour.Invoke(hour);
        //while statements = keep doing this when that happens
        // (360/Time.deltaTime is the speed the hands go
        // -(360/Time.deltaTime makes it go clockwise


    }


    public void StopTheClock()
    {
        StopCoroutine(clockIsRunning);
        StopCoroutine(doingOneHourOfMovement);
    }
}
