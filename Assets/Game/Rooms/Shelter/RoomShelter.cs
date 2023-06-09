using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomShelter : RoomScript<RoomShelter>
{


	IEnumerator OnInteractPropDoor( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return E.WaitSkip();
		if (E.GetTimer("escape") != 0) {
			yield return C.Me.Say("It's unsafe to go out now.");
		} else {
			if (Globals.gamePhase == eProgress.EndGame) {
				if (!Prop("Door").Animating) {
					Audio.Play("door_open1");
					Prop("Door").PlayAnimationBG("doorOpen");
				}
		
				yield return E.FadeOut(1.5f);
				yield return E.ChangeRoom(R.EndScene);
			}
			else {
				Audio.Play("door_open1");
				C.Plr.ChangeRoom(R.UndergroundHallway);
			}
		}
		yield return E.Break;
	}

	void OnEnterRoom()
	{
		Audio.Play("door_close1");
		C.Plr.SetPosition(Point("Entry"));
	}

	IEnumerator OnEnterRoomAfterFade()
	{
		yield return C.Plr.WalkTo(Point("EntryWalk"));
		if (FirstTimeVisited)
			yield return C.Me.Say("This room looks like a pretty good shelter.");
		yield return E.Break;
	}
}