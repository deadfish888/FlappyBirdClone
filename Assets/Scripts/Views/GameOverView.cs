using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class GameOverView : MonoBehaviour
{
    [SerializeField] private Button restartButton;

    private GameOverPresenter presenter;

    public void Init(GameOverPresenter presenter)
    {
        this.presenter = presenter;
        restartButton.onClick.AddListener(presenter.Restart);
    }
}

public class GameOverPresenter
{
    private GameOverView view;

    [Inject] private SignalBus signalBus;
    public void Init(GameOverView view)
    {
        this.view = view;
        this.signalBus.Subscribe<GameOverSignal>(this.GameOver);
        HideView();
    }

    private void GameOver()
    {
        ShowView();
    }

    private void ShowView()
    {
        foreach (Transform child in view.transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    internal void HideView()
    {
        foreach (Transform child in view.transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    internal void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
