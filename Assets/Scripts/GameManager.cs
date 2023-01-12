using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject menuPanel;//Oyun içi duraklat menüsü
    public GameObject weaponScript;
    bool isPauseGame = false;//Oyunun durup durmadýðýný kontrol eden deðiþken
   
    void StopGame()
    {//Oyunu durdur ve duraklat menüsünü aç metodu
        menuPanel.SetActive(true);
        Time.timeScale = 0;
        weaponScript.SetActive(false);
    }
    void ResumeGame()
    {//Oyunu sürdür ve duraklat menüsünü kapat metodu
        Time.timeScale = 1;
        menuPanel.SetActive(false);
        weaponScript.SetActive(true);
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
