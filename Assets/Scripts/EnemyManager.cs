using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyManager : MonoBehaviour
{
    public int enemyHealth = 200;

    //NavMesh
    public NavMeshAgent enemyAgent;//D��man�n navmesh'ini tutacak de�i�ken
    public Transform playerTransform;//Player objesinin transform'unu tutacak de�i�ken
    public LayerMask groundLayerMask;//Zemin layer'�
    public LayerMask playerLayerMask;//Player layer'�

    //Patrolling-Devriye gezme-Burada d��man bizi g�rm�yor
    public Vector3 walkPoint;//Y�r�me noktas�
    public float walkPointRange;//Y�r�me noktas� aral���
    public bool walkPointSet;//Y�r�me noktas� kontrolc�s�

    //Bizi g�r�p yakla�mas�n� ve atak yapmas�n� kontrol eden de�i�kenler
    public float sightRange, attackRange;//Float tipinde g�r�� aral��� ve atak aral��� de�i�kenleri
    public bool enemySightRange, enemyAttackRange;//G�r�� aral��� veya atak aral���nda olup olmad���m�z� kontrol edecek bool de�i�kenler
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.Find("Player").transform;
    }

    
    void FixedUpdate()
    {
        enemySightRange = Physics.CheckSphere(transform.position, sightRange, playerLayerMask);
        //Player,belirlenen sightRange aral��� i�inde bulunursa �arp��t�r�c� bunu alg�layacak ve bize true/false �eklinde geri d�n�� sa�layacak.
        enemyAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayerMask);
        //Player, belirlenen attackRange aral��� i�inde bulunursa �arp��t�r�c� bunu alg�layacak ve bize true/false �eklinde geri d�n�� sa�layacak.

        if (!enemyAttackRange && !enemySightRange)
        {//Player,atak ve g�r�� aral���nda de�il ise;
            //D��man burada devriye(patrol) hareketini yapacak.
            Patrolling();
        }
        else if (!enemyAttackRange && enemySightRange)
        {
            //Player, atak aral���nda de�il ancak g�r�� aral���nda ise;
            //D��man player'� alg�lay�p ona g�re hareket edecek
        }
        else if (enemyAttackRange && enemySightRange)
        {
            //Player hem atak hem de g�r�� aral���nda ise;
            //D��man player'a sald�racak.
        }
    }
    void Patrolling()
    {
        //D��man�n devriye gezme metodu
        if (walkPointSet == false)
        {
            float randomZPos = Random.Range(-walkPointRange, walkPointRange);
            float randomXPos = Random.Range(-walkPointRange, walkPointRange);
            walkPoint = new Vector3(transform.position.x + randomXPos, transform.position.y, transform.position.z + randomZPos);

            if (Physics.Raycast(walkPoint, -transform.up, 2f, groundLayerMask))
            {
                //walkPoint noktas�ndan zemine bir ���n g�nderiyoruz. Zemin tespiti i�in. E�er d��man objesi zeminin �zerinde ise;
                walkPointSet = true;
            }
            if (walkPointSet == true)
            {
                enemyAgent.SetDestination(walkPoint); //D��man objemizin walkPoint noktas�na gitmesini s�ylemi� olduk.

            }
            Vector3 distanceToWalkpoint = transform.position - walkPoint;//walkPoint'e olan mesafeyi vector3 cinsinden tutuyor

            if (distanceToWalkpoint.magnitude < 1f)
            {
                //walkPoint'e olan mesafe 1f'den k���kse;
                walkPointSet = false;
            }
        }
    }

    public void EnemyTakeDamage(int damageAmount)
    {//D��man hasar yeme fonksiyonu
        enemyHealth -= damageAmount;//Yenen hasar miktar�n� d��man�n can�ndan ��kar.
        if (enemyHealth <= 0)
        {//E�er can 0'a e�it veya k���kse;
            //EnemyHealth metodunu �a��r
            EnemyHealth();
        }
    }
    void EnemyHealth()
    {
        //D��man objesini yok et
        Destroy(this.gameObject);

    }
}

