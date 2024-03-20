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
    private Enemy _enemy;
    

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
        ChooseEnemyTagAndSetSliderMax();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = _enemy.Health / _enemy.MaxHealth;
    }

    private void ChooseEnemyTagAndSetSliderMax()
    {
        GameObject enemyRoot = _enemyRoot.gameObject;
        if (enemyRoot.CompareTag("EnemySlime"))
        {
            _enemy = enemyRoot.GetComponent<Slime>();
        }
        else if(enemyRoot.CompareTag("EnemyTurtle"))
        {
            _enemy = enemyRoot.GetComponent<Turtle>();
        }
    }

    public void Attack()
    {
        _enemy.TakeDamage();
        Debug.Log(_enemy.Name + " took " + _enemy.TakenDamage + " damage.");
    }
}
