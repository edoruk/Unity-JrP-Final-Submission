using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public PlayerController player;
    public UIController uiController;

    private bool onTrigger;

    public string title;
    public string description;
    public int expReward;
    private QuestType questType = QuestType.Kill;
    private int goalAmound = 3;

    private void Start()
    {
        uiController = GameObject.Find("UIManager").GetComponent<UIController>();
        
        title = "Quest 1";
        description = "Kill 3 monster.";
        expReward = 20;

        quest.Title = title;
        quest.Description = description;
        quest.ExpReward = expReward;
        
        quest.QuestGoal.questType = questType;
        quest.QuestGoal.goalAmount = goalAmound;

    }

    private void Update()
    {
        ShowQuestToPlayer();
        ShowQuestCompleted();
    }

    public void AcceptQuest()
    {
        quest.IsActive = true;
        player.quest = quest;
        Debug.Log(quest.Title + " accepted");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            onTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            onTrigger = false;
    }

    private void ShowQuestToPlayer()
    {
        if (Input.GetKeyDown(KeyCode.E) && onTrigger)
        {
            uiController._questCanvas.enabled = true;
        }
    }

    private void ShowQuestCompleted()
    {
        if (quest.QuestGoal.IsReached())
            uiController._questCompletedText.enabled = true;
    }
}
