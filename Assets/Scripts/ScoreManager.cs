using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ScoreManager : IInitializable
{
    private SignalBus signalBus;

    public ScoreManager(SignalBus signalBus)
    {
        this.signalBus = signalBus;
    }

    private int score;

    public void Initialize()
    {
        score = 0;
    }

    public void ScoreIncrement(int value)
    {
        score += value;
        this.signalBus.Fire(new ScoreSignal(score));
    }
}

public class ScoreSignal
{
    public int score;

    public ScoreSignal(int value)
    {
        this.score = value;
    }
}