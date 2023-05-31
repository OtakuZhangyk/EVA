using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomHandnote : RoomScript<RoomHandnote>
{
	int page = 1;
	public void OnEnterRoom()
	{
		
		// Hide the inventory in the title scene
		G.InventoryBar.Hide();
		
		Prop("TurnL").Disable();
		C.Plr.Disable();
		
		// Later we could start some music here
		//SystemAudio.PlayMusic("MusicSlowStrings", 1);
	}

	IEnumerator OnLookAtPropTurnL( IProp prop )
	{

		yield return E.Break;
	}

	IEnumerator OnInteractPropTurnL( IProp prop )
	{

		yield return E.Break;
	}


	IEnumerator OnInteractPropClose( IProp prop )
	{
		E.ChangeRoomBG(C.Me.LastRoom);
		G.InventoryBar.Show();
		yield return E.Break;
	}

	IEnumerator OnInteractPropTurnR( IProp prop )
	{
		((PropComponent)Prop("TextR").Instance).GetComponent<TextMesh>().text = "hello";
		page += 2;
		yield return E.Break;
	}

	IEnumerator OnUseInvPropClose( IProp prop, IInventory item )
	{

		yield return E.Break;
	}

	IEnumerator OnExitRoom( IRoom oldRoom, IRoom newRoom )
	{
		C.Plr.Enable();
		yield return E.Break;
	}
}