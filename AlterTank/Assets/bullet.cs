using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public greenTank greenTank;
    public Rigidbody2D GreenTank;
    public Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        
        moveDirection = new Vector3(GreenTank.GetRelativeVector(Vector2.up).x, GreenTank.GetRelativeVector(Vector2.up).y, 0);
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
            moveDirection = new Vector3(moveDirection.x, -moveDirection.y, 0);

        }
        if (collision.gameObject.CompareTag("southWalls"))
        {
           moveDirection = new Vector3(-moveDirection.x, moveDirection.y, 0);

        }
        if (collision.gameObject.CompareTag("bullet"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("tank"))
        {
            Destroy(this.gameObject);
        }

    }
}
