using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject menuPanel;//Oyun i�i duraklat men�s�
    public GameObject weaponScript;
    bool isPauseGame = false;//Oyunun durup durmad���n� kontrol eden de�i�ken
   
    public void StopGame()
    {//Oyunu durdur ve duraklat men�s�n� a� metodu
        menuPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;//Fare imlecini ekranda g�sterir
        Time.timeScale = 0;
        weaponScript.SetActive(false);
        isPauseGame = true;
    }
    public void ResumeGame()
    {//Oyunu s�rd�r ve duraklat men�s�n� kapat metodu
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;//Fare imlecini kald�r�r
        menuPanel.SetActive(false);
        weaponScript.SetActive(true);
        isPauseGame = false;
    }
    public void GetSettings()
    {
        Debug.Log("Ayarlar penceresii!");
    }
    public void GetMainMenu()
    {
        Debug.Log("Ana men�!");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {//ESC tu�una her basmamda isPauseGame de�eri true/false aras�nda de�i�ecek. 
            isPauseGame = !isPauseGame;//false ise true,true ise false olacak.
            Debug.Log(isPauseGame);
        }
        if (!isPauseGame)
        {//E�er isPauseGame negatif ise(true) 
            ResumeGame();//Oyunu devam ettir
        }
        else
        {
            //De�ilse oyunu durdur.
            StopGame();
        }
    }
}
