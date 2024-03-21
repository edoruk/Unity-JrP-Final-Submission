using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private CanvasGroup _canvas1;
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemySlime") || other.CompareTag("EnemyTurtle"))
        {
            CanvasGroup canvasGroup = other.transform.Find("Canvas/Canvas2").GameObject().GetComponent<CanvasGroup>();
            Debug.Log(canvasGroup.name);
            canvasGroup.alpha = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("EnemySlime") || other.CompareTag("EnemyTurtle"))
        {
            CanvasGroup canvasGroup = other.transform.Find("Canvas/Canvas2").GameObject().GetComponent<CanvasGroup>();
            Debug.Log(canvasGroup.name);
            canvasGroup.alpha = 1;
        }
    }
    
}

