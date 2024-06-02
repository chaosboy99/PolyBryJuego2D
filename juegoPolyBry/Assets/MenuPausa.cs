using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject BtPausa;

    public GameObject MnPausa;

    private bool JuegoPausado = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (JuegoPausado)
            {
                volver();
            }
            else
            {
                Pausa();
            }
        }
    }
    public void Pausa()
    {
        JuegoPausado=true;
        Time.timeScale = 0f;
        BtPausa.SetActive(false);
        MnPausa.SetActive(true);
    }
    public void volver()
    {
        JuegoPausado = false;
        Time.timeScale = 1f;
        BtPausa.SetActive(true);
        MnPausa.SetActive(false);
    }
    public void reiniciar()
    {
        JuegoPausado = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void exit() 
    { 
        Application.Quit();
    }
}
