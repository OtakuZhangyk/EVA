using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomHallway : RoomScript<RoomHallway>
{


	IEnumerator OnInteractPropOperation_Room( IProp prop )
	{
		E.ChangeRoomBG(R.Operation_Room);
		yield return E.ConsumeEvent;
	}

	IEnumerator OnInteractPropOperationRoom( IProp prop )
	{
		yield return C.WalkToClicked();
		E.ChangeRoomBG(R.Operation_Room);
		yield return E.ConsumeEvent;
	}

	IEnumerator OnInteractPropOffice_door( IProp prop )
	{
		yield return C.WalkToClicked();
		E.ChangeRoomBG(R.OfficeL1);
		yield return E.ConsumeEvent;
	}

	IEnumerator OnInteractPropStair_up( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.Me.WalkTo(Point("HallwayL2Enter"),true);
		E.ChangeRoomBG(R.HallwayL2);
		yield return E.ConsumeEvent;
	}

	IEnumerator OnInteractPropStair_down( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.Me.WalkTo(Point("UndergroundHallwayEntry"));
		yield return E.ChangeRoom(R.UndergroundHallway);
		yield return E.Break;
	}

	void OnEnterRoom()
	{
		if (C.Me.LastRoom == R.UndergroundHallway)
			C.Me.SetPosition(Point("UndergroundHallwayEntry"));
		if (C.Me.LastRoom == R.Operation_Room)
			C.Me.SetPosition(Point("OpEnter"));
		if (C.Me.LastRoom == R.OfficeL1)
			C.Me.SetPosition(Point("OfficeEnter"));
		if (C.Me.LastRoom == R.HallwayL2)
			C.Me.SetPosition(Point("HallwayL2Enter"));
	}

	IEnumerator OnEnterRoomAfterFade()
	{
		if (C.Me.LastRoom == R.UndergroundHallway)
			yield return C.Me.WalkTo(Point("UndergroundHallwayEntryWalk"),true);
		if (C.Me.LastRoom == R.HallwayL2)
			yield return C.Me.WalkTo(Point("HallwayL2EnterWalk"),true);
		
	}
}