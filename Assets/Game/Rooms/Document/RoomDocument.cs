using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomDocument : RoomScript<RoomDocument>
{


	void OnEnterRoom()
	{
		C.Me.Disable();
		G.InventoryBar.Hide();
		Prop("Prev").Disable();
	}

	IEnumerator OnExitRoom( IRoom oldRoom, IRoom newRoom )
	{
		C.Me.Enable();
		G.InventoryBar.Show();
		yield return E.Break;
	}

	IEnumerator OnInteractPropExit( IProp prop )
	{
		E.ChangeRoomBG(R.Admin);
		yield return E.Break;
	}
}