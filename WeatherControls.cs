using MelonLoader;
using Placemaker;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LittleWeather
{
	public static class WeatherControlsMain
	{
			
		// prefabs from assetbundle
		public static GameObject rainAverage;
		public static GameObject rainCalm;
		public static GameObject rainHeavy;
		public static GameObject snowAverage;
		public static GameObject snowCalm;
		public static GameObject snowHeavy;
		public static GameObject littleWeatherButtonPrefab;
		public static GameObject guiPrefab;

		// instance on runtime
		public static GameObject currentWeather;

		public static Vector3 weatherCenter;
		public static Vector3 weatherOffset = new Vector3(0,20f,0);

		public static void InitEffects()
		{
			MelonLogger.Msg("Initializing weather effects ...");
			WeatherControlsMain.rainAverage = LittleWeatherMain.weatherBundle.LoadAsset<GameObject>("RainAverageParent");
			UnityEngine.Object.DontDestroyOnLoad(rainAverage);
			WeatherControlsMain.rainCalm = LittleWeatherMain.weatherBundle.LoadAsset<GameObject>("RainCalmParent");
			UnityEngine.Object.DontDestroyOnLoad(rainCalm);
			WeatherControlsMain.rainHeavy = LittleWeatherMain.weatherBundle.LoadAsset<GameObject>("RainHeavyParent");
			UnityEngine.Object.DontDestroyOnLoad(rainHeavy);

			WeatherControlsMain.snowAverage = LittleWeatherMain.weatherBundle.LoadAsset<GameObject>("SnowAverageParent");
			UnityEngine.Object.DontDestroyOnLoad(snowAverage);
			WeatherControlsMain.snowCalm = LittleWeatherMain.weatherBundle.LoadAsset<GameObject>("SnowCalmParent");
			UnityEngine.Object.DontDestroyOnLoad(snowCalm);
			WeatherControlsMain.snowHeavy = LittleWeatherMain.weatherBundle.LoadAsset<GameObject>("SnowHeavyParent");
			UnityEngine.Object.DontDestroyOnLoad(snowHeavy);			
		}

		public static void Activate(string weatherName)
		{
			WeatherControlsMain.weatherCenter = BootMaster.instance.worldMaster.graph.groundCollider.center + WeatherControlsMain.weatherOffset;
			MelonLogger.Msg("Switch to weather: " + weatherName);
			UnityEngine.Object.Destroy(currentWeather);
			currentWeather = UnityEngine.Object.Instantiate(LittleWeatherMain.weatherBundle.LoadAsset<GameObject>(weatherName));
			SceneManager.MoveGameObjectToScene(currentWeather, SceneManager.GetSceneByName("Placemaker"));
		
			currentWeather.transform.position = weatherCenter;
		}

		public static void Stop()
		{
			MelonLogger.Msg("Stopping weather ...");
			UnityEngine.Object.Destroy(currentWeather);
		}
	}
}
