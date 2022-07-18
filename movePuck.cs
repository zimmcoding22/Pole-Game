using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class movePuck : MonoBehaviour {

    public GameObject puck;
    public GameObject stick;
    public GameObject pole;
    public GameObject streak;
    public GameObject poleTopHitText;
    public GameObject fireworkText;
    public GameObject supernovaText;
    public GameObject bigStreak;
    public GameObject WindArea;
    public GameObject falcon;
    public GameObject poleTop;
    public GameObject nextPuck;
    public GameObject poleParticles;
    public GameObject firework;
    public GameObject supernova;
    public GameObject rightStick;
    public GameObject moonRock;
    public GameObject noGravityText;
    public int currentStreak;
    public Material[] materials;
    public AudioSource falconNoise;
    
    private Vector3 puckStartingPosition;
    private Quaternion puckStartingRotation;
    private Quaternion camStartingRotation;
    private float velocity, tilt;
    private bool createPuck;
    private bool uiOn;
    private bool particlesOn;
    private int windStrength;
    private int windDirection; 
    
    DateTime start, end;
    DateTime uiStart, uiEnd, particlesEnd;
    
    windArea wind;
    moveFalcon move_falcon;
    AudioSource audioData;
    Animator animController;
    Rigidbody rb;
    Renderer rend;
    Camera cam;
    swipeUp swipe_up;
    poleCollision pole_collision;
    poleTopCollision pole_top_collision;


    void Start()
    {
        if (rightStick.activeSelf)
        {
            //Debug.Log("right here");
            stick = GameObject.Find("Stick");
        }
        else
        {
            stick = GameObject.Find("Left Stick");
            Debug.Log("left here");
        }
        pole = GameObject.Find("Pole");
        streak = GameObject.Find("Streak");
        poleTopHitText = GameObject.Find("Pole Top Hit Text");
        fireworkText = GameObject.Find("Firework Reward");
        supernovaText = GameObject.Find("Supernova Reward");
        bigStreak = GameObject.Find("Big Streak");
        WindArea = GameObject.Find("WindArea");
        falcon = GameObject.Find("Falcon");
        poleTop = GameObject.Find("Pole Top");
        try
        {
            wind = WindArea.GetComponent<windArea>();
        } catch (NullReferenceException)
        {
            Debug.Log("");
        }
        swipe_up = stick.GetComponent<swipeUp>();
        pole_collision = pole.GetComponent<poleCollision>();
        pole_top_collision = poleTop.GetComponent<poleTopCollision>();
        puck = GameObject.FindGameObjectWithTag("Puck");
        //Debug.Log("puck original position: " + transform.position);
        cam = GameObject.Find("Camera").GetComponent<Camera>();
        //Debug.Log("starting camera rotation: " + cam.transform.rotation);
        //Debug.Log("starting camera position: " + cam.transform.position);
        audioData = stick.GetComponent<AudioSource>();
        puckStartingPosition = puck.transform.position;
        puckStartingRotation = puck.transform.rotation;
        camStartingRotation = cam.transform.rotation;
        animController = stick.GetComponent<Animator>();
        nextPuck = puck;
        move_falcon = falcon.GetComponent<moveFalcon>();
        //generate random puck color for each instance
        createPuck = false;
        uiOn = false;
        
    }
  
    void FixedUpdate()
    {
        rb = nextPuck.GetComponent<Rigidbody>();
        if (uiOn)
        {
            uiEnd = DateTime.UtcNow;
            TimeSpan uiTimeDiff = uiEnd - uiStart;
            int ui_time_in_milliseconds = Convert.ToInt32(uiTimeDiff.TotalMilliseconds);
            int uiWaitTime = 950;
            if (firework.activeSelf || poleTopHitText.GetComponent<Text>().enabled)
            {
                //Debug.Log("firework wait time");
                uiWaitTime = 1500;
            }
            if (ui_time_in_milliseconds > uiWaitTime)
            {
                uiOn = false;
                //Debug.Log("turning off text");
                streak.GetComponent<Text>().enabled = false;
                noGravityText.GetComponent<Text>().enabled = false;
                poleTopHitText.GetComponent<Text>().enabled = false;
                fireworkText.GetComponent<Text>().enabled = false;
                supernovaText.GetComponent<Text>().enabled = false;
                if (firework.activeSelf)
                {
                    firework.SetActive(false);
                }
                if (supernova.activeSelf)
                {
                    supernova.SetActive(false);
                }
            }
        }
        if (particlesOn)
        {
            particlesEnd = DateTime.UtcNow;
            TimeSpan particlesTimeDiff = particlesEnd - uiStart;
            int particles_time_in_milliseconds = Convert.ToInt32(particlesTimeDiff.TotalMilliseconds);
            int particlesDelay = 400;
            if (particles_time_in_milliseconds > particlesDelay)
            {
                poleParticles.SetActive(false);
                poleTop.GetComponent<Renderer>().material = Resources.Load<Material>("pole top");
                particlesOn = false;
            }
        }
        if (createPuck) //if a shot was taken and a new puck needs to be spawned
        {
            end = DateTime.UtcNow;
            TimeSpan timeDiff = end - start;
            int time_in_milliseconds = Convert.ToInt32(timeDiff.TotalMilliseconds);
            int waitTime = 1550;
            if (moonRock.activeSelf)
            {
                waitTime = 1300;
            }
            //reinstantiate puck if it stops moving or if certain number of millisecs elapse
            if (rb.velocity.z == 0 || time_in_milliseconds > waitTime)
            {
                //streak hasn't been incremented, so it starts over and text color changes back
                if (currentStreak == PlayerPrefs.GetInt("streak"))
                {
                    streak.GetComponent<Text>().color = Color.white;
                    bigStreak.GetComponent<Text>().enabled = false;
                    PlayerPrefs.SetInt("streak", 1);
                }
                uiOn = true;
                if (poleParticles.activeSelf)
                {
                    particlesOn = true;
                }
                uiStart = DateTime.UtcNow;
                createPuck = false;
                System.Random rnd = new System.Random();
                int c = rnd.Next(0, 6);
                if (c == 0 && !move_falcon.bird_flying && !moonRock.activeSelf) //1 in 5 chance for bird. No bird on the moon. Birds need oxygen.
                {
                    move_falcon.bird_flying = true;
                    falconNoise.Play(0);
                }
                puck = nextPuck;
                if (moonRock.activeSelf)
                {
                    puck.GetComponent<Rigidbody>().useGravity = false;
                } 
                nextPuck = Instantiate(nextPuck, puckStartingPosition, puckStartingRotation);
                rend = nextPuck.GetComponent<Renderer>();
                rend.sharedMaterial = materials[c];
                rend.enabled = true;
                pole_collision.collisionsOn = true; //ensures that collision checks stop after one collision until next instance is created
                pole_top_collision.collisionsOnTop = true;
                move_falcon.collisionsOn = true;
                cam.transform.rotation = Quaternion.identity; //reset puck rotation
                int pole_shine = rnd.Next(0, 3);
                if (pole_shine == 0 && !poleParticles.activeSelf)
                {
                    //illuminating pole
                    poleParticles.SetActive(true);
                    if (moonRock.activeSelf)
                    {
                        poleTop.GetComponent<Renderer>().material = Resources.Load<Material>("green puck");
                    } else
                    {
                        poleTop.GetComponent<Renderer>().material = Resources.Load<Material>("red puck");
                    }
                }
                int use_wind = rnd.Next(0, 5);
                if (use_wind < 4 || PlayerPrefs.GetInt("streak") > 4 || moonRock.activeSelf) //5 is big streak
                {
                    windStrength = 0;
                    windDirection = 0;
                    //Debug.Log("no wind");
                    wind.SetWindStrengthAndDirection(0, 1);
                } else
                {
                    windStrength = rnd.Next(1, 11);
                    //Debug.Log("wind: " + windStrength);
                    windDirection = rnd.Next(0, 2);
                    //if (windDirection == 0) {
                        //Debug.Log("wind direction left");
                    //} else
                    //{
                    //    Debug.Log("wind direction right");
                    //}
                    wind.SetWindStrengthAndDirection(windStrength, windDirection);
                }
            }  
        }
    }

    public void Move()
    {
        //camera tilt determined by big or small swipe. fast big swipe = high and far
        tilt = swipe_up.mouseRelease - swipe_up.mousePress;
        //Debug.Log("tilt in move: " + tilt);
        //Debug.Log("Camera tilt value: " + CameraTilt(tilt));
        //inputPositionUp.x = x direction of raycast
        if (swipe_up.inputPositionUp.x != 0 && tilt != 0 && !createPuck)
        {
            
            //Debug.Log("camera tilt: " + CameraTilt(tilt));
            if (!animController.enabled)
            {
                //Debug.Log("enabling animator");
                animController.enabled = true;
            }
            animController.SetBool("playShot", true);
            audioData.Play(0);
            //x axis
            float x_axis_rotation = CameraRotationX(swipe_up.inputPositionUp.x);
            //float x_axis_rotation = -2.0f;
            float camera_tilt = CameraTilt(tilt);
            //float camera_tilt = -38.5f;
            velocity = Velocity(swipe_up.time_elapsed);
            //velocity = 23.98f;
            float angular_velocity = AngularVelocity(windStrength, windDirection);
            Debug.Log("velocity in Move: " + velocity);
            Debug.Log("tilt in Move: " + camera_tilt);
            Debug.Log("x axis rotation in Move: " + x_axis_rotation);
            int which_device = adjustPlatform.isTablet();
            if (which_device != -1)
            {
                if (which_device != 1334)
                {
                    velocity += 3;
                }
                else
                {
                    Debug.Log("adjusting for 4.7 inch");
                    camera_tilt -= 15;
                }
            }
            if (which_device == 2048)
            {
                Debug.Log("platform resolution: " + which_device);
                x_axis_rotation = CameraRotationX(swipe_up.inputPositionUp.x) - 6;
            }
            if (which_device == 2224)
            {
                x_axis_rotation = CameraRotationX(swipe_up.inputPositionUp.x) - 8;
            }
            if (which_device == 2732)
            {
                x_axis_rotation = CameraRotationX(swipe_up.inputPositionUp.x) - 12;
            }
            if (which_device == 2208)
            {
                x_axis_rotation = CameraRotationX(swipe_up.inputPositionUp.x) - 2;
            }
            if (which_device == 1334)
            {
                x_axis_rotation = CameraRotationX(swipe_up.inputPositionUp.x) + 4;
            }
            cam.transform.Rotate(0.0f, x_axis_rotation, 0.0f, Space.Self);
            //tilt
            cam.transform.Rotate(camera_tilt, 0.0f, 0.0f, Space.Self);
            currentStreak = PlayerPrefs.GetInt("streak");
            nextPuck.transform.position = nextPuck.transform.position + nextPuck.transform.forward * 2;
            rb.velocity = cam.transform.forward * velocity;
            //to make puck rotate about its axis
            rb.angularVelocity = cam.transform.forward * angular_velocity;
            createPuck = true;
            start = DateTime.UtcNow;
            tilt = 0;
        } 
    }
    //below deals with shot physics
    //returns y value to use in transform.Rotate
    float CameraRotationX(float x)
    {
        float conversion = 37; //screen x max is 1130. 1130/30 = 37 //rotation number range is between -15 and 15 (30 intervals). 
        float x_rotation = x / conversion;
        x_rotation -= 15;
        return (x_rotation);
    }

    //between 0 and -50 (camera rotation)
    //between 0 and 2000 (returned value)
    float CameraTilt(float swipe_distance)
    {
        float conversion = 40;
        float tilt = swipe_distance / conversion;
        tilt *= -1;
        return (tilt);
    }

    //output between 15 and 30
    float Velocity(float t)
    {
        int max = 30;
        float conversion = .067f; //slowest swipe is designated at 1 sec. 1/15 (15 intervals) = .067 **# of intervals is arbitrary**
        if (t > 1)
        {
            t = 1;
        }
        float velocity = t / conversion;
        velocity = max - velocity;
        return (velocity);
    }

    //between 0 and 10 input
    //output between .1-.5
    float AngularVelocity(float w, float d)
    {
        float conversion = .05f; //.5/10 *max value input/desired number of intervals*
        float angular_velocity = w * conversion;
        if (d == 1)
        {
            angular_velocity *= -1;
        }
        return (angular_velocity);
    }
}
