using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomDocument : RoomScript<RoomDocument>
{
	int page = 0;	System.Collections.Generic.List<string> documents = new System.Collections.Generic.List<string>();
	void OnEnterRoom()
	{
		//Audio.Play("page");
		C.Me.Disable();
		G.InventoryBar.Hide();
		Prop("Prev").Disable();
		if (C.Me.LastRoom == R.Admin)
		{
			documents.Add(@"Objective: Reconstructing functionalities of an inactive brain
Subject: 18 yrs old full female body with all systems functioning
	except brain dead
Environment setup: Subject is submerged in nutrient solution
	and connected to life maintenance devices
Approach: injection of different types of compounds. Each
	compound is injected with increasing doses over the course
	of 3 months.");
			documents.Add(@"Initial assessment: Severe head injury including concussion and
	penetrating injury. Need to perform operations to remove
	extra objects and clean up infections from the brain.
Log 1: Successfully performed operation, subject is plugged into
	life maintenance devices and is in recovering phase.
	Medications have been used to boost recovery speed, so
	far the tissues are healing at an extraordinary speed.");
			documents.Add(@"Log 2: The brain tissues have fully recovered, in a suprisingly
	short period of time. Brain functions still inactive. No
	signals of brain activities at all. Starting injection of
	Compound 5.
Log 3: Finally detecting weak brain signals from the eva!
	Compound 5 is reestablishing neural links as expected.
	I will be watching the signal coming out of eva's brain,
	hoping to see some patterns out of the messy diagrams.");
			documents.Add(@"Log 4: I was not expecting compound 5 to work this well. Eva
	has retored part of her awareness. I am observing her
	reaction to changes in the environment such as lighting,
	sound, and temperature changes.
Log 5: One month in, EVA has gained most of her brain functions
	back. I can now do simple communications with her through
	this helmet that amplifies and translates both of our brain
	waves. I'm teaching her basic words and expressions, just
	like when I used to teach my daughter when she was little.
	Am I having my daughter back soon? It's unbelievable...");
		}
        else
        {
			Prop("Next").Disable();
			((PropComponent)Prop("Title").Instance).GetComponent<TextMesh>().text = "Laboratory Code";
			Prop("Title").SetPosition(-80f, 70f);
			Prop("Text").SetPosition(-116f, 24f);
			documents.Add(@"1. Protective clothing must be worn before entering the
	laboratory and valuables placed in protective clothing
	pockets and zipped up.
2. It is prohibited to take laboratory containers out of the
	laboratory.");
		}
		((PropComponent)Prop("Text").Instance).GetComponent<TextMesh>().text = documents[page];
	}

	IEnumerator OnExitRoom( IRoom oldRoom, IRoom newRoom )
	{
		//Audio.Play("page");
		C.Me.Enable();
		G.InventoryBar.Show();
		yield return E.Break;
	}

	IEnumerator OnInteractPropExit( IProp prop )
	{
		if (C.Me.LastRoom == R.Admin)
			Audio.Play("button_click");
		if (C.Me.LastRoom == R.LabL2)
			Audio.Play("page");
		E.ChangeRoomBG(C.Me.LastRoom);
		yield return E.Break;
	}

	IEnumerator OnInteractPropNext( IProp prop )
	{
		Audio.Play("button_click");
		page++;
		((PropComponent)Prop("Text").Instance).GetComponent<TextMesh>().text = documents[page];
		Prop("Prev").Enable();
		if (page > 2)
			Prop("Next").Disable();
		yield return E.ConsumeEvent;
	}

	IEnumerator OnInteractPropPrev( IProp prop )
	{
		Audio.Play("button_click");
		page--;
		((PropComponent)Prop("Text").Instance).GetComponent<TextMesh>().text = documents[page];
		Prop("Next").Enable();
		if (page == 0)
			Prop("Prev").Disable();
		yield return E.ConsumeEvent;
	}
}