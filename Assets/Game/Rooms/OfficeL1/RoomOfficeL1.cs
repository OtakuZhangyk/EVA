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

		yield return E.Break;
	}

	IEnumerator OnEnterRoomAfterFade()
	{

		yield return E.Break;
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
		yield return C.Me.Say("'Leading Neurologist or Mad Scientist? Scandal of Human Experimentation Unveiled'");
		yield return E.WaitSkip();
		yield return C.Me.Say("Seems like Dr. Newman was having a big problem");
		if (prop.FirstUse && Globals.searched_trash == 3)
		{
			yield return E.WaitSkip();
			yield return C.Me.Say("Why am I so interested in garbage?");
		}
	}
}