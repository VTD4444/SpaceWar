using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet : MonoBehaviour
{
    public float speed;
    public PlayerShipMovement playershipmovement;

    private void Start()
    {
        playershipmovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShipMovement>();
    }

    void Update()
    {
        gameObject.transform.position += speed * Time.deltaTime * Vector3.up;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            playershipmovement.score += 10;
            playershipmovement.uigamemanager.scoretext.text = "SCORE: " + playershipmovement.score;
            Destroy(gameObject);
            Destroy(other.gameObject);
            AudioManager.instance.PlaySFX(AudioManager.instance.destroy);
        }
        else if (other.gameObject.tag == "EnemyBullet")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}