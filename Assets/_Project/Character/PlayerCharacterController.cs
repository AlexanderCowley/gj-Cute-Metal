using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    public Animator animator;
    CharacterController _characterController;
    [SerializeField] float MovementSpeed;
    void Awake() => _characterController = GetComponent<CharacterController>();

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        float yAxis = Input.GetAxis("Vertical") * MovementSpeed * Time.deltaTime;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {   
            animator.SetBool ("Idle", false);
            animator.SetBool ("Walk", true);
        }
        else
        {
            animator.SetBool ("Idle", true);
            animator.SetBool ("Walk", false);
        }
        if (Input.GetKey(KeyCode.S))
        {

        }
        else
        {

        }
        if (Input.GetKey(KeyCode.D))
        {

        }
        else
        {

        }
        if (Input.GetKey(KeyCode.A))
        {

        }
        else
        {

        }
        if (Input.GetKey(KeyCode.Space))
        {

        }
        else
        {

        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Run", true);
        }
        else
        {

        }
    }
}
