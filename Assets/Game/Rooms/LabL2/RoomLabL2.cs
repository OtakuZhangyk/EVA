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
		Audio.Play("door_open");
		yield return E.WaitSkip();
		E.ChangeRoomBG(R.HallwayL2);
		yield return E.ConsumeEvent;
	}

	void OnEnterRoom()
	{
		if (C.Me.LastRoom == R.HallwayL2)
		{
			Audio.Play("door_close");
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
		Audio.Play("search_cloth");
		yield return E.WaitSkip();
		yield return E.WaitSkip();
		yield return E.WaitSkip();
		yield return E.WaitSkip();
		yield return E.WaitSkip();
		yield return E.WaitSkip();
		yield return E.WaitSkip();
		yield return E.WaitSkip();
		yield return E.WaitSkip();
		yield return C.Me.Say("A key. I wonder what it unlocks.");
		Audio.Play("pickup_keys");
		I.Admin_Key.Add();
		prop.Clickable = false;
		yield return E.Break;
	}
}