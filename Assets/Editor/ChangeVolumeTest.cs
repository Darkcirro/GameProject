using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class ChangeVolumeTest {
	[Test]
	public void ChangeVolume_Test(){

		var changeVolume = new ChangeVolume();
		var expectedValue = 0;
		var volume = changeVolume.Test_SetVolume(1);
		Assert.That (volume, Is.EqualTo(expectedValue));
	}
}
