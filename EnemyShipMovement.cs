using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyShipMovement : MonoBehaviour
{
    private float speed = 3f;
    private float firerate = 1f;
    public GameObject EnemyBullet;
    public PlayerShipMovement playershipmovement;
    
    void Update()
    {
        firerate -= Time.deltaTime;
        if (firerate < 0)
        {
            Instantiate(EnemyBullet, gameObject.transform.position + new Vector3(0, (float)-0.9, 0), quaternion.identity);
            firerate = 1f;
        }
        gameObject.transform.position += speed * Time.deltaTime * Vector3.down;
    }
}
