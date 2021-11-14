using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comboplacer : MonoBehaviour
{
    public GameObject comboPrefab;
    public float timer;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public string[] combos;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 10)
        {
            Debug.Log("timer");
            GameObject go;
            go = Instantiate(comboPrefab);
            go.transform.position = new Vector3(UnityEngine.Random.Range(minX, maxX), UnityEngine.Random.Range(minX, maxX), 0);

            timer = 0;
        }
    }
}
