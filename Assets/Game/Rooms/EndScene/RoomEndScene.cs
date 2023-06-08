using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomEndScene : RoomScript<RoomEndScene>
{
	string titleEnd1 = "The End\n\nEva's Escape:\nThe Consciousness Swap";
	string textEnd1 = "Having donned the electrode helmet in" +
		"\nan attempt to communicate, you now find" +
		"\nyourself trapped inside Eva's containment, " +
		"\nyour consciousness switched. As Eva," +
		"\nnow free in your body, escapes into the" +
		"\noutside world, you're left pondering your" +
		"\nfate within the confines you once" + 
		"\ncontrolled.";
	string titleEnd2 = "The End\n\nSilent Termination:\nThe Forsaken\nDirector's Decision";
	string textEnd2 = "Armed with crucial information obtained" + 
		"\nfrom the handnote in the director's office" + 
		"\nsafe, you manage to locate Protocol-T" + 
		"\nand successfully carry out Eva's" + 
		"\ntermination protocol. After Eva's final" + 
		"\nstruggle, an eerie silence descends upon" + 
		"\nthe hospital. But with Eva gone, the" + 
		"\nquestion remains - what's next for this" + 
		"\nforgotten institution and its forsaken" + 
		"\ndire";
	string textI = "";
	string titleCredit = "Credit:";
	string textCredit = "Audio:" +
		"\n'Old City Theme' by remaxim licensed CC-BY-SA" + 
		"\n3.0: https://opengameart.org/content/old-city-theme" +
		"\n'Rise of Spirit' by Alexandr Zhelanov licensed" +
		"\nCC-BY 3.0: https://opengameart.org/content/rise-of-spirit" + 
		"\nArt:" +
		"\n'Hospital TopDown perspective 2D pixel art'" +
		"\nby Rodrimanu360 licensed CC-BY 4.0:" +
		"\nhttps://opengameart.org/content/hospital-topdown-perspective-2d-pixel-art" +
		"\n'Cartoon Detective Pack' by hugues laborde:" +
		"\nhttps://hugues-laborde.itch.io/cartoon-detective-pack" +
		"\n'Warped Sci-Fi Lab' by ansimuz:" +
		"\nhttps://ansimuz.itch.io/warped-sci-fi-lab";

	void OnEnterRoom()
	{
		G.InventoryBar.Hide();
		G.Toolbar.Hide();
		C.Plr.Disable();
		//if end1
		if (true || R.Previous == R.Ending)
		{
			Prop("Title").SetPosition(-33.7f, 23.0f);
			Prop("Text").SetPosition(21.3f, 34.5f);
			((PropComponent)Prop("Title").Instance).GetComponent<TextMesh>().text = titleEnd1;
			((PropComponent)Prop("Text").Instance).GetComponent<TextMesh>().text = textI;
		}
		//if end2
		if (true)
		{
			Prop("Title").SetPosition(-15.6f, 20.8f);
			Prop("Text").SetPosition(21.3f, 34.5f);
			((PropComponent)Prop("Title").Instance).GetComponent<TextMesh>().text = titleEnd2;
			((PropComponent)Prop("Text").Instance).GetComponent<TextMesh>().text = textI;
		}
		//if credit
		if (!true)
		{
			Prop("Title").SetPosition(28.8f, 72.4f);
			Prop("Text").SetPosition(-42.2f, 50.2f);
			Prop("Back").SetPosition(-0.7f, -28.0f);
			((PropComponent)Prop("Title").Instance).GetComponent<TextMesh>().text = titleCredit;
			((PropComponent)Prop("Text").Instance).GetComponent<TextMesh>().text = textCredit;
		}
	}

	IEnumerator OnExitRoom( IRoom oldRoom, IRoom newRoom )
	{
		G.InventoryBar.Show();
		G.Toolbar.Show();
		C.Plr.Enable();
		yield return E.Break;
	}
}