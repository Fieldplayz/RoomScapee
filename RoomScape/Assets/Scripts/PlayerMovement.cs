using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

public class PlayerMovement : MonoBehaviourPunCallbacks
{
    [SerializeField] float movementSpeed = 5f;

    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator anim;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnMovement(InputValue value)
    {
        if (photonView.IsMine)
        {
            movement = value.Get<Vector2>();

            if (movement.x != 0 || movement.y != 0)
            {
                anim.SetFloat("X", movement.x);
                anim.SetFloat("Y", movement.y);

                anim.SetBool("IsWalking", true);
            }
            else
            {
                anim.SetBool("IsWalking", false);
            }
        }
        
    }

    private void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            rb.MovePosition(rb.position + movement * movementSpeed * Time.deltaTime);
            //rb.velocity = movement * movementSpeed * Time.deltaTime;
        }


    }
}
