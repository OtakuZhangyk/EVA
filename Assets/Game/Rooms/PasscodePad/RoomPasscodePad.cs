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
		TextMesh m_text = ((PropComponent)Prop("Screen").Instance).GetComponent<TextMesh>();
		if (m_text.text.Length < 4)
			m_text.text += "2";
		yield return E.Break;
	}

	IEnumerator OnInteractPropB3( IProp prop )
	{
		yield return prop.PlayAnimation("b3");
		TextMesh m_text = ((PropComponent)Prop("Screen").Instance).GetComponent<TextMesh>();
		if (m_text.text.Length < 4)
			m_text.text += "3";
		yield return E.Break;
	}

	IEnumerator OnInteractPropB4( IProp prop )
	{
		yield return prop.PlayAnimation("b4");
		TextMesh m_text = ((PropComponent)Prop("Screen").Instance).GetComponent<TextMesh>();
		if (m_text.text.Length < 4)
			m_text.text += "4";
		yield return E.Break;
	}

	IEnumerator OnInteractPropB5( IProp prop )
	{
		yield return prop.PlayAnimation("b5");
		TextMesh m_text = ((PropComponent)Prop("Screen").Instance).GetComponent<TextMesh>();
		if (m_text.text.Length < 4)
			m_text.text += "5";
		yield return E.Break;
	}

	IEnumerator OnInteractPropB6( IProp prop )
	{
		yield return prop.PlayAnimation("b6");
		TextMesh m_text = ((PropComponent)Prop("Screen").Instance).GetComponent<TextMesh>();
		if (m_text.text.Length < 4)
			m_text.text += "6";
		yield return E.Break;
	}

	IEnumerator OnInteractPropB7( IProp prop )
	{
		yield return prop.PlayAnimation("b7");
		TextMesh m_text = ((PropComponent)Prop("Screen").Instance).GetComponent<TextMesh>();
		if (m_text.text.Length < 4)
			m_text.text += "7";
		yield return E.Break;
	}

	IEnumerator OnInteractPropB8( IProp prop )
	{
		yield return prop.PlayAnimation("b8");
		TextMesh m_text = ((PropComponent)Prop("Screen").Instance).GetComponent<TextMesh>();
		if (m_text.text.Length < 4)
			m_text.text += "8";
		yield return E.Break;
	}

	IEnumerator OnInteractPropB9( IProp prop )
	{
		yield return prop.PlayAnimation("b9");
		TextMesh m_text = ((PropComponent)Prop("Screen").Instance).GetComponent<TextMesh>();
		if (m_text.text.Length < 4)
			m_text.text += "9";
		yield return E.Break;
	}

	IEnumerator OnInteractPropB0( IProp prop )
	{
		yield return prop.PlayAnimation("b0");
		TextMesh m_text = ((PropComponent)Prop("Screen").Instance).GetComponent<TextMesh>();
		if (m_text.text.Length < 4)
			m_text.text += "0";
		yield return E.Break;
	}

	IEnumerator OnInteractPropDelete( IProp prop )
	{
		yield return prop.PlayAnimation("del");
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
			m_text.text = "APPROVED";
			m_text.color = Color.green;
			m_text.fontSize = 140;
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			RoomAdmin.Script.bSafeUnlocked = true;
		} else if (m_text.text == "APPROVED") {
		
		} else {
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
}