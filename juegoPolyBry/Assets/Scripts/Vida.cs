using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    public Sprite hp_bar_0;
    public Image hp_bar_1;
    public Image hp_bar_2;
    public Image hp_bar_3;
    public Image hp_bar_4;
    public Image hp_bar_5;
    public int Life;
    public RectTransform PosicionHpBar;
    public Canvas MyCanvas;
    public int OffSet;
    private List<Image> corazones = new List<Image>();


    // Start is called before the first frame update
    void Start()
    {
        Sprite fullHp = Instantiate(hp_bar_0, PosicionHpBar.position, Quaternion.identity);
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
