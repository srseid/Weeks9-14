using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class enemymovement : MonoBehaviour
{
    Animator enani;
    //access animator 
    SpriteRenderer enspri;
    // access player sprite renderer
    public UnityEvent<int> Stop;
    public int enattack = 0;
    public GameObject kill;

    // Start is called before the first frame update
    void Start()
    {
        enani = GetComponent<Animator>();
        //access animator
        enspri = GetComponent<SpriteRenderer>();
        //access player sprite renderer
    }

    // Update is called once per frame
    void Update()
    {
        GameObject smth = Instantiate(kill);
        playermovement myScript = GetComponent<playermovement>();
        //myScript.attack = att;
        //myScript.playermovement = KillStreak();

        if(Time.deltaTime == 5)
        {
            enani.SetTrigger("enemy attack");
            enattack++;
        }

        //if (att++)
        {
            enani.SetTrigger("enemy hurt");
            Stop.Invoke(enattack);
        }

        if(enattack == 10)
        {
            //KillStreak.Invoke(enattack);
        }

        
    }
}
