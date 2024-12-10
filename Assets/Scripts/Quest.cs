using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum QuestStatus { NotStarted, InProgress, Completed, Failed }
public class TaskObjective {
    public int Type;
    public QuestChristmasTreeObjective questChristmasTreeObjective;
    public QuestGiftsObjective questGiftsObjective;
    public QuestHuntObjective questHuntObjective;
    public QuestSurvivingObjective questSurvivingObjective;
    public TaskObjective(int type, int GiftsToCollect) {
        Type = type;
        questGiftsObjective = new QuestGiftsObjective(GiftsToCollect);
    }
    public TaskObjective(int type, float dur, int health) 
    {
        Type = type;
        questHuntObjective = new QuestHuntObjective(dur, health);
    }

    public TaskObjective(int type) {
        Type = type;
        if (type == 2){
            questChristmasTreeObjective = new QuestChristmasTreeObjective();
        }
        else {
            questSurvivingObjective = new QuestSurvivingObjective();
        }
    }
}

[System.Serializable]
public class Quest
{
    public string questTitle;
    public QuestStatus status;

    public int amount;
    public List<TaskObjective> objectives;

    public Quest(string title)
    {
        questTitle = title;
        status = QuestStatus.NotStarted;
        objectives = new List<TaskObjective>();
    }
}

[System.Serializable]
public class QuestGiftsObjective
{
    public int GiftsToCollect;
    public bool isCompleted;

    public QuestGiftsObjective(int GiftsAmount)
    {
        GiftsToCollect = GiftsAmount;
        isCompleted = false;
    }
}

[System.Serializable]
public class QuestChristmasTreeObjective
{
    public bool isCompleted;

    public QuestChristmasTreeObjective()
    {
        isCompleted = false;
    }
}

public class QuestSurvivingObjective
{
    public bool isCompleted;

    public QuestSurvivingObjective()
    {
        isCompleted = false;
    }
}

public class QuestHuntObjective
{
    public float Duration;
    public float Health;
    public bool isCompleted;

    public QuestHuntObjective(float dur, float health)
    {
        Duration = dur;
        Health = health;
        isCompleted = false;
    }
}

