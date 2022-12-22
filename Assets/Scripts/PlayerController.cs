using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    public float speed = 5f;
    public float gravity = -9.81f;//Yer�ekimi de�eri
    private Vector3 gravityVector;//Yer�ekimi vekt�r�
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;//�leri-geri ve yatay hareket girdisi.
        characterController.Move(move * speed * Time.deltaTime);//karakter kontrolc�s�ne vector3 tipinde bir hareket de�eri veriyoruz sonra onu h�z ve zaman ile �arp�yoruz.

        gravityVector.y += gravity * Time.deltaTime;//gravity de�erini gravityVector.y de�erine e�itledik. Ancak bu de�er her saniye -9.81 artarak devam ediyor.
        characterController.Move(gravityVector * Time.deltaTime);
    }
}
