using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomOfficeL1 : RoomScript<RoomOfficeL1>
{


	IEnumerator OnUseInvPropDoor( IProp prop, IInventory item )
	{

		yield return E.Break;
	}

	IEnumerator OnLookAtPropDoor( IProp prop )
	{

		yield return E.Break;
	}

	IEnumerator OnInteractPropDoor( IProp prop )
	{
		yield return C.WalkToClicked();
		E.ChangeRoomBG(R.Hallway);
		yield return E.ConsumeEvent;
	}

	void OnEnterRoom()
	{
		if (C.Me.LastRoom == R.Hallway)
			C.Me.SetPosition(Point("Enter"));
	}

	IEnumerator OnUseInvPropDrawers( IProp prop, IInventory item )
	{

		yield return E.Break;
	}

	IEnumerator OnInteractPropDrawers( IProp prop )
	{

		yield return E.Break;
	}
}