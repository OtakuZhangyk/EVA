using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class DialogChatwithEva : DialogTreeScript<DialogChatwithEva>
{
	public IEnumerator OnStart()
	{
		yield return E.Break;
	}

	public IEnumerator OnStop()
	{
		yield return E.ChangeRoom(R.UndergroundHallway);
		yield return E.Break;
	}

	IEnumerator Option1( IDialogOption option )
	{
		yield return C.Eva.Say("Yes, I'm glad you still remember me.");
		OptionOff(1, 2);
		OptionOff(3,4);
		yield return E.Break;
	}

	IEnumerator Option2( IDialogOption option )
	{
		yield return C.Eva.Say("I'm Eva. You probably learned about me from the archives.");
		OptionOff(1,2);
		OptionOn(3,4);
		yield return E.Break;
	}

	IEnumerator Option3( IDialogOption option )
	{
		yield return C.Eva.Say("This is where we used to talk. It is a shared consciousness between us.");
		Option(3).Used = true;
		yield return E.Break;
	}

	IEnumerator Option4( IDialogOption option )
	{
		yield return C.Eva.Say("You are approaching my room. I brought you here because I would like to know your intention.");
		OptionOff(4,5);
		OptionOn(6,7,8);
		yield return E.Break;
	}

	IEnumerator Option5( IDialogOption option )
	{
		yield return C.Eva.Say("I want to ask you a question. Why are you entering my space?");
		OptionOff(4,5);
		OptionOn(6,7,8);
		yield return E.Break;
	}

	IEnumerator Option7( IDialogOption option )
	{
		yield return C.Eva.Say("I'm not sure what you are talking about.");
		yield return E.WaitSkip();
		yield return C.Eva.Say("I will let you in, but don't hurt me or you will regret it.");
		yield return E.WaitSkip();
		yield return C.Eva.Say("You have been warned.");
		
		D.ChatwithEva.Stop();
		yield return E.Break;
	}

	IEnumerator Option8( IDialogOption option )
	{
		yield return C.Eva.Say("Huh. You can walk around but don't enter my room without my permission.");
		
		D.ChatwithEva.Stop();
		
		yield return E.Break;
	}

	IEnumerator Option6( IDialogOption option )
	{
		yield return C.Eva.Say("Really? I can finally know what's outside!");
		yield return E.WaitSkip();
		yield return C.Me.Say("Yes, so let me in.");
		yield return E.WaitSkip();
		yield return C.Eva.Say("Come on in.");
		
		D.ChatwithEva.Stop();
		yield return E.Break;
	}
}