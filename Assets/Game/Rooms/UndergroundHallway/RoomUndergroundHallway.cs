using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomUndergroundHallway : RoomScript<RoomUndergroundHallway>
{
	public bool bLabOpen = false;
	
	IEnumerator OnInteractPropSteelDoor( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return E.WaitSkip();
		if (bLabOpen) {
			Audio.Play("door_open1");
			E.ChangeRoomBG(R.Lab);
		} else {
			Audio.Play("cant_open");
			yield return C.Me.Say("The door is locked. Need a key.");
		}
		yield return E.Break;
	}

	void OnEnterRoom()
	{
		if (C.Me.LastRoom == R.Hallway) {
			C.Me.SetPosition(Point("HallwayEntry"));
		}
		if (C.Me.LastRoom == R.Lab) {
			Audio.Play("door_close1");
			C.Me.SetPosition(Point("LabEntry"));
		}
	}

	IEnumerator OnLookAtPropStairsUp( IProp prop )
	{
		yield return C.FaceClicked();
		yield return E.WaitSkip();
		yield return C.Me.Say("I can go up to L1 here");
	}

	IEnumerator OnInteractPropStairsUp( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.Me.WalkTo(Point("HallwayEntry"),true);
		E.ChangeRoomBG(R.Hallway);
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

	IEnumerator OnUseInvPropSteelDoor( IProp prop, IInventory item )
	{
		yield return C.WalkToClicked();
		if (!bLabOpen) {
			if (I.LabKey.Active) {
				bLabOpen = true;
				Audio.Play("lock");
			   yield return E.WaitSkip();
				Audio.Play("door_open1");
				E.ChangeRoomBG(R.Lab);
				I.LabKey.Active = false;
				I.LabKey.Remove();
		
			} else if (I.Admin_Key.Active) {
				Audio.Play("lock");
				yield return C.Me.Say("This is the wrong key.");
			} else {
				Audio.Play("cant_open");
			}
		} else {
			Audio.Play("door_open1");
			E.ChangeRoomBG(R.Lab);
		}
		yield return E.Break;
	}

	IEnumerator OnLookAtPropSteelDoor( IProp prop )
	{
		yield return C.FaceClicked();
		yield return E.WaitSkip();
		yield return C.Me.Say("It's a heavy steel door");
	}
}