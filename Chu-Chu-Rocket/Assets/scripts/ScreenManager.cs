using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    public GameObject CameraRotator;
    public Camera MainCamera;
    public GameObject MainMenu;
    public GameObject Instructions;

    private bool showInstructions = false;


    // Movement speed in units/sec.
    public float speed = 3.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    private float fracJourney = 0;

    private bool isCamRotating;
    public static bool isButtonPressed;
    private bool playSound;



    private float angle = 0;

    public GameObject ws;

    private int counter;
    private bool isCamMov;


    public void OnButtonClick()
    {
        isButtonPressed = true;
        MainCamera.GetComponentInParent<CameraRotation>().speed = 1f;

        MainMenu.SetActive(false);
        showInstructions = true;
        isCamRotating = true;
    }
    private void Start()
    {
        MainMenu.SetActive(true);
        Instructions.SetActive(false);
        isCamMov = true;
        isButtonPressed = false;
        playSound = true;

        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(new Vector3(0, 1.25f, -4.5f),  new Vector3(0, 8.8f, -4.5f));
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            showInstructions = false;
            if (isButtonPressed) {
                if (playSound)
                {   
                    GetComponent<AudioSource>().Play();
                    playSound = false;
                }
                isCamMov = false;
                MainCamera.GetComponentInParent<CameraRotation>().speed = 0;
                MainCamera.transform.localPosition = new Vector3(0, 8.8f, -4.5f);
                MainCamera.transform.localRotation = Quaternion.Euler(65, 0, 0);
                CameraRotator.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
      
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            showInstructions = !showInstructions;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }
        if (showInstructions)
        {
            Instructions.SetActive(true);
        }
        else
        {
            Instructions.SetActive(false);
        }
     
        if (isCamRotating)
        {

            // Distance moved = time * speed.
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed = current distance divided by total distance.
            fracJourney = distCovered / journeyLength;

            MainCamera.transform.localPosition = Vector3.Lerp(new Vector3(0, 1.25f, -4.5f), new Vector3(0, 8.8f, -4.5f), fracJourney);
            MainCamera.transform.localRotation = Quaternion.Slerp(Quaternion.Euler(0, 0, 0), Quaternion.Euler(65, 0, 0), fracJourney);

            if (isCamMov && CameraRotator.transform.eulerAngles.y < 2 && CameraRotator.transform.eulerAngles.y > -2)
            {
                MainCamera.GetComponentInParent<CameraRotation>().speed = 0;
                CameraRotator.transform.localRotation = Quaternion.Slerp(Quaternion.Euler(0, CameraRotator.transform.localEulerAngles.y, 0), Quaternion.Euler(0, 0, 0), distCovered);
            }
        }
    }

}
