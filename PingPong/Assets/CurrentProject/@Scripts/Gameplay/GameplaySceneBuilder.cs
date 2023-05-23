using System;
using PM.PingPong.General;
using PM.UsefulThings;
using UnityEngine;
using Zenject;
using IInitializable = Zenject.IInitializable;

namespace PM.PingPong.Gameplay
{
	public class GameplaySceneBuilder : MonoBehaviour, IInitializable
	{
		private GeneralConfigHolder generalConfigHolder;
		private WindowManagerUT windowManager;
		
		[Inject]
		public void Construct(GeneralConfigHolder generalConfigHolder, WindowManagerUT windowManagerUt)
		{
			this.generalConfigHolder = generalConfigHolder;
			windowManager = windowManagerUt;
		}

		public void Initialize()
		{
			windowManager.OpenNewPanel<GameplayPanel>(WindowCloseModes.CloseEverything);
		}
	}
}