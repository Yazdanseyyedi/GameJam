using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundController : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource shot;
    public AudioSource explosion;
    public AudioSource combo;
    public AudioSource mine;
    public AudioSource shieldbreak;
    //public AudioSource drums;

    // Update is called once per frame

    public void shotsound()
    {
        shot.Play();
    }
    public void shieldbreaksound()
    {
        shieldbreak.Play();
    }
    public void explosionsound()
    {
        explosion.Play();
    }

    public void combosound()
    {
        combo.Play();
    }
    public void minesound()
    {
        mine.Play();
    }
}
