using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomUndergroundHallway : RoomScript<RoomUndergroundHallway>
{


	IEnumerator OnInteractPropSteelDoor( IProp prop )
	{
		yield return C.WalkToClicked();
		
		E.ChangeRoomBG(R.Lab);
		yield return E.Break;
	}

	void OnEnterRoom()
	{
		if (C.Me.LastRoom == R.Hallway) {
			C.Me.SetPosition(Point("HallwayEntry"));
		}
		if (C.Me.LastRoom == R.Lab) {
			C.Me.SetPosition(Point("LabEntry"));
		}
	}

	IEnumerator OnLookAtPropStairsUp( IProp prop )
	{

		yield return E.Break;
	}

	IEnumerator OnInteractPropStairsUp( IProp prop )
	{
		yield return C.WalkToClicked();
		E.ChangeRoomBG(R.Hallway);
		C.Me.SetPosition(-418,-46);
		yield return E.Break;
	}

	IEnumerator OnEnterRoomAfterFade()
	{
		if (C.Me.LastRoom == R.Hallway) {
			C.Me.WalkToBG(Point("HallwayEntryWalk"));
		}
		if (C.Me.LastRoom == R.Lab) {
			C.Me.WalkToBG(Point("LabEntryWalk"));
		}
		yield return E.Break;
	}

	IEnumerator OnExitRoom( IRoom oldRoom, IRoom newRoom )
	{

		yield return E.Break;
	}
}