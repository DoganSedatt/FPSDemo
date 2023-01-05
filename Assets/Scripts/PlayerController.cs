using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    public int playerHealth;
    public float speed = 5f;
    public float gravity = -14f;//Yerçekimi deðeri
    private Vector3 gravityVector;//Yerçekimi vektörü
    
    //GroundCheck
    public Transform groundCheckPoint;
    public float groundCheckRadius = 0.35f;
    public LayerMask groundLayer;
    public bool isGrounded = false;
    public float jumpSpeed = 5f;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        GroundCheck();
        JumpAndGravity();
        //Debug.Log(playerHealth);
    }
    void MovePlayer()
    {
        Vector3 move = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;//Ýleri-geri ve yatay hareket girdisi.
        characterController.Move(move * speed * Time.deltaTime);//karakter kontrolcüsüne vector3 tipinde bir hareket deðeri veriyoruz sonra onu hýz ve zaman ile çarpýyoruz.
    }

    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheckPoint.position, groundCheckRadius, groundLayer);//Yer kontrolü
    }
    void JumpAndGravity()
    {
        gravityVector.y += gravity * Time.deltaTime;//gravity deðerini gravityVector.y deðerine eþitledik. Ancak bu deðer her saniye -9.81 artarak devam ediyor.
        characterController.Move(gravityVector * Time.deltaTime);


        if (isGrounded && gravityVector.y < 0)
        {
            gravityVector.y = -3f;
        }

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            gravityVector.y = jumpSpeed;
        }
    }

    public void PlayerTakeDamage(int damageAmount)
    {//Player hasar yeme metodu
        playerHealth -= damageAmount;
        Debug.Log(damageAmount + " hasar yedi");
        if (playerHealth <= 0)
        {
            PlayerDeath();
        }
    }
    void PlayerDeath()//Player ölme metodu
    {
        Destroy(this.gameObject);
        Debug.Log("Can deðeri: " + playerHealth );
    }
}
