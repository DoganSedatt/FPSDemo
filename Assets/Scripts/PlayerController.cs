using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    public float speed = 5f;
    public float gravity = -9.81f;//Yerçekimi deðeri
    private Vector3 gravityVector;//Yerçekimi vektörü
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;//Ýleri-geri ve yatay hareket girdisi.
        characterController.Move(move * speed * Time.deltaTime);//karakter kontrolcüsüne vector3 tipinde bir hareket deðeri veriyoruz sonra onu hýz ve zaman ile çarpýyoruz.

        gravityVector.y += gravity * Time.deltaTime;//gravity deðerini gravityVector.y deðerine eþitledik. Ancak bu deðer her saniye -9.81 artarak devam ediyor.
        characterController.Move(gravityVector * Time.deltaTime);
    }
}
