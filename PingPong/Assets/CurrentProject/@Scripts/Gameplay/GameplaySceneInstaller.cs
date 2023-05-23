using PM.PingPong.General;
using PM.UsefulThings;
using Zenject;

namespace PM.PingPong.Gameplay
{
	public class GameplaySceneInstaller : MonoInstaller
	{
		public GeneralConfigHolder GeneralConfigHolder;
		public GameplayConfigHolder GameplayConfigHolder;
		public GameplayPrefabHolder GameplayPrefabHolder;
		public GameplaySoundHolder GameplaySoundHolder;
		public InputFacade InputFacade;

		public GameplaySceneBuilder GameplaySceneBuilder;
		public GameplayLoopController GameplayLoopController;
		public GameplayStateController GameplayStateController;

		public WindowManagerUT WindowManager;

		public override void InstallBindings()
		{
			Container.Bind<WindowManagerUT>()
				.FromInstance(WindowManager)
				.AsSingle()
				.NonLazy();

			Container.Bind<GameplayConfigHolder>()
				.FromInstance(GameplayConfigHolder)
				.AsSingle()
				.NonLazy();

			Container.Bind<GeneralConfigHolder>()
				.FromInstance(GeneralConfigHolder)
				.AsSingle()
				.NonLazy();

			Container.Bind<GameplayPrefabHolder>()
				.FromInstance(GameplayPrefabHolder)
				.AsSingle()
				.NonLazy();

			Container.Bind<GameplaySoundHolder>()
				.FromInstance(GameplaySoundHolder)
				.AsSingle()
				.NonLazy();

			Container.BindInterfacesAndSelfTo<GameplaySceneBuilder>()
				.FromInstance(GameplaySceneBuilder)
				.AsSingle()
				.NonLazy();

			Container.Bind<GameplayLoopController>()
				.FromInstance(GameplayLoopController)
				.AsSingle()
				.NonLazy();

			Container.Bind<GameplayStateController>()
				.FromInstance(GameplayStateController)
				.AsSingle()
				.NonLazy();

			Container.Bind<InputFacade>()
				.FromInstance(InputFacade)
				.AsSingle()
				.NonLazy();

			Container.Bind<BestScoreController>()
				.AsSingle()
				.NonLazy();

			Container.BindFactory<bool, AbRocketLogic, AbRocketLogic.LogicFactory>()
				.FromFactory<AbRocketLogic.RocketLogicFactory>();
		}
	}
}