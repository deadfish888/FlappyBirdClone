using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdView : MonoBehaviour
{
    private BirdPresenter birdPresenter;

    public void Init(BirdPresenter birdPresenter)
    {
        this.birdPresenter = birdPresenter;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        birdPresenter.PipeCollide();
    }
}
