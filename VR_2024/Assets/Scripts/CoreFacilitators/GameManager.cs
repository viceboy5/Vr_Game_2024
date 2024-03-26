using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent onAwake, onSceneInit, onLateInit, onGameStart, onGameOver, onRestartGame;
    private GameAction _gameOverAction;
    private readonly WaitForFixedUpdate _wffu = new();

    private void Awake()
    {
        onAwake.Invoke();
        _gameOverAction.Raise += GameOver;
    }

    private void OnDisable()
    {
        _gameOverAction.Raise -= GameOver;
    }

    private void Start()
    {
        onSceneInit.Invoke();
        StartCoroutine(LateInit());
    }
    
    private IEnumerator LateInit()
    {
        yield return _wffu;
        yield return _wffu;
        yield return _wffu;
        onLateInit.Invoke();
    }

    public void StartGame()
    {
        onGameStart.Invoke();
    }

    public void GameOver()
    {
        onGameOver.Invoke();
    }

    public void GameOver(GameAction action)
    {
        onGameOver.Invoke();
    }

    public void RestartGame()
    {
        onRestartGame.Invoke();
    }
}
