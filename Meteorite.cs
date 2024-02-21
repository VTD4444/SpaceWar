using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class Meteorite : MonoBehaviour
{
    public float speed = 3f;
    private int HP = 5;
    public PlayerShipMovement playershipmovement;

    private void Start()
    {
        playershipmovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShipMovement>();
    }

    void Update()
    {
        gameObject.transform.position += speed * Time.deltaTime * Vector3.down;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            Destroy(other.gameObject);
            HP -= 1;
            if (HP <= 0)
            {
                playershipmovement.score += 30;
                playershipmovement.uigamemanager.scoretext.text = "SCORE: " + playershipmovement.score;
                Destroy(gameObject);
                AudioManager.instance.PlaySFX(AudioManager.instance.destroy);
            }
        }
    }
}