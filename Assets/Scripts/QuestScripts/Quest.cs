using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Quest
{
    public bool IsActive { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int ExpReward { get; set; }

    public QuestGoal QuestGoal;

    public void Complete()
    {
        IsActive = false;
        Debug.Log(Title + " completed");
    }

    public string ShowProgress()
    {
        return $"{QuestGoal.currentAmount}/{QuestGoal.goalAmount}";
    }
}
