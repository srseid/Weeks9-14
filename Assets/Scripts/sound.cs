using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
    public playermovement plyr;

    public AudioSource aus;
    public AudioClip crit;
    // Start is called before the first frame update
    void Start()
    {
        plyr.KillStreak.AddListener(hurt);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void hurt(int attack)
    {
        //aus.PlayOneShot(crit);
    }

}
