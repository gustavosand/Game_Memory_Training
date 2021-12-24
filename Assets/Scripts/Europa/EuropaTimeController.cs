using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EuropaTimeController : MonoBehaviour
{
    [SerializeField] int min, seg;
    [SerializeField] Text tiempo;

    private float restante;
    public static bool enMarcha;
    private void Awake() {
       restante = (min * 60) + seg; 
       enMarcha = true;
    }

    void Update()
    {
        if (enMarcha){
            restante -= Time.deltaTime;
            if(restante < 1){
                enMarcha = false;
                //termina el juego
            }
            int tempMin = Mathf.FloorToInt(restante / 60);
            int tempSeg = Mathf.FloorToInt(restante % 60);
            tiempo.text = string.Format("{00:00}:{01:00}", tempMin, tempSeg);
            
        }
    }
	
	public void BuySeconds(){
		if(DataPlayer.monedas < 10) return;
		restante += 10;
		DataPlayer.monedas-=10;
	}
}
