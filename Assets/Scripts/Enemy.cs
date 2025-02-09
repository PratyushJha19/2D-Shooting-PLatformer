using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health = 100;

	public GameObject deathEffect;

	public void TakeDamage (int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			Die();
		}
	}

	void Die ()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		gameObject.SetActive(false);
		Invoke("Respawn", 10);
	}

	void Respawn()
	{
		health = 100;
		gameObject.SetActive(true);
	}
}
