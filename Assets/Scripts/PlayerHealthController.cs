using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    
    public int currentHealth;
   
    [SerializeField] private int maxHealth;

    [SerializeField] float invincibleLenght;
  
    private float invincibleCounter;

    private SpriteRenderer sprite;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        sprite = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        if (invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;
        }
        if (invincibleCounter <= 0) 
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
        }

    }

    public void DealDamage()
    {
        if (invincibleCounter <= 0)
        {

            currentHealth--;

            if (currentHealth <= 0)
            {

              gameObject.SetActive(false);
                //LevelManager.instance.RespawnPlayer();
                LevelController.instance.SpawnRespawn();
            }
            else
            {
                invincibleCounter = invincibleLenght;
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, .5f);
                PlayerController.instance.KnockBack();
            }

            UIController.instance.UpdateHealthDisplay();

        }
    }
}
