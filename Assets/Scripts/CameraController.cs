using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Transform follow;
    public Transform light;
    public float edgeTolerance;    // between 0 and 1
    public float maxOffset;        // between 0 and 1
    public float maxMoveSpeed;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        Camera.main.ResetAspect();
        Vector3 center = new Vector3(follow.position.x, follow.position.y, this.transform.position.z);

        // Need to replace all this with Tobii stuff
        Vector3 eyeViewPos = Camera.main.WorldToViewportPoint(light.position);
        Vector3 cameraMoveDir = (light.position - center).normalized;
        Vector3 speed = Vector3.zero;

        // If eye is out of bounds, move camera. speed is scaled to how far away from the tolerance it is.
        if (eyeViewPos.x < edgeTolerance)
        {
            speed.x = -((edgeTolerance - eyeViewPos.x) * maxMoveSpeed) / edgeTolerance;
        }
        else if ((1.0f - edgeTolerance) < eyeViewPos.x)
        {
            speed.x = ((eyeViewPos.x - (1.0f - edgeTolerance)) * maxMoveSpeed) / edgeTolerance;
        }
        if (eyeViewPos.y < edgeTolerance)
        {
            speed.y = -((edgeTolerance - eyeViewPos.y) * maxMoveSpeed) / edgeTolerance;
        }
        else if ((1.0f - edgeTolerance) < eyeViewPos.y)
        {
            speed.y = ((eyeViewPos.y - (1.0f - edgeTolerance)) * maxMoveSpeed) / edgeTolerance;
        }

        // clamp speed
        if (speed.magnitude > maxMoveSpeed)
            speed = speed.normalized * maxMoveSpeed;

        // add to the camera offset
        offset += speed;
        this.transform.position = center + offset;

        // reverse change if the player is too off-center
        Vector3 playerScreenPos = Camera.main.WorldToViewportPoint(follow.position);
        if (playerScreenPos.x < maxOffset || playerScreenPos.x > (1.0f - maxOffset))
        {
            offset.x -= speed.x;
        }
        if (playerScreenPos.y < maxOffset || playerScreenPos.y > (1.0f - maxOffset))
        {
            offset.y -= speed.y;
        }
        this.transform.position = center + offset;
	}
}
