using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject,5);
    }

    // public float timetodie = 5;
    // void Update()
    // {
    //     timetodie -= Time.deltaTime;
    //     if (timetodie <= 0) 
    //         Destroy(gameObject);
    // }
}
