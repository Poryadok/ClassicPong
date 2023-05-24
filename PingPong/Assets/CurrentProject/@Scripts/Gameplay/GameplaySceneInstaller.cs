using PM.PingPong.General;
using PM.PingPong.MainMenu;
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
		public BallMovementController BallMovementController;
		public RocketMovementController RocketMovementController;

		public WindowManagerUT WindowManager;

		public Rocket RocketTop;
		public Rocket RocketBottom;
		public Goal GoalTop;
		public Goal GoalBottom;
		public Ball Ball;
		public Wall[] Walls;
		
		public override void InstallBindings()
		{
			InstallFieldObjects();
			InstallControllers();
			InstallHolders();
			
			Container.Bind<WindowManagerUT>()
				.FromInstance(WindowManager)
				.AsSingle()
				.NonLazy();

			Container.BindInterfacesAndSelfTo<GameplaySceneBuilder>()
				.FromInstance(GameplaySceneBuilder)
				.AsSingle()
				.NonLazy();

			Container.Bind<InputFacade>()
				.FromInstance(InputFacade)
				.AsSingle()
				.NonLazy();

			Container.BindFactory<bool, AbRocketMovement, AbRocketMovement.MovementFactory>()
				.FromFactory<AbRocketMovement.RocketMovementFactory>();
			
			Container.Bind<Merchandiser>()
				.AsSingle();
			
			Container.Bind<RewardCollector>()
				.AsSingle()
				.NonLazy();
		}
		
		private void InstallFieldObjects()
		{
			Container.Bind<Rocket>()
				.WithId("top")
				.FromInstance(RocketTop)
				.NonLazy();
			Container.Bind<Rocket>()
				.WithId("bottom")
				.FromInstance(RocketBottom)
				.NonLazy();
			Container.Bind<Goal>()
				.WithId("top")
				.FromInstance(GoalTop)
				.NonLazy();
			Container.Bind<Goal>()
				.WithId("bottom")
				.FromInstance(GoalBottom)
				.NonLazy();
			Container.Bind<Wall[]>()
				.FromInstance(Walls)
				.AsSingle()
				.NonLazy();
			Container.Bind<Ball>()
				.FromInstance(Ball)
				.AsSingle()
				.NonLazy();
		}

		private void InstallHolders()
		{
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

		}

		private void InstallControllers()
		{
			Container.Bind<GameplayLoopController>()
				.FromInstance(GameplayLoopController)
				.AsSingle()
				.NonLazy();

			Container.Bind<GameplayStateController>()
				.FromInstance(GameplayStateController)
				.AsSingle()
				.NonLazy();

			Container.Bind<BallMovementController>()
				.FromInstance(BallMovementController)
				.AsSingle()
				.NonLazy();

			Container.Bind<RocketMovementController>()
				.FromInstance(RocketMovementController)
				.AsSingle()
				.NonLazy();

			Container.Bind<BestScoreController>()
				.AsSingle()
				.NonLazy();

		}
	}
}