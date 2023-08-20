using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
//using NN;
//using System;
// using MathNet.Numerics;
// using MathNet.Numerics.LinearAlgebra;

public class FishMovement : MonoBehaviour
{
    public Rigidbody2D controller;
    private bool hasController = false;
    private Vector3 playerVelocity;
    //private float gravityValue = -9.81f;
    public float speed = 10.0F;
    public float rotateSpeed = 10.0F;
    public float FB = 0;
    public float LR = 0;

    //private ObjectTracker objectTracker;
    private Fish creature;

    void Awake()
    {
        //objectTracker = FindObjectOfType<ObjectTracker>();
        creature = GetComponent<Fish>();
        controller = GetComponent<Rigidbody2D>();
    }

    public void Move(float FB, float LR)
    {
        //clamp the values of LR and FB
        //LR = Mathf.Clamp(LR, -1, 1);
        //FB = Mathf.Clamp(FB, 0.2f, 2);
        

        //move the agent
        if (!creature.isDead)
        {
            // Rotate around y - axis
            transform.Rotate(0, 0, LR * rotateSpeed * -1); 

            // Move forward / backward
            Vector3 forward = transform.up;

            // Get the facing direction of the creature
            Vector3 facingDirection = transform.up;
            // Move the creature one unit in the facing direction
            transform.position += facingDirection * speed * Time.deltaTime * FB;
            
        }


        //playerVelocity.y = 0f;
        ////Checks to see if the agent is grounded, if it is, don't apply gravity
        //if (controller.isGrounded && playerVelocity.y < 0)
        //{
        //    playerVelocity.y = 0f;
        //}
        //else
        //{
        //    // Gravity
        //    playerVelocity.y += gravityValue * Time.deltaTime;
        //    controller.Move(playerVelocity * Time.deltaTime);
        //}
    }
}