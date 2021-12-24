using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HistoriaControlador : MonoBehaviour
{
	public RawImage m_RawImage;
	public int ind = 0;
    // Start is called before the first frame update
    void Start()
    {
		ind = 1;
    }

    public void Next()
    {
		if(ind == 13){
			DataPlayer.h = true;
			SceneManager.LoadScene("Niveles");
			return;
		}
        m_RawImage.texture = Resources.Load <Texture2D>("Historia/Introduccion_h"+ind);
		ind++;
	}
}
