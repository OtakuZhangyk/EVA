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
}