using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float movementSpeed = 2.0f;
    private float rotationSpeed = 2.0f;
    public float _jumpForce = 5.0f;
    
    private Animator _animator;
    private UIController _uiControllerScript;
    private Rigidbody _playerRb;

    private bool isOnGround = true;
    private bool isRunning = false;
    

    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _uiControllerScript = GameObject.Find("UIManager").GetComponent<UIController>();
        _playerRb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        
        transform.Translate(Vector3.forward * verticalInput * movementSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * horizontalInput * rotationSpeed);
        
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _animator.SetFloat("movementSpeed",0.6f);
            }
            else
            {
                _animator.SetFloat("movementSpeed",0.3f);
            }
        }
        else
        {
            _animator.SetFloat("movementSpeed",0.0f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            _playerRb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _animator.SetTrigger("jumpTrigger");
            isOnGround = false;
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
        if (other.gameObject.tag == "Ground")
            isOnGround = true;
    }
}
