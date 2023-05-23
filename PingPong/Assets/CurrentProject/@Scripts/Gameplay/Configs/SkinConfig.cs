using PM.PingPong.General;
using PM.UsefulThings.Extensions;
using UnityEngine;

namespace PM.PingPong.Gameplay
{
	[CreateAssetMenu]
	public class SkinConfig : ScriptableObject
	{
		[ReadOnly] public string Id;
		[ReadOnly] public bool IsDefault;
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