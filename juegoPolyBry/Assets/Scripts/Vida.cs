using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    public Image Corazon;
    public int CantidadCorazones;
    public RectTransform PosicionPrimerCorazon;
    public Canvas MyCanvas;
    public int OffSet;
    private List<Image> corazones = new List<Image>();


    // Start is called before the first frame update
    void Start()
    {
        Transform PosicionCorazon = PosicionPrimerCorazon;
        for (int i = 0; i < CantidadCorazones; i++)
        {
            Image NewCorazon = Instantiate(Corazon, PosicionCorazon.position, Quaternion.identity);
            NewCorazon.transform.parent = MyCanvas.transform;
            corazones.Add(NewCorazon);
            PosicionCorazon.position = new Vector2(PosicionCorazon.position.x + OffSet, PosicionCorazon.position.y);

        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            Destroy(MyCanvas.transform.GetChild(CantidadCorazones + 1).gameObject);
            CantidadCorazones -= 1;
           
        }
        if (CantidadCorazones <= 0)
        {
            Destroy(gameObject);
        }
    }
}
