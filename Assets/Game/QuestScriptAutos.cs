using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PowerTools.Quest;

namespace PowerScript
{	
	// Shortcut access to SystemAudio.Get
	public class Audio : SystemAudio
	{
	}

	public static partial class C
	{
		// Access to specific characters (Auto-generated)
		public static ICharacter Dave           { get { return PowerQuest.Get.GetCharacter("Dave"); } }
		public static ICharacter Barney         { get { return PowerQuest.Get.GetCharacter("Barney"); } }
		public static ICharacter Me             { get { return PowerQuest.Get.GetCharacter("Me"); } }
		public static ICharacter Eva            { get { return PowerQuest.Get.GetCharacter("Eva"); } }
		// #CHARS# - Do not edit this line, it's used by the system to insert characters
	}

	public static partial class I
	{		
		// Access to specific Inventory (Auto-generated)
		public static IInventory Bucket         { get { return PowerQuest.Get.GetInventory("Bucket"); } }
		public static IInventory Handnote       { get { return PowerQuest.Get.GetInventory("Handnote"); } }
		public static IInventory Admin_Key      { get { return PowerQuest.Get.GetInventory("Admin_Key"); } }
		public static IInventory Injector         { get { return PowerQuest.Get.GetInventory("Injector"); } }
		public static IInventory LabKey   { get { return PowerQuest.Get.GetInventory("LabKey"); } }
		public static IInventory HeadGear         { get { return PowerQuest.Get.GetInventory("HeadGear"); } }
		// #INVENTORY# - Do not edit this line, it's used by the system to insert rooms for easy access
	}

	public static partial class G
	{
		// Access to specific gui (Auto-generated)
		public static IGui DialogTree     { get { return PowerQuest.Get.GetGui("DialogTree"); } }
		public static IGui SpeechBox      { get { return PowerQuest.Get.GetGui("SpeechBox"); } }
		public static IGui HoverText  { get { return PowerQuest.Get.GetGui("HoverText"); } }
		public static IGui DisplayBox    { get { return PowerQuest.Get.GetGui("DisplayBox"); } }
		public static IGui Prompt         { get { return PowerQuest.Get.GetGui("Prompt"); } }
		public static IGui Toolbar          { get { return PowerQuest.Get.GetGui("Toolbar"); } }
		public static IGui InventoryBar   { get { return PowerQuest.Get.GetGui("InventoryBar"); } }
		public static IGui Options        { get { return PowerQuest.Get.GetGui("Options"); } }
		public static IGui Save           { get { return PowerQuest.Get.GetGui("Save"); } }
		// #GUI# - Do not edit this line, it's used by the system to insert rooms for easy access
	}

	public static partial class R
	{
		// Access to specific room (Auto-generated)
		public static IRoom Title          { get { return PowerQuest.Get.GetRoom("Title"); } }
		public static IRoom Forest         { get { return PowerQuest.Get.GetRoom("Forest"); } }
		public static IRoom Operation_Room { get { return PowerQuest.Get.GetRoom("Operation_Room"); } }
		public static IRoom Hallway        { get { return PowerQuest.Get.GetRoom("Hallway"); } }
		public static IRoom Handnote       { get { return PowerQuest.Get.GetRoom("Handnote"); } }
		public static IRoom Lab            { get { return PowerQuest.Get.GetRoom("Lab"); } }

		public static IRoom UndergroundHallway { get { return PowerQuest.Get.GetRoom("UndergroundHallway"); } }

		public static IRoom OfficeL1       { get { return PowerQuest.Get.GetRoom("OfficeL1"); } }
		public static IRoom HallwayL2      { get { return PowerQuest.Get.GetRoom("HallwayL2"); } }

		public static IRoom Admin          { get { return PowerQuest.Get.GetRoom("Admin"); } }

		public static IRoom PasscodePad    { get { return PowerQuest.Get.GetRoom("PasscodePad"); } }

		public static IRoom LabL2          { get { return PowerQuest.Get.GetRoom("LabL2"); } }

		public static IRoom Safe           { get { return PowerQuest.Get.GetRoom("Safe"); } }
		public static IRoom PCScreen       { get { return PowerQuest.Get.GetRoom("PCScreen"); } }
		public static IRoom PCScreen2      { get { return PowerQuest.Get.GetRoom("PCScreen2"); } }
		public static IRoom Document       { get { return PowerQuest.Get.GetRoom("Document"); } }
		public static IRoom Mind           { get { return PowerQuest.Get.GetRoom("Mind"); } }
		// #ROOM# - Do not edit this line, it's used by the system to insert rooms for easy access
	}

	// Dialog
	public static partial class D
	{
		// Access to specific dialog trees (Auto-generated)
		public static IDialogTree ChatWithBarney       { get { return PowerQuest.Get.GetDialogTree("ChatWithBarney"); } }
		public static IDialogTree ChatwithEva          { get { return PowerQuest.Get.GetDialogTree("ChatwithEva"); } }
		// #DIALOG# - Do not edit this line, it's used by the system to insert rooms for easy access	    	    
	}


}
