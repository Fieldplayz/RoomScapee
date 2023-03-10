using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using Photon.Pun;
using Photon.Realtime;

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

        if (!photonView.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        if (photonView.IsMine)
        {
            movement = context.ReadValue<Vector2>();

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

    private void Update()
    {
        
        
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
       LeaveRoom();
    }
    

    [PunRPC]
    public void LeaveRoom()
    {
        SceneManager.LoadScene(0);
    }
}
