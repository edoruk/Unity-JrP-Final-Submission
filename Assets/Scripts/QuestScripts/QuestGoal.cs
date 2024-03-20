using System;
using UnityEngine;

[Serializable]
public class QuestGoal
{
    public QuestType questType { get; set; }
    public int currentAmount { get; set; }
    public int goalAmount { get; set; }

    public bool IsReached()
    {
        return currentAmount >= goalAmount;
    }

    public void EnemyKilled()
    {
        if (questType == QuestType.Kill && !IsReached())
        {
            currentAmount++;
            Debug.Log(currentAmount + " enemy killed");
        }
    }
}

public enum QuestType
{
    Kill,
    Gather
}
