using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ESTO SE ENCARGA DE CARGAR TODOS LOS AUDIOS QUE SE USARÁN EN EL JUEGO
public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    // Esta función estática se encarga de cargar el recurso GameAssets si aún no se ha cargado
    public static GameAssets i {
        get {
            if (_i == null) {
                _i = Resources.Load<GameAssets>("GameAssets");
                if (_i == null) {
                    Debug.LogError("GameAssets no encontrado en la carpeta Resources.");
                }
            }
            return _i;
        }
    }

    public SoundAudioClip[] soundAudioClipArray;

    [System.Serializable]
    public class SoundAudioClip {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }
}
