using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float rotSpeed;
    private Vector3 offsetPos = new Vector3(0, 1.5f, 2.5f);
    
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SetCamera();
    }

    private void SetCamera()
    {
        // float horizontalInput = Input.GetAxis("Horizontal");
        // transform.LookAt(player.transform.position);
        // transform.RotateAround(player.transform.position, Vector3.up, horizontalInput * rotSpeed );
    }

}

