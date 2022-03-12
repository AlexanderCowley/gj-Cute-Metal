using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlayerCharacterController : MonoBehaviour
{
    public Animator animator;
    CharacterController _characterController;
    [SerializeField] private float MovementSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float crouchWalk;
    private Vector3 moveDirection;

    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isCrouched;
    [SerializeField] private float groundCheckDistrance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    [SerializeField] private float jumpHeight;

    private Vector3 velocity;
    float speed = 1;
    float rot;
    float rotspeed;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator = GetComponentInChildren<Animator>();
        _characterController = GetComponent<CharacterController>();


        float yAxis = Input.GetAxis("Vertical") * MovementSpeed * Time.deltaTime;
        float xAxis = Input.GetAxis("Horizontal") * MovementSpeed * Time.deltaTime;

        Vector3 moveObject = new Vector3(xAxis, 0, yAxis);

    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistrance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(0, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);

        if (isGrounded)
        {
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                WalkFoward();
            }
            else if (moveDirection != Vector3.zero && Input.GetKeyDown(KeyCode.LeftShift))
            {
                RunFoward();
            }
            else if (moveDirection == Vector3.zero)
            {
                Idle();
            }
            moveDirection *= MovementSpeed;

            if (Input.GetKey(KeyCode.Space))
            {
                JumpFoward();
            }

            if (Input.GetKey(KeyCode.C))
            {
                Crouch();
            }
        }

        if (isCrouched)
        {

        }

        rot += Input.GetAxis("Horizontal") * rotspeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDirection.y -= gravity * Time.deltaTime;
        _characterController.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        _characterController.Move(velocity * Time.deltaTime);
    }

    private void Idle()
    {
        animator.SetBool("Idle", true);
    }

    private void WalkFoward()
    {
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Idle", false);

            animator.SetBool("Walk", true);
            MovementSpeed = walkSpeed;
        }
        else
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Walk", false);

        }
    }

    private void WalkBack()
    {
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Idle", false);
            animator.SetBool("WalkBack", true);
        }
        else
        {
            animator.SetBool("Idle", true);
            animator.SetBool("WalkBack", false);
        }
    }

    private void RunFoward()
    {
        if (moveDirection != Vector3.zero && Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool("SlowRun", true);
            MovementSpeed = runSpeed;

            animator.SetBool("Walk", false);
        }
        else
        {
            animator.SetBool("SlowRun", false);
            animator.SetBool("Walk", true);
        }
    }

    private void JumpFoward()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("Jump", true);
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);

            animator.SetBool("Idle", false);
        }
        else
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Idle", true);
        }
    }

    private void Crouch()
    {
        if (Input.GetKey(KeyCode.C))
        {
            isCrouched = true;
            animator.SetBool("Idle", false);
            animator.SetBool("Crouch", true);
        }
        else
        {
            isCrouched = false;
            animator.SetBool("Idle", true);
            animator.SetBool("Crouch", false);
        }
    }

    private void CrouchWalk()
    {
        float moveZ = Input.GetAxis("Vertical");

        MovementSpeed = crouchWalk;
    }
}
