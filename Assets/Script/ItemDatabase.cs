using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemDatabase : MonoBehaviour {
	public List<Item> items = new List<Item>();

	void Awake(){
		items.Add (new Item ("Green Potion", 0, "The potion that make from green slime", 1, Item.ItemType.Potion));
		items.Add (new Item ("Red Potion", 1, "The potion that make from blood", 5, Item.ItemType.Potion));
		items.Add (new Item ("Yellow Potion", 2, "The potion that make from shit", 5, Item.ItemType.Potion));
		items.Add (new Item ("Blue Potion", 3, "The potion that make from poison frog", 5, Item.ItemType.Potion));
		items.Add (new Item ("Thug glasses", 4, "The legendary glasses.", 5, Item.ItemType.Equipment));
	}
}
