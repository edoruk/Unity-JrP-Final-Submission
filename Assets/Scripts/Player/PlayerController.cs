using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float rotationSpeed = 2.0f;
    public float _jumpForce = 4.0f;
    public float distanceToAttack;
    
    private Animator _animator;
    private UIController _uiControllerScript;
    private Rigidbody _playerRb;



    private bool isOnGround = true;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _uiControllerScript = GameObject.Find("UIManager").GetComponent<UIController>();
        _playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
        RunMovementAnimations();
        FindAndKillEnemiesInRange();
    }

    private void MovePlayer()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        float movementSpeed = Input.GetKey(KeyCode.LeftShift) ? 4.0f : 2.0f;
        
        transform.Translate(Vector3.forward * verticalInput * movementSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * horizontalInput * rotationSpeed);
    }

    private void RunMovementAnimations()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            _animator.SetFloat("movementSpeed", Input.GetKey(KeyCode.LeftShift) ? 0.6f : 0.3f);
        }
        else
        {
            _animator.SetFloat("movementSpeed",0.0f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            isOnGround = false;
            _playerRb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _animator.SetTrigger("jumpTrigger");
        }
    }

    
    private void FindAndKillEnemiesInRange()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, distanceToAttack);
        int count = 0;
        foreach (var collider in colliders)
        {
            if (collider.tag == "Enemy" && Input.GetKeyDown(KeyCode.X))
            {
                Destroy(collider.gameObject);
                Debug.Log(collider.tag + " destroyed");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("StoneCircle"))
        {
            _uiControllerScript.SetUsageText(other);
            Debug.Log(other.gameObject.name + " triggered");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("StoneCircle"))
        {
            _uiControllerScript.ResetUsageText();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Ground":
                isOnGround = true;
                break;
        }
    }
}
