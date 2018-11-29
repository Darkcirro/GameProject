using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class InventoryTest {

    [Test]
    public void ItemSlot_Test() {
        // Use the Assert class to test conditions.
		var Inventory = new Inventory();
		int x=12,y=4;
		int expectedTotal = 48;
		int point = Inventory.Test_ItemSlot(x,y);
		Assert.That (point, Is.EqualTo(expectedTotal));
    }
	[Test]
	public void ItemInventory_Test() {
        // Use the Assert class to test conditions.
		var Inventory = new Inventory();
		int x=12,y=4;
		int expectedTotal = 48;
		int point = Inventory.Test_ItemInventory(x,y);
		Assert.That (point, Is.EqualTo(expectedTotal));
    }
	[Test]
	public void slotsMonster_Test() {
        // Use the Assert class to test conditions.
		var Inventory = new Inventory();
		int x=12,y=4;
		int expectedTotal = 48;
		int point = Inventory.Test_slotsMonster(x,y);
		Assert.That (point, Is.EqualTo(expectedTotal));
    }
	[Test]
	public void monsterInventory_Test() {
        // Use the Assert class to test conditions.
		var Inventory = new Inventory();
		int x=12,y=4;
		int expectedTotal = 48 ;
		int point = Inventory.Test_monsterInventory(x,y);
		Assert.That (point, Is.EqualTo(expectedTotal));
    }
    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    /*[UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }*/
}
