using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ESTO SE ENCARGA DE CARGAR TODOS LOS AUDIOS QUE SE USARÁN EN EL JUEGO
public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;
    public static GameAssets i{
        get{
            if(_i == null) _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            Debug.Log("Cargando audios");
            return _i;
        }
    }
    public SoundAudioClip[] soundAudioClipArray;

    [System.Serializable]
    public class SoundAudioClip{
        public SoundManager.Sound sound;
        public AudioClip audioClip;
        public GameObject instanceObject;

    }

}
