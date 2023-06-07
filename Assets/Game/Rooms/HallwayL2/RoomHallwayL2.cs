using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomHallwayL2 : RoomScript<RoomHallwayL2>
{

	bool admin_door_lock = true;
	
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
		{
			Audio.Play("door_close1");
			C.Me.SetPosition(Point("AdminEnter"));
		}
		if (C.Me.LastRoom == R.LabL2)
		{
			Audio.Play("door_close");
			C.Me.SetPosition(Point("LabEnter"));
		}
	}

	IEnumerator OnEnterRoomAfterFade()
	{
		if (C.Me.LastRoom == R.Hallway)
			yield return C.Me.WalkTo(Point("HallwayL1EnterWalk"),true);
		//if (C.Me.LastRoom == R.LabL2)
		//End
		/*	if (Globals.m_progressExample == eProgress.None)
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
		*/
	}

	IEnumerator OnInteractPropAdmin_door( IProp prop )
	{
		yield return C.WalkToClicked();
		if (admin_door_lock)
		{
			Audio.Play("cant_open");
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			yield return C.Me.Say("It's locked. Need to find a key.");
		}
		else
		{
			Audio.Play("door_open1");
			yield return E.WaitSkip();
			E.ChangeRoomBG(R.Admin);
		}
		yield return E.ConsumeEvent;
	}

	IEnumerator OnInteractPropLab_door( IProp prop )
	{
		yield return C.WalkToClicked();
		Audio.Play("door_open");
		yield return E.WaitSkip();
		E.ChangeRoomBG(R.LabL2);
		yield return E.ConsumeEvent;
	}

	IEnumerator OnUseInvPropAdmin_door( IProp prop, IInventory item )
	{
		yield return C.WalkToClicked();
		if (I.Admin_Key.Active == true)
		{
			admin_door_lock = false;
			I.Admin_Key.Active = false;
			I.Admin_Key.Remove();
			Audio.Play("lock");
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			Audio.Play("door_open1");
			yield return E.WaitSkip();
			E.ChangeRoomBG(R.Admin);
		}
		yield return E.ConsumeEvent;
	}

	IEnumerator OnUseInvPropStairs_down( IProp prop, IInventory item )
	{

		yield return E.Break;
	}

	IEnumerator OnInteractPropMap( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return E.WaitSkip();
		yield return C.Me.Say("This floor has a lab and a hospital director's room");
		yield return E.WaitSkip();
		yield return C.Me.Say("The floor below has an office and an operation room");
		yield return E.WaitSkip();
		yield return C.Me.Say("There is also a basement");
		yield return E.Break;
	}

	IEnumerator OnLookAtPropStairs_down( IProp prop )
	{
		yield return C.FaceClicked();
		yield return E.WaitSkip();
		yield return C.Me.Say("I can go down to L1 here");
	}

	IEnumerator OnLookAtPropAdmin_door( IProp prop )
	{
		yield return C.FaceClicked();
		yield return E.WaitSkip();
		yield return C.Me.Say("It's the hospital director's room");
	}

	IEnumerator OnLookAtPropLab_door( IProp prop )
	{
		yield return C.FaceClicked();
		yield return E.WaitSkip();
		yield return C.Me.Say("It's a lab");
	}

	IEnumerator OnLookAtPropMap( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return E.WaitSkip();
		yield return C.Me.Say("This floor has a lab and a hospital director's room");
		yield return E.WaitSkip();
		yield return C.Me.Say("The floor below has an office and an operation room");
		yield return E.WaitSkip();
		yield return C.Me.Say("There is also a basement");
		yield return E.Break;
	}
}