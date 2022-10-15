using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LittleWeather
{
    public class LittleWeatherMain : MelonMod
    {		
		public static Il2CppAssetBundle weatherBundle;
		public override void OnApplicationStart()
		{
			MelonLogger.Msg("Loading assetbundle ...");
			weatherBundle = Il2CppAssetBundleManager.LoadFromFile("Mods\\LittleWeatherBundle.unity3d");

			if (weatherBundle == null)
			{
				MelonLogger.Msg("Failed to load assetbundle: \"littleweatherbundle.unity3d\"");
				return;
			}
			else
			{
				WeatherControlsMain.InitEffects();				
			}
		}


		public override void OnSceneWasLoaded(int buildIndex, string sceneName)
		{			
			if(sceneName == "Placemaker")
			{
				MyModUI.Initialize(this);
			}			
		}

		public override void OnUpdate()
		{
			
		}
	}
}
