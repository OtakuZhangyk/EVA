using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class InventorySecretNotebook : InventoryScript<InventorySecretNotebook>
{


	IEnumerator OnInteractInventory( IInventory thisItem )
	{
		
		yield return E.Break;
	}

	IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		Audio.Play("book_flip");
		E.ChangeRoomBG(R.SecretHandnote);
		yield return E.Break;
	}

	IEnumerator OnUseInvInventory( IInventory thisItem, IInventory item )
	{
		if (I.SecretNotebook.Active == true)
			Audio.Play("book_flip");
			E.ChangeRoomBG(R.SecretHandnote);
			I.SecretNotebook.Active = false;
		yield return E.Break;
	}
}