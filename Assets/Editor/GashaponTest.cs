using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class GashaponTest{

	[Test]
	public void AddRandomMonster_Test(){
		var inventory = new Inventory ();
		var expectedValue = inventory.Test_AddRandomMonster ();

		Assert.IsTrue (expectedValue);
		

	}
}
