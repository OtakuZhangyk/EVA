using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomLab : RoomScript<RoomLab>
{
	public bool monitorOff = false;
	
	IEnumerator OnInteractPropUndergroundHallway( IProp prop )
	{
		yield return C.WalkToClicked();
		Audio.Play("door_open1");
		E.ChangeRoomBG(R.UndergroundHallway);
		
		yield return E.Break;
	}

	void OnEnterRoom()
	{
		if (C.Me.LastRoom == R.UndergroundHallway)
		{
			C.Me.SetPosition(-150,-50);
			C.Me.Face(0,0);
			Audio.Play("door_close1");
		}
	}

	IEnumerator OnExitRoom( IRoom oldRoom, IRoom newRoom )
	{
		C.Me.SetPosition(-26,-50);
		yield return E.Break;
	}

	IEnumerator OnLookAtPropEVA( IProp prop )
	{
		yield return C.Me.WalkTo(Prop("EVA"));
		yield return E.WaitSkip();
		yield return C.Me.Say("Eva...");
		yield return E.Break;
	}

	IEnumerator OnInteractPropEVA( IProp prop )
	{
		yield return E.FadeOut();
		yield return C.Display("Free me.");
		yield return E.WaitSkip();
		yield return E.FadeIn();
		//G.Timer.Show();
		yield return E.Break;
	}

	IEnumerator OnInteractPropElectricHelm( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return E.WaitSkip();
		prop.Disable();
		I.HeadGear.Add();
		
		yield return E.FadeOut();
		yield return C.Display("Put it on.");
		yield return E.WaitSkip();
		yield return E.FadeIn();
		yield return E.Break;
	}

	IEnumerator OnLookAtPropElectricHelm( IProp prop )
	{
		yield return C.FaceClicked();
		yield return C.Me.Say(" That must be the electrode helmet.");
		yield return E.Break;
	}

	IEnumerator OnLookAtPropUndergroundHallway( IProp prop )
	{
		yield return C.FaceClicked();
		yield return E.WaitSkip();
		yield return C.Me.Say("Door to the hallway");
	}

	IEnumerator OnUseInvPropInjectionDevice( IProp prop, IInventory item )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return E.WaitSkip();
		if (I.Injector.Active)
		{
			Audio.Play("drawer_open");
			I.Injector.Active = false;
			yield return C.Me.Say("What should i inject?");
			Audio.Play("drawer_close");
		}
		else if (I.Injector_HF.Active)
		{
			Audio.Play("drawer_open");
			I.Injector_HF.Active = false;
			I.Injector_HF.Remove();
			Globals.injected = 1;
			yield return C.Me.Say("Alright, then the helmet");
			Audio.Play("drawer_close");
		
		}
		else if (I.Injector_F.Active)
		{
			Audio.Play("drawer_open");
			I.Injector_F.Active = false;
			I.Injector_F.Remove();
			Globals.injected = 2;
			yield return C.Me.Say("Goodbye Eva, goodbye");
			Audio.Play("drawer_close");
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			Camera.Shake(3.0f, 0.5f, 0.5f);
			yield return E.WaitSkip();
			yield return E.WaitSkip();
			yield return C.Me.Say("What happened?");
			yield return E.WaitSkip();
			Camera.Shake(3.0f, 1.0f, 0.5f);
			yield return E.WaitSkip();
			yield return C.Me.Say("Run!!!");
			yield return E.WaitSkip();
			Camera.Shake(3.0f, 30.0f, 0.5f);
			G.Timer.Show();
			Globals.gamePhase = eProgress.EndGame;
			E.Save(1,"Autosave");
		
		}
		yield return E.Break;
	}

	IEnumerator OnLookAtPropLabMonitor( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return E.WaitSkip();
		yield return C.Me.Say("Eva's vital signs are stable.");
		yield return E.ConsumeEvent;
	}

	IEnumerator OnInteractPropLabMonitor( IProp prop )
	{
		yield return C.WalkToClicked();
		if (!monitorOff) {
			prop.PlayAnimationBG("monitorOff");
			monitorOff = true;
		}
		else {
			prop.PlayAnimationBG("monitorAnim");
			monitorOff = false;
		}
		yield return E.Break;
	}

	IEnumerator OnInteractPropInjectionDevice( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return E.WaitSkip();
		Audio.Play("drawer_open");
		yield return C.Me.Say("It only accept injectors.");
		Audio.Play("drawer_close");
		yield return E.Break;
	}

	IEnumerator OnLookAtPropInjectionDevice( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return E.WaitSkip();
		yield return C.Me.Say("It has injector-shaped trays.");
		yield return E.Break;
	}

	IEnumerator OnLookAtPropLaptop( IProp prop )
	{
		yield return C.FaceClicked();
		yield return E.WaitSkip();
		yield return C.Me.Say("Looks like it's being used as a logging device.");
		yield return E.ConsumeEvent;
	}

	IEnumerator OnInteractPropLaptop( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return E.WaitSkip();
		yield return C.Me.Say("No abonormal behaviors logged. Seems normal.");
	}

	IEnumerator OnUseInvPropEVA( IProp prop, IInventory item )
	{

		yield return E.Break;
	}
}