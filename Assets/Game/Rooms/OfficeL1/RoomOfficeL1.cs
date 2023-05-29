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
		C.Me.SetPosition(258,-42);
		yield return E.ConsumeEvent;
	}

	void OnEnterRoom()
	{
		C.Me.SetPosition(Point("Enter"));
	}
}