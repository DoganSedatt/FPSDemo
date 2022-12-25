using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public int minDamage, maxDamage;
    public Camera playerCamera;
    public float range = 300f;
    private EnemyManager enemyManager;//EnemyManager scriptine eriþmek için
    public ParticleSystem muzzleEffect;//Namlu ateþi efekti
    public AudioSource fireSound;//Ateþ etme sesi
    void Start()
    {
     
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();//Fire metodunu çalýþtýr
            muzzleEffect.Play();//Namlu ateþ efektini oynat
            
        }
    }

    void Fire()
    {
        fireSound.Play();//Ateþ etme sesini çalýþtýr
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {//playerCamera çýkýþ noktasýndan playerCameranýn forward yönüne doðru range miktarý mesafesinde ýþýn oluþturur.
            //Debug.Log(hit.transform.name);
            enemyManager = hit.transform.GetComponent<EnemyManager>();//Vurulan hedefin içindeki EnemyManager scriptini al deðiþkene at. Onun üstünden iþlem yapacaðýz.
            if (enemyManager != null)
            {
                
                //Eðer enemyManager deðiþkeni boþ deðilse yani vurulan hedefte enemyManager scripti mevcut ise
                int rng = Random.Range(minDamage, maxDamage);
                enemyManager.EnemyTakeDamage(rng);
                //enemyManager scriptine baðlý olan EnemyTakeDamage metodunu çaðýr ve hedefe hasar ver.
                Debug.Log(hit.transform.name+" hedefine "+ rng +" hasar vuruldu");
            }
        }
    }
}
