using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomPCScreen : RoomScript<RoomPCScreen>
{


	IEnumerator OnInteractPropExitButton( IProp prop )
	{

		yield return E.Break;
	}

	void OnEnterRoom()
	{
	}
}