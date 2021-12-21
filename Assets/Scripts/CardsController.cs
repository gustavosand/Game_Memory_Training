using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class CardsController : MonoBehaviour
{
	
	public GameObject Card;
	
	GameObject[] panelsArray;
	GameObject[] cardsArray;
    string[] spritesArray; 
	public static Sprite spriteReverse;
	public static int cantSelected;
	public static GameObject XSelected;
	public static GameObject YSelected;

	// Start is called before the first frame update
    void Start()
    {
		SetSprites();
		GenerateCards();
        AddCards();
		cantSelected = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(cantSelected == 2){
			//Aniamtion here
			//end animation
			
			StartCoroutine(WaitTime2());
			CardDefinition xScript = XSelected.GetComponent<CardDefinition>();
			CardDefinition yScript = YSelected.GetComponent<CardDefinition>();
			
			if(xScript.GetId() == yScript.GetId()){
				xScript.SaveAnimal();
				yScript.SaveAnimal();
			}else{
				xScript.HideAnimal();
				yScript.HideAnimal();
			}
			cantSelected = 0;
		}
    }
	
	IEnumerator WaitTime2() {     
		float timePassed = 0;     
		while (timePassed < 30){
			timePassed += Time.deltaTime;   
			print(timePassed);
		} 
		yield return null;  
	}
	
	void AddCards()
    {
		Shuffle(cardsArray);
		int cantCards = cardsArray.Length;
		panelsArray = new GameObject[cantCards];
		int col = cantCards/2;
			
		//Data for panel
		RectTransform paS = GetComponent<RectTransform>();
		int parentW = (int)paS.sizeDelta[0];
		int parentH = (int)paS.sizeDelta[1];
		int sizepanelsArrayW = parentW/col; 
		int sizepanelsArrayH = parentH/2;
		int initialW = -parentW/2;
		int initialH = parentH/2;
		
		int contW = 0;
		int contH = 0;
		int contIndpanelsArray = 0;
		
		
		for(int i=1;i<=col;++i){
			//Create panel for card
			GameObject panel = new GameObject();
			panel.AddComponent<CanvasRenderer>();
			panel.AddComponent<RectTransform>();
			//panel.AddComponent<Image>();
			panel.transform.SetParent(transform);
			RectTransform pRT = panel.GetComponent<RectTransform>();
			
			pRT.sizeDelta = new Vector2(sizepanelsArrayW, sizepanelsArrayH);
			pRT.localScale = new Vector3(1, 1, 1);
			pRT.localPosition = new Vector3(contW+initialW+(sizepanelsArrayW/2), initialH+(-sizepanelsArrayH/2), 0);
			contW = contW + sizepanelsArrayW;
			
			panelsArray[contIndpanelsArray] = panel;
			
			//Set random CARD
			cardsArray[contIndpanelsArray].transform.SetParent(panel.transform);
			RectTransform cardCenter = cardsArray[contIndpanelsArray].GetComponent<RectTransform>();
			cardCenter.sizeDelta = new Vector2(144, 160);
			cardCenter.localScale = new Vector3(1, 1, 1);
			cardCenter.localPosition = new Vector3(0, 0, 0);
			
			contIndpanelsArray++;
			
		}
		contW = 0;
		contH = -sizepanelsArrayH;
		for(int i=1;i<=col;++i){
			//Create panel for card
			GameObject panel = new GameObject();
			panel.AddComponent<CanvasRenderer>();
			panel.AddComponent<RectTransform>();
			//panel.AddComponent<Image>();
			panel.transform.SetParent(transform);
			RectTransform pRT = panel.GetComponent<RectTransform>();
			
			pRT.sizeDelta = new Vector2(sizepanelsArrayW, sizepanelsArrayH);
			pRT.localScale = new Vector3(1, 1, 1);
			pRT.localPosition = new Vector3(contW+initialW+(sizepanelsArrayW/2), contH+initialH+(-sizepanelsArrayH/2), 0);
			contW = contW + sizepanelsArrayW;
			
			panelsArray[contIndpanelsArray] = panel;
			
			//Set random CARD
			//cardsArray[contIndpanelsArray].transform.parent = panel.transform;
			cardsArray[contIndpanelsArray].transform.SetParent(panel.transform);
			RectTransform cardCenter = cardsArray[contIndpanelsArray].GetComponent<RectTransform>();
			cardCenter.sizeDelta = new Vector2(144, 160);
			cardCenter.localScale = new Vector3(1, 1, 1);
			cardCenter.localPosition = new Vector3(0, 0, 0);
			
			contIndpanelsArray++;
		}
    }
	
	void GenerateCards(){
		int cant = spritesArray.Length*2;
		cardsArray = new GameObject[cant];
		
		int spriteCont = 0;
		for(int i=0;i<cant;i+=2){

			GameObject card = Instantiate(Card,new Vector2 (0, 0), Quaternion.identity);
			Image img = card.GetComponent<Image>();
			img.sprite = spriteReverse;
			CardDefinition cS = card.GetComponent<CardDefinition>();
			cS.SetAnimalSprite(spritesArray[spriteCont]);
			cS.SetId(spritesArray[spriteCont]);
			
			GameObject cardPair = Instantiate(Card,new Vector2 (0, 0), Quaternion.identity);
			Image imgPair = cardPair.GetComponent<Image>();
			imgPair.sprite = spriteReverse;
			CardDefinition cSPair = cardPair.GetComponent<CardDefinition>();
			cSPair.SetAnimalSprite(spritesArray[spriteCont]);
			cSPair.SetId(spritesArray[spriteCont]);
			
			cardsArray[i] = card;
			cardsArray[i+1] = cardPair;
			spriteCont++;
		}
	}
	
	void SetSprites(){
		spriteReverse = Resources.Load <Sprite>("cardReverse");
		
		//Image here 2, 3, 4, 5, 6, 7 or 8
		//Las imagenes se emparejan por nombre por lo que los nombres
	
		Sprite s = Resources.Load <Sprite>("cardReverse_0");
		spritesArray = new string[2]{
			"but",
			"mon"
		};
	}
	
	void Shuffle(GameObject[] values){
		int n = values.Length;
		System.Random rnd = new System.Random();
		for (int i = n - 1; i > 0; i--)
		{
			var j = rnd.Next(0, i);
			var temp = values[i];
			values[i] = values[j];
			values[j] = temp;
		}
	}

}
