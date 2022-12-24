using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int enemyHealth = 200;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void EnemyTakeDamage(int damageAmount)
    {
        enemyHealth -= damageAmount;
        if (enemyHealth <= 0)
        {
            EnemyHealth();
        }
    }
    void EnemyHealth()
    {
        Destroy(this.gameObject);

    }
}

