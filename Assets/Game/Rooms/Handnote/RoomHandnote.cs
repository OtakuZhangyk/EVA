using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomHandnote : RoomScript<RoomHandnote>
{
	int page = 1;
	static int MAX_PAGE = 3;
	string textPage1 = "Communication with Eva" +
		"\nTo establish a communication" + 
		"\nlink with Eva, follow these" + 
		"\ninstructions strictly: " +
		"\n1. Retrieve Compound-5 from" +
		"\nthe laboratory. " +
		"\n2. Load the injector with" + 
		"\nCompound-5. " +
		"\n3. Inject the Compound-5 into" + 
		"\nthe designated port on Eva's" + 
		"\ncontainment unit. ";
	
	string textPage2 = "4. Locate the electrode helmet" +
		"\n5. Place the electrode helmet" + 
		"\nsecurely on your head" +
		"\n6. Once the helmet is on, sit" + 
		"\nin a relaxed position, clear your" + 
		"\nmind, and let Eva's thoughts" +
		"\ncome in. Do not resist or fight" +
		"\nher psychic presence, as it may" +
		"\ncause mental stress or harm.";
	string textPage3 = "";
	string textPage5 = "2023\nThe secret is right behind me";
	
	
    public void OnEnterRoom()
	{
		
		// Hide the inventory in the title scene
		G.InventoryBar.Hide();
		
		Prop("TurnL").Disable();
		C.Plr.Disable();

		page = 1;
		((PropComponent)Prop("TextL").Instance).GetComponent<TextMesh>().text = textPage1;
		((PropComponent)Prop("TextR").Instance).GetComponent<TextMesh>().text = textPage2;

		// Later we could start some music here
		//SystemAudio.PlayMusic("MusicSlowStrings", 1);
	}

	IEnumerator OnLookAtPropTurnL( IProp prop )
	{
		yield return E.ConsumeEvent;
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

	IEnumerator OnLookAtPropTurnR( IProp prop )
	{
		yield return E.ConsumeEvent;
	}

	IEnumerator OnLookAtPropClose( IProp prop )
	{
		yield return E.ConsumeEvent;
	}
}