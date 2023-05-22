using PM.UsefulThings;
using Unity.Netcode;
using Zenject;

namespace PM.PingPong.General
{
	public class ProjectInstaller : MonoInstaller
	{
		public SoundManager SoundManagerPrefab;
		
		public override void InstallBindings()
		{
			Container.Bind<NetworkManager>()
				.FromInstance(NetworkManager.Singleton)
				.AsSingle()
				.NonLazy();

			Container.Bind<NetworkFacade>()
				.AsSingle()
				.NonLazy();

			Container.Bind<SoundManager>()
				.FromComponentInNewPrefab(SoundManagerPrefab)
				.AsSingle()
				.NonLazy();
		}
	}
}