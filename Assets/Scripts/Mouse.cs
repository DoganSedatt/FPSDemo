using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public Transform player;//Player transformu
    float mouseSens = 300f;//Mouse hassasiyeti
    private float xRotation;
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X")*mouseSens*Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y")*mouseSens*Time.deltaTime;
        //X ve Y d�zleminde mouse girdisini tutacak de�i�kenler.

        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);//xRotation de�i�kenini -90 ile 90 de�erleri aras�nda tut.
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        player.Rotate(Vector3.up * MouseX);//Player'�n rotasyonunu RotateY(Sa� sol) d�zleminde hareket ettir ve bunu fare ile kontrol et.
    }
}
