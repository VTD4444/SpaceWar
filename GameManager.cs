using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject EnemyShip;
    public GameObject meteorite;
    private float timeLevel = 1;
    private float timer = 1;
    private float timer2 = 3;
    private float timeRate = 5;

    public static float screenheight;
    public static float screenwidth;

    private void Start()
    {
        screenheight = Camera.main.orthographicSize * 2;
        screenwidth = screenheight * ((float)Screen.width / Screen.height);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Vector3 PositionSpawn = new Vector3();
            PositionSpawn.y = screenheight / 2 + 1;
            PositionSpawn.x = Random.Range(-screenwidth/2, screenwidth/2);
            Instantiate(EnemyShip, PositionSpawn, quaternion.identity);
            timer = 1 * timeLevel;
        }

        timer2 -= Time.deltaTime;
        if (timer2 <= 0)
        {
            Vector3 PositionSpawn = new Vector3();
            PositionSpawn.y = screenheight / 2 + 1;
            PositionSpawn.x = Random.Range(-screenwidth/2,screenwidth/2);
            Instantiate(meteorite, PositionSpawn, quaternion.identity);
            timer2 = 3 * timeLevel;
        }

        timeRate -= Time.deltaTime;
        if (timeRate <= 0)
        {
            timeLevel /= 2;
            timeRate = 5;
        }
    }
}
