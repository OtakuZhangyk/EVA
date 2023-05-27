using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class CharacterMe : CharacterScript<CharacterMe>
{


	IEnumerator OnLookAt()
	{

		yield return E.Break;
	}
}