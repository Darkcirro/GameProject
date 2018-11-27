using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour {
	public int slotsX,  slotsY;
	public GUISkin skin;

	private bool showTooltip;
	private string toolTip;

	public List<Monster> monsterInventory = new List<Monster>();
	public List<Monster> slotsMonster = new List<Monster>();
	private MonsterDatabase databaseMon;
	// Use this for initialization

	void Start () {
		for(int i = 0; i < (slotsX * slotsY); i++){
			slotsMonster.Add (new Monster());
			monsterInventory.Add (new Monster ()); 
		}
		databaseMon = GameObject.FindGameObjectWithTag ("Monster Database").GetComponent<MonsterDatabase> ();
		AddAllMonster ();
	}
	//**************************************************************************************************************************************************
	void OnGUI(){
		toolTip = "";
		GUI.skin = skin;
		DrawAllMonster ();
		if (showTooltip) {
			GUI.Box (new Rect (900, 200, 400, 370), toolTip, skin.GetStyle ("Tooltip"));
		}
	}
	//***************************************************************************************************************************************************
	void DrawAllMonster(){
		Event currentEvent = Event.current;
		int i = 0;
		for(int y = 0; y < slotsY; y++){
			for(int x = 0; x < slotsX; x++){
				Rect slotRect = new Rect(x * 100 + 75, y * 92+200, 90, 90);
				GUI.Box (slotRect, "",skin.GetStyle("Slot"));
				slotsMonster [i] = monsterInventory [i];
				Monster monster = slotsMonster [i];
				if (slotsMonster [i].monsterName != null) {
					GUI.DrawTexture (slotRect, slotsMonster [i].monsterIcon);
					if (slotRect.Contains(Event.current.mousePosition)) {
						toolTip = createToolTipMon (monsterInventory [i]);
						showTooltip = true;
					} else if (toolTip == "")
						showTooltip = false;
				}
				i++;
			}
		}
	}

	private string createToolTipMon(Monster monster){
		toolTip = "";
		toolTip += "<color=#DC143C><b>" + monster.monsterName + "</b></color>\n\n" + monster.monsterDesc +"<color=#CCCC00><b> \n\n HP : " + monster.monsterHP + "\n ATK : " + monster.monsterAtk + "\n Critical Rate : " + monster.monsterCricitalRate + "%</b></color>";
		return toolTip;
	}

	public void AddAllMonster(){
		for (int i = 0; i < databaseMon.monsters.Count; i++) {
			monsterInventory[i] = databaseMon.monsters[i];
			print (databaseMon.monsters.Count);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
