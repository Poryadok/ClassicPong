using System;
using UnityEngine;

namespace PM.PingPong.Gameplay
{
	public class Goal : MonoBehaviour
	{
		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.CompareTag("Ball"))
			{
				other.transform.position = Vector3.zero;
			}
		}
	}
}