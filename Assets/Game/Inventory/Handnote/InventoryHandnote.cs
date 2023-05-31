using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class InventoryHandnote : InventoryScript<InventoryHandnote>
{


	IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		E.ChangeRoomBG(R.Handnote);
		yield return E.Break;
	}

	IEnumerator OnUseInvInventory( IInventory thisItem, IInventory item )
	{
		if (I.Handnote.Active == true)
			E.ChangeRoomBG(R.Handnote);
		yield return E.Break;
	}

	IEnumerator OnInteractInventory( IInventory thisItem )
	{
		
		yield return E.Break;
	}
}