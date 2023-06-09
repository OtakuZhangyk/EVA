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
			//E.ChangeRoom(R.EndScene);
		}
		else {
			C.Plr.ChangeRoom(R.UndergroundHallway);
		}
		yield return E.Break;
	}
}