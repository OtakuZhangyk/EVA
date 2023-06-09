using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomShelter : RoomScript<RoomShelter>
{


	IEnumerator OnInteractPropDoor( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return E.WaitSkip();
		if (Globals.gamePhase == eProgress.EndGame) {
			yield return E.ChangeRoom(R.EndScene);
		}
		else {
			C.Plr.ChangeRoom(R.UndergroundHallway);
		}
		yield return E.Break;
	}

	void OnEnterRoom()
	{
		C.Plr.SetPosition(Point("Entry"));
	}

	IEnumerator OnEnterRoomAfterFade()
	{
		yield return C.Plr.WalkTo(Point("EntryWalk"));
		yield return E.Break;
	}
}