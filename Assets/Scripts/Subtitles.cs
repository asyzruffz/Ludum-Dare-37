using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subtitles : MonoBehaviour {


	public string SubtitleText;
	public string SubtitleText1;
	public string SubtitleText2;
	public string SubtitleText3;
	public string SubtitleText4;
	public string SubtitleText5;
	public string SubtitleText6;
	public string SubtitleText7;
	public bool ShowSubtitle=false;
	public int SubtitleCount =1;
	public float Subtimer;


	// Use this for initialization
	void Start()
	{
		Subtimer = SubtitleCount;	
	}
	// Update is called once per frame
	void Update () {
		if(Subtimer>0)
		{
			Subtimer -= Time.deltaTime;
		}
		if(Subtimer<=0)
		{
			SubtitleCount+=1;
			Subtimer=SubtitleCount;
		}
		if(ShowSubtitle==true)
		{
			if(SubtitleCount==1)
			{
				SubtitleText = SubtitleText1;
			}
			if(SubtitleCount==2)
			{
				SubtitleText = SubtitleText2;
			}
			if(SubtitleCount==3)
			{
				SubtitleText = SubtitleText3;
			}
			if(SubtitleCount==4)
			{
				SubtitleText = SubtitleText4;
			}
			if(SubtitleCount==5)
			{
				SubtitleText = SubtitleText5;
			}
			if(SubtitleCount==6)
			{
				SubtitleText = SubtitleText6;
			}
			if(SubtitleCount==7)
			{
				SubtitleText = SubtitleText7;
			}
			if (SubtitleCount > 7) {
				ShowSubtitle = false;
			}
		}
	}
		
	void OnGUI()
	{
		if (ShowSubtitle == true) {
			Vector3 centre = Camera.main.ViewportToScreenPoint(Vector3.one/2);
			Debug.Log (centre.ToString());
			GUI.Box(new Rect(centre.x - 100,centre.y - 100,200,200),"" + SubtitleText);
		}
	}

}
