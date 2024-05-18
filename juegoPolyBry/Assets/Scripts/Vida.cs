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
    // Start is called before the first frame update
    void Start()
    {
        Transform PosicionCorazon = PosicionPrimerCorazon;
        for (int i = 0; i < CantidadCorazones; i++)
        {
            Image NewCorazon = Instantiate(Corazon, PosicionCorazon.position, Quaternion.identity);
            NewCorazon.transform.parent = MyCanvas.transform;
            PosicionCorazon.position = new Vector2(PosicionCorazon.position.x + OffSet, PosicionCorazon.position.y);

        }

    }

}
