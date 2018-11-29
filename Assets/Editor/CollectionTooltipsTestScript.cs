using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class CollectionTooltipsTestScript {

    [Test]
    public void CreateToolTipMon_Test() {
        Collection collection = new Collection();
        string monsterName = "Clound";
        string monsterDesc = "It look like clound.";
        int monsterHP = 10;
        int monsterAtk = 1;
        int monsterCri = 0;
        string expectedResult = "<color=#DC143C><b>" + monsterName + "</b></color>\n\n" + monsterDesc + "<color=#CCCC00><b> \n\n HP : " + monsterHP + "\n ATK : " + monsterAtk + "\n Critical Rate : " + monsterCri + "%</b></color>";

        string tooltipsTest = collection.Test_createToolTipMon(monsterName, monsterDesc, monsterHP, monsterAtk, monsterCri);

        Assert.AreEqual(expectedResult, tooltipsTest);

    }

}
