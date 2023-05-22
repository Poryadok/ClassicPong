using PM.PingPong.General;
using PM.UsefulThings;
using Zenject;

namespace PM.PingPong.MainMenu
{
	public class MainMenuSceneInstaller : MonoInstaller
	{
		public GeneralConfigHolder GeneralConfigHolder;
		public MainMenuSoundHolder MainMenuSoundHolder;
		
		public MainMenuController MainMenuController;

		public WindowManagerUT WindowManager;
		
		public override void InstallBindings()
		{
			Container.Bind<WindowManagerUT>()
				.FromInstance(WindowManager)
				.AsSingle()
				.NonLazy();

			Container.Bind<GeneralConfigHolder>()
				.FromInstance(GeneralConfigHolder)
				.AsSingle()
				.NonLazy();

			Container.Bind<MainMenuSoundHolder>()
				.FromInstance(MainMenuSoundHolder)
				.AsSingle()
				.NonLazy();

			Container.BindInterfacesAndSelfTo<MainMenuController>()
				.FromInstance(MainMenuController)
				.AsSingle()
				.NonLazy();

			Container.Bind<GameModeSelector>()
				.AsSingle()
				.NonLazy();
		}
	}
}