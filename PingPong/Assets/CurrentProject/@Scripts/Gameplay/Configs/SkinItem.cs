using System;
using PM.PingPong.MainMenu;
using PM.UsefulThings.Extensions;
using UnityEditor;
using UnityEngine;

namespace PM.PingPong.Gameplay
{
	[CreateAssetMenu]
	public class SkinItem : ScriptableObject
	{
		[ReadOnly]
		public string Id;
		[ReadOnly]
		public bool IsDefault;
		public GameObject Prefab;
		public Color Color;

#if UNITY_EDITOR
		public ShopItemConfig RelatedShopConfig;

		private void OnValidate()
		{
			Id = RelatedShopConfig.Id;
			IsDefault = RelatedShopConfig.IsDefault;
		}
#endif
	}
}