using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomPCScreen2 : RoomScript<RoomPCScreen2>
{


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

	IEnumerator OnInteractPropExit( IProp prop )
	{
		Audio.Play("button_click");
		E.ChangeRoomBG(R.OfficeL1);
		yield return E.Break;
	}

	IEnumerator OnLookAtPropExit( IProp prop )
	{
		yield return E.ConsumeEvent;
	}

	IEnumerator OnEnterRoomAfterFade()
	{

		yield return E.Break;
	}
}