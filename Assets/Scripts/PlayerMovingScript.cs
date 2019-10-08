using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovingScript : MonoBehaviour
{
    [SerializeField] float rotSpeed = 3;
    Vector2 rotation = Vector2.zero;
    [SerializeField] float MoveSpeed;
    [SerializeField] float JumpForce;
    Rigidbody rb;

    void Start()
    {
        //LockMouse(true);
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        RoatateWithMouse();
        WalkWithKeyboard();
    }

    void RoatateWithMouse()
    {
        rotation.x += -Input.GetAxis("Mouse Y");
        rotation.x = Mathf.Clamp(rotation.x, -15f, 15f);
        rotation.y += Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector2(0, rotation.y) * rotSpeed;
        Camera.main.transform.localRotation = Quaternion.Euler(rotation.x * rotSpeed, 0, 0);
    }

    void WalkWithKeyboard()
    {
        
        rb.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * MoveSpeed) + (transform.right * Input.GetAxis("Horizontal") * MoveSpeed));

        if (Input.GetKeyDown("space"))
        {
            RaycastHit hit = new RaycastHit();
            
            if (Physics.Raycast(transform.position + Vector3.forward/2, -Vector3.up, out hit))if (hit.distance <= 1)
                if (hit.distance <= 1)
                {
                    rb.AddForce(transform.up * JumpForce);
                    return;
                }
            if (Physics.Raycast(transform.position - Vector3.forward / 2, -Vector3.up, out hit))
                if (hit.distance <= 1)
                {
                    rb.AddForce(transform.up * JumpForce);
                    return;
                }
            if (Physics.Raycast(transform.position + Vector3.right / 2, -Vector3.up, out hit))
                if (hit.distance <= 1)
                {
                    rb.AddForce(transform.up * JumpForce);
                    return;
                }
            if (Physics.Raycast(transform.position - Vector3.right / 2, -Vector3.up, out hit))
                if (hit.distance <= 1)
                {
                    rb.AddForce(transform.up * JumpForce);
                    return;
                }              
        }            
    }


    public void LockMouse(bool locked)
    {
        if (locked)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        
    }
}
