using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public int minDamage, maxDamage;
    public Camera playerCamera;
    public float range = 300f;
    private EnemyManager enemyManager;//EnemyManager scriptine eri�mek i�in
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void Fire()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {//playerCamera ��k�� noktas�ndan playerCameran�n forward y�n�ne do�ru range miktar� mesafesinde ���n olu�turur.
            //Debug.Log(hit.transform.name);
            enemyManager = hit.transform.GetComponent<EnemyManager>();//Vurulan hedefin i�indeki EnemyManager scriptini al de�i�kene at. Onun �st�nden i�lem yapaca��z.
            if (enemyManager != null)
            {
                //E�er enemyManager de�i�keni bo� de�ilse yani vurulan hedefte enemyManager scripti mevcut ise
                int rng = Random.Range(minDamage, maxDamage);
                enemyManager.EnemyTakeDamage(rng);
                //enemyManager scriptine ba�l� olan EnemyTakeDamage metodunu �a��r ve hedefe hasar ver.
                Debug.Log(hit.transform.name+" hedefine "+ rng +" hasar vuruldu");
            }
        }
    }
}
