using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointerevents : MonoBehaviour
{
    //change sprite on enter and exit
    //spawn prefab on click

    public GameObject prefab;
    public RectTransform steak;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnMouseEnter()
    {
        steak.localScale = Vector3.one * 0.6f;
    }

    public void OnMouseExit()
    {
        steak.localScale = Vector3.one;
    }

    public void OnMouseClick()
    {
        Instantiate(prefab);

        
       
    }
}
