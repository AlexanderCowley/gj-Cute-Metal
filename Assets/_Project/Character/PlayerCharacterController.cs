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
        
    }
    void MoveOnInput()
    {
        float xAxis = Input.GetAxis("Horizontal") * MovementSpeed * Time.deltaTime;
        float yAxis = Input.GetAxis("Vertical") * MovementSpeed * Time.deltaTime;

        Vector3 moveObject = new Vector3(xAxis, 0, yAxis);

        object p = _characterController.Move(moveObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("Walk");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetTrigger("Crouch");
        }

        if (!Input.GetKeyDown(KeyCode.C))
        {
            animator.SetTrigger("Stand");
        }
    }
}
