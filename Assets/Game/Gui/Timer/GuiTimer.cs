using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class GuiTimer : GuiScript<GuiTimer>
{


	void OnShow()
	{
		
		E.SetTimer("escape",30.0f);
		G.Timer.GetControl("Timer").GetComponent<TextMesh>().text = E.GetTimer("escape").ToString();
	}

	void Update()
	{
		
		ILabel timer = (ILabel)G.Timer.GetControl("Timer");
		timer.Text = ((int)(E.GetTimer("escape")*10)/10.0f).ToString();
	}
}