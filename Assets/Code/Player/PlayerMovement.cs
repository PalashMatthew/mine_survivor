using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joy;
    public float speed;

    Rigidbody rb;

    public Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();        
    }

    private void FixedUpdate()
    {
        if (joy.Horizontal != 0 || joy.Vertical != 0)
        {
            transform.forward = new Vector3(joy.Horizontal, 0, joy.Vertical);
        }

        float vertical = joy.Vertical;
        float horizontal = joy.Horizontal;

        rb.velocity = new Vector3(horizontal, 0, vertical) * speed * Time.fixedDeltaTime;

        anim.SetFloat("speed", rb.velocity.sqrMagnitude);
    }
}
