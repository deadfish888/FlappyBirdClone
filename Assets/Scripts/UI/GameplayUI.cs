using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class GameplayUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [Inject] private SignalBus signalBus;

    private void Start()
    {
        this.signalBus.Subscribe<ScoreSignal>(UpdateScore);
    }
    public void UpdateScore(ScoreSignal obj)
    {
        scoreText.text = "Score: "+ obj.score;
    }
}
