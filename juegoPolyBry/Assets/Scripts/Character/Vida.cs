using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Vida : MonoBehaviour
{
    public Image Corazon;
    public int CantidadCorazones;
    public RectTransform PosicionPrimerCorazon;
    public Canvas MyCanvas;
    public int OffSet;

    private List<Image> corazones;


    void Start()
    {
        corazones = new List<Image>();
        Vector2 posicionCorazon = PosicionPrimerCorazon.anchoredPosition;
        for (int i = 0; i < CantidadCorazones; i++)
        {
            Image newCorazon = Instantiate(Corazon, MyCanvas.transform);
            newCorazon.rectTransform.anchoredPosition = posicionCorazon;
            corazones.Add(newCorazon);
            posicionCorazon.x += OffSet;
        }
        if (CantidadCorazones == 0)
        {
            Die();
        }
        
    }

    public void PerderCorazones()
    {
        if (corazones.Count > 0)
        {
            Image UltimoCorazon = corazones[corazones.Count - 1];
            corazones.Remove(UltimoCorazon);
            Destroy(UltimoCorazon.gameObject);
            if (corazones.Count == 0)
            {
                Die();
            }
        }
    }
    


    public void Die()
    {
        SceneManager.LoadScene("GameOver");
    }
}