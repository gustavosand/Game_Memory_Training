using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InforController : MonoBehaviour
{
    [SerializeField] 
    private GameObject botonIconoPausa;
    [SerializeField] 
    private GameObject menuPausa;
    public void Pausa(){
        Time.timeScale = 0f;
        botonIconoPausa.SetActive(false);
        menuPausa.SetActive(true);
    }
    public void reanudar(){
        Time.timeScale = 1f;
        botonIconoPausa.SetActive(true);
        menuPausa.SetActive(false);
    }
}
