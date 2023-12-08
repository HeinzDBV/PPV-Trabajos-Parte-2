using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//GAME MANAGER DONDE SE DEFINEN TODOS LOS AUDIOS Y SE CONTROLARÁN
public static class SoundManager{

    public enum Sound{
        PlayerWalkWood,
        PlayerWalkConcrete,
        PlayerSprintBreathing,
        PlayerDie,
        PlayerObjectPickup,
        PlayerObjectDrop,
        PlayerObjectInteraction
    }

    private static Dictionary<Sound, float> soundTimerDictionary;

    public static void Initialize(){
        soundTimerDictionary = new Dictionary<Sound, float>();
        soundTimerDictionary[Sound.PlayerWalkWood] = .0f;
        soundTimerDictionary[Sound.PlayerWalkConcrete] = .0f;
        Debug.Log("Audios cargados");

    }

    
    public static void PlaySound(Sound sound){
        
        if(CanPlaySound(sound)){
            GameObject soundGameObject = new GameObject("Sound");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.PlayOneShot(GetAudioClip(sound));
        }
    }

    public static void StopSound (Sound sound){
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.Stop();
    }

    private static bool CanPlaySound(Sound sound){
        switch(sound){
            default:
                return true;
            case Sound.PlayerWalkWood:
                if(soundTimerDictionary.ContainsKey(sound)){
                    float lastTimePlayed = soundTimerDictionary[sound];
                    float playerWalkWoodTimerMax = 0.05f;
                    if(lastTimePlayed + playerWalkWoodTimerMax < Time.time){
                        soundTimerDictionary[sound] = Time.time;
                        return true;
                    }else{
                        return false;
                    }
                }else{
                    return true;
                }
            case Sound.PlayerWalkConcrete:
                if(soundTimerDictionary.ContainsKey(sound)){
                    float lastTimePlayed = soundTimerDictionary[sound];
                    float playerWalkConcreteTimerMax = 0.05f;
                    if(lastTimePlayed + playerWalkConcreteTimerMax < Time.time){
                        soundTimerDictionary[sound] = Time.time;
                        return true;
                    }else{
                        return false;
                    }
                }else{
                    return true;
                }
        }
    }

    private static AudioClip GetAudioClip(Sound sound){
        foreach(GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipArray){
            if(soundAudioClip.sound == sound){
                return soundAudioClip.audioClip;
            }
        }

        Debug.LogError("Sound " + sound + " not found!");
        return null;
    }
   
}


