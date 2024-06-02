using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    public Sprite hp_bar_0;
    public Sprite hp_bar_1;
    public Sprite hp_bar_2;
    public Sprite hp_bar_3;
    public Sprite hp_bar_4;
    public Sprite hp_bar_5;
    public Sprite inventarioHud;
    public int life = 100;
    public RectTransform PosicionHpBar, PosicionInventarioHud;
    public Canvas MyCanvas;
    public int OffSet;
    private List<Sprite> corazones = new List<Sprite>();

    private Image hpImage, hudInventory;

    // Start is called before the first frame update
    void Start()
    {
        corazones.Add(hp_bar_0);
        corazones.Add(hp_bar_1);
        corazones.Add(hp_bar_2);
        corazones.Add(hp_bar_3);
        corazones.Add(hp_bar_4);
        corazones.Add(hp_bar_5);

        GameObject hpBar = new GameObject("HP Bar");
        GameObject inventario = new GameObject("InventoryHUD");
        hpBar.transform.SetParent(MyCanvas.transform);
        inventario.transform.SetParent(MyCanvas.transform);

        hpImage = hpBar.AddComponent<Image>();
        hudInventory = inventario.AddComponent<Image>();

        RectTransform rt = hpBar.GetComponent<RectTransform>();
        RectTransform rts = inventario.GetComponent<RectTransform>();
        rt.position = PosicionHpBar.position;
        rt.sizeDelta = new Vector2(220, 60);
        rts.position = PosicionInventarioHud.position;
        rts.sizeDelta = new Vector2(660, 180);
        hudInventory.sprite = inventarioHud;

    }

    private void Update()
    {
        if (life >= 80)
        {
            hpImage.sprite = hp_bar_0;
        }
        else if (life < 80 && life >= 60)
        {
            hpImage.sprite = hp_bar_1;
        }
        else if (life < 60 && life >= 40)
        {
            hpImage.sprite = hp_bar_2;
        }
        else if (life < 40 && life >= 20)
        {
            hpImage.sprite = hp_bar_3;
        }
        else if (life < 20 && life > 0)
        {
            hpImage.sprite = hp_bar_4;
        }
        else if (life <= 0)
        {
            hpImage.sprite = hp_bar_5;
        }
    }

    public void recibirDaño(int daño)
    {
        life -= daño;
        if (life <= 0)
        {
            life = 0;
            Die();
        }
    }

    public void Die()
    {
        //agregar animación de muerte del personaje
        SceneManager.LoadScene(2);
    }
}