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
		C.Me.Disable();
		G.InventoryBar.Hide();
		Prop("Prev").Disable();
		documents.Add(@"Objective: Reconstructing functionalities of an inactive brain
Subject: 18 yrs old full female body with all systems functioning
		except brain dead
Environment setup: Subject is submerged in nutrient solution
		and connected to life maintenance devices
Approach: injection of different types of compounds. Each
		compound is injected with increasing doses over the
		course of 3 months.");
		documents.Add(@"Initial assessment: Severe head injury including concussion and
		penetrating injury. Need to perform operations to
		remove extra objects and clean up infections from
		the brain.
Log 1: Successfully performed operation, subject is plugged into
		life maintenance devices and is in recovering phase.
		Medications have been used to boost recovery speed,
		so far the tissues are healing at an extraordinary
		speed.");
		documents.Add(@"Log 2: The brain tissues have fully recovered, in a suprisingly
		short period of time. Brain functions still inactive.
		No signals of brain activities at all. Starting injection
		of Compound 5.");
		((PropComponent)Prop("Text").Instance).GetComponent<TextMesh>().text = documents[page];
	}

	IEnumerator OnExitRoom( IRoom oldRoom, IRoom newRoom )
	{
		C.Me.Enable();
		G.InventoryBar.Show();
		yield return E.Break;
	}

	IEnumerator OnInteractPropExit( IProp prop )
	{
		E.ChangeRoomBG(R.Admin);
		yield return E.Break;
	}

	IEnumerator OnInteractPropNext( IProp prop )
	{
		page++;
		((PropComponent)Prop("Text").Instance).GetComponent<TextMesh>().text = documents[page];
		Prop("Prev").Enable();
		if (page == 2)
			Prop("Next").Disable();
		yield return E.ConsumeEvent;
	}

	IEnumerator OnInteractPropPrev( IProp prop )
	{
		page--;
		((PropComponent)Prop("Text").Instance).GetComponent<TextMesh>().text = documents[page];
		Prop("Next").Enable();
		if (page == 0)
			Prop("Prev").Disable();
		yield return E.ConsumeEvent;
	}
}