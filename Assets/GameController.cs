using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject playerObject;
    PlayerController playerScript;
    public TextMeshProUGUI gameOverText;
    void Start()
    {
        playerObject = GameObject.Find("Player");
        playerScript = playerObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerObject.transform.position.y < -5.0f)
        {
            playerObject.transform.position = this.transform.position;
            Camera.main.GetComponent<CameraFollow>().CameraReset();
            playerScript.UpdateHealth(-1);
        }

        if (Input.GetKeyDown(KeyCode.R) && playerScript.isDead())
        {
            SceneManager.LoadScene("SampleScene");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void GameOverSequence() 
    {
        gameOverText.enabled = true;
        playerObject.SetActive(false);
        GameObject.Find("Spawner").SetActive(false);
    }
}
