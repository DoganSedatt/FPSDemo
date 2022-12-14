using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public Transform player;//Player transformu
    float mouseSens = 200f;//Mouse hassasiyeti
   
    void Start()
    {
        
    }

   
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X")*mouseSens*Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y")*mouseSens*Time.deltaTime;
        //X ve Y d�zleminde mouse girdisini tutacak de�i�kenler.

        player.Rotate(Vector3.up * MouseX);//Player'�n rotasyonunu RotateY(Sa� sol) d�zleminde hareket ettir ve bunu fare ile kontrol et.
    }
}
