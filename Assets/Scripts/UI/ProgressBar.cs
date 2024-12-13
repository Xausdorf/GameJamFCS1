using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider progressBar;  // Ссылка на UI Slider

    public QuestManager questManager; // ссылка на квест манагер

    public TaskUpdater taskUpdater;

    public bool fstspawnObserver = true;

    private GameObject spawned;

    public PlayerLifeCountController playerLifeCountController;

    public bool fst = true;
    private float currentProgress = 0f;  // Текущий прогресс

    public Health health;

    // Эта переменная будет вызываться для обновления прогресса

    public void Update() {
        int curQuest = questManager.CurLevel;
        int cur = questManager.Levels[curQuest].curTask;
        if ((curQuest == 0 && cur == 3) || (curQuest == 1 && cur == 5) ||( curQuest == 2 && cur == 7)) {
            questManager.CheckQuestObjectiveCompletion(questManager.Levels[curQuest]);
        }
        if (playerLifeCountController.curLifeCount <= 0){
            questManager.Fail();
        }
        if (fst == true) {
            taskUpdater.UpdateTaskObjectiveUI(fst);
            fst = false;
        }
        if (questManager.Levels[curQuest].objectives[cur].Type == 3) {
            // Debug.Log("kmdskdm");
            if (health.curHealth <= 0) {
                questManager.Fail();
            }
            UpdateSurvivalTask(curQuest, cur);
        } else if (questManager.Levels[curQuest].objectives[cur].Type == 4) {
            // Debug.Log("kmdskdm");
            if (fstspawnObserver) {
                Debug.Log("Goyda");
                spawned = ObserverSpawner.instance.Spawn(questManager.player.transform.position + Vector3.up * 5);
                fstspawnObserver = false;
            }
            if (spawned == null) {
                progressBar.value = 1;
                UpdateHuntTask(curQuest, cur);
            }
            else if (Mathf.Abs(spawned.transform.position.x) >= 80) {
                Destroy(spawned);
                questManager.Fail();
            }
            
        } else if (questManager.Levels[curQuest].objectives[cur].Type == 2){
            UpdateChristmasTreeTask(curQuest, cur);
        } else {
            if (progressBar.value >= 1f) {
                Debug.Log("Big goyda");
                progressBar.value = 0;
                taskUpdater.UpdateTaskObjectiveUI(false);
            }
        }
    }

    public void UpdateSurvivalTask(int curQuest, int cur) {
        UpdateTimeProgress();
        if (currentProgress >= 1) {
            questManager.Levels[curQuest].objectives[cur].isCompleted = true;
            progressBar.value = 0f;
            currentProgress = 0f;
            Debug.Log("Goyda");
            taskUpdater.UpdateTaskObjectiveUI(false);
        }
    }

    public void UpdateHuntTask(int curQuest, int cur) {
        
        if (progressBar.value == 1) {
            progressBar.value = 0;
            fstspawnObserver = true;
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
            Debug.Log("Goyda");
            taskUpdater.UpdateTaskObjectiveUI(false);
        }
    }

    public void UpdateGiftTask() {
        currentProgress += 1f / 10f;
        progressBar.value = currentProgress;
        if (progressBar.value >= 1) {
            taskUpdater.UpdateTaskObjectiveUI(false);
            progressBar.value = 0;
            currentProgress = 0f;
        }
    }
    public void UpdateTimeProgress()
    {
        currentProgress += 1f/60f * Time.deltaTime; 
        progressBar.value = currentProgress;
    }

    public void UpdateProgress(float progress)
    {
        currentProgress = Mathf.Clamp01(progress);  // Обновляем прогресс от 0 до 1
        progressBar.value = currentProgress;  // Обновляем значение шкалы
    }

    void Start()
    {
        spawned = null;
        fstspawnObserver = true;
        progressBar.value = 0f;  // Начинаем с нулевого прогресса
        questManager = FindObjectOfType<QuestManager>();
        taskUpdater = FindObjectOfType<TaskUpdater>();
        playerLifeCountController = FindObjectOfType<PlayerLifeCountController>();
        health = questManager.player.GetComponent<Health>();
    }
}
