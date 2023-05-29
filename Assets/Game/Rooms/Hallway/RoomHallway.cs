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
		C.Me.SetPosition(87,-44);
		yield return E.ConsumeEvent;
	}

	IEnumerator OnInteractPropOffice_door( IProp prop )
	{
		yield return C.WalkToClicked();
		E.ChangeRoomBG(R.OfficeL1);
		yield return E.ConsumeEvent;
	}

	IEnumerator OnInteractPropStair_up( IProp prop )
	{
		yield return C.WalkToClicked();
		E.ChangeRoomBG(R.HallwayL2);
		C.Me.SetPosition(417,-43);
		yield return E.ConsumeEvent;
	}
}