using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class InventoryHandnote : InventoryScript<InventoryHandnote>
{


	IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		yield return C.Display("It's a blue cup");
		yield return C.Display("I mean... a bucket");
		yield return E.Break;
	}

	IEnumerator OnUseInvInventory( IInventory thisItem, IInventory item )
	{

		yield return E.Break;
	}
}