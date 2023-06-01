using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class GuiInventoryBar : GuiScript<GuiInventoryBar>
{


	IEnumerator OnAnyClick( IGuiControl control )
	{

		yield return E.Break;
	}

	void Update()
	{
	}

	void OnPostRestore( int version )
	{
	}

	void OnShow()
	{
	}
}