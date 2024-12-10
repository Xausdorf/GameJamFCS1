using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

// подарки - 1, ёлка - 2, выживание - 3, охота - 4

public class QuestManager : MonoBehaviour
{
    public List<Quest> Levels;

    void Start()
    {
        Levels = new List<Quest>{new Quest("Уровень 1"), new Quest("Уровень 2"), new Quest("Уровень 3")};
        System.Random rnd = new();
        foreach(var Level in Levels) {
            int prev = -1;
            foreach(var task in Level.objectives) {
                int type = rnd.Next(1, 5);
                if (type == prev) {
                    type = prev + 1 == 5? rnd.Next(0, prev) : rnd.Next(prev + 1, 5);
                }
                task.Type = type;
            }
        }
    }

    private void CheckQuestObjectiveCompletion(Quest quest)
    {
        bool allObjectivesCompleted = true;

        foreach (var objective in quest.objectives)
        {
            if (objective.Type == 1 && !objective.questGiftsObjective.isCompleted) {
                 allObjectivesCompleted = false;
            }
            if (objective.Type == 2 && !objective.questChristmasTreeObjective.isCompleted) {
                 allObjectivesCompleted = false;
            }
            if (objective.Type == 3 && !objective.questSurvivingObjective.isCompleted) {
                 allObjectivesCompleted = false;
            }
            if (objective.Type == 4 && !objective.questHuntObjective.isCompleted) {
                 allObjectivesCompleted = false;
            }
        }

        if (allObjectivesCompleted)
        {
            quest.status = QuestStatus.Completed;
            // Можете добавить какие-то действия, когда квест завершён
            Debug.Log("Quest Completed: " + quest.questTitle);
        } else {
            quest.status = QuestStatus.Failed;
            // Действия при провале квеста
            Debug.Log("Quest Failed: " + quest.questTitle);
        }
    }
}

