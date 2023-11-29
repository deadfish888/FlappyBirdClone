using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Pipe : MonoBehaviour
{
    [Inject] private GameManager gameManager;
    [Inject] private ScoreManager scoreManager;
    [SerializeField] private float movingSpeed = 10f;
    private float deadZone = -45f;
    void Update()
    {
        if (gameManager.IsGameOver())
        {
            return;
        }
        transform.position += Vector3.left * Time.deltaTime * movingSpeed;
        if(transform.position.x <= deadZone)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            scoreManager.ScoreIncrement(1);
        }
    }
}
public class PipeFactory : PlaceholderFactory<Pipe>
{
}