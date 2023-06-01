using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomOperation_Room : RoomScript<RoomOperation_Room>
{


	IEnumerator OnInteractPropDoor( IProp prop )
	{
		yield return C.WalkToClicked();
		Audio.Play("door_open");
		yield return E.WaitSkip();
		E.ChangeRoomBG(R.Hallway);
		yield return E.ConsumeEvent;
	}

	IEnumerator OnInteractPropHandnote( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		
		prop.Disable();
		I.Handnote.Add();
		yield return E.WaitSkip();
		//C.Player.FaceDown();
		yield return C.Me.Say("A notebook? I wonder what it says...");
		yield return E.WaitSkip();
		yield return C.Display("Access your Inventory from the top left of the screen");
		yield return C.Display("Right click on item to inspect");
		
		yield return E.Break;
	}

	IEnumerator OnLookAtPropHandnote( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return C.Me.Say("A handnote? Who left it here?");
		yield return E.Break;
	}

	IEnumerator OnLookAtPropDoor( IProp prop )
	{
		yield return C.WalkToClicked();
		E.ChangeRoomBG(R.Hallway);
		C.Me.SetPosition(-263,-46);
		yield return E.ConsumeEvent;
		
	}

	void OnEnterRoom()
	{
		if (C.Me.LastRoom == R.Title)
		{
			C.Me.SetPosition(Point("Spawn"));
			Audio.PlayMusic("hospital_bgm");
		}
		if (C.Me.LastRoom == R.Hallway)
		{
			C.Me.SetPosition(Point("Enter"));
			Audio.Play("door_close");
		}
	}

	IEnumerator OnUseInvPropHandnote( IProp prop, IInventory item )
	{

		yield return E.Break;
	}

	IEnumerator OnEnterRoomAfterFade()
	{

		yield return E.Break;
	}
}