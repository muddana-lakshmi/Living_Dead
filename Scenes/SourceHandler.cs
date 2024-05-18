using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using Unity.VisualScripting;
using UnityEngine;

public class SourceHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioSource adsrc;
    public static AudioClip Arrow,Burger,Sprite,Jump,Enemy;
    void Start()
    {
        adsrc=GetComponent<AudioSource>();
        Arrow=Resources.Load<AudioClip>("Arrow");
        Burger=Resources.Load<AudioClip>("Burger Sound");
        Sprite=Resources.Load<AudioClip>("Sprite Sound");
        Jump=Resources.Load<AudioClip>("Jump");
        Enemy=Resources.Load<AudioClip>("Enemy Touch");

    }

    // Update is called once per frame
    public static void playtheAudio(string clip)
    {
        switch(clip)
        {
            case "Arrow":
                adsrc.PlayOneShot(Arrow);
                break;
            case "Jump":
                adsrc.PlayOneShot(Jump);
                break;
            case "Burger":
                adsrc.PlayOneShot(Burger);
                break;
            case "Sprite":
                adsrc.PlayOneShot(Sprite);
                break;
            case "Enemy":
                adsrc.PlayOneShot(Enemy);
                break;
        }
    }
}
