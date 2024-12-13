using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

// подарки - 1, ёлка - 2, выживание - 3, охота - 4

public class QuestManager : MonoBehaviour
{
    public List<Quest> Levels;

    public GameObject player;
    public int CurLevel = 0;
    public string sceneToLoadAfterQuestComplete = "NextScene";

    void Start()
    {
        player = GameObject.Find("Player");
        Levels = new List<Quest>{new Quest("Уровень 1", 3), new Quest("Уровень 2", 5), new Quest("Уровень 3", 7)};
        System.Random rnd = new();
        foreach(var Level in Levels) {
            int prev = -1;
            for(int i = 0; i < Level.amount; i++) {
                int type = rnd.Next(1, 5);
                if (type == prev) {
                    type = prev + 1 == 5? rnd.Next(1, prev == 1? 2:prev) : rnd.Next(prev + 1, 5);
                }
                if (type == 2) {
                    type = 3;
                }
                if (type == 0) {
                    type = 4;
                }
                TaskObjective task = new TaskObjective(type);
                Level.objectives[i] = task;
            }
        }
    }

    public void Fail() {
        sceneToLoadAfterQuestComplete = "FailScene";
        Destroy(player);
        LoadNextScene();
    }

    // void Update() {
    //     CheckQuestObjectiveCompletion(Levels[CurLevel]);
    // }

    void Awake()
    {
        // Делаем объект неуничтожаемым при смене сцен
        DontDestroyOnLoad(gameObject);
    }

    private void LoadNextScene()
    {
        if (CurLevel == 3) {
            SceneManager.LoadScene("WinScene");
        }
        // Загрузка следующей сцены
        SceneManager.LoadScene(sceneToLoadAfterQuestComplete);
    }

    public void CheckQuestObjectiveCompletion(Quest quest)
    {
        bool allObjectivesCompleted = true;
        if (allObjectivesCompleted)
        {
            quest.status = QuestStatus.Completed;
            // Можете добавить какие-то действия, когда квест завершён
            CurLevel++;
            sceneToLoadAfterQuestComplete = $"CoolScene{CurLevel + 1}";
            LoadNextScene();
            Debug.Log("Quest Completed: " + quest.questTitle);
        }
    }
}

