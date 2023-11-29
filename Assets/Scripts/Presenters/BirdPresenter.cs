using UnityEngine;
using Zenject;

public class BirdPresenter
{
    private BirdModel birdModel;
    private BirdView birdView;

    [Inject] private SignalBus signalBus;
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
        this.signalBus.Fire(new GameOverSignal());
    }

}