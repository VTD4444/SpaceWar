using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    public float speed;

    void Update()
    {
        gameObject.transform.position += speed * Time.deltaTime * Vector3.up;
    }
}