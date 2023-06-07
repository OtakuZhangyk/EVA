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
		Audio.Play("beep");
		TextMesh m_text = ((PropComponent)Prop("Screen").Instance).GetComponent<TextMesh>();
		if (m_text.text.Length < 4)
			m_text.text += "1";
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
		Audio.Play("beep");
		TextMesh m_text = ((PropComponent)Prop("Screen").Instance).GetComponent<TextMesh>();
		if (m_text.text.Length < 4)
			m_text.text += "2";
		yield return E.Break;
	}

	IEnumerator OnInteractPropB3( IProp prop )
	{
		yield return prop.PlayAnimation("b3");
		Audio.Play("beep");
		TextMesh m_text = ((PropComponent)Prop("Screen").Instance).GetComponent<TextMesh>();
		if (m_text.text.Length < 4)
			m_text.text += "3";
		yield return E.Break;
	}

	IEnumerator OnInteractPropB4( IProp prop )
	{
		yield return prop.PlayAnimation("b4");
		Audio.Play("beep");
		TextMesh m_text = ((PropComponent)Prop("Screen").Instance).GetComponent<TextMesh>();
		if (m_text.text.Length < 4)
			m_text.text += "4";
		yield return E.Break;
	}

	IEnumerator OnInteractPropB5( IProp prop )
	{
		yield return prop.PlayAnimation("b5");
		Audio.Play("beep");
		TextMesh m_text = ((PropComponent)Prop("Screen").Instance).GetComponent<TextMesh>();
		if (m_text.text.Length < 4)
			m_text.text += "5";
		yield return E.Break;
	}

	IEnumerator OnInteractPropB6( IProp prop )
	{
		yield return prop.PlayAnimation("b6");
		Audio.Play("beep");
		TextMesh m_text = ((PropComponent)Prop("Screen").Instance).GetComponent<TextMesh>();
		if (m_text.text.Length < 4)
			m_text.text += "6";
		yield return E.Break;
	}

	IEnumerator OnInteractPropB7( IProp prop )
	{
		yield return prop.PlayAnimation("b7");
		Audio.Play("beep");
		TextMesh m_text = ((PropComponent)Prop("Screen").Instance).GetComponent<TextMesh>();
		if (m_text.text.Length < 4)
			m_text.text += "7";
		yield return E.Break;
	}

	IEnumerator OnInteractPropB8( IProp prop )
	{
		yield return prop.PlayAnimation("b8");
		Audio.Play("beep");
		TextMesh m_text = ((PropComponent)Prop("Screen").Instance).GetComponent<TextMesh>();
		if (m_text.text.Length < 4)
			m_text.text += "8";
		yield return E.Break;
	}

	IEnumerator OnInteractPropB9( IProp prop )
	{
		yield return prop.PlayAnimation("b9");
		Audio.Play("beep");
		TextMesh m_text = ((PropComponent)Prop("Screen").Instance).GetComponent<TextMesh>();
		if (m_text.text.Length < 4)
			m_text.text += "9";
		yield return E.Break;
	}

	IEnumerator OnInteractPropB0( IProp prop )
	{
		yield return prop.PlayAnimation("b0");
		Audio.Play("beep");
		TextMesh m_text = ((PropComponent)Prop("Screen").Instance).GetComponent<TextMesh>();
		if (m_text.text.Length < 4)
			m_text.text += "0";
		yield return E.Break;
	}

	IEnumerator OnInteractPropDelete( IProp prop )
	{
		yield return prop.PlayAnimation("del");
		Audio.Play("beep");
		TextMesh m_text = ((PropComponent)Prop("Screen").Instance).GetComponent<TextMesh>();
		if (m_text.text.Length > 0) {
			if (m_text.text != "APPROVED" && m_text.text != "DENIED")
				m_text.text = m_text.text.Remove(m_text.text.Length - 1, 1);
		}
		yield return E.Break;
	}

	IEnumerator OnInteractPropEnter( IProp prop )
	{
		yield return prop.PlayAnimation("ent");
		TextMesh m_text = ((PropComponent)Prop("Screen").Instance).GetComponent<TextMesh>();
		if (m_text.text == "2023") {
			Audio.Play("approve");
			m_text.text = "APPROVED";
			m_text.color = Color.green;
			m_text.fontSize = 140;
			Audio.Play("lock");
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			RoomAdmin.Script.bSafeUnlocked = true;
			E.ChangeRoomBG(R.Safe);
		} else if (m_text.text == "APPROVED") {
		
		} else {
			Audio.Play("deny");
			m_text.text = "DENIED";
			m_text.color = Color.red;
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			m_text.text = "";
			m_text.color = Color.black;
		}
		yield return E.Break;
	}

	IEnumerator OnInteractPropExitButton( IProp prop )
	{
		yield return E.ChangeRoom(R.Safe);
		yield return E.Break;
	}

	IEnumerator OnInteractPropScreen( IProp prop )
	{

		yield return E.Break;
	}

	IEnumerator OnLookAtPropB1( IProp prop )
	{
		yield return E.ConsumeEvent;
	}

	IEnumerator OnLookAtPropB2( IProp prop )
	{
		yield return E.ConsumeEvent;
	}

	IEnumerator OnLookAtPropB3( IProp prop )
	{
		yield return E.ConsumeEvent;
	}

	IEnumerator OnLookAtPropB4( IProp prop )
	{
		yield return E.ConsumeEvent;
	}

	IEnumerator OnLookAtPropB5( IProp prop )
	{
		yield return E.ConsumeEvent;
	}

	IEnumerator OnLookAtPropB6( IProp prop )
	{
		yield return E.ConsumeEvent;
	}

	IEnumerator OnLookAtPropB7( IProp prop )
	{
		yield return E.ConsumeEvent;
	}

	IEnumerator OnLookAtPropB8( IProp prop )
	{
		yield return E.ConsumeEvent;
	}

	IEnumerator OnLookAtPropB9( IProp prop )
	{
		yield return E.ConsumeEvent;
	}

	IEnumerator OnLookAtPropB0( IProp prop )
	{
		yield return E.ConsumeEvent;
	}

	IEnumerator OnLookAtPropDelete( IProp prop )
	{
		yield return E.ConsumeEvent;
	}

	IEnumerator OnLookAtPropEnter( IProp prop )
	{
		yield return E.ConsumeEvent;
	}

	IEnumerator OnLookAtPropExitButton( IProp prop )
	{
		yield return E.ConsumeEvent;
	}

	IEnumerator OnLookAtPropScreen( IProp prop )
	{

		yield return E.Break;
	}
}