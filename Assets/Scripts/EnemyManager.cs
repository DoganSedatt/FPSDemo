using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyManager : MonoBehaviour
{
    public int enemyHealth = 200;

    //NavMesh
    public NavMeshAgent enemyAgent;//Düþmanýn navmesh'ini tutacak deðiþken
    public Transform playerTransform;//Player objesinin transform'unu tutacak deðiþken
    public LayerMask groundLayerMask;//Zemin layer'ý
    public LayerMask playerLayerMask;//Player layer'ý

    //Patrolling-Devriye gezme-Burada düþman bizi görmüyor
    public Vector3 walkPoint;//Yürüme noktasý
    public float walkPointRange;//Yürüme noktasý aralýðý
    public bool walkPointSet;//Yürüme noktasý kontrolcüsü

    //Bizi görüp yaklaþmasýný ve atak yapmasýný kontrol eden deðiþkenler
    public float sightRange, attackRange;//Float tipinde görüþ aralýðý ve atak aralýðý deðiþkenleri
    public bool enemySightRange, enemyAttackRange;//Görüþ aralýðý veya atak aralýðýnda olup olmadýðýmýzý kontrol edecek bool deðiþkenler

    //Attacking
    public float attackDelay;//Saldýrý gecikmesi.Belirli aralýklarla saldýrý yapmasý için
    public bool isAttacking;//Atak modunda olup olmadýðýný kontrol edecek
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.Find("Player").transform;
    }

    
    void FixedUpdate()
    {
        enemySightRange = Physics.CheckSphere(transform.position, sightRange, playerLayerMask);
        //Player,belirlenen sightRange aralýðý içinde bulunursa çarpýþtýrýcý bunu algýlayacak ve bize true/false þeklinde geri dönüþ saðlayacak.
        enemyAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayerMask);
        //Player, belirlenen attackRange aralýðý içinde bulunursa çarpýþtýrýcý bunu algýlayacak ve bize true/false þeklinde geri dönüþ saðlayacak.

        if (!enemyAttackRange && !enemySightRange)
        {//Player,atak ve görüþ aralýðýnda deðil ise;
            //Düþman burada devriye(patrol) hareketini yapacak.
            Patrolling();
        }
        else if (!enemyAttackRange && enemySightRange)
        {
            //Player, atak aralýðýnda deðil ancak görüþ aralýðýnda ise;
            //Düþman player'ý algýlayýp ona göre hareket edecek
            DetectPlayer();
        }
        else if (enemyAttackRange && enemySightRange)
        {
            //Player hem atak hem de görüþ aralýðýnda ise;
            //Düþman player'a saldýracak.
            AttackPlayer();
        }
    }
    void Patrolling()
    {
        //Düþmanýn devriye gezme metodu
        if (walkPointSet == false)
        {
            float randomZPos = Random.Range(-walkPointRange, walkPointRange);
            float randomXPos = Random.Range(-walkPointRange, walkPointRange);
            walkPoint = new Vector3(transform.position.x + randomXPos, transform.position.y, transform.position.z + randomZPos);

            if (Physics.Raycast(walkPoint, -transform.up, 2f, groundLayerMask))
            {
                //walkPoint noktasýndan zemine bir ýþýn gönderiyoruz. Zemin tespiti için. Eðer düþman objesi zeminin üzerinde ise;
                walkPointSet = true;
            }
            if (walkPointSet == true)
            {
                enemyAgent.SetDestination(walkPoint); //Düþman objemizin walkPoint noktasýna gitmesini söylemiþ olduk.

            }
            Vector3 distanceToWalkpoint = transform.position - walkPoint;//walkPoint'e olan mesafeyi vector3 cinsinden tutuyor

            if (distanceToWalkpoint.magnitude < 1f)
            {
                //walkPoint'e olan mesafe 1f'den küçükse;
                walkPointSet = false;
            }
        }
    }

    void DetectPlayer()//Player'ýn düþman tarafýndan tespiti sonrasýnda yapýlacaklar
    {
        enemyAgent.SetDestination(playerTransform.position);//Düþman player objemize doðru gelecek
        transform.LookAt(playerTransform);//Düþmanýn yönü player objemize doðru olacak
    }

    void AttackPlayer()//Düþmanýn player'a saldýrmasý
    {
        enemyAgent.SetDestination(transform.position);
        //Player objemiz düþmanýn attackRange mesafesine geldikten sonra düþman objesi artýk player'ýn deðil kendi transformunun pzoisyon deðerlerine gidecek
        transform.LookAt(playerTransform);//Yine player'a dönük olmasý saðlanýyor

        if (isAttacking == false)
        {//Player objemiz attackRange mesafesine gelmiþ ve düþman objesi saldýrý modunda deðilse; 
            isAttacking = true;//Atak modunu aç
            Invoke("ResetAttack", attackDelay);
            //Invoke ile bir metodu belli aralýkla çalýþtýrýyoruz. Bu da belirlediðimiz attackDelay süresine baðlý olarak atak modunu açýp kapatýyor. Yani her attackDelay saniyede player'a saldýrý gerçekleþtiriyoruz. 
        }
    }
    void ResetAttack()
    {
        isAttacking = false;
    }
    public void EnemyTakeDamage(int damageAmount)
    {//Düþman hasar yeme fonksiyonu
        enemyHealth -= damageAmount;//Yenen hasar miktarýný düþmanýn canýndan çýkar.
        if (enemyHealth <= 0)
        {//Eðer can 0'a eþit veya küçükse;
            //EnemyHealth metodunu çaðýr
            EnemyHealth();
        }
    }
    void EnemyHealth()
    {
        //Düþman objesini yok et
        Destroy(this.gameObject);

    }
}

