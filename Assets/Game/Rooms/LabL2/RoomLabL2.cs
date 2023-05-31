using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomLabL2 : RoomScript<RoomLabL2>
{


	IEnumerator OnInteractPropDoor( IProp prop )
	{
		yield return C.WalkToClicked();
		E.ChangeRoomBG(R.HallwayL2);
		yield return E.ConsumeEvent;
	}

	void OnEnterRoom()
	{
		if (C.Me.LastRoom == R.HallwayL2)
		{
			C.Me.SetPosition(Point("Enter"));
		}
		if (Globals.m_progressExample == eProgress.LeaveLabL2)
		{
			Prop("Protect_suit").Disable();
			Prop("Prot_suitF").Visible = true;
			Region("Block_by_suit").Walkable = false;
		}
		if (Globals.m_progressExample == eProgress.None)
		{
			Prop("Prot_suitF").Visible = false;
		}
	}

	IEnumerator OnInteractPropProtect_suit( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		
		I.Admin_Key.Add();
		yield return E.Break;
	}
}