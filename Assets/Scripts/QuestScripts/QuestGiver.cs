using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public PlayerController player;

    private bool onTrigger;

    public string title;
    public string description;
    public int expReward;
    private QuestType questType = QuestType.Kill;
    private int goalAmound = 3;

    private void Start()
    {
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
        GiveQuestToPlayer();
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

    private void GiveQuestToPlayer()
    {
        if (Input.GetKeyDown(KeyCode.E) && onTrigger)
        {
            AcceptQuest();
        }
    }
}
