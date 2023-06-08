using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class InventoryInjector_F : InventoryScript<InventoryInjector_F>
{


	IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		yield return C.Me.Say("It's an injector, loaded with Compound-5 and Protocol-T");
		yield return E.Break;
	}
}