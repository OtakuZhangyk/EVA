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
		yield return C.FaceClicked();
		yield return C.Me.Say("Looks like doors to the hallway.");
		yield return E.ConsumeEvent;
		
	}

	void OnEnterRoom()
	{
		if (FirstTimeVisited) {
			E.FadeIn(3);
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
		if (FirstTimeVisited) {
			yield return C.Plr.WalkTo(0,-80);
			yield return C.Plr.FaceLeft();
			yield return E.WaitSkip();
			yield return C.Plr.FaceRight();
			yield return E.WaitSkip();
			yield return C.Me.Say("Where am I? Why am I here?");
			yield return E.WaitSkip();
			yield return C.Me.Say("Who am I? I don't remember anything...");
		}
		yield return E.Break;
	}

	IEnumerator OnInteractPropNeedle( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		
		prop.Disable();
		I.Needle.Add();
		yield return E.WaitSkip();
		yield return E.Break;
	}

	IEnumerator OnInteractPropTrash( IProp prop )
	{
		if (prop.FirstUse)
		{
			yield return C.WalkToClicked();
			yield return C.FaceClicked();
			Globals.searched_trash++;
			Audio.Play("loot");
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			yield return E.WaitSkip();
		}
		else
			yield return C.FaceClicked();
		yield return E.WaitSkip();
		yield return C.Me.Say("Nothing interesting in there, just a bunch of garbage.");
		if (prop.FirstUse && Globals.searched_trash == 3)
		{
			yield return E.WaitSkip();
			yield return C.Me.Say("Why am I so interested in garbage?");
		}
		yield return E.Break;
	}

	IEnumerator OnLookAtPropPc( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return E.WaitSkip();
		yield return C.Me.Say("Someone's heart was really dead over here...");
		yield return E.Break;
	}

	IEnumerator OnLookAtPropInfusion_stand( IProp prop )
	{

		yield return E.Break;
	}

	IEnumerator OnInteractPropSink( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return E.WaitSkip();
		yield return C.Me.Say("Gotta wash my hands before exiting the operating room.");
		yield return E.WaitSkip();
		yield return C.Me.Say("Wait, why did that line just pop in my head?");
		yield return E.Break;
		
	}

	IEnumerator OnInteractPropPc( IProp prop )
	{
		if (prop.FirstUse)
		{
			yield return C.WalkToClicked();
			yield return C.FaceClicked();
			Audio.Play("button_click");
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			Audio.Play("button_click");
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			yield return C.Me.Say("It doesn't work.");
		}
		else
		{
			yield return C.FaceClicked();
			yield return E.WaitSkip();
			yield return C.Me.Say("I've checked it. Doesn't work.");
		}
	}

	IEnumerator OnLookAtPropSink( IProp prop )
	{
		yield return C.FaceClicked();
		yield return C.Me.Say("A Sink.");
		yield return E.Break;
	}

	IEnumerator OnLookAtPropTrash( IProp prop )
	{
		yield return C.Me.Say("It's a trashcan.");
		yield return E.Break;
	}

	IEnumerator OnLookAtPropNeedle( IProp prop )
	{

		yield return E.Break;
	}

	IEnumerator OnInteractPropInfusion_stand( IProp prop )
	{

		yield return E.Break;
	}
}