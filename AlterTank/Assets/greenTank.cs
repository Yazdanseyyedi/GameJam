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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
        if (Input.GetKeyDown(KeyCode.R))
        {
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            TankMove(1,0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            TankMove(-1,0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            TankMove(0,1);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            TankMove(0,-1);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (BulletLimit > 0)
            {
                BulletLimit -= 1;

            }

            if (BulletLimit > 0)
            {
                GameObject bullet;
                bullet = Instantiate(bulletObject);
                bullet.transform.position = transform.position + new Vector3(GreenTank.GetRelativeVector(Vector2.up).x, GreenTank.GetRelativeVector(Vector2.up).y, 1);
            }
        }
    }

    public void TankMove(int forward,int rotate)
    {
        float translation = forward * moveSpeed;
        float rotation = -rotate * rotationSpeed;
        GreenTank.rotation += rotation * Mathf.Sign(Vector2.Dot(GreenTank.velocity, GreenTank.GetRelativeVector(Vector2.up)));
        tankDiraction = new Vector3(GreenTank.GetRelativeVector(Vector2.up).x, GreenTank.GetRelativeVector(Vector2.up).y, 1);
        transform.position += tankDiraction * translation;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Score.UpdateRedScore();
            Score.ReloadGame();
            //Destroy(this.gameObject);
            //Destroy(collision.gameObject);


        }

    }
}
