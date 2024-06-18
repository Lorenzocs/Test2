using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFalso : MonoBehaviour
{
    [SerializeField] private float life;
    [SerializeField] private float lifeMax;

    [SerializeField] private int health;
    // Update is called once per frame

    private UiManager uiManager;

    public void Start()
    {
        uiManager = UiManager.Instance;
        uiManager.UpdateLifeHeart(health);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //Regeneration();
            AddHealth();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            // TakeDamage();
            TakeLife();
        }
    }

    public void TakeLife()
    {
        health--;
        uiManager.UpdateLifeHeart(health);
    }
    public void AddHealth()
    {
        health++;
        uiManager.UpdateLifeHeart(health);
    }
    /*
    public void TakeDamage()
    {
        float amountDamage = Random.Range(10, 50);
        life -= amountDamage;
        if (life < 0)
        {
            life = 0;
        }
        uiManager.UpdateLife(life, lifeMax);
    }

    public void Regeneration()
    {
        float amountLife = Random.Range(10, 50);
        life += amountLife;
        if (life > lifeMax)
        {
            life = lifeMax;
        }
        uiManager.UpdateLife(life, lifeMax);
    }*/


}
