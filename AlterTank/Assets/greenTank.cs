﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenTank : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    public Rigidbody2D GreenTank;
    private Vector3 tankDiraction;
    public GameObject bulletObject;
    public float BulletDeadTime;
    public int BulletLimit;
    public Scores Score;
    public string Activecombo;
    public GameObject mineObject;
    public comboplacer comboplacer;
    public int MineLimit=3;
    public bool shieldActivate;
    public GameObject shield;
    public Animator animator;
    public bool defeated;
    public reloadgame reloadgame;
    public soundController soundController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (defeated)
        {
            reloadgame.Reload();
        }
        else
        {
            if (BulletLimit == 0)
            {
                BulletDeadTime -= Time.deltaTime;

            }
            if (BulletDeadTime < 0)
            {
                BulletLimit = 5;
                BulletDeadTime = 5f;
            }
            if (shieldActivate)
            {
                shield.SetActive(true);
            }
            else
            {
                shield.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                TankMove(1, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                TankMove(-1, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                TankMove(0, 1);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                TankMove(0, -1);
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                if (Activecombo == "" || Activecombo == "shield")
                {

                    if (BulletLimit > 0)
                    {
                        soundController.shotsound();
                        BulletLimit -= 1;
                        GameObject bullet;
                        bullet = Instantiate(bulletObject);
                        bullet.transform.position = transform.position + new Vector3(GreenTank.GetRelativeVector(Vector2.up).x, GreenTank.GetRelativeVector(Vector2.up).y, 1);
                    }
                }
                if (Activecombo == "mine")
                {
                    if (MineLimit > 0)
                    {
                        soundController.minesound();
                        MineLimit -= 1;
                        GameObject mine;
                        mine = Instantiate(mineObject);
                        mine.transform.position = transform.position - new Vector3(GreenTank.GetRelativeVector(Vector2.up).x, GreenTank.GetRelativeVector(Vector2.up).y, 1);

                    }

                    if (MineLimit == 0)
                    {
                        Activecombo = "";
                        MineLimit = 3;
                    }
                }

            }
        }
        
    }

    public void TankMove(int forward,int rotate)
    {
        float translation = forward * moveSpeed;
        float rotation = -rotate * rotationSpeed;
        GreenTank.rotation += rotation * Mathf.Sign(Vector2.Dot(GreenTank.velocity, GreenTank.GetRelativeVector(Vector2.up)));
        tankDiraction = new Vector3(GreenTank.GetRelativeVector(Vector2.up).x, GreenTank.GetRelativeVector(Vector2.up).y, 0);
        transform.position += tankDiraction * translation;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            if (!defeated)
            {
                if (shieldActivate)
                {
                    shieldActivate = false;
                    soundController.shieldbreaksound();
                    Destroy(collision.gameObject);

                }
                else
                {
                    Score.UpdateRedScore();
                    animator.SetBool("GreenDefeat", true);
                    Score.ReloadGame();
                    defeated = true;
                    soundController.explosionsound();
                }
            }
            Destroy(collision.gameObject);



            //Destroy(this.gameObject);
            //Destroy(collision.gameObject);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("mine"))
        {
            if (!defeated)
            {
                if (shieldActivate)
                {
                    shieldActivate = false;
                    soundController.shieldbreaksound();
                    Destroy(collision.gameObject);


                }
                else
                {
                    Score.UpdateRedScore();
                    animator.SetBool("GreenDefeat", true);
                    Score.ReloadGame();
                    Destroy(collision.gameObject);
                    defeated = true;
                    soundController.explosionsound();

                }
            }
            


        }
        if (collision.gameObject.CompareTag("combo"))
        {

            //Destroy(this.gameObject);
            Destroy(collision.gameObject);
            soundController.combosound();
            Activecombo = comboplacer.combos[UnityEngine.Random.Range(0, comboplacer.combos.Length)];
            if (Activecombo == "shield")
            {

                shieldActivate = true;
            }
        }
    }
}
