using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverScript : MonoBehaviour
{
    [SerializeField] float start = 9;
    [SerializeField] float stop = 16;
    [SerializeField] float speed = 3;
    bool floatRight;
    Rigidbody rb;
    Rigidbody thisRb;
    Vector3 currPos;
    Vector3 prevPos;
    Vector3 velocity;

    private void Start()
    {
        rb = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Rigidbody>();
        thisRb = this.gameObject.GetComponent<Rigidbody>();
        prevPos = this.transform.position;
    }

    void FixedUpdate()
    {
        movePlatform();
        platformVelocityUpdate();
    }

    void movePlatform()
    {
        if (floatRight)
        {
            thisRb.MovePosition(transform.position - transform.forward * Time.deltaTime * speed);
            if (transform.position.z < start)
                floatRight = !floatRight;
        }
        else
        {
            thisRb.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
            if (transform.position.z > stop)
                floatRight = !floatRight;
        }
    }

    //void movePlatform()
    //{
    //    if (floatRight)
    //    {
    //        transform.Translate(-Vector3.forward * Time.deltaTime * speed);
    //        if (transform.position.z < start)
    //            floatRight = !floatRight;
    //    }
    //    else
    //    {
    //        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    //        if (transform.position.z > stop)
    //            floatRight = !floatRight;
    //    }
    //}

    void platformVelocityUpdate()
    {
        currPos = transform.position;
        Vector3 media = (currPos - prevPos);
        velocity = media / Time.deltaTime;
        prevPos = currPos;
        currPos = transform.position;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    print("v1 " + rb.velocity);
    //    print("v2 " + velocity);
    //    if (other.gameObject.tag == "Player")
    //    {
    //        rb.velocity += velocity;
    //        print("v3 " + rb.velocity);
    //    }
           
    //}
}
