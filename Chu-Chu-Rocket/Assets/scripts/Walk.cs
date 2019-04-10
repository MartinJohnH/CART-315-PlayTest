using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Walk : MonoBehaviour
{
    public float speed = 0.2f;
    public static bool startWalk = false;
    private bool isWalkingFast = false;
    public string accelerateKey = "";

    private GameObject gameOver;
    private static int blueWin;
    private static int redWin;

    private GameObject mainLight;
    private GameObject[] stationLights;



    private void Start()
    {
        gameOver = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        gameOver.SetActive(false);
        mainLight = GameObject.Find("Directional Light");
        stationLights = GameObject.FindGameObjectsWithTag("rocket");
        stationLights[0] = stationLights[0].transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        stationLights[1] = stationLights[1].transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;

        stationLights[0].SetActive(false);
        stationLights[1].SetActive(false);
        blueWin = 5;
        redWin = 5;
        startWalk = false;
        GameObject.Find("Walls").GetComponent<WallSpawner>().enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ScreenManager.isButtonPressed)
        {
            GameObject.Find("Walls").GetComponent<WallSpawner>().enabled = true;
            StartCoroutine(Delay(1));
        }
        if (Input.GetKeyDown(accelerateKey))
        {
            isWalkingFast = !isWalkingFast;
            if (isWalkingFast)
            {
                speed *= 1.3f;
                GetComponent<AudioSource>().pitch = 1.25f;
            }
            else
            {
                speed /= 1.3f;
                GetComponent<AudioSource>().pitch = 1.0f;
            }
        }
        if (blueWin <= 0)
        {
            gameOver.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Blue Wins!";
            gameOver.SetActive(true);
            speed = 0;
            GetComponent<AudioSource>().Stop();
            mainLight.GetComponent<Light>().intensity = 0.44f;
            stationLights[0].transform.GetChild(0).gameObject.GetComponent<Light>().color = new Color(0, 0.25f, 0.7f, 1);
            stationLights[0].transform.GetChild(1).gameObject.GetComponent<Light>().color = new Color(0, 0.25f, 0.7f, 1);
            stationLights[0].transform.GetChild(2).gameObject.GetComponent<Light>().color = new Color(0, 0.25f, 0.7f, 1);
            stationLights[0].transform.GetChild(3).gameObject.GetComponent<Light>().color = new Color(0, 0.25f, 0.7f, 1);

            stationLights[1].transform.GetChild(0).gameObject.GetComponent<Light>().color = new Color(0, 0.25f, 0.7f, 1);
            stationLights[1].transform.GetChild(1).gameObject.GetComponent<Light>().color = new Color(0, 0.25f, 0.7f, 1);
            stationLights[1].transform.GetChild(2).gameObject.GetComponent<Light>().color = new Color(0, 0.25f, 0.7f, 1);
            stationLights[1].transform.GetChild(3).gameObject.GetComponent<Light>().color = new Color(0, 0.25f, 0.7f, 1);


            stationLights[0].SetActive(true);
            stationLights[1].SetActive(true);
        }
        if (redWin <= 0)
        {
            gameOver.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Red Wins!";
            gameOver.SetActive(true);
            speed = 0;
            GetComponent<AudioSource>().Stop();
            mainLight.GetComponent<Light>().intensity = 0.44f;
            stationLights[0].transform.GetChild(0).gameObject.GetComponent<Light>().color = new Color(0.8f, 0, 0, 1);
            stationLights[0].transform.GetChild(1).gameObject.GetComponent<Light>().color = new Color(0.8f, 0, 0, 1);
            stationLights[0].transform.GetChild(2).gameObject.GetComponent<Light>().color = new Color(0.8f, 0, 0, 1);
            stationLights[0].transform.GetChild(3).gameObject.GetComponent<Light>().color = new Color(0.8f, 0, 0, 1);

            stationLights[1].transform.GetChild(0).gameObject.GetComponent<Light>().color = new Color(0.8f, 0, 0, 1);
            stationLights[1].transform.GetChild(1).gameObject.GetComponent<Light>().color = new Color(0.8f, 0, 0, 1);
            stationLights[1].transform.GetChild(2).gameObject.GetComponent<Light>().color = new Color(0.8f, 0, 0, 1);
            stationLights[1].transform.GetChild(3).gameObject.GetComponent<Light>().color = new Color(0.87f, 0, 0, 1);

            stationLights[0].SetActive(true);
            stationLights[1].SetActive(true);
        }

    }
    private IEnumerator Delay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        startWalk = true;
        GetComponent<AudioSource>().Play();
    }

    private void FixedUpdate()
    {
        if (startWalk)
        {
            transform.position += transform.right * speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "wall" || other.gameObject.tag == "wall1" || other.gameObject.tag == "wall2")
        {
            if(this.gameObject.tag == "mouse")
            {
                transform.Rotate(0.0f, -90.0f, 0.0f);
            }else if (this.gameObject.tag == "cat")
            {
                transform.Rotate(0.0f, 90.0f, 0.0f);
            }
        }
        if (other.gameObject.tag == "rocket")
        {
            if (this.gameObject.tag == "mouse")
            {
                blueWin--;
            }
            else if (this.gameObject.tag == "cat")
            {
                redWin--;
            }
            Destroy(gameObject);
        }
    } 
}
