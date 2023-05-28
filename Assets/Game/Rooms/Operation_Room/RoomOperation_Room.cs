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
		E.ChangeRoomBG(R.Hallway);
		yield return E.ConsumeEvent;
	}

	IEnumerator OnInteractPropHandnote( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return C.Display("Dave stoops to pick up the bucket");
		prop.Disable();
		I.Handnote.Add();
		yield return E.WaitSkip();
		yield return C.Player.FaceDown();
		yield return C.Me.Say("Say something.");
		yield return E.WaitSkip();
		yield return C.Display("Access your Inventory from the top of the screen");
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
}