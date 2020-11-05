using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Singleton;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private int currentLevel;
    private int maxLevelCount;

    public int CurrentLevel => currentLevel;

    private void OnEnable()
    {
        maxLevelCount = SceneManager.sceneCountInBuildSettings - 1;
        SubscribeToNecessaryEvets();
    }

    public void SubscribeToNecessaryEvets()
    {
        Observer.Instance.OnLoadNextLevel += LoadNextLevel;
        Observer.Instance.OnRestartGame += RestartLevel;
    }

    private void OnDestroy()
    {
        Observer.Instance.OnLoadNextLevel -= LoadNextLevel;
    }

    private void Start()
    {
        currentLevel = PlayerPrefs.HasKey(GameConstants.PrefsCurrentLevel)
            ? PlayerPrefs.GetInt(GameConstants.PrefsCurrentLevel)
            : 1;

        Observer.Instance.OnLevelManagerLoaded(currentLevel);
    }

    private void LoadNextLevel()
    {
        UpdateCurrentLevel();
        SceneManager.LoadScene(currentLevel);
    }

    private void UpdateCurrentLevel()
    {
        Debug.Log("UpdateActiveLevel");
        Debug.Log($"<color=red> Setted active level prefs to currentlevel = {currentLevel} </color>");
        currentLevel++;
        CheckFinishedGame();
        PlayerPrefs.SetInt(GameConstants.PrefsCurrentLevel, currentLevel);
    }

    private void CheckFinishedGame()
    {
        if(currentLevel > maxLevelCount)
        {
            currentLevel = 1;
            PlayerPrefs.SetInt(GameConstants.PrefsFinished, 1);
        }
    }

    private void RestartLevel()
    {
        DOTween.Clear(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    [ContextMenu("Clean prefs")]
    public void CleanPrefs()
    {
        PlayerPrefs.DeleteKey(GameConstants.PrefsCurrentLevel);
    }

}
