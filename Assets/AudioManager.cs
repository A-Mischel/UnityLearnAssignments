using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
        private static AudioManager _instance;
        public static AudioManager Instance { get { return _instance; } }
        private bool mute = false;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        public void toggleMute()
        {
            mute = !mute;
            AudioListener.volume = mute ? 0 : 1;
        }
}
