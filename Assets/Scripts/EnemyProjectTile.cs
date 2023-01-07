using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectTile : MonoBehaviour
{
    
    public int enemyDamageAmount = 20;

   

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            Debug.Log(this.gameObject.name + " objesi" + " " + other.transform.tag + " e çarptý");
            playerController.PlayerTakeDamage(enemyDamageAmount);
            Destroy(this.transform.gameObject,1);
        }
        else
        {
            Destroy(this.transform.gameObject, 3f);
        }
    }
}
