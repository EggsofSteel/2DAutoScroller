using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsController : MonoBehaviour {

	public Text currentGold;
	public Image expBar;

	public float goldAmount;				//Gold in stash
	public int heroLevel;					//Current hero level
	public float currentExp;				//Current hero exp
	public float expToLvlUp;				//Current exp needed for levelup

	private float expBarRatio;				//Exp bar visual ratio


	void Update () {
		
		currentGold.text = (goldAmount * 10).ToString ("0");				//Gold amount text updater

		expBarRatio = currentExp / expToLvlUp;								//Exp and level calc
		if(currentExp >= expToLvlUp){
			expToLvlUp = expToLvlUp * 2;
			heroLevel++;
		}

		expBar.rectTransform.localScale = new Vector3 (expBarRatio, 1, 1);	//Exp bar visual updater
	}
}
