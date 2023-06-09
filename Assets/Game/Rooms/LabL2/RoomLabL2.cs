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
		if (!I.Compound_5.Owned)
		{
			Audio.Play("door_open");
			yield return E.WaitSkip();
			E.ChangeRoomBG(R.HallwayL2);
		}
		else
		{
			yield return E.WaitSkip();
			yield return C.Me.Say("I shouldn't take laboratory containers out of the laboratory");
		}
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

	IEnumerator OnInteractPropMemo( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		Audio.Play("book_flip");
		E.ChangeRoomBG(R.Document);
		yield return E.Break;
	}

	IEnumerator OnLookAtPropDoor( IProp prop )
	{
		yield return C.FaceClicked();
		yield return E.WaitSkip();
		yield return C.Me.Say("It's the door to the hallway");
	}

	IEnumerator OnLookAtPropProtect_suit( IProp prop )
	{
		yield return C.FaceClicked();
		yield return E.WaitSkip();
		yield return C.Me.Say("A set of protect suit");
	}

	IEnumerator OnLookAtPropMemo( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		Audio.Play("book_flip");
		E.ChangeRoomBG(R.Document);
		yield return E.Break;
	}

	IEnumerator OnLookAtPropTable( IProp prop )
	{
		yield return C.FaceClicked();
		yield return E.WaitSkip();
		yield return C.Me.Say("A bottle of red solution. The label says 'Compound-5'");
		prop.Description = "Compound-5";
	}

	IEnumerator OnInteractPropTable( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return E.WaitSkip();
		if (!I.Compound_5.Owned)
		{
			yield return C.Me.Say("A bottle of red potion. The label says 'Compound-5'");
		
			Audio.Play("pickup_glass");
			Prop("No_potion").Visible = true;
			prop.Description = "Place Compound-5 Back";
			//prop.Clickable = false;
			I.Compound_5.Add();
		}
		else
		{
			yield return C.Me.Say("Ok, I'll put it back");
			prop.Description = "Compound-5";
			Audio.Play("pickup_glass");
			Prop("No_potion").Visible = false;
			I.Compound_5.Remove();
		}
	}

	IEnumerator OnUseInvPropTable( IProp prop, IInventory item )
	{
		if (I.Compound_5.Active == true)
		{
			yield return C.Me.Say("Ok, I'll put it back");
			prop.Description = "Compound-5";
			Audio.Play("pickup_glass");
			Prop("No_potion").Visible = false;
			I.Compound_5.Active = false;
			I.Compound_5.Remove();
		}
		yield return E.ConsumeEvent;
	}
}