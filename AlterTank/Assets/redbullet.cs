using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redbullet : MonoBehaviour
{
    public RedTank redTank;
    public Rigidbody2D RedTank;
    public Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(redTank.transform.position);
        moveDirection = new Vector3(RedTank.GetRelativeVector(Vector2.up).x, RedTank.GetRelativeVector(Vector2.up).y, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * 0.04f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("northWalls"))
        {
            moveDirection = new Vector3(moveDirection.x, -moveDirection.y, 1);

        }
        if (collision.gameObject.CompareTag("southWalls"))
        {
            moveDirection = new Vector3(-moveDirection.x, moveDirection.y, 1);

        }
        if (collision.gameObject.CompareTag("bullet"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);

        }
    }
}
