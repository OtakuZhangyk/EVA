using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomPasscodePad : RoomScript<RoomPasscodePad>
{


	IEnumerator OnInteractPropB1( IProp prop )
	{
		yield return prop.PlayAnimation("b1");
		yield return E.Break;
	}

	void OnEnterRoom()
	{
		C.Plr.Disable();
		G.InventoryBar.Visible = false;
	}

	IEnumerator OnExitRoom( IRoom oldRoom, IRoom newRoom )
	{
		C.Plr.Enable();
		G.InventoryBar.Visible = true;
		yield return E.Break;
	}

	IEnumerator OnInteractPropB2( IProp prop )
	{
		yield return prop.PlayAnimation("b2");
		yield return E.Break;
	}

	IEnumerator OnInteractPropB3( IProp prop )
	{
		yield return prop.PlayAnimation("b3");
		yield return E.Break;
	}

	IEnumerator OnInteractPropB4( IProp prop )
	{
		yield return prop.PlayAnimation("b4");
		yield return E.Break;
	}

	IEnumerator OnInteractPropB5( IProp prop )
	{
		yield return prop.PlayAnimation("b5");
		yield return E.Break;
	}

	IEnumerator OnInteractPropB6( IProp prop )
	{
		yield return prop.PlayAnimation("b6");
		yield return E.Break;
	}

	IEnumerator OnInteractPropB7( IProp prop )
	{
		yield return prop.PlayAnimation("b7");
		yield return E.Break;
	}

	IEnumerator OnInteractPropB8( IProp prop )
	{
		yield return prop.PlayAnimation("b8");
		yield return E.Break;
	}

	IEnumerator OnInteractPropB9( IProp prop )
	{
		yield return prop.PlayAnimation("b9");
		yield return E.Break;
	}

	IEnumerator OnInteractPropB0( IProp prop )
	{
		yield return prop.PlayAnimation("b0");
		yield return E.Break;
	}

	IEnumerator OnInteractPropDelete( IProp prop )
	{
		yield return prop.PlayAnimation("del");
		yield return E.Break;
	}

	IEnumerator OnInteractPropEnter( IProp prop )
	{
		yield return prop.PlayAnimation("ent");
		yield return E.Break;
	}

	IEnumerator OnInteractPropExitButton( IProp prop )
	{
		yield return E.ChangeRoom(R.Previous);
		yield return E.Break;
	}
}