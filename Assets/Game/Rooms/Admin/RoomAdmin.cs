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
}