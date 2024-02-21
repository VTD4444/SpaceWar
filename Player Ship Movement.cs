using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class PlayerShipMovement : MonoBehaviour
{
    private float speed = 5;
    public GameObject PlayerBullet;
    public Transform firetransform;
    public int HP = 10;
    public UIGameManager uigamemanager;
    public int score = 0;
    void Update()
    {
        #region MouseInput

        // Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // mousepos.z = 0;
        // Vector3 direction = (mousepos - gameObject.transform.position).normalized;
        // gameObject.transform.position += speed * Time.deltaTime * direction;

        #endregion

        #region KeyInput

        Vector3 temp = new Vector3();
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            temp.x = -1;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            temp.x = 1;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            temp.y = 1;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            temp.y = -1;
        temp.Normalize();
        gameObject.transform.position += speed * Time.deltaTime * temp;

        #endregion

        #region limitpos

        if (gameObject.transform.position.x < -GameManager.screenwidth / 2)
        {
            gameObject.transform.position =
                new Vector3(-GameManager.screenwidth / 2, gameObject.transform.position.y, gameObject.transform.position.z);
        }

        if (gameObject.transform.position.x > GameManager.screenwidth / 2)
        {
            gameObject.transform.position =
                new Vector3(GameManager.screenwidth / 2, gameObject.transform.position.y, gameObject.transform.position.z);
        }

        if (gameObject.transform.position.y < -GameManager.screenheight / 2)
        {
            gameObject.transform.position =
                new Vector3(gameObject.transform.position.x, -GameManager.screenheight / 2, gameObject.transform.position.z);
        }

        if (gameObject.transform.position.y > GameManager.screenheight / 2)
        {
            gameObject.transform.position =
                new Vector3(gameObject.transform.position.x, GameManager.screenheight / 2, gameObject.transform.position.z);
        }

        #endregion

        #region shoot
        // if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        // {
        //     Instantiate(PlayerBullet, gameObject.transform.position + new Vector3(0, (float)0.97, 0),
        //         Quaternion.identity);
        // }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(PlayerBullet, firetransform.position, quaternion.identity);
        }
        #endregion
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyBullet")
        {
            HP -= 1;
            uigamemanager.hptext.text = "HP: " + HP;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Enemy")
        {
            HP -= 3;
            uigamemanager.hptext.text = "HP: " + HP;
            score += 10;
            uigamemanager.scoretext.text = "SCORE: " + score;
            Destroy(other.gameObject);
            AudioManager.instance.PlaySFX(AudioManager.instance.destroy);
        }
        else if (other.gameObject.tag == "Meteorite")
        {
            HP -= 5;
            uigamemanager.hptext.text = "HP: " + HP;
            score += 30;
            uigamemanager.scoretext.text = "SCORE: " + score;
            Destroy(other.gameObject);
            AudioManager.instance.PlaySFX(AudioManager.instance.destroy);
        }

        if (HP <= 0)
        {
            HP = 0;
            uigamemanager.endgamepopup.SetActive(true);
            uigamemanager.scorefinal.text = "SCORE: " + score;
            uigamemanager.hptext.text = "HP: " + HP;
            AudioManager.instance.PlaySFX(AudioManager.instance.gameOver);
            Time.timeScale = 0;
        }
    }
}
