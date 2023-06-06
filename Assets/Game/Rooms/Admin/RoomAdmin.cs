using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomAdmin : RoomScript<RoomAdmin>
{
	public bool bSafeUnlocked = false;
	IEnumerator OnInteractPropEnter( IProp prop )
	{
        yield return C.WalkToClicked();
        Audio.Play("door_open1");
        yield return E.WaitSkip();
        E.ChangeRoomBG(R.HallwayL2);
        yield return E.ConsumeEvent;
    }

	void OnEnterRoom()
	{
        if (C.Me.LastRoom == R.HallwayL2)
        {
            Audio.Play("door_close1");
            C.Me.SetPosition(Point("Enter"));
        }
    }

	IEnumerator OnEnterRoomAfterFade()
	{
		if (C.Me.LastRoom == R.HallwayL2)
		{
			yield return C.Me.WalkTo(Point("EnterWalk"),true);
			yield return C.Me.Face(Point("Enter"));
		}
		if (Globals.b_knowhimself == 0)
		{
			//C.Me.WalkTo(Prop("Photo").Position + Prop("Photo").WalkToPoint);
			//C.Me.FaceRight();
			yield return E.WaitSkip();
			yield return C.Me.Say("Is it me?");
			yield return E.WaitSkip();
			yield return C.Me.Say("Dr. Newman, Hospital Director");
			yield return E.WaitSkip();
			yield return C.Me.Say("Looks like I'm the head of this hostipal");
			Globals.b_knowhimself = 2;
		}
	}

	IEnumerator OnInteractPropPhoto_down( IProp prop )
	{
		
		yield return E.Break;
	}

	IEnumerator OnInteractPropPhoto( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return E.FadeOut(0.2f);
		Prop("Photo").Disable();
		Prop("Photo_down").Visible = true;
		Region("Block_by_photo").Walkable = false;
		yield return E.FadeIn(0.2f);
		yield return E.Break;
	}

	IEnumerator OnInteractPropSafe( IProp prop )
	{
		yield return E.ChangeRoom(R.Safe);
		yield return E.Break;
	}

	IEnumerator OnInteractPropTrashF( IProp prop )
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
			yield return C.Me.Say("Hmmm... A balled up personal letter");
		}
		else
			yield return C.FaceClicked();
		yield return E.WaitSkip();
		yield return C.Me.Say("Dr. Newman, Following the recent controversy surrounding your research practices, we regret to inform you that your membership in our Neurological Society has been terminated...");
		yield return E.WaitSkip();
		yield return C.Me.Say("Seems like I'm having a tough time");
		if (prop.FirstUse && Globals.searched_trash == 3)
		{
			yield return E.WaitSkip();
			yield return C.Me.Say("Why am I so interested in garbage?");
		}
	}

	IEnumerator OnInteractPropDrawers( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		Audio.Play("drawer_open");
		yield return E.WaitSkip();
		yield return E.WaitSkip();
		//Eva documents
		yield return E.WaitSkip();
		Audio.Play("drawer_close");
	}
}