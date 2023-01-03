using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeSound : MonoBehaviour
{
    public AudioSource Engine;
    private MyBikeControll car_controller;

    //public AudioSource GearChangeSound;

    [SerializeField] private AudioSource brakeSound;

    public float PitchOffSet1;
    public float PitchOffSet2;
    public float PitchOffSet3;
    public float PitchOffSet4;
    public float PitchOffSet5;
    public float PitchOffSet6;

    void Start()
    {
        car_controller = GetComponent<MyBikeControll>();
    }

    void Update()
    {
        PitchControl();
        GearChange();
        EngineVolume();
        //BrakeVolume();
    }

    // private void BrakeVolume()
    // {


    //     if (car_controller.CurrentSpeed > 39 && (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.S)))
    //     {
    //         brakeSound.volume = +100 * Time.deltaTime;
    //     }
    //     else if (brakeSound.volume > 0)
    //     {
    //         brakeSound.volume -= 100 * Time.deltaTime;
    //     }
    // }

    public void EngineVolume()
    {

        if (Input.GetAxis("Vertical") == 1)
        {
            Engine.volume += Time.deltaTime;
        }
        else
        {
            if (Engine.volume > 0.1f)
            {
                Engine.volume -= Time.deltaTime;
            }
        }

    }

    // public void GearChangeSounds()
    // {
    //     if (GearChangeSound.isPlaying == false)
    //     {
    //         GearChangeSound.Play();
    //     }
    // }
    public void GearChange()
    {
        // if (car_controller.gear==1)
        // {
        //     if(GearChangeSound.isPlaying == false)
        //     {
        //         GearChangeSound.Play();
        //     }
        // }

        // if (car_controller.gear==2)
        // {
        //     if (GearChangeSound.isPlaying == false)
        //     {
        //         GearChangeSound.Play();
        //     }
        // }

        // if (car_controller.gear==3)
        // {
        //     if (GearChangeSound.isPlaying == false)
        //     {
        //         GearChangeSound.Play();
        //     }
        // }

        // if (car_controller.gear==4)
        // {
        //     if (GearChangeSound.isPlaying == false)
        //     {
        //         GearChangeSound.Play();
        //     }
        // }

        // if (car_controller.gear==5)
        // {
        //     if (GearChangeSound.isPlaying == false)
        //     {
        //         GearChangeSound.Play();
        //     }
        // }

        // if (car_controller.gear==6)
        // {
        //     if (GearChangeSound.isPlaying == false)
        //     {
        //         GearChangeSound.Play();
        //     }
        // }
    }

    public void PitchControl()
    {
        if (car_controller.CurrentSpeed > 0 & car_controller.CurrentSpeed < 30)
        {
            Engine.pitch = car_controller.CurrentSpeed * PitchOffSet1;
        }

        if (car_controller.CurrentSpeed > 30 & car_controller.CurrentSpeed < 60)
        {
            Engine.pitch = car_controller.CurrentSpeed * PitchOffSet2;
        }

        if (car_controller.CurrentSpeed > 60 & car_controller.CurrentSpeed < 90)
        {
            Engine.pitch = car_controller.CurrentSpeed * PitchOffSet3;
        }

        if (car_controller.CurrentSpeed > 90 & car_controller.CurrentSpeed < 120)
        {
            Engine.pitch = car_controller.CurrentSpeed * PitchOffSet4;
        }

        if (car_controller.CurrentSpeed > 120 & car_controller.CurrentSpeed < 150)
        {
            Engine.pitch = car_controller.CurrentSpeed * PitchOffSet5;
        }

        if (car_controller.CurrentSpeed > 150)
        {
            Engine.pitch = car_controller.CurrentSpeed * PitchOffSet6;
        }
    }
}
