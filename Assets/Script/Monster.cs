using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Monster {

	public string monsterName;
	public int monsterID;
	public string monsterDesc;
	public int monsterAtk;
	public int monsterHP;
	public int monsterCricitalRate;
	public Texture2D monsterIcon;

	public Monster(string name, int id, string desc, int atk, int hp, int critical){
		monsterName = name;
		monsterDesc = desc;
		monsterID = id;
		monsterIcon = Resources.Load<Texture2D> ("Monster/"+monsterName);
		monsterAtk = atk;
		monsterHP = hp;
		monsterCricitalRate = critical;
	}

	public Monster(){
		monsterID = -1;
	}
}
