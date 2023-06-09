using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomMind : RoomScript<RoomMind>
{


	void OnEnterRoom()
	{
		C.Plr.SetPosition(0,-75);
		G.InventoryBar.Visible = false;
		if (FirstTimeVisited) {
			C.Plr.Instance.GetComponent<SpriteRenderer>().color = new Color(0.3f,0.3f,0.5f,1);
			C.Eva.Instance.GetComponent<SpriteRenderer>().color = new Color(0.3f,0.3f,0.5f,1);
			C.Plr.Data.FootstepSound = null;
		} else {
			C.Plr.SetPosition(0,-75);
			C.Plr.Disable();
			C.Eva.Disable();
		}
		Audio.Pause("hospital_bgm");
	}

	IEnumerator OnExitRoom( IRoom oldRoom, IRoom newRoom )
	{
		C.Plr.Data.FootstepSound = "step";
		C.Plr.Instance.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
		G.InventoryBar.Visible = true;
		C.Plr.Enable();
		Audio.UnPause("hospital_bgm");
		yield return E.Break;
	}

	IEnumerator OnInteractCharacterEva( ICharacter character )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return E.WaitSkip();
		D.ChatwithEva.Start();
		yield return E.Break;
	}

	IEnumerator OnEnterRoomAfterFade()
	{
		if (FirstTimeVisited)
			yield return C.Eva.Say("So you have come. I was expecting you.");
		else {
			yield return C.Me.Say(" E..Eva?");
			yield return E.WaitSkip();
			yield return C.Me.Say("Hello?");
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			yield return C.Eva.Say("Thank you, Doctor. Your job is done.");
			yield return C.Me.Say("Thank you, Doctor. Your job is done.");
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			yield return C.Me.Say("I am free.");
			yield return C.Eva.Say("Wait...");
			yield return E.WaitSkip();
			E.ChangeRoomBG(R.Ending);
		}
		yield return E.Break;
	}

	IEnumerator OnLookAtCharacterEva( ICharacter character )
	{
		yield return E.ConsumeEvent;
	}
}