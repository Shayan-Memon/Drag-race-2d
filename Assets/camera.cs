using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 10f;
    public Transform target;
    public victory victor;
    public float cameramove = 0f;
    public float maxCameraMove = 50f; // Set this to the desired limit
    public float cameraMoveSpeed = 2f; // Speed at which the camera lets go

    private void Start()
    {
        victor = GameObject.FindGameObjectWithTag("victory").GetComponent<victory>();
    }

    // LateUpdate is called after all Update functions have been called
    void LateUpdate()
    {
        if (target != null && victor.win_or_lose)
        {
            Vector3 newPos = new Vector3(target.position.x, target.position.y, -10);
            transform.position = Vector3.Lerp(transform.position, newPos, followSpeed * Time.deltaTime);
        }
        else if (!victor.win_or_lose)
        {
            if (cameramove < maxCameraMove)
            {
                cameramove += cameraMoveSpeed * Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene("mainmenu");
            }
            Vector3 newPos = new Vector3(target.position.x - cameramove, target.position.y, -10);
            transform.position = Vector3.Lerp(transform.position, newPos, followSpeed * Time.deltaTime);
        }
    }
}
