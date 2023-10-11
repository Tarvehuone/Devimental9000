using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    private Transform player;
    public Vector3 offset;
    [Range(1, 10)]
    public float smoothFactor;
    public Vector3 minValue, maxValue;

    void Start()
    {
        FindPlayer();
    }

    private void FixedUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
            Follow();
    }

    void Follow()
    {
        //Define minimum x,y,z values and maximum x,y,z values

        Vector3 targetPosition = player.position + offset;

        //Verify if the targetPosition is out of bound or not
        //Limit it to the min and max values

        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(targetPosition.x, minValue.x, maxValue.x),
            Mathf.Clamp(targetPosition.y, minValue.y, maxValue.y),
            Mathf.Clamp(targetPosition.z, minValue.z, maxValue.z));

        Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }

    public void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
