using PM.UsefulThings.Extensions;
using UnityEditor;
using UnityEngine;

namespace PM.PingPong.General
{
	// [CreateAssetMenu]
	public class ShopItemConfig : ScriptableObject
	{
		[ReadOnly] public string Id;
		public bool IsDefault;
		public string Name;
		public Sprite Image;
		public Color Color = Color.white;
		public int Cost;

#if UNITY_EDITOR
		public void Awake()
		{
			if (string.IsNullOrWhiteSpace(Id))
				Id = GUID.Generate().ToString();
		}
#endif
	}
}