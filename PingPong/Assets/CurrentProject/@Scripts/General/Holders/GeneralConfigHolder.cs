using PM.PingPong.Gameplay;
using UnityEngine;

namespace PM.PingPong.General
{
	// [CreateAssetMenu]
	public class GeneralConfigHolder : ScriptableObject
	{
		public GameSettings GameSettings;
		public GameModeSettings[] GameModeSettings;
	}
}