using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomEnding : RoomScript<RoomEnding>
{


	void OnEnterRoom()
	{
		C.Eva.Room = R.Current;
		C.Me.SetPosition(0,-65);
		E.SetPlayer(C.Eva);
		C.Eva.Disable();
	}

	IEnumerator OnEnterRoomAfterFade()
	{
		C.Me.TextColour = new Color(0.5f,0.5f,1.0f,0.7f);
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
		C.Me.Disable();
		yield return E.Break;
	}
}