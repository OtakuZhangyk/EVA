using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomOfficeL1 : RoomScript<RoomOfficeL1>
{


	IEnumerator OnUseInvPropDoor( IProp prop, IInventory item )
	{

		yield return E.Break;
	}

	IEnumerator OnLookAtPropDoor( IProp prop )
	{

		yield return E.Break;
	}

	IEnumerator OnInteractPropDoor( IProp prop )
	{
		yield return C.WalkToClicked();
		Audio.Play("door_open1");
		yield return E.WaitSkip();
		E.ChangeRoomBG(R.Hallway);
		yield return E.ConsumeEvent;
	}

	void OnEnterRoom()
	{
		if (C.Me.LastRoom == R.Hallway)
		{
			Audio.Play("door_close1");
			C.Me.SetPosition(Point("Enter"));
		}
	}

	IEnumerator OnUseInvPropDrawers( IProp prop, IInventory item )
	{

		yield return E.Break;
	}

	IEnumerator OnInteractPropDrawers( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		Audio.Play("drawer_open");
		yield return E.WaitSkip();
		yield return E.WaitSkip();
		yield return C.Me.Say("A research paper");
		yield return E.WaitSkip();
		yield return C.Me.Say("Dr. Newman: Groundbreaking Contribution to Neuroscience or Unethical Human Experimentation?");
		yield return E.WaitSkip();
		I.LabKey.Add();
		Audio.Play("drawer_close");
	}

	IEnumerator OnEnterRoomAfterFade()
	{
		if ((C.Me.LastRoom == R.PCScreen || C.Me.LastRoom == R.PCScreen2) && Globals.b_knowhimself == 1)
		{
			yield return E.WaitSkip();
			yield return C.Me.Say("Here is a photo of Dr. Newman");
			yield return E.WaitSkip();
			yield return C.Me.Say("Wait, it's me");
			yield return E.WaitSkip();
			yield return C.Me.Say("So I'm Dr. Newman?");
			yield return E.WaitSkip();
			yield return C.Me.Say("Then why did I lost my memory?");
			yield return E.WaitSkip();
			yield return C.Me.Say("Does it have some kind of connection with the human experimentation?");
			Globals.b_knowhimself = 2;
		}
	}

	IEnumerator OnInteractPropTrash( IProp prop )
	{
		if (prop.FirstUse)
		{
			yield return C.WalkToClicked();
			yield return C.FaceClicked();
			Globals.searched_trash++;
			Audio.Play("loot_paper");
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			yield return C.Me.Say("Hmmm... A balled up newspaper");
		}
		else
			yield return C.FaceClicked();
		yield return E.WaitSkip();
		yield return C.Me.Say("Leading Neurologist or Mad Scientist? Scandal of Human Experimentation Unveiled");
		yield return E.WaitSkip();
		if (Globals.b_knowhimself > 0)
			yield return C.Me.Say("Seems like I had big trouble");
		else
			yield return C.Me.Say("Seems like Dr. Newman was having a big problem");
		if (prop.FirstUse && Globals.searched_trash == 3)
		{
			yield return E.WaitSkip();
			yield return C.Me.Say("Why am I so interested in garbage?");
		}
	}

	IEnumerator OnInteractPropDesks( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		Audio.Play("page");
		yield return E.WaitSkip();
		yield return E.WaitSkip();
		yield return C.Me.Say("A magazine");
		yield return E.WaitSkip();
		yield return C.Me.Say("From Acclaimed Neurologist to Pariah: The Shocking Fall of Victor Newman");
		
	}

	IEnumerator OnInteractPropPc1( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		Audio.Play("button_click");
		if (prop.FirstUse)
		{
			if (Globals.b_knowhimself == 0)
				Globals.b_knowhimself = 1;
		}
		E.ChangeRoomBG(R.PCScreen);
	}

	IEnumerator OnInteractPropPc2( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		Audio.Play("button_click");
		if (prop.FirstUse)
		{
			if (Globals.b_knowhimself == 0)
				Globals.b_knowhimself = 1;
		}
		E.ChangeRoomBG(R.PCScreen2);
	}

	IEnumerator OnUseInvPropPc1( IProp prop, IInventory item )
	{

		yield return E.Break;
	}

	IEnumerator OnLookAtPropDrawers( IProp prop )
	{

		yield return E.Break;
	}
}