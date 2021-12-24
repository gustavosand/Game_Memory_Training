using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfricaController : MonoBehaviour
{
    public static void CambiarEscena(string nombre){
        SceneManager.LoadScene(nombre);
    }

    public void Salir(){
        Application.Quit();
    }
}

