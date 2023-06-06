using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class InventoryInjector : InventoryScript<InventoryInjector>
{


	IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		yield return C.Me.Say("It's a needle... with glowing solution remaining inside.");
		yield return E.Break;
	}
}