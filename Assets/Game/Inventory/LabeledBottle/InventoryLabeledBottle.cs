using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class InventoryLabeledBottle : InventoryScript<InventoryLabeledBottle>
{


	IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		yield return C.Me.Say("A bottle of blue solution. The label says 'Protocol-T'");
		yield return E.Break;
	}

	IEnumerator OnUseInvInventory( IInventory thisItem, IInventory item )
	{
		if (I.Injector_HF.Active == true)
		{
			Audio.Play("load_injector");
			I.Injector_HF.Active = false;
			I.LabeledBottle.Active = false;
			I.LabeledBottle.Remove();
			I.Injector_HF.Remove();
			I.Injector_F.AddAsActive();
		}
		if (I.Injector.Active == true)
			yield return C.Me.Say("I should load Compound-5 first");
		if (I.LabeledBottle.Active == true)
			I.LabeledBottle.Active = false;
		yield return E.ConsumeEvent;
	}
}