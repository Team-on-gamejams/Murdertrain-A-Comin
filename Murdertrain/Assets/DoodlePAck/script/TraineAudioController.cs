using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System.Collections;

public class TraineAudioController : MonoBehaviour {
    public static TraineAudioController instant;
    public List<AudioClip> sounds = new List<AudioClip>();

    public enum SoundPack {
        Joy = 0,
        Crush = 1,
        whistle = 2
    }

    
	// Use this for initialization
	void Start () {
        instant = this;
    }
	
    public AudioSource PlaySoud(SoundPack sound) {
        AudioSource ac = gameObject.AddComponent<AudioSource>();
        /*Debug.Log(sounds.Count);
        Debug.Log(sounds[0].name);
        Debug.Log("sound.GetHashCode()"+sound.GetHashCode());*/
        ac.clip = sounds[sound.GetHashCode()];
        ac.volume = 0.1f;
        ac.Play();
        return ac;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
