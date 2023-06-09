using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomSecretHandnote : RoomScript<RoomSecretHandnote>
{
	int page = 1;
	int MAX_page = 3;
	string textPage1 = "Emergency Action Plan: " + 
		"\nProcedure for Eva's Termination" +
		"\nIn the event that termination" + 
		"\nof Eva becomes necessary, follow" + 
		"\nthese steps meticulously:" +
		"\n" + 
		"\n1. Locate the tagged bottle" + 
		"\ncontaining the primary termination" + 
		"\nagent. This bottle is labeled as" + 
		"\n'Protocol-T' and is stored in the" + 
		"\nsafe in director's room. ";
	string textPage2 = "2. After securing Protocol-T," +
		"\nacquire Compound-5 from the" +
		"\nlaboratory. This substance" +
		"\namplifies the termination agent's" +
		"\nefficacy and must be combined in" +
		"\nthe injector prior to injection." +
		"\n3. First, load the injector with" + 
		"\nCompound-5. Then, add Protocol-T." + 
		"\nEnsure the substances are in the" + 
		"\ncorrect order before proceeding.";
	string textPage3 = "4. Inject the mixture through" +
		"\nthe injection device into Eva's" +
		"\ncontainment unit. " +
		"\n" +
		"\nIMPORTANT: It's been observed" +
		"\nthat Eva may possess the ability" +
		"\nto exchange consciousness with" +
		"\nany individual wearing the" +
		"\nelectrode helmet, effectively" +
		"\nallowing Eva to usurp control" +
		"\nover the host body.";
	string textPage4 = "This presents an extraordinarily" + 
		"\nhigh risk of Eva achieving" + 
		"\nuncontrolled freedom." +
        "\nRecommendation: All personnel" + 
		"\nmust avoid use of the electrode" + 
		"\nhelmet under all circumstances." + 
		"\nThere can be no exceptions to" + 
		"\nthis rule." +
        "\nRemember: These actions should" + 
		"\nonly be taken in the utmost" + 
		"\nemergency situation." + 
		"\n    This is our last resort.";

	IEnumerator OnInteractPropNext( IProp prop )
	{
		Audio.Play("book_flip");
		page += 2;
		Prop("Prev").Enable();
		if (page + 1 >= MAX_page)
			prop.Disable();
		if (page == 3)
		{
			((PropComponent)Prop("TextL").Instance).GetComponent<TextMesh>().text = textPage3;
			((PropComponent)Prop("TextR").Instance).GetComponent<TextMesh>().text = textPage4;
		}
		yield return E.ConsumeEvent;
	}

	void OnEnterRoom()
	{
		G.InventoryBar.Hide();
		C.Plr.Disable();
		
		page = 1;
		Prop("Prev").Disable();
		Prop("Next").Enable();
		((PropComponent)Prop("TextL").Instance).GetComponent<TextMesh>().text = textPage1;
		((PropComponent)Prop("TextR").Instance).GetComponent<TextMesh>().text = textPage2;
	}

	IEnumerator OnExitRoom( IRoom oldRoom, IRoom newRoom )
	{
		G.InventoryBar.Show();
		C.Plr.Enable();
		yield return E.Break;
	}

	IEnumerator OnInteractPropPrev( IProp prop )
	{
		Audio.Play("book_flip");
		page -= 2;
		Prop("Next").Enable();
		if (page == 1)
			prop.Disable();
		if (page == 1)
		{
			((PropComponent)Prop("TextL").Instance).GetComponent<TextMesh>().text = textPage1;
			((PropComponent)Prop("TextR").Instance).GetComponent<TextMesh>().text = textPage2;
		}
		yield return E.ConsumeEvent;
	}

	IEnumerator OnInteractPropClose( IProp prop )
	{
		Audio.Play("book_flip");
		E.ChangeRoomBG(C.Me.LastRoom);
		yield return E.ConsumeEvent;
	}
}