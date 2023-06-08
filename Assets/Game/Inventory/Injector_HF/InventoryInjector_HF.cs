using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class InventoryInjector_HF : InventoryScript<InventoryInjector_HF>
{


	IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		yield return C.Me.Say("It's an injector, loaded with Compound-5");
		yield return E.Break;
	}

	IEnumerator OnUseInvInventory( IInventory thisItem, IInventory item )
	{
		if (I.LabeledBottle.Active == true)
		{
			Audio.Play("load_injector");
			I.Injector_HF.Active = false;
			I.LabeledBottle.Active = false;
			I.LabeledBottle.Remove();
			I.Injector_HF.Remove();
			I.Injector_F.AddAsActive();
		}
		if (I.Injector_HF.Active == true)
			I.Injector_HF.Active = false;
		yield return E.ConsumeEvent;
	}
}