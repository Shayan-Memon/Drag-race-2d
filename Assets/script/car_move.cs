

using UnityEngine;

public class CarMove : MonoBehaviour
{
    public WheelJoint2D frontWheel;
    public WheelJoint2D backWheel;
    public float motorSpeed = 1000f;
    public float maxMotorTorque = 100000f;
    public float decelerationRate = 120f; // Rate at which the car decelerates
    private Road road;
    public int gear;
    public needle need;
    int[] myNum = { 300, 500, 900, 2000, 5000, 9000 };
    public AudioSource audios;
    public AudioClip gear1, gear2, gear3, gear4, gear5, gear6;
    public float startTime; // Start time in seconds (100 milliseconds)
    public float endTime;   // End time in seconds (1000 milliseconds)
    private bool isPlayingClip = false;
    private int gearchange = 0;
    public countdownscript pause;




    private JointMotor2D motor;

    // Start is called before the first frame update
    private void Awake()
    {



        need = GameObject.FindGameObjectWithTag("needle").GetComponent<needle>();
        pause = GameObject.FindGameObjectWithTag("pause").GetComponent<countdownscript>();
        // Get references to the WheelJoint2D components
        if (frontWheel == null || backWheel == null)
        {
            Debug.LogError("Please assign the front and back wheels in the inspector.");
        }

        motor = new JointMotor2D { motorSpeed = 0f, maxMotorTorque = maxMotorTorque };
        road = FindObjectOfType<Road>();
    }

    // Update is called once per frame
    void Update()
    {

        Physics2D.IgnoreLayerCollision(6, 7);

        motorSpeed = myNum[need.gear - 1];
        if (need.gear == 1)
        {
            PlayClipSegment(gear1);
        }

        if (need.gear == 2)
        {
            PlayClipSegment(gear2);

        }

        if (need.gear == 3)
        {
            PlayClipSegment(gear3);

        }

        if (need.gear == 4)
        {
            PlayClipSegment(gear4);

        }

        if (need.gear == 5)
        {
            PlayClipSegment(gear5);

        }

        if (need.gear == 6)
        {
            PlayClipSegment(gear6);

        }




        if (!pause.ispaused)
        {
            // Check for left and right arrow key inputs
            if (Input.GetKey(KeyCode.LeftArrow) || need.isleft)
            {
                motor.motorSpeed = motorSpeed;
            }
            else if (Input.GetKey(KeyCode.RightArrow) || need.isright)
            {
                motor.motorSpeed = -motorSpeed;
            }
            else
            {
                // Gradually reduce motor speed linearly
                if (motor.motorSpeed > 0)
                {
                    motor.motorSpeed -= decelerationRate * Time.deltaTime;
                    if (motor.motorSpeed < 0)
                    {
                        motor.motorSpeed = 0f;
                    }
                }
                else if (motor.motorSpeed < 0)
                {
                    motor.motorSpeed += decelerationRate * Time.deltaTime;
                    if (motor.motorSpeed > 0)
                    {
                        motor.motorSpeed = 0f;
                    }
                }
            }
        }
            motor.motorSpeed += road.speed * 100;
            // Apply the motor settings to the wheels
            frontWheel.motor = motor;
            backWheel.motor = motor;
        
    }

    private void PlayClipSegment(AudioClip clip)
    {   if (motor.motorSpeed != 0)
        {
            if (gearchange != need.gear)
            {
                endTime = clip.length;
                startTime = 0;
                gearchange = need.gear;
            }
            else
            {
                endTime = clip.length - 0.4f;
                startTime = Mathf.Max(0, endTime - 0.7f);
            }
        }
        if (motor.motorSpeed == 0)
        {
            if (isPlayingClip)
            {
                audios.Stop();
                isPlayingClip = false;
            }
        }
        else if (!isPlayingClip || audios.clip != clip)
        {
            audios.clip = clip;
            audios.time = startTime;
            audios.loop = false;
            audios.Play();
            isPlayingClip = true;
        }
        else if (audios.time >= endTime)
        {
            audios.Stop();
            audios.time = startTime;
            audios.Play();
        }
    }

    
}



