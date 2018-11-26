using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDatabase : MonoBehaviour {
	public List<Monster> monsters = new List<Monster>();

	void Awake(){
		monsters.Add (new Monster ("Cloude", 0, "It look like clound.", 1, 10, 0));
		monsters.Add (new Monster ("Horn", 1, "It look like devil but It's too weak.", 2, 5, 0)); 
		monsters.Add (new Monster ("Three", 2, "It has three eye.", 1, 10, 30)); 
		monsters.Add (new Monster ("Yellow", 3, "What!! It a yellow slime. Did you know?", 5, 5, 10)); 
		monsters.Add (new Monster ("Deviljho", 4, "This monster is a Food chain destroyer.", 100, 100, 50));
		monsters.Add (new Monster ("Poring", 5, "What a cute slime!", 5, 5, 5));
		monsters.Add (new Monster ("Eevee", 6, "So cute!!!", 1, 1, 100));
		monsters.Add (new Monster ("Pikachu", 7, "A mouse with electric thunder", 20, 58, 10));
	}


}
