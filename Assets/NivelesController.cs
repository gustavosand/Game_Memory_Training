using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NivelesController : MonoBehaviour
{
	public GameObject america;
	public GameObject europa;
	public GameObject asia;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DataPlayer.AmericaCheck){
			america.GetComponent<Image>().sprite = Resources.Load <Sprite>("check");
		}
		if(DataPlayer.EuropaCheck){
			europa.GetComponent<Image>().sprite = Resources.Load <Sprite>("check");
		}
		if(DataPlayer.AsiaCheck){
			asia.GetComponent<Image>().sprite = Resources.Load <Sprite>("check");
		}
    }
}
