using PM.PingPong.General;
using UnityEngine;

namespace PM.PingPong.Gameplay
{
	[CreateAssetMenu]
	public class GameModeSettings : ScriptableObject
	{
		public GameMode GameMode;
		public int ScoreToWin;
		public bool IsBotPlaying;
	}
}