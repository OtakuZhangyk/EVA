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
		Audio.Play("door_open");
		yield return E.WaitSkip();
		E.ChangeRoomBG(R.Operation_Room);
		yield return E.ConsumeEvent;
	}

	IEnumerator OnInteractPropOffice_door( IProp prop )
	{
		yield return C.WalkToClicked();
		Audio.Play("door_open1");
		yield return E.WaitSkip();
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
		{
			Audio.Play("door_close");
			C.Me.SetPosition(Point("OpEnter"));
		}
		if (C.Me.LastRoom == R.OfficeL1)
		{
			Audio.Play("door_close1");
			C.Me.SetPosition(Point("OfficeEnter"));
		}
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

	IEnumerator OnEnterRegionScale_Stair_Down( IRegion region, ICharacter character )
	{

		yield return E.Break;
	}

	IEnumerator OnInteractPropBoard( IProp prop )
	{
		if (prop.FirstUse)
			yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return E.WaitSkip();
		yield return C.Me.Say("Just some posters, nothing special");
	}

	IEnumerator OnLookAtPropOperationRoom( IProp prop )
	{
		yield return C.FaceClicked();
		yield return E.WaitSkip();
		yield return C.Me.Say("It's operation room");
		yield return E.Break;
	}

	IEnumerator OnLookAtPropMap( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return E.WaitSkip();
		yield return C.Me.Say("This floor has an office and an operation room");
		yield return E.WaitSkip();
		yield return C.Me.Say("The floor above has a lab and a hospital director's room");
		yield return E.WaitSkip();
		yield return C.Me.Say("It shows the hospital also has a basement");
		yield return E.Break;
	}

	IEnumerator OnLookAtPropBoard( IProp prop )
	{
		yield return C.FaceClicked();
		yield return E.WaitSkip();
		yield return C.Me.Say("Just some posters, nothing special");
	}

	IEnumerator OnInteractPropMap( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return E.WaitSkip();
		yield return C.Me.Say("This floor has an office and an operation room");
		yield return E.WaitSkip();
		yield return C.Me.Say("The floor above has a lab and a hospital director's room");
		yield return E.WaitSkip();
		yield return C.Me.Say("It shows the hospital also has a basement");
		yield return E.Break;
	}

	IEnumerator OnLookAtPropStair_down( IProp prop )
	{
		yield return C.FaceClicked();
		yield return E.WaitSkip();
		yield return C.Me.Say("It goes to the basement");
	}

	IEnumerator OnLookAtPropStair_up( IProp prop )
	{
		yield return C.FaceClicked();
		yield return E.WaitSkip();
		yield return C.Me.Say("I can go to L2 here");
	}

	IEnumerator OnLookAtPropOffice_door( IProp prop )
	{
		yield return C.FaceClicked();
		yield return E.WaitSkip();
		yield return C.Me.Say("It's an office");
	}
}