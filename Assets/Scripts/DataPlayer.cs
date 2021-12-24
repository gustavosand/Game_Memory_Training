using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataPlayer : MonoBehaviour
{
	[SerializeField] Text mon;
	public static int monedas = 50; 
	public static bool h = false; 
	public static bool AmericaCheck = false; 
	public static bool EuropaCheck = false; 
	public static bool AsiaCheck = false; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mon.text = monedas+" ";
    }
}
