using UnityEngine;

public class pagani_move : MonoBehaviour
{
    public WheelJoint2D frontWheel;
    public WheelJoint2D backWheel;
    public float motorSpeed = -1000f;
    private JointMotor2D motor;
    public float maxMotorTorque = 100000f;

    private float timeElapsed = 0f;
    private float reductionInterval = 4f;
    public int gear = 1;
    int[] mygears = { 400, 800, 1500, 4000, 7000, 11000 };
    public AudioSource audios;
    public AudioClip gear1;
    public float startTime; // Start time in seconds (100 milliseconds)
    public float endTime;   // End time in seconds (1000 milliseconds)
    private bool isPlayingClip = false;
    private int gearchange = 0;
    private int needgear = 1;
    private countdownscript pause;

    public CarMove lamb;
    void Start()
    {
        motor = new JointMotor2D { motorSpeed = 0f, maxMotorTorque = maxMotorTorque };
        lamb = GameObject.FindGameObjectWithTag("Player").GetComponent<CarMove>();
        pause = GameObject.FindGameObjectWithTag("pause").GetComponent<countdownscript>();
    }

    void Update()
    {

        if (!pause.ispaused) { 
        float distance = (lamb.transform.position.x - transform.position.x);
        float maxDistance = -50.0f; // Set this to the maximum allowed distance

      


        // Check if the distance exceeds the maximum allowed distance
        if (distance <= maxDistance)
        {

            // Reset the car's position
            float respawnDistance = 5.0f; // Adjust this to the desired respawn distance from lamb
            Vector3 respawnPosition = new Vector3(lamb.transform.position.x-maxDistance + respawnDistance, transform.position.y, transform.position.z);
            transform.position = respawnPosition;
        }
        else if (distance >= -maxDistance)
        {

            // Reset the car's position
            float respawnDistance = 5.0f; // Adjust this to the desired respawn distance from lamb
            Vector3 respawnPosition = new Vector3(lamb.transform.position.x+maxDistance + respawnDistance, transform.position.y, transform.position.z);
            transform.position = respawnPosition;
        }


        PlayClipSegment(gear1);
        motor.motorSpeed = motorSpeed;
        frontWheel.motor = motor;
        backWheel.motor = motor;

        timeElapsed += Time.deltaTime;
            if (timeElapsed >= reductionInterval && gear < 6)
            {
                motorSpeed = -mygears[gear];
                timeElapsed = 0f;
                gear += 1;
            }
        }
    }

    private void PlayClipSegment(AudioClip clip)
    {
        float distance = Mathf.Abs(lamb.transform.position.x - transform.position.x);
        float maxDistance = 10.0f; // Adjust this value based on the maximum distance you expect
        float volume = Mathf.Clamp(1.0f - (distance / maxDistance), 0.0f, 1.0f); // Adjust this formula based on how you want the volume to change with distance

        
        if (motor.motorSpeed != 0)
        {
            if (gearchange != needgear)
            {
                endTime = clip.length;
                startTime = 0;
                gearchange = needgear;
            }
            else
            {
                endTime = clip.length - 0.5f;
                startTime = Mathf.Max(0, endTime - 0.6f);
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
            audios.volume = volume; // Set the volume here
            audios.Play();
            isPlayingClip = true;
        }
        else if (audios.time >= endTime)
        {
            audios.Stop();
            audios.time = startTime;
            audios.Play();
        }
        else
        {
            audios.volume = volume; // Update the volume continuously
        }
    }

}
