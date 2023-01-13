using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject menuPanel;//Oyun içi duraklat menüsü
    public GameObject weaponScript;
    bool isPauseGame = false;//Oyunun durup durmadýðýný kontrol eden deðiþken
   
    public void StopGame()
    {//Oyunu durdur ve duraklat menüsünü aç metodu
        menuPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;//Fare imlecini ekranda gösterir
        Time.timeScale = 0;
        weaponScript.SetActive(false);
        isPauseGame = true;
    }
    public void ResumeGame()
    {//Oyunu sürdür ve duraklat menüsünü kapat metodu
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;//Fare imlecini kaldýrýr
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
        Debug.Log("Ana menü!");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {//ESC tuþuna her basmamda isPauseGame deðeri true/false arasýnda deðiþecek. 
            isPauseGame = !isPauseGame;//false ise true,true ise false olacak.
            Debug.Log(isPauseGame);
        }
        if (!isPauseGame)
        {//Eðer isPauseGame negatif ise(true) 
            ResumeGame();//Oyunu devam ettir
        }
        else
        {
            //Deðilse oyunu durdur.
            StopGame();
        }
    }
}
