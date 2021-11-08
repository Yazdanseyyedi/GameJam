using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenTank : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    public Rigidbody2D GreenTank;
    private Vector3 tankDiraction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TankMove();
    }

    public void TankMove()
    {
        float translation = Input.GetAxis("Vertical") * moveSpeed;
        float rotation = -Input.GetAxis("Horizontal") * rotationSpeed;
        GreenTank.rotation += rotation * Mathf.Sign(Vector2.Dot(GreenTank.velocity, GreenTank.GetRelativeVector(Vector2.up)));
        tankDiraction = new Vector3(GreenTank.GetRelativeVector(Vector2.up).x, GreenTank.GetRelativeVector(Vector2.up).y, 1);
        transform.position += tankDiraction * translation;
    }
}
