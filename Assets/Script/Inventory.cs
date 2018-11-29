using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
	public int slotsX,  slotsY;
	public GUISkin skin;
	public List<Item> inventory = new List<Item> ();
	public List<Item> slots = new List<Item> ();
	private ItemDatabase database;

	private bool showTooltip = false;
	private string toolTip;

	private bool draggingItem = false;
	private Item draggedItem;

	private bool draggingMonster = false;
	private Monster draggedMonster;
	private int prevIndex;
	private int prevIndex2;
	//**********************************************************************************
	public List<Monster> monsterInventory = new List<Monster>();
	public List<Monster> slotsMonster = new List<Monster>();
	private MonsterDatabase databaseMon;

	private bool changeInventory = false;

	private bool sceneCheck = true;
	public string scene;

	private bool openGashaCheck=false;
	private int randomID;

	public Button gashaButton;
	private Monster newMonster;
	public bool inventoryFull = false;
	private bool inventoryCheck = false;

	public Texture2D Pic;
	//**********************************************************************************
	// Use this for initialization
	void Start () {
		for(int i = 0; i < (slotsX * slotsY); i++){
			slots.Add (new Item());
			inventory.Add (new Item ()); 
		}
		for(int i = 0; i < (slotsX * slotsY); i++){
			slotsMonster.Add (new Monster());
			monsterInventory.Add (new Monster ()); 
		}
		database = GameObject.FindGameObjectWithTag ("Item Database").GetComponent<ItemDatabase>();
		databaseMon = GameObject.FindGameObjectWithTag ("Monster Database").GetComponent<MonsterDatabase> ();

		for (int i = 0; i < inventory.Count; i++) {
			inventory [i] = PlayerPrefs.GetInt ("Inventory " + i, -1) >= 0 ? database.items [PlayerPrefs.GetInt ("Inventory " + i)] : new Item (); 
		}

		for (int i = 0; i < monsterInventory.Count; i++) {
			monsterInventory [i] = PlayerPrefs.GetInt ("Monster Inventory " + i, -1) >= 0 ? databaseMon.monsters [PlayerPrefs.GetInt ("Monster Inventory " + i)] : new Monster (); 
		}

		if (scene == "Gashapon") {
			gashaButton.interactable = true;
		}
		AddItem (0);
		AddItem (1);
		AddItem (2);
	}
		

	void OnGUI(){
		Vector2 mousePosition = new Vector2 (Input.mousePosition.x, Screen.height - Input.mousePosition.y);

		if (scene == "Gashapon")
			sceneCheck = false;
		else
			sceneCheck = true;

		toolTip = "";
		GUI.skin = skin;
		if (sceneCheck) {
			if (changeInventory)
				DrawInventory ();
			if (!changeInventory)
				DrawInventoryMonster ();
				
			if (GUI.Button (new Rect (40, 150, 375, 63), "Monster Collection")) {
				changeInventory = false;

			}
			if (GUI.Button (new Rect (445, 150, 375, 63), "Item Collection")) {
				changeInventory = true;
			}

			if (showTooltip) {
				GUI.Box (new Rect (mousePosition.x+5f,mousePosition.y +5f, 370, 370), toolTip, skin.GetStyle ("Tooltip"));
			}
			if (draggingItem) {
				GUI.DrawTexture (new Rect (Event.current.mousePosition.x, Event.current.mousePosition.y, 100, 100), draggedItem.itemIcon);
			}
			if (draggingMonster) {
				GUI.DrawTexture (new Rect (Event.current.mousePosition.x, Event.current.mousePosition.y, 100, 100), draggedMonster.monsterIcon);
			}
		} else {
			if (openGashaCheck) {
				showRandomMonster ();
				gashaButton.interactable = false;
				if (GUI.Button (new Rect (Screen.width/2-187, Screen.height/2+170, 375, 63), "OK")) {
					openGashaCheck = false;
					StartCoroutine (DelayButton());
				}
			}
		}

		if (inventoryFull) {
			gashaButton.interactable = false;
			GUI.Box (new Rect (Screen.width/2-200, Screen.height/2-200, 400, 400), "", skin.GetStyle("Slot"));
			GUI.DrawTexture (new Rect (Screen.width/2-75, Screen.height/2-75, 150, 150), Pic);
			GUI.Label (new Rect (Screen.width / 2-150, Screen.height / 2-150 ,1000,200), "Inventory is full.",skin.GetStyle("label"));
			if (GUI.Button (new Rect (Screen.width/2-187, Screen.height/2+100, 375, 63), "OK")) {
				inventoryFull = false;
				StartCoroutine (DelayButton());
			}
		}

		if (inventoryCheck) {
			GUI.Box (new Rect (Screen.width/2-200, Screen.height/2-200, 400, 400), "", skin.GetStyle("Slot"));
			GUI.DrawTexture (new Rect (Screen.width/2-75, Screen.height/2-75, 150, 150), Pic);
			GUI.Label (new Rect (Screen.width / 2-150, Screen.height / 2-150 ,400,200), "Can't Delete Monster.",skin.GetStyle("label"));
			if (GUI.Button (new Rect (Screen.width/2-187, Screen.height/2+100, 375, 63), "OK")) {
				inventoryCheck = false;
			}
		}

	}

	IEnumerator DelayButton(float delay = 0.001f){
		yield return new WaitForSeconds (delay);
		gashaButton.interactable = true;
	}
	//******************************************************************************************************************************************************
	void DrawInventory(){
		Event currentEvent = Event.current;
		int i = 0;
		Vector2 mousePosition = new Vector2 (Input.mousePosition.x, Screen.height - Input.mousePosition.y);

		for(int y = 0; y < slotsY; y++){
			for(int x = 0; x < slotsX; x++){
				Rect slotRect = new Rect(x * 100 + 90, y * 92+250, 90, 90);
				GUI.Box (slotRect, "",skin.GetStyle("Slot"));
				slots [i] = inventory [i];
				Item item = slots [i];
				if (slots [i].itemName != null) {
					GUI.DrawTexture (slotRect, slots [i].itemIcon);
					if (slotRect.Contains (mousePosition)) {
						if (currentEvent.button == 0 && currentEvent.type == EventType.MouseDrag && !draggingItem) {
							draggingItem = true;
							prevIndex = i;
							draggedItem = slots [i]; 
							inventory [i] = new Item ();
						}
						if (currentEvent.type == EventType.MouseUp && draggingItem) {
							inventory [prevIndex] = inventory [i];
							inventory [i] = draggedItem;
							draggingItem = false;
							draggedItem = null;
						}
						if (!draggingItem) {
							showTooltip = true;
							toolTip = createToolTip (inventory [i]);
						}
						if(currentEvent.isMouse && currentEvent.type == EventType.MouseDown && currentEvent.button == 1){
							if (item.itemType == Item.ItemType.Potion) {
								UsePotion (slots[i], i,true);
							}
						}
					}						
					if(toolTip == ""){
						showTooltip = false;
					}
				} else {
					if(slotRect.Contains(currentEvent.mousePosition)){
						if(currentEvent.type == EventType.MouseUp && draggingItem){
							inventory [i] = draggedItem;
							draggingItem = false;
							draggedItem = null;
						}
					}
				}
				i++;
			}
		}
	}
	//*****************************************************************************************************************************************************
	public void DrawInventoryMonster(){
		Event currentEvent = Event.current;
		int i = 0;
		Vector2 mousePosition = new Vector2 (Input.mousePosition.x, Screen.height - Input.mousePosition.y);


		for(int y = 0; y < slotsY; y++){
			for(int x = 0; x < slotsX; x++){
				Rect slotRect = new Rect(x * 100 + 90, y * 92+250, 90, 90);
				GUI.Box (slotRect, "",skin.GetStyle("Slot"));
				slotsMonster [i] = monsterInventory [i];
				Monster monster = slotsMonster [i];

				if (slotsMonster [i].monsterName != null) {
					GUI.DrawTexture (slotRect, slotsMonster [i].monsterIcon);
					if (slotRect.Contains (mousePosition)) {
						if (currentEvent.button == 0 && currentEvent.type == EventType.MouseDrag && !draggingMonster) {
							draggingMonster = true;
							prevIndex2 = i;
							draggedMonster = slotsMonster [i]; 
							monsterInventory [i] = new Monster ();
						}
						if (currentEvent.type == EventType.MouseUp && draggingMonster) {
							monsterInventory [prevIndex2] = monsterInventory [i];
							monsterInventory [i] = draggedMonster;
							draggingMonster = false;
							draggedItem = null;
						}
						if (!draggingMonster) {
							showTooltip = true;
							toolTip = createToolTipMon (monsterInventory [i]);
						}

						if(currentEvent.isMouse && currentEvent.type == EventType.MouseDown && currentEvent.button == 1){
							//print("Remove > " + slotsMonster[i].monsterName);
							print("Count " + slotsMonster.Count);
							RemoveMonster (slotsMonster[i], i );
						}
					}

					if(toolTip == ""){
						showTooltip = false;
					}
				} else {
					if(slotRect.Contains(currentEvent.mousePosition)){
						if(currentEvent.type == EventType.MouseUp && draggingMonster){
							monsterInventory [i] = draggedMonster;
							draggingMonster = false;
							draggedItem = null;
						}
					}
				}
				i++;
			}
		}
	}
	//***************************************************************************************************************************************
	private string createToolTip(Item item){
		toolTip = "";
		toolTip += "<color=#DC143C><b>" + item.itemName + "</b></color>\n\n" + item.itemDesc;
		return toolTip;
	}

	private string createToolTipMon(Monster monster){
		toolTip = "";
		toolTip += "<color=#DC143C><b>" + monster.monsterName + "</b></color>\n\n" + monster.monsterDesc +"<color=#CCCC00><b> \n\n HP : " + monster.monsterHP + "\n ATK : " + monster.monsterAtk + "\n Critical Rate : " + monster.monsterCricitalRate + "%</b></color>";
		return toolTip;
	}
	//****************************************************************************************************************************************
	public void AddItem(int id){
		for (int i = 0; i < inventory.Count; i++) {
				if (inventory [i].itemName == null) {
					for(int j = 0; j < database.items.Count; j++){
						if (database.items [j].itemID == id) {
							inventory [i] = database.items [j];
						}
					}
					break;
				}
		}
	}

	public void AddMonster(int id){
			for (int i = 0; i < monsterInventory.Count; i++) {
				if (monsterInventory [i].monsterName == null) {
					for (int j = 0; j < databaseMon.monsters.Count; j++) {
						if (databaseMon.monsters [j].monsterID == id) {
							monsterInventory [i] = databaseMon.monsters [j];
						}
					}
					break;
				}
			}
	}


	public void AddRandomMonster(){
		for (int j = 0; j < monsterInventory.Count; j++) {
			if (monsterInventory [j].monsterName == null) {
				for (int i = 0; i < monsterInventory.Count; i++) {
					if (monsterInventory [i].monsterName == null) {
						randomID = Random.Range (0, databaseMon.monsters.Count);
						monsterInventory [i] = databaseMon.monsters [randomID];
						print ("Name : " + databaseMon.monsters [randomID].monsterName + "\n ID : " + randomID + "");
						break;
					}
				}
				openGashaCheck = true;
				if (monsterInventory [j].monsterName != null) {
					break;
				}
			} else {
				if (j == monsterInventory.Count - 1) {
					inventoryFull = true;
					break;
				}
			}
		}
	}

	void RemoveItem(int id){
		for (int i = 0; i < inventory.Count; i++) {
			if (inventory [i].itemID == id) {
				inventory [i] = new Item ();
				break;
			}
		}
	}

	void RemoveMonster(Monster monster,int slot){
		if(slot >=4) {
			for (int i = slot; i < monsterInventory.Count; i++) {
				if (i != monsterInventory.Count - 1) {
					newMonster = monsterInventory [i + 1];
					monsterInventory [i] = new Monster ();
					monsterInventory [i] = newMonster;
				} else if (i == monsterInventory.Count - 1) {
					monsterInventory [i] = new Monster ();
				}
			}
		} else {
			inventoryCheck = true;
		}
	}

	private void UsePotion(Item item, int slot, bool deleteItem){
		switch(item.itemID){
			case 1:
			{
				//MonsterStats.IncreaseStat (// HP, Attack, Critical chance);
				//print("USE Potion : " + item.itemName);
				break;
			}
			/*case 1:
			{
				//MonsterStats.IncreaseStat (// HP, Attack, Critical chance);
			}*/
		}
		if (deleteItem) {
			inventory [slot] = new Item ();
		}
	}

	bool InventoryContains(int id){ 		//check Item in database
		bool result = false;
		for (int i = 0; i < inventory.Count; i++) {
			if (inventory [i].itemID == id) {
				result = true;
			} else {
				result = false;
			}
			if (result)
				break;
		}
		return result;
	}


	public void SaveInventoryItem(){
		for (int i = 0; i < inventory.Count; i++)
			PlayerPrefs.SetInt ("Inventory " +i, inventory [i].itemID);
	}

	public void SaveInventoryMonster(){
		for (int j = 0; j < monsterInventory.Count; j++)
			PlayerPrefs.SetInt ("Monster Inventory " + j, monsterInventory [j].monsterID);
	}



	public void showRandomMonster(){
		
		GUI.Box (new Rect (Screen.width/2-250, Screen.height/2-250, 500, 500), "", skin.GetStyle("Slot"));
		GUI.DrawTexture (new Rect (Screen.width/2-150, Screen.height/2-150, 300, 300), databaseMon.monsters[randomID].monsterIcon);
		GUI.Label (new Rect (Screen.width / 2-100, Screen.height / 2 - 200,1000,200), "YOU GOT",skin.GetStyle("label"));
	}

	//unit Test
	public int Test_ItemSlot(int slotX,int slotY){
		for(int i = 0; i < (slotX * slotY); i++){
			slots.Add (new Item());
		}
		return slots.Count;
	}
	public int Test_ItemInventory(int slotX,int slotY){
		for(int i = 0; i < (slotX * slotY); i++){	
			inventory.Add (new Item ()); 
		}
		return inventory.Count;
	}
	public int Test_slotsMonster(int slotX,int slotY){
		for(int i = 0; i < (slotX * slotY); i++){
			slotsMonster.Add (new Monster());
		}
		return slotsMonster.Count;
	}
	public int Test_monsterInventory(int slotX,int slotY){
		for(int i = 0; i < (slotX * slotY); i++){
			monsterInventory.Add (new Monster ()); 
		}
		return monsterInventory.Count;
	}

}
