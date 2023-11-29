using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPresenter
{
    private BirdModel birdModel;
    private BirdView birdView;

    public event EventHandler OnStatusChanged;
    public void Init(BirdModel bird, BirdView birdView)
    {
        birdModel = bird;
        this.birdView = birdView;
    }

    public void OnSpaceOrClick()
    {
        birdView.GetComponent<Rigidbody2D>().velocity = (Vector3.up * birdModel.FlapStrength);
    }

    public void PipeCollide()
    {
        birdModel.IsAlive = false;
        OnStatusChanged?.Invoke(this, EventArgs.Empty);
    }

}
