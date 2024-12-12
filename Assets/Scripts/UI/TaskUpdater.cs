using UnityEngine;
using TMPro;

public class TaskUpdater : MonoBehaviour
{
    public QuestManager questManager;    // Ссылка на QuestManager
    public TextMeshProUGUI subTaskText;
    // Start is called before the first frame update
    void Start()
    {
        questManager = FindObjectOfType<QuestManager>(); // Найти QuestManager в сцене
        // subTaskText = GameObject.Find("SubTaskText");
        // int curQuest = questManager.CurLevel;
    }

    public void UpdateQuest()
    {
        if (questManager != null) {
            int curQuest = questManager.CurLevel;
            int cur = questManager.Levels[curQuest].curTask;
            subTaskText.text = questManager.Levels[curQuest].objectives[0].QuestDescription;
            // gameObject.SetActive(true);
            if (questManager.Levels[curQuest].objectives[cur].isCompleted) {
                UpdateTaskObjectiveUI(false);
                // gameObject.SetActive(true);
            }
            // subTaskText.text = "ГОЙДА";
            if (subTaskText == null) {
                Debug.LogError("Компонент Text не найден на объекте SubTaskText!");
            }
            
        }
    }

    public void UpdateTaskObjectiveUI(bool fst)
    {
        int curQuest = questManager.CurLevel;
        int cur = questManager.Levels[curQuest].curTask;
        if (cur < questManager.Levels[curQuest].amount)
        {
            if (!fst) questManager.Levels[curQuest].curTask++;
            TaskObjective currentSubTask = questManager.Levels[curQuest].objectives[questManager.Levels[curQuest].curTask];
            Debug.Log("SHIT");
            subTaskText.text = currentSubTask.QuestDescription; // Обновляем текст подзадачи
        }
    }
}
