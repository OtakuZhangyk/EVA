using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class InventoryInjector : InventoryScript<InventoryInjector>
{


	IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		yield return C.Me.Say("It's an empty injector.");
		yield return E.Break;
	}

	IEnumerator OnInteractInventory( IInventory thisItem )
	{

		yield return E.Break;
	}

	IEnumerator OnUseInvInventory( IInventory thisItem, IInventory item )
	{
		if (I.Compound_5.Active == true)
		{
			Audio.Play("load_injector");
			I.Compound_5.Active = false;
			I.Injector.Active = false;
			I.Compound_5.Remove();
			I.Injector.Remove();
			I.Injector_HF.AddAsActive();
		}
		if (I.Injector.Active == true)
			I.Injector.Active = false;
		yield return E.ConsumeEvent;
	}
}