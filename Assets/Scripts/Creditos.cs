using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Creditos : MonoBehaviour
{
 
    void Start()
    {
        Invoke("cambiarEscenario",13.13f);
    }
    public void cambiarEscenario(){
        SceneManager.LoadScene("Portada");
    }
}
