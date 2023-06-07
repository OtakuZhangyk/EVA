using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomMind : RoomScript<RoomMind>
{


	void OnEnterRoom()
	{
		C.Plr.SetPosition(0,-75);
		C.Plr.Instance.GetComponent<SpriteRenderer>().color = new Color(0.3f,0.3f,0.5f,1);
		C.Eva.Instance.GetComponent<SpriteRenderer>().color = new Color(0.3f,0.3f,0.5f,1);
		C.Plr.Data.FootstepSound = null;
	}

	IEnumerator OnExitRoom( IRoom oldRoom, IRoom newRoom )
	{
		C.Plr.Data.FootstepSound = "step";
		yield return E.Break;
	}
}