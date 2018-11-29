using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class CollectionTest{

	[Test]
	public void AddAllMonster_Test(){
		var collection = new Collection ();
		var check = collection.Test_AddAllMonster();
		var expectedValue = 8;
		Assert.AreEqual(check, expectedValue);
	}
}
