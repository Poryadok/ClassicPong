using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace PM.PingPong.Gameplay
{
	public class Ball : MonoBehaviour
	{
		public event Action<float> OnRocketHit;
		
		public Rigidbody Rigidbody;
		private Material material;
		private float spawnTime;
		
		private static readonly int HitPosition = Shader.PropertyToID("_HitPosition");
		private static readonly int HitTime = Shader.PropertyToID("_HitTime");

		private void Awake()
		{
			spawnTime = Time.time;
		}

		public void Init()
		{
			Rigidbody = GetComponent<Rigidbody>();
			material = GetComponentInChildren<MeshRenderer>().material;
		}
		
		public void OnCollisionEnter(Collision other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				OnRocketHit?.Invoke(other.gameObject.GetComponent<Rigidbody>().velocity.x);
			}

			if (!other.gameObject.CompareTag("Untagged"))
			{
				material.SetVector(HitPosition, other.contacts[0].point - transform.position);
				material.SetFloat(HitTime, Time.time - spawnTime);
			}
		}
	}
}