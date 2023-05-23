using System;
using System.Linq;
using PM.PingPong.Gameplay;
using UnityEngine;

namespace PM.PingPong.General
{
	// [CreateAssetMenu]
	public class GeneralConfigHolder : ScriptableObject
	{
		public GameSettings GameSettings;
		public GameModeSettings[] GameModeSettings;
		
		public ShopItemConfig[] ShopItems;


		private void OnValidate()
		{
			ShopItems = ShopItems.OrderBy(x => x.Cost).ToArray();
		}
	}
}