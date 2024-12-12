using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider progressBar;  // Ссылка на UI Slider

    public QuestManager questManager; // ссылка на квест манагер

    public TaskUpdater taskUpdater;

    public bool fst = true;
    private float currentProgress = 0f;  // Текущий прогресс

    // Эта переменная будет вызываться для обновления прогресса

    public void Update() {
        int curQuest = questManager.CurLevel;
        int cur = questManager.Levels[curQuest].curTask;
        if (fst == true) {
            taskUpdater.UpdateTaskObjectiveUI(fst);
            fst = false;
        }
        if (questManager.Levels[curQuest].objectives[cur].Type == 3) {
            UpdateSurvivalTask(curQuest, cur);
        } else if (questManager.Levels[curQuest].objectives[cur].Type == 4) {
            UpdateHuntTask(curQuest, cur);
        } else if (questManager.Levels[curQuest].objectives[cur].Type == 1) {
            UpdateGiftTask(curQuest, cur);
        } else {
            UpdateChristmasTreeTask(curQuest, cur);
        }
    }

    public void UpdateSurvivalTask(int curQuest, int cur) {
        UpdateTimeProgress();
        if (currentProgress >= 1) {
            questManager.Levels[curQuest].objectives[cur].isCompleted = true;
            progressBar.value = 0f;
            Debug.Log("Goyda");
            taskUpdater.UpdateTaskObjectiveUI(false);
        }
    }

    public IEnumerator UpdateHuntTask(int curQuest, int cur) {
        yield return new WaitForSeconds(2);
        progressBar.value = 1;
        if (progressBar.value == 1) {
            progressBar.value = 0;
            questManager.Levels[curQuest].objectives[cur].isCompleted = true;
            progressBar.value = 0f;
            Debug.Log("Goyda");
            taskUpdater.UpdateTaskObjectiveUI(false);
        }
    }

    public IEnumerator UpdateChristmasTreeTask(int curQuest, int cur) {
        yield return new WaitForSeconds(2);
        progressBar.value = 1;
        if (progressBar.value == 1) {
            progressBar.value = 0;
            questManager.Levels[curQuest].objectives[cur].isCompleted = true;
            progressBar.value = 0f;
            Debug.Log("Goyda");
            taskUpdater.UpdateTaskObjectiveUI(false);
        }
    }

    private void UpdateGiftTask(int curQuest, int cur) {
        currentProgress = Inventory.instance.GetItemCount("Present") / 10f;
        progressBar.value = currentProgress;
    }
    public void UpdateTimeProgress()
    {
        currentProgress += 1f/20f * Time.deltaTime; 
        progressBar.value = currentProgress;
    }

    public void UpdateProgress(float progress)
    {
        currentProgress = Mathf.Clamp01(progress);  // Обновляем прогресс от 0 до 1
        progressBar.value = currentProgress;  // Обновляем значение шкалы
    }

    void Start()
    {
        progressBar.value = 0f;  // Начинаем с нулевого прогресса
        questManager = FindObjectOfType<QuestManager>();
        taskUpdater = FindObjectOfType<TaskUpdater>();
    }
}
