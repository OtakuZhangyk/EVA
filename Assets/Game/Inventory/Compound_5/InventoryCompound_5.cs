using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class InventoryCompound_5 : InventoryScript<InventoryCompound_5>
{


	IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		yield return C.Me.Say("A bottle of red solution. The label says 'Compound-5'");
	}

	IEnumerator OnUseInvInventory( IInventory thisItem, IInventory item )
	{
		if (I.Injector.Active == true)
		{
			Audio.Play("load_injector");
			I.Injector.Active = false;
			I.Compound_5.Active = false;
			I.Compound_5.Remove();
			I.Injector.Remove();
			I.Injector_HF.AddAsActive();
		}
		if (I.Compound_5.Active == true)
			I.Compound_5.Active = false;
		yield return E.ConsumeEvent;
	}
}