using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health = 100;
	public int scorePoint = 5;
	public GameObject deathEffect;
	public AudioSource audioSource;
	public AudioClip deathsound;

    private void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
    }

    public void TakeDamage (int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			audioSource.PlayOneShot(deathsound);
			Die();
		}
	}

	public void Die ()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		gameObject.SetActive(false);
		Invoke("Respawn", 10);
		FindObjectOfType<ScoreController>().score += scorePoint; 
	}

	void Respawn()
	{
		health = 100;
		gameObject.SetActive(true);
	}
}
