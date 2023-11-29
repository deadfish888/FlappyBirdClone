using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private GameObject[] gameObjects;

    [Inject] private SignalBus signalBus;

    private void Awake()
    {
        foreach(var gameObject in gameObjects)
        {
            gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        this.signalBus.Subscribe<GameOverSignal>(this.GameOver);
    }

    private void GameOver()
    {
        foreach (var gameObject in gameObjects)
        {
            gameObject.SetActive(true);
        }
        restartButton.onClick.AddListener(() => restart());
    }

    private void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
