using UnityEngine;

namespace PM.PingPong.Gameplay
{
	// [CreateAssetMenu]
	public class GameplayConfigHolder : ScriptableObject
	{
		public Balance Balance;
		public SkinConfig[] Skins;
	}
}