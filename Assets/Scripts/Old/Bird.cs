using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Bird : MonoBehaviour
{
    [Inject]         private GameManager gameManager;
    [SerializeField] private float flapStrength;

    private Rigidbody2D BirdRigidbody;
    private bool isAlive;

    private void Awake()
    {
        BirdRigidbody = GetComponent<Rigidbody2D>();
        isAlive = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isAlive)
        {
            BirdRigidbody.velocity = (Vector3.up * flapStrength);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isAlive = false;
        //gameManager.SetOver(true);
    }
}
