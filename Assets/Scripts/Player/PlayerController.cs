using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 2f;
    private float rotationSpeed = 2f;
    private Animator _animator;

    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float verticalInput = Input.GetAxis("Vertical");
        Debug.Log(verticalInput);
        float horizontalInput = Input.GetAxis("Horizontal");
        
        transform.Translate(Vector3.forward * verticalInput * movementSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * horizontalInput * rotationSpeed);
        
        if(verticalInput == 0)
            _animator.SetFloat("movementSpeed", 0);
        else
        {
            _animator.SetFloat("movementSpeed",0.3f);
        }
    }
}
