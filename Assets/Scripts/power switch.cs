using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class powerswitch : MonoBehaviour
{
    public UnityEvent OnPowerSwitch;

    public SpriteRenderer Lighton;
    public SpriteRenderer Lightoff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //OnPowerSwitch.Invoke();
            Lighton.enabled = !Lighton.enabled;
            OnPowerSwitch.Invoke();

        }

        
    }
}
