using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class TaskViewer : MonoBehaviour
{
    public bool isCompleted;
    public string TaskDescription = "";
    public QuestManager questManager;
    // Start is called before the first frame update
    void Start() {
        questManager = FindObjectOfType<QuestManager>();
    }
    // Update is called once per frame
    void Update()
    {
        questManager = FindObjectOfType<QuestManager>();
        int curQuest = questManager.CurLevel;
        int cur = questManager.Levels[curQuest].curTask;
        isCompleted = questManager.Levels[curQuest].objectives[cur].isCompleted;
        TaskDescription = questManager.Levels[curQuest].objectives[cur].QuestDescription;
    }
}
