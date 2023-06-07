using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class InventoryHeadGear : InventoryScript<InventoryHeadGear>
{


	IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		if (R.Current != R.Lab)
			yield return C.Me.Say("I can't use that here..");
		else {
			yield return C.Me.Say("Let's do this.");
		}
		yield return E.Break;
	}
}