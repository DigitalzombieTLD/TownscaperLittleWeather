using MelonLoader;
using System;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LittleWeather
{
	public static class GUIMain
	{
		public static GameObject currentGUI;
		public static GameObject guiPrefab;
		public static bool active = false;

		public static Button buttonSnowCalm;
		public static Button buttonSnowNormal;
		public static Button buttonSnowHeavy;

		public static Button buttonRainCalm;
		public static Button buttonRainNormal;
		public static Button buttonRainHeavy;

		public static Button buttonClose;
		public static Button buttonDisableWeather;

		public static void InitUI()
		{
			MelonLogger.Msg("Initializing mod GUI elements ...");

			currentGUI = UnityEngine.Object.Instantiate(LittleWeatherMain.weatherBundle.LoadAsset<GameObject>("ModGUI"));			
			SceneManager.MoveGameObjectToScene(currentGUI, SceneManager.GetSceneByName("FlatscreenUi"));
			UnityEngine.Object.DontDestroyOnLoad(currentGUI);
			InitButtons();
			currentGUI.SetActive(false);
			active = false;
		}

		public static void InitButtons()
		{
			MelonLogger.Msg("Initializing mod GUI buttons ...");

			buttonSnowCalm = GameObject.Find("buttonSnowCalm").GetComponent<Button>();
			buttonSnowCalm.onClick.AddListener(DelegateSupport.ConvertDelegate<UnityAction>(new Action(delegate { WeatherControlsMain.Activate("SnowCalmParent"); })));
			buttonSnowNormal = GameObject.Find("buttonSnowNormal").GetComponent<Button>();
			buttonSnowNormal.onClick.AddListener(DelegateSupport.ConvertDelegate<UnityAction>(new Action(delegate { WeatherControlsMain.Activate("SnowAverageParent"); })));
			buttonSnowHeavy = GameObject.Find("buttonSnowHeavy").GetComponent<Button>();
			buttonSnowHeavy.onClick.AddListener(DelegateSupport.ConvertDelegate<UnityAction>(new Action(delegate { WeatherControlsMain.Activate("SnowHeavyParent"); })));
			buttonRainCalm = GameObject.Find("buttonRainCalm").GetComponent<Button>();
			buttonRainCalm.onClick.AddListener(DelegateSupport.ConvertDelegate<UnityAction>(new Action(delegate { WeatherControlsMain.Activate("RainCalmParent"); })));
			buttonRainNormal = GameObject.Find("buttonRainNormal").GetComponent<Button>();
			buttonRainNormal.onClick.AddListener(DelegateSupport.ConvertDelegate<UnityAction>(new Action(delegate { WeatherControlsMain.Activate("RainAverageParent"); })));
			buttonRainHeavy = GameObject.Find("buttonRainHeavy").GetComponent<Button>();
			buttonRainHeavy.onClick.AddListener(DelegateSupport.ConvertDelegate<UnityAction>(new Action(delegate { WeatherControlsMain.Activate("RainHeavyParent"); })));
	
			buttonClose = GameObject.Find("buttonCloseMenu").GetComponent<Button>();
			buttonClose.onClick.AddListener(DelegateSupport.ConvertDelegate<UnityAction>(new Action(delegate{	CloseUI();	})));

			buttonDisableWeather = GameObject.Find("buttonDisableWeather").GetComponent<Button>();
			buttonDisableWeather.onClick.AddListener(DelegateSupport.ConvertDelegate<UnityAction>(new Action(delegate { WeatherControlsMain.Stop(); })));
		}

		public static void CloseUI()
		{
			currentGUI.SetActive(false);
			active = false;
		}


		public static void ToggleUI()
		{
			MelonLogger.Msg("Toggle GUI.");

			if (active)
			{
				currentGUI.SetActive(false);
				active = false;
			}
			else
			{
				currentGUI.SetActive(true);
				active = true;
			}
		}
	}
}
