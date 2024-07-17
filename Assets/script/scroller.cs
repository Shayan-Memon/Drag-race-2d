
using UnityEngine;


public class Scroller : MonoBehaviour
{
    public float speed;
    [SerializeField]
    private Renderer bgrenderer;
    public Transform target;

    private Vector2 offset = Vector2.zero;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.position;
        offset.x = targetPosition.x * speed;
        

        bgrenderer.material.mainTextureOffset = offset;
    }
}
