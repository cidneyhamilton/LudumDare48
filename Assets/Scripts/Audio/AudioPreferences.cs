using UnityEngine;

namespace Cyborg.Audio {

	public enum PlayerPrefKeys
	{
		Volume
	}
	
	
	// Manages user-defined audio controls
	public static class AudioPreferences 
	{
		
		// Audio controls don't start out maxed
		const float DEFAULT_VOLUME = 0.75f;
		
		public static float Volume
		{
			get
			{
				return PlayerPrefs.GetFloat(PlayerPrefKeys.Volume.ToString(), DEFAULT_VOLUME);
			}
			set
			{
				PlayerPrefs.SetFloat(PlayerPrefKeys.Volume.ToString(), value);
			}
		}
		
	}
	
}

