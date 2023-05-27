using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomHallway : RoomScript<RoomHallway>
{


	IEnumerator OnInteractPropOperation_Room( IProp prop )
	{
		E.ChangeRoomBG(R.Operation_Room);
		yield return E.ConsumeEvent;
	}

	IEnumerator OnInteractPropOperationRoom( IProp prop )
	{
		yield return C.WalkToClicked();
		E.ChangeRoomBG(R.Operation_Room);
		yield return E.ConsumeEvent;
	}
}