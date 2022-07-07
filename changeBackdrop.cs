using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//flip between different settings
public class changeBackdrop : MonoBehaviour
{
    public GameObject backLeftTree;
    public GameObject backLeftTreeNoLeaves;
    public GameObject backRightTree;
    public GameObject backRightTreeNoLeaves;
    public GameObject backMiddleTree;
    public GameObject backMiddleTreeNoLeaves;
    public GameObject frontLeftTree;
    public GameObject frontLeftTreeNoLeaves;
    public GameObject frontRightTree;
    public GameObject frontRightTreeNoLeaves;
    public GameObject backLeftPalm;
    public GameObject backRightPalm;
    public GameObject frontLeftPalm;
    public GameObject frontRightPalm;
    public GameObject parkGrass;
    public GameObject parkSnow;
    public GameObject parkSand;
    public GameObject frontGrass;
    public GameObject frontSnow;
    public GameObject frontSand;
    public GameObject street;
    public GameObject streetSnow;
    public GameObject streetSand;
    public GameObject sidewalkSnow;
    public GameObject bushes;
    public GameObject bushesSnow;
    public GameObject coconuts;
    public GameObject snowfall;
    public GameObject snowfallTwo;
    public GameObject snowfallThree;
    public GameObject mainCamera;
    public GameObject water;
    public GameObject beachWater;
    public GameObject coastline;
    public GameObject coastlineSnow;
    public GameObject coastlineSand;
    public GameObject moonRock;
    public GameObject moonRockFront;
    public GameObject moonRocks;
    public GameObject earth;
    public GameObject stars;
    public Material nightSky;
    public Material defaultSky;
    AudioSource winterSound;
    AudioSource beachSound;
    AudioSource birdSound;
    AudioSource moonSound;
    bool normalSetting;
    bool winterSetting;
    bool beachSetting;
    bool moonSetting;

    void Start()
    {
        Debug.Log("starting change backdrop");

        birdSound = mainCamera.GetComponent<AudioSource>();
        beachSound = mainCamera.AddComponent<AudioSource>();
        winterSound = mainCamera.AddComponent<AudioSource>();
        moonSound = mainCamera.AddComponent<AudioSource>();
        winterSound.clip = Resources.Load<AudioClip>("snowy wind");
        winterSound.playOnAwake = true;
        winterSound.loop = true;
        beachSound.clip = Resources.Load<AudioClip>("beach sounds");
        beachSound.playOnAwake = true;
        beachSound.loop = true;
        moonSound.clip = Resources.Load<AudioClip>("moon sound");
        moonSound.playOnAwake = true;
        moonSound.loop = true;

    }

    public void changeSetting(int setting)
    {
       
        if (setting == 0)
        {
            RenderSettings.skybox = defaultSky;
            winterSound.enabled = false;
            beachSound.enabled = false;
            moonSound.enabled = false;
            birdSound.enabled = true;
            birdSound.Play(0);
            normalSetting = true;
            winterSetting = false;
            beachSetting = false;
            moonSetting = false;
            water.SetActive(true);
            beachWater.SetActive(false);
        }
        else if (setting == 1)
        {
            RenderSettings.skybox = defaultSky;
            birdSound.enabled = false;
            beachSound.enabled = false;
            moonSound.enabled = false;
            winterSound.enabled = true;
            winterSound.Play(0);
            normalSetting = false;
            winterSetting = true;
            beachSetting = false;
            moonSetting = false;
            water.SetActive(true);
            beachWater.SetActive(false);
        }
        else if (setting == 2)
        {
            RenderSettings.skybox = defaultSky;
            birdSound.enabled = false;
            winterSound.enabled = false;
            moonSound.enabled = false;
            beachSound.enabled = true;
            beachSound.Play(0);
            normalSetting = false;
            winterSetting = false;
            beachSetting = true;
            moonSetting = false;
            water.SetActive(false);
            beachWater.SetActive(true);
        }
        else
        {
            RenderSettings.skybox = nightSky;
            birdSound.enabled = false;
            winterSound.enabled = false;
            beachSound.enabled = false;
            moonSound.enabled = true;
            moonSound.Play(0);
            normalSetting = false;
            winterSetting = false;
            beachSetting = false;
            moonSetting = true;
            water.SetActive(false);
            beachWater.SetActive(false);
        }
            
        backLeftTree.SetActive(normalSetting);
        backLeftTreeNoLeaves.SetActive(winterSetting);
        backRightTree.SetActive(normalSetting);
        backRightTreeNoLeaves.SetActive(winterSetting);
        backMiddleTree.SetActive(normalSetting);
        backMiddleTreeNoLeaves.SetActive(winterSetting);
        frontLeftTree.SetActive(normalSetting);
        frontLeftTreeNoLeaves.SetActive(winterSetting);
        frontRightTree.SetActive(normalSetting);
        frontRightTreeNoLeaves.SetActive(winterSetting);
        parkGrass.SetActive(normalSetting);
        parkSnow.SetActive(winterSetting);
        frontGrass.SetActive(normalSetting);
        frontSnow.SetActive(winterSetting);
        street.SetActive(normalSetting);
        streetSnow.SetActive(winterSetting);
        sidewalkSnow.SetActive(winterSetting);
        bushes.SetActive(normalSetting);
        bushesSnow.SetActive(winterSetting);
        snowfall.SetActive(winterSetting);
        snowfallTwo.SetActive(winterSetting);
        snowfallThree.SetActive(winterSetting);
        backLeftPalm.SetActive(beachSetting);
        backRightPalm.SetActive(beachSetting);
        frontLeftPalm.SetActive(beachSetting);
        frontRightPalm.SetActive(beachSetting);
        coconuts.SetActive(beachSetting);
        streetSand.SetActive(beachSetting);
        frontSand.SetActive(beachSetting);
        parkSand.SetActive(beachSetting);
        coastline.SetActive(normalSetting);
        coastlineSnow.SetActive(winterSetting);
        coastlineSand.SetActive(beachSetting);
        moonRock.SetActive(moonSetting);
        moonRocks.SetActive(moonSetting);
        moonRockFront.SetActive(moonSetting);
        earth.SetActive(moonSetting);
        stars.SetActive(moonSetting);
    }
}