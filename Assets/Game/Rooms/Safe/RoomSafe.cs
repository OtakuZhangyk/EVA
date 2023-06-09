using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomSafe : RoomScript<RoomSafe>
{


	IEnumerator OnInteractHotspotNumPad( IHotspot hotspot )
	{
		yield return E.ChangeRoom(R.PasscodePad);
		yield return E.Break;
	}

	void OnEnterRoom()
	{
		C.Plr.Disable();
		G.InventoryBar.Visible = false;
		Hotspot("Handle").Enable();
		Prop("Notebook").Disable();
		Prop("LabeledBottle").Disable();

	}

	IEnumerator OnExitRoom( IRoom oldRoom, IRoom newRoom )
	{
		C.Plr.Enable();
		G.InventoryBar.Visible = true;
		if (Hotspot("Handle").Clickable == false)
			Audio.Play("safe_door");
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotHandle( IHotspot hotspot )
	{
		if (RoomAdmin.Script.bSafeUnlocked == true) {
			Audio.Play("safe_door");
			yield return Prop("Background").PlayAnimation("Opensafe");
			Hotspot("Handle").Disable();
			Hotspot("Numpad").Disable();
			if (!I.SecretNotebook.EverCollected) {
				Prop("Notebook").Enable();
			}
			if (!I.LabeledBottle.EverCollected) {
				Prop("LabeledBottle").Enable();
			}
		} else {
			yield return C.Display("The safe is locked.");
		}
		yield return E.Break;
	}

	IEnumerator OnInteractHotspotNumpad( IHotspot hotspot )
	{
		yield return E.ChangeRoom(R.PasscodePad);
		yield return E.Break;
	}

	IEnumerator OnInteractPropExitButton( IProp prop )
	{
		yield return E.ChangeRoom(R.Admin);
		yield return E.Break;
	}

	IEnumerator OnInteractPropLabeledBottle( IProp prop )
	{
		Audio.Play("pickup_glass");
		Prop("LabeledBottle").Disable();
		I.LabeledBottle.Add();
		yield return E.ConsumeEvent;
	}

	IEnumerator OnInteractPropNotebook(IProp prop)
	{
		Audio.Play("book_flip");
		Prop("Notebook").Disable();
		I.SecretNotebook.Add();
		yield return E.ConsumeEvent;
	}

	IEnumerator OnLookAtPropExitButton( IProp prop )
	{
		yield return E.ConsumeEvent;
	}

	IEnumerator OnLookAtPropNotebook( IProp prop )
	{
		Prop("Notebook").Disable();
		I.SecretNotebook.Add();
		yield return E.ConsumeEvent;
	}

	IEnumerator OnLookAtPropLabeledBottle( IProp prop )
	{
		Prop("LabeledBottle").Disable();
		I.LabeledBottle.Add();
		yield return E.ConsumeEvent;
	}

	IEnumerator OnLookAtHotspotHandle( IHotspot hotspot )
	{
		yield return E.ConsumeEvent;
	}

	IEnumerator OnLookAtHotspotNumpad( IHotspot hotspot )
	{
		yield return E.ConsumeEvent;
	}
}