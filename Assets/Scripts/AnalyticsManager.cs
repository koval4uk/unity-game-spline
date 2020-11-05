using System;
using System.Collections;
using System.Collections.Generic;
using LionStudios;
using UnityEngine;
using UnityEngine.SceneManagement;
using Singleton;

public class AnalyticsManager : Singleton<AnalyticsManager>
{
    public Action<Observer> OnObserverLoaded = delegate { Debug.Log("Observer was loaded!"); };
    
    private void Awake()
    {
        PreventDuplicate();
        DontDestroyOnLoad(gameObject);
        LionKitInit();
        StartCoroutine(DelayLoadScene());
    }

    private void OnEnable()
    {
        OnObserverLoaded += RefreshObserver;
    }

    private void PreventDuplicate()
    {
        AnalyticsManager[] objs = FindObjectsOfType<AnalyticsManager>();

        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }
    }

    private void LionKitInit()
    {
        LionKit.Initialize();
    }
    
    private IEnumerator DelayLoadScene()
    {
        int currentLevel = PlayerPrefs.HasKey(GameConstants.PrefsCurrentLevel)
            ? PlayerPrefs.GetInt(GameConstants.PrefsCurrentLevel)
            : 1;
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(currentLevel);
    }
    
    private void RefreshObserver(Observer observer)
    {
        if (!PlayerPrefs.HasKey(GameConstants.PrefsFinished))
        {
            Debug.Log("Analytics subscribing!");
            observer.OnStartGame += LogStartLevel;
            observer.OnWinLevel += LogFinishLevel;
        }
        else
        {
            Debug.Log("All levels are finished!");
        }
    }

    private void LogStartLevel()
    {
        Analytics.Events.LevelStarted(LevelManager.Instance.CurrentLevel, 99);
    }

    private void LogFinishLevel()
    {
        int currentLevel = LevelManager.Instance.CurrentLevel + 1;
        Analytics.Events.LevelComplete(currentLevel, 99);
    }
}
