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
		if (C.Me.LastRoom == R.LabL2)
			C.Me.SetPosition(Point("LabEnter"));
		
	}

	IEnumerator OnEnterRoomAfterFade()
	{
		if (C.Me.LastRoom == R.Hallway)
			yield return C.Me.WalkTo(Point("HallwayL1EnterWalk"),true);
		if (C.Me.LastRoom == R.LabL2)
			if (Globals.m_progressExample == eProgress.None)
			{
				yield return C.Me.WalkTo(Point("LabEnterWalk"),true);
				Camera.Shake(3);
				//play a sfx: heavy item drop on ground
				yield return E.WaitSkip();
				yield return C.Me.Face(Point("LabEnter"));
				yield return E.WaitSkip();
				yield return E.WaitSkip();
				Globals.m_progressExample = eProgress.LeaveLabL2;
				yield return C.Me.WalkTo(Point("LabEnter"),true);
				E.ChangeRoomBG(R.LabL2);
			}
		
	}

	IEnumerator OnInteractPropAdmin_door( IProp prop )
	{
		yield return C.WalkToClicked();
		E.ChangeRoomBG(R.Admin);
		yield return E.ConsumeEvent;
	}

	IEnumerator OnInteractPropLab_door( IProp prop )
	{
		yield return C.WalkToClicked();
		E.ChangeRoomBG(R.LabL2);
		yield return E.ConsumeEvent;
	}
}