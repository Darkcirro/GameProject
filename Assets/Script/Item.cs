using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item {
	public string itemName;
	public int itemID;
	public string itemDesc;
	public Texture2D itemIcon;
	public int itemPower;
	public ItemType itemType;

	public enum ItemType{
		Potion,
		Equipment
	}

	public Item(string name, int id, string desc, int power, ItemType type){
		itemName = name;
		itemID = id;
		itemDesc = desc;
		itemIcon = Resources.Load<Texture2D> ("Icon/" + itemName);
		itemPower = power;
		itemType = type;

	}

	public Item(){
		itemID = -1;
	}
}
