using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class InventoryHeadGear : InventoryScript<InventoryHeadGear>
{


	IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		if (R.Current != R.Lab)
			yield return C.Me.Say("I can't use that here..");
		else {
			if (Globals.injected == 0)
			{
				yield return C.Me.Say("I must do the injection first");
			}
			else if (R.SecretHandnote.Visited && Globals.injected != 3)
			{
				Globals.injected = 3;
				yield return C.Me.Say("Should I do this?");
				yield return C.Me.Say("The secret notebook I found says they have banned anyone from using this helmet");
			}
			else if (Globals.injected == 1)
			{
				yield return C.Me.Say("Let's do this.");
				E.ChangeRoomBG(R.Mind);
				Globals.gamePhase = eProgress.EndGame;
			}
			else if (Globals.injected == 3)
			{
				yield return C.Me.Say("I'll do it anyway");
				E.ChangeRoomBG(R.Mind);
				Globals.gamePhase = eProgress.EndGame;
			}
		}
		yield return E.Break;
	}

	IEnumerator OnInteractInventory( IInventory thisItem )
	{

		yield return E.Break;
	}
}