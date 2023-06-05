using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomPCScreen : RoomScript<RoomPCScreen>
{


	IEnumerator OnInteractPropExitButton( IProp prop )
	{
		E.ChangeRoomBG(R.OfficeL1);
		yield return E.Break;
	}

	void OnEnterRoom()
	{
		C.Me.Disable();
	}

	IEnumerator OnExitRoom( IRoom oldRoom, IRoom newRoom )
	{
		C.Me.Enable();
		yield return E.Break;
	}

	IEnumerator OnEnterRoomAfterFade()
	{

		yield return E.Break;
	}
}