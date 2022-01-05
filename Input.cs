using System;
using MelonLoader;
using Harmony;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using Placemaker;

namespace LittleWeather
{
	public static class InputMain
	{
		public static Material tempMat;
		public static Vector3 mousePos = new Vector3(0,0,0);
		public static void GetInput()
		{		
			if(Input.GetKeyDown(KeyCode.F1))
			{
				WeatherControlsMain.weatherCenter = BootMaster.instance.worldMaster.graph.groundCollider.center + WeatherControlsMain.weatherOffset;
				GUIMain.ToggleUI();
			}
		}
	}
}
