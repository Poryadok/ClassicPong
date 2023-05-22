using System;
using PM.PingPong.General;
using UnityEngine;
using Zenject;

namespace PM.PingPong.Gameplay
{
	public class GameplaySceneBuilder : MonoBehaviour, IInitializable
	{
		private GeneralConfigHolder generalConfigHolder;
		
		[Inject]
		public void Construct(GeneralConfigHolder generalConfigHolder)
		{
			this.generalConfigHolder = generalConfigHolder;
		}

		public void Initialize()
		{
			Debug.LogError($"play {generalConfigHolder.GameSettings.GameMode}");
		}
	}
}