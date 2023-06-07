using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomHandnote : RoomScript<RoomHandnote>
{
	int page = 1;
	static int MAX_PAGE = 3;
	string textPage1 = "Memo #5\nTo let Eva out, the main power \nsupply has to be turned off \nfirst."+
		"\nAfterward, you need to turn \noff three backup power supplies, \nor else it'll still be restrained."+
		"\nThen it's going to the cryogenic \nchamber, injecting the drug, I \nhave to remember to bring the \nsyringe.";

	string textPage2 = "Lastly, open up those restraints, \nlet Eva be free.";
    string textPage3 = "";
	string textPage5 = "2023";

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
		TextMesh m_textL = ((PropComponent)Prop("TextL").Instance).GetComponent<TextMesh>();
		TextMesh m_textR = ((PropComponent)Prop("TextR").Instance).GetComponent<TextMesh>();
		page -= 1;
		Audio.Play("book_flip");
		if (page <= 1) {
			prop.Disable();
		}
		if (page < MAX_PAGE) {
			Prop("TurnR").Enable();
		}
		if (page == 2)
		{
			m_textL.text = textPage3;
			m_textR.text = textPage3;
		
		}
		else if (page == 1)
		{
			m_textL.text = textPage1;
			m_textR.text = textPage2;
		}
		yield return E.ConsumeEvent;
	}


	IEnumerator OnInteractPropClose( IProp prop )
	{
		if (R.Previous != null)
			E.ChangeRoomBG(C.Me.LastRoom);
		G.InventoryBar.Show();
		
		yield return E.Break;
	}

	IEnumerator OnInteractPropTurnR( IProp prop )
	{
		TextMesh m_textL = ((PropComponent)Prop("TextL").Instance).GetComponent<TextMesh>();
		TextMesh m_textR = ((PropComponent)Prop("TextR").Instance).GetComponent<TextMesh>();
		page += 1;
		Audio.Play("book_flip");
		if (page >= MAX_PAGE) {
			prop.Disable();
		}
		if (page > 1) {
			Prop("TurnL").Enable();
		}
		if (page == 2)
		{
			m_textL.text = textPage3;
			m_textR.text = textPage3;
		
		} else if (page == 3)
		{
			m_textL.text = textPage5;
			m_textR.text = textPage3;
		}
		
		yield return E.ConsumeEvent;
	}

	IEnumerator OnUseInvPropClose( IProp prop, IInventory item )
	{

		yield return E.Break;
	}

	IEnumerator OnExitRoom( IRoom oldRoom, IRoom newRoom )
	{
		C.Plr.Enable();
		if (FirstTimeVisited) {
			Globals.m_FirstReadMemo = true;
		} else {
			Globals.m_FirstReadMemo = false;
		}
		yield return E.Break;
	}

	IEnumerator OnEnterRoomAfterFade()
	{

		yield return E.Break;
	}
}