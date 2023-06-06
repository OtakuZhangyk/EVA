using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomLab : RoomScript<RoomLab>
{


	IEnumerator OnInteractPropUndergroundHallway( IProp prop )
	{
		yield return C.WalkToClicked();
		Audio.Play("door_open1");
		E.ChangeRoomBG(R.UndergroundHallway);
		
		yield return E.Break;
	}

	void OnEnterRoom()
	{
		C.Me.SetPosition(-150,-50);
		C.Me.Face(0,0);
		Audio.Play("door_close1");
	}

	IEnumerator OnExitRoom( IRoom oldRoom, IRoom newRoom )
	{
		C.Me.SetPosition(-26,-50);
		yield return E.Break;
	}

	IEnumerator OnLookAtPropEVA( IProp prop )
	{
		yield return C.Me.WalkTo(Prop("EVA"));
		yield return E.WaitSkip();
		yield return C.Me.Say("Eva...");
		yield return E.Break;
	}
}