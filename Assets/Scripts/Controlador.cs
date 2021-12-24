using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Controlador : MonoBehaviour
{
	public static string LEVEL_NAME;
	public static int LEVEL_MODE;
	
    public void CambiarEscena(string nombre){
        SceneManager.LoadScene(nombre);
    }
	
	public void LoadLevel(int mode){
		if(mode == 4){
			System.Random rnd = new System.Random();
			mode = rnd.Next(1, 3);
		}
		LEVEL_MODE = mode;
        SceneManager.LoadScene(LEVEL_NAME);
    }

    public void Salir(){
        Application.Quit();
    }
	
	public void SetLevelName(string name){
		LEVEL_NAME = name;
	}
}

