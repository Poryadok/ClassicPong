using System;
using UnityEngine;

namespace PM.PingPong.Gameplay
{
	public class Wall : MonoBehaviour
	{
		public event Action OnHit;

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.CompareTag("Ball"))
			{
				OnHit?.Invoke();
			}
		}
	}
}