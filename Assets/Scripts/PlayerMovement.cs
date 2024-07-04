using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController playerController;
    public float runSpeed = 40.0f;
    private float horizontalMove = 0.0f;
    [SerializeField] private Animator playerAnimator;
    bool jump = false;
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        playerAnimator.SetFloat("speed", Math.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }
    private void FixedUpdate()
    {
        playerController.Move(horizontalMove * Time.fixedDeltaTime * runSpeed, false, jump);
        jump = false;
    }
}
