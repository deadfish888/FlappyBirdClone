using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller
{
    [SerializeField] private GameObject pipePrefab;
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        Container.BindInterfacesAndSelfTo<ScoreManager>().AsSingle();
        Container.BindInterfacesAndSelfTo<GameManager>().AsSingle();
        Container.Bind<BirdView>().FromComponentInHierarchy().AsSingle();
        Container.BindFactory<Pipe, PipeFactory>().FromComponentInNewPrefab(pipePrefab);

        Container.DeclareSignal<GameOverSignal>();
        Container.DeclareSignal<ScoreSignal>();
    }
}