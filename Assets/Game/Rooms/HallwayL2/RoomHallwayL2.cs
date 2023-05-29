using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomHallwayL2 : RoomScript<RoomHallwayL2>
{


	IEnumerator OnInteractPropStairs_down( IProp prop )
	{
		yield return C.WalkToClicked();
		E.ChangeRoomBG(R.Hallway);
		C.Me.SetPosition(393,-43);
		yield return E.ConsumeEvent;
	}
}