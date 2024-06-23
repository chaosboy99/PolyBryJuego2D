using System.Collections;
using TMPro;
using UnityEngine;

public class Textos : MonoBehaviour
{
    [SerializeField] private GameObject PanelTexto;
    [SerializeField] private TMP_Text DialogoTexto;
    [SerializeField, TextArea(4, 6)] private string[] LineasTexto;
    private bool PlayerRange;
    private bool TextoInicio;
    private int IndexLinea;
    private float TiempoTexto = 0.01f;

    void Update()
    {
        if (PlayerRange)
        {
            if (!TextoInicio)
            {
                InicioTexto();
            }
            else if (DialogoTexto.text == LineasTexto[IndexLinea] && Input.GetMouseButtonDown(0)) 
            {
                NextLine();
            }
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            CerrarTexto();
       
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerRange = false;
            CerrarTexto();
        }
    }

    private void InicioTexto()
    {
        TextoInicio = true;
        PanelTexto.SetActive(true);
        IndexLinea = 0;
        StartCoroutine(ShowText());
        
    }

    private void NextLine()
    {
        IndexLinea++;
        if (IndexLinea < LineasTexto.Length)
        {
            StartCoroutine(ShowText());
        }
       
    }

    private IEnumerator ShowText()
    {
        DialogoTexto.text = string.Empty;
        foreach (char ch in LineasTexto[IndexLinea])
        {
            DialogoTexto.text += ch;
            yield return new WaitForSeconds(TiempoTexto);
        }
    }

    private void CerrarTexto()
    {
        TextoInicio = false;
        PanelTexto.SetActive(false);
    }
}
