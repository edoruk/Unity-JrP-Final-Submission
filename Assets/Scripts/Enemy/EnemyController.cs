using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    private void Start()
    {
        _canvasGroup = GetComponentInChildren<CanvasGroup>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _canvasGroup.alpha = 1;
    }

    private void OnTriggerExit(Collider other)
    {
        _canvasGroup.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
