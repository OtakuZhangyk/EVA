using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class CharacterEva : CharacterScript<CharacterEva>
{


	IEnumerator OnLookAt()
	{

		yield return E.Break;
	}

	IEnumerator OnInteract()
	{

		yield return E.Break;
	}
}