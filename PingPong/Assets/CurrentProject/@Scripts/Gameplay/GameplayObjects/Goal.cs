using System;
using UnityEngine;

namespace PM.PingPong.Gameplay
{
	public class Goal : MonoBehaviour
	{
		public event Action OnGoal;
		
		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.CompareTag("Ball"))
			{
				OnGoal?.Invoke();
			}
		}
	}
}