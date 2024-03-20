using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class EnemyInfo : MonoBehaviour
{
    private Slider slider;
    private Transform _camera;
    private TextMeshProUGUI _enemyNameText;
    private Transform _enemyRoot;
    private PlayerController player;
    

    // Start is called before the first frame update
    private void Awake()
    {
        slider = GetComponent<Slider>();
        _camera = GameObject.Find("FreeLook Camera").GetComponent<Transform>();
        _enemyNameText = GetComponentInChildren<TextMeshProUGUI>();
        _enemyRoot = transform.root;
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        string cloneText = "(Clone)";
        _enemyNameText.text = _enemyRoot.gameObject.name.Replace(cloneText,"");

    }

    private void LateUpdate()
    {
        transform.LookAt(transform.forward + _camera.position);
        transform.Rotate(0,180,0);
        if (slider.value <= 0)
        {
            Destroy(_enemyRoot.gameObject);
            if (player.quest.IsActive)
            {
                player.quest.QuestGoal.EnemyKilled();
                if (player.quest.QuestGoal.IsReached())
                {
                    player.quest.Complete();
                }
            }
            
        }
            
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ShowInfo()
    {
    }

    public void UpdateHealthBar(float attackValue)
    {
        slider.value -= 0.3f;
    }
}
