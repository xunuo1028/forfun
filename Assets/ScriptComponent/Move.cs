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
    private Animator animator;


    private Vector3 translation;
    private bool isRun;
    private bool isMove;



    Ray groundCheck = new Ray();
    RaycastHit rh;
    Rigidbody rigidbody;

    // Use this for initialization
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            Jump();
        }

        if(Input.GetKeyUp(KeyCode.F))
        {
            isRun = !isRun;
        }

        Walk();
    }

    void FixedUpdate()
    {
        IsOnGround();
    }

    private void Walk()
    {
        translation = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (translation != Vector3.zero)
        {
            if (isRun)
            {
                transform.Translate(translation * speed * 2 * Time.deltaTime);
                //animator.SetBool("Run", true);
                //animator.SetBool("Walk", false);
            }
            else
            {
                transform.Translate(translation * speed * Time.deltaTime);
                //animator.SetBool("Run", false);
                //animator.SetBool("Walk", true);
            }
            //Debug.Log(translation.normalized);
            Vector3 nor = translation.normalized;
        }
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
            rigidbody.AddForce(Vector3.up * jumpSpeed);
        }
    }
}
