using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomPCScreen : RoomScript<RoomPCScreen>
{


	IEnumerator OnInteractPropExitButton( IProp prop )
	{
		Audio.Play("button_click");
		E.ChangeRoomBG(R.OfficeL1);
		yield return E.Break;
	}

	void OnEnterRoom()
	{
		C.Me.Disable();
		G.InventoryBar.Hide();
	}

	IEnumerator OnExitRoom( IRoom oldRoom, IRoom newRoom )
	{
		C.Me.Enable();
		G.InventoryBar.Show();
		yield return E.Break;
	}

	IEnumerator OnEnterRoomAfterFade()
	{

		yield return E.Break;
	}

	IEnumerator OnLookAtPropExitButton( IProp prop )
	{
		yield return E.ConsumeEvent;
	}
}