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
		yield return C.Me.WalkTo(Point("HallwayL1Enter"),true);
		E.ChangeRoomBG(R.Hallway);
		yield return E.ConsumeEvent;
	}

	void OnEnterRoom()
	{
		if (C.Me.LastRoom == R.Hallway)
			C.Me.SetPosition(Point("HallwayL1Enter"));
		if (C.Me.LastRoom == R.Admin)
			C.Me.SetPosition(Point("AdminEnter"));
		
		
	}

	IEnumerator OnEnterRoomAfterFade()
	{
		if (C.Me.LastRoom == R.Hallway)
			yield return C.Me.WalkTo(Point("HallwayL1EnterWalk"),true);
	}

	IEnumerator OnInteractPropAdmin_door( IProp prop )
	{
		yield return C.WalkToClicked();
		E.ChangeRoomBG(R.Admin);
		yield return E.ConsumeEvent;
	}
}