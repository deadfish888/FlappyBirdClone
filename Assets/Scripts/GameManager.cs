using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class GameManager : ITickable, IInitializable
{
    private SignalBus signalBus;
    private DiContainer _container;
    private BirdView birdView;
    private GameOverView gameOverView;

    public GameManager(SignalBus signalBus, DiContainer container, BirdView birdView, GameOverView gameOverView)
    {
        this.signalBus = signalBus;
        _container = container;
        this.birdView = birdView;
        this.gameOverView = gameOverView;
    }

    private GameOverPresenter gameOverPresenter;
    private BirdPresenter birdPresenter;
    private bool isOver;

    public void Initialize()
    {
        isOver = false;
        birdPresenter = _container.Instantiate<BirdPresenter>();

        BirdModel bird = new BirdModel();
        bird.FlapStrength = 20f;
        birdPresenter.Init(bird, birdView);
        birdView.Init(birdPresenter);
        birdPresenter.OnStatusChanged += BirdPresenter_OnStatusChanged;

        gameOverPresenter = _container.Instantiate<GameOverPresenter>();
        gameOverPresenter.Init(gameOverView);
        gameOverView.Init(gameOverPresenter);
    }

    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isOver)
        {
            birdPresenter.OnSpaceOrClick();
        }
    }

    private void BirdPresenter_OnStatusChanged(object sender, EventArgs e)
    {
        isOver = true;
        this.signalBus.Fire(new GameOverSignal());
    }

    public bool IsGameOver()
    {
        return isOver;
    }

}

public class GameOverSignal
{

}
