using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject powerUp;
    public AudioClip powerUpSound;
    public AudioSource audioSource;
    public bool powerOn;
    public int powerTime;
    public PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        powerOn = false;
        audioSource = FindObjectOfType<AudioSource>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (powerOn)
        {
            playerHealth.health = 99999;
            playerHealth.healthText.text = "999";
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Power Up")
        {
            powerOn = true;
            audioSource.PlayOneShot(powerUpSound);
            powerUp.SetActive(false);
            Invoke("PowerUpOff", powerTime);
        }
    }

    void PowerUpOff()
    {
        powerUp.SetActive(true);
        powerOn = false;
        playerHealth.health = 2;
        playerHealth.healthText.text = playerHealth.health.ToString();
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
