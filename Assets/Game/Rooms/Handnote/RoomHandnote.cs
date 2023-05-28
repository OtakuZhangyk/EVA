using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomHandnote : RoomScript<RoomHandnote>
{
	public void OnEnterRoom()
	{
		
		// Hide the inventory in the title scene
		G.InventoryBar.Hide();
		
		Prop("TurnL").Disable();
		
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
}