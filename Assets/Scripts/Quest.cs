using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public enum QuestStatus { NotStarted, InProgress, Completed, Failed }
public class TaskObjective {
    public int Type;
    public string QuestDescription;
    public bool isCompleted;
    public QuestChristmasTreeObjective questChristmasTreeObjective;
    public QuestGiftsObjective questGiftsObjective;
    public QuestHuntObjective questHuntObjective;
    public QuestSurvivingObjective questSurvivingObjective;

    public TaskObjective(int type) {
        Type = type;
        if (type == 2){
            questChristmasTreeObjective = new QuestChristmasTreeObjective();
            QuestDescription = QuestChristmasTreeObjective.QuestDescription;
        }
        else if (type == 3) {
            questSurvivingObjective = new QuestSurvivingObjective();
            QuestDescription = QuestSurvivingObjective.QuestDescription;
        } else if (type == 1) {
            questGiftsObjective = new QuestGiftsObjective();
            QuestDescription = QuestGiftsObjective.QuestDescription;
        } else {
            questHuntObjective = new QuestHuntObjective();
            QuestDescription = QuestHuntObjective.QuestDescription;
        }
    }
}

[System.Serializable]
public class Quest
{
    public string questTitle;
    public QuestStatus status;

    public int curTask = 0;
    public int amount;
    public List<TaskObjective> objectives;

    public Quest(string title, int size)
    {
        questTitle = title;
        status = QuestStatus.NotStarted;
        objectives = new List<TaskObjective>(new TaskObjective[size]);
        amount  = size;
    }
}

[System.Serializable]
public class QuestGiftsObjective
{
    public static string QuestDescription = "Доставить подарки в дымоходы";
    public static int GiftsToCollect = 10;
    public bool isCompleted;

    public QuestGiftsObjective()
    {
        isCompleted = false;
    }
}

[System.Serializable]
public class QuestChristmasTreeObjective
{
    public static string QuestDescription = "Сохранить ёлку";
    public bool isCompleted;

    public QuestChristmasTreeObjective()
    {
        isCompleted = false;
    }
}

public class QuestSurvivingObjective
{
    public static string QuestDescription = "Выжить минуту";
    public bool isCompleted;

    public QuestSurvivingObjective()
    {
        isCompleted = false;
    }
}

public class QuestHuntObjective
{
    public static string QuestDescription = "Убить наблюдателя";
    public float Duration;
    public float Health;
    public bool isCompleted;

    public QuestHuntObjective()
    {
        isCompleted = false;
    }
}

