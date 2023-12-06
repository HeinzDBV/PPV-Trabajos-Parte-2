using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private float duration;

    public void ToOptions(Transform target)
    {
        transform.DOMove(new Vector3(0.10f,1f,50.44f), duration);
        transform.DORotate(new Vector3(85f, 9.08f,0), duration);
    }
    public void ToMain(Transform target)
    {
        transform.DOMove(new Vector3(-2.8f,3f,48.03f), duration);
        transform.DORotate(new Vector3(0, 100,0), duration);
    }
    public void ToCrediTs (Transform target)
    {
        transform.DOMove(new Vector3(-4.9f,-1.9f,43.2f), duration);
        transform.DORotate(new Vector3(-4.2f, 75.57f,3.4f), duration);
    }

}
