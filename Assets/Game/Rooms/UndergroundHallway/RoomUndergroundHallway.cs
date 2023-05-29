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
}