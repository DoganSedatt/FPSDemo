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
        //X ve Y düzleminde mouse girdisini tutacak deðiþkenler.

        player.Rotate(Vector3.up * MouseX);//Player'ýn rotasyonunu RotateY(Sað sol) düzleminde hareket ettir ve bunu fare ile kontrol et.
    }
}
