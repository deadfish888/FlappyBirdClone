using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private Transform pipePrefab;
    [Inject]         private GameManager gameManager;
    [Inject]         private PipeFactory pipeFactory;
    private float spawnTimer;
    private float spawnTimerMax = 2f;
    private float pipeOffsetY = 10f;

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0f && ! gameManager.IsGameOver())
        {
            spawnTimer = spawnTimerMax;
            PipeSpawn();
        }
    }

    private void PipeSpawn()
    {
        var pipeTransform = pipeFactory.Create();
        pipeTransform.transform.SetParent(transform);
        pipeTransform.transform.localPosition = new Vector2(0f, Random.Range(-pipeOffsetY, pipeOffsetY));
    }
}
