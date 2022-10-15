using MelonLoader;
using UnityEngine;
using ModUI;
using System;
using UnityEngine.UI;

namespace LittleWeather
{
	public static class MyModUI
	{
		public static MelonMod myMod;
		public static ModSettings myModSettings;

		public static bool isInitialized;
		

		public static void Initialize(MelonMod thisMod)
		{
			myModSettings = UIManager.Register(thisMod, new Color32(10, 180, 70, 255));
			
			myModSettings.AddButton("Calm", "Rain", new Color32(98, 177, 232, 200), new Action(delegate { WeatherControlsMain.Activate("RainCalmParent"); }));
			myModSettings.AddButton("Average", "Rain", new Color32(56, 148, 213, 200), new Action(delegate { WeatherControlsMain.Activate("RainAverageParent"); }));
			myModSettings.AddButton("Heavy", "Rain", new Color32(36, 137, 207, 200), new Action(delegate { WeatherControlsMain.Activate("RainHeavyParent"); }));

			myModSettings.AddButton("Low", "Snow", new Color32(235, 235, 235, 200), new Action(delegate { WeatherControlsMain.Activate("SnowCalmParent"); }));
			myModSettings.AddButton("Mid", "Snow", new Color32(200, 200, 200, 200), new Action(delegate { WeatherControlsMain.Activate("SnowAverageParent"); }));
			myModSettings.AddButton("High", "Snow", new Color32(180, 180, 180, 200), new Action(delegate { WeatherControlsMain.Activate("SnowHeavyParent"); }));

			myModSettings.AddButton("Stop weather", "Deactivate", new Color32(180, 200, 104, 255), new Action(delegate { WeatherControlsMain.Stop(); }));

			UpdateValues();
			isInitialized = true;
		}

		public static void UpdateValues()
		{
			

		}
	}
}
