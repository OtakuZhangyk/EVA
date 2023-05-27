using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomOperation_Room : RoomScript<RoomOperation_Room>
{


	IEnumerator OnInteractPropDoor( IProp prop )
	{
		E.ChangeRoomBG(R.Hallway);
		yield return E.ConsumeEvent;
	}
}