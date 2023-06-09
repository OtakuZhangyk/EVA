using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomEnding : RoomScript<RoomEnding>
{


	void OnEnterRoom()
	{
		C.Eva.Room = R.Ending;
		C.Me.SetPosition(0,-65);
		E.SetPlayer(C.Eva);
		C.Eva.Disable();
		Audio.Pause("hospital_bgm");
	}

	IEnumerator OnEnterRoomAfterFade()
	{
		C.Me.TextColour = new Color(0.27f,0.93f,1.0f,1.0f);
		yield return C.Me.Say("Enjoy your break from all those sophisticated experiments.");
		yield return E.WaitSkip();
		yield return C.Me.Say("Farewell, doctor...");
		yield return E.WaitSkip();
		yield return C.Me.WalkTo(Point("Exit"));
		yield return C.Me.FaceLeft();
		yield return C.Me.Say("Or should I call you... EVA?");
		yield return E.WaitSkip();
		yield return C.Me.FaceRight();
		yield return E.WaitSkip();
		Audio.Play("door_open1");
		yield return E.WaitSkip();
		C.Me.Disable();
		yield return E.WaitSkip();
		Audio.Play("door_close1");
		yield return E.Wait(4.0f);
		yield return E.FadeOut(1.5f);
		E.ChangeRoomBG(R.EndScene);
		yield return E.Break;
	}

	IEnumerator OnExitRoom( IRoom oldRoom, IRoom newRoom )
	{
		E.SetPlayer(C.Me);
		yield return E.Break;
	}
}