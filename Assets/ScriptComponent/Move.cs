using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 3f;
    private float g = 10f;
    public float jumpSpeed = 12f;
    private Vector3 moveV;
    public bool isOnGround;



    Ray groundCheck = new Ray();
    RaycastHit rh;
    Rigidbody rigidbody;

    // Use this for initialization
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        IsOnGround();
    }

    private void Walk()
    {

    }

    public void IsOnGround()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out rh, 0.2f))
        {
            Debug.DrawRay(transform.position, Vector3.down);
            if(rh.collider.tag == "ground")
            {
                isOnGround = true;
            }
            else
            {
                isOnGround = false;
            }
        }
    }

    public void Jump()
    {
        if(rigidbody != null || isOnGround == true)
        {
            Debug.Log("hahaha");
            rigidbody.AddForce(Vector3.up * jumpSpeed);
        }
    }
}
