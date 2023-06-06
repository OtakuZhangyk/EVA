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
}