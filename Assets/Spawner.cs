using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    public float spawnCooldown = 1.5f;
    public float spawnTimer = -1.0f;
    //TextMeshProUGUI gameover;
    void Start()
    {
        //gameover = GameObject.Find("GameOver").GetComponent<TextMeshProUGUI>();
        //StartCoroutine(GameOver());
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawnTimer)
        {
            spawnTimer = Time.time + spawnCooldown;
            GameObject temp = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
            Destroy(temp, 5.0f);
        }
    }


    //IEnumerator GameOver()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(0.5f);
    //        gameover.enabled = false;
    //        yield return new WaitForSeconds(0.5f);
    //        gameover.enabled = true;
    //    }
    //}


}
