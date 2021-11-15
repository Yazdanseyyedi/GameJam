using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reloadgame : MonoBehaviour
{
    // Start is called before the first frame update
    public float reloadTime;
    public bool reloadActivated;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (reloadActivated)
        {
            reloadTime -= Time.deltaTime;
        }
        if (reloadTime < 0)
        {
            SceneManager.LoadScene(0);

        }
    }

    public void Reload()
    {
        reloadActivated = true;
    }
}
