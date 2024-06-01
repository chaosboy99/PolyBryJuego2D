using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    public Image hp_bar_0;
    public Image hp_bar_1;
    public Image hp_bar_2;
    public Image hp_bar_3;
    public Image hp_bar_4;
    public Image hp_bar_5;
    public int life = 100;
    public RectTransform PosicionHpBar;
    public Canvas MyCanvas;
    public int OffSet;
    private List<Image> corazones = new List<Image>();


    // Start is called before the first frame update
    void Start()
    {
        //CORREJIR, NO FUNCIONA
        Image fullHp = Instantiate(hp_bar_0, PosicionHpBar.position, Quaternion.identity);
    }

    //TERMINAR UPDATE
    private void Update()
    {
        if (life >= 80)
        {
            //hpbar 0
        }
        else if (life <80 && life > 60)
        {
            //hpbar 1
        }
        else if (life <=60 && life > 40)
        {
            //hpbar 2
        }
        else if (life <= 40 && life > 20)
        {
            //hpbar 3
        }
        else if (life <= 20 && life > 0)
        {
            //hpbar 4
        }
        else if(life <= 0)
        {
            //hpbar 5
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.tag == "Enemigo")
        {
            Destroy(MyCanvas.transform.GetChild(CantidadCorazones + 1).gameObject);
            CantidadCorazones -= 1;
           
        }
        if (CantidadCorazones <= 0)
        {
            SceneManager.LoadScene(2);
            Destroy(gameObject);

        }*/
    }
}
