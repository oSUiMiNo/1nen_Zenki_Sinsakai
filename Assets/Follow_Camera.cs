using UnityEngine;

[ExecuteInEditMode, DisallowMultipleComponent]
public class Follow_Camera : MonoBehaviour
{
    public GameObject target; // an object to follow
    public Vector3 offset; // offset form the target object

    float distance = 20f; // distance from following object
    float polarAngle = 45.0f; // angle with y-axis
    float azimuthalAngle = 45.0f; // angle with x-axis

    float minDistance = 15.0f;
    float maxDistance = 25.0f;
    
    float minPolarAngle = 5.0f;
    float maxPolarAngle = 90.0f;
    
    float mouseXSensitivity = 5.0f;
    float mouseYSensitivity = 5.0f;
    
    float scrollSensitivity = 5.0f;

    float x;
    float y;



    public void LateUpdate()
    {
        UpdateAngle(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        UpdateDistance(Input.GetAxis("Mouse ScrollWheel"));

        var lookAtPos = target.transform.position + offset;
        UpdatePosition(lookAtPos);
        transform.LookAt(lookAtPos);
    }

    public void UpdateAngle(float x, float y)
    {
        this.x = x = azimuthalAngle - x * mouseXSensitivity;
        azimuthalAngle = Mathf.Repeat(x, 360);

        this.y = y = polarAngle + y * mouseYSensitivity;
        polarAngle = Mathf.Clamp(y, minPolarAngle, maxPolarAngle);
    }

    void UpdateDistance(float scroll)
    {
        scroll = distance - scroll * scrollSensitivity;
        distance = Mathf.Clamp(scroll, minDistance, maxDistance);
    }

    void UpdatePosition(Vector3 lookAtPos)
    {
        var da = azimuthalAngle * Mathf.Deg2Rad;
        var dp = polarAngle * Mathf.Deg2Rad;
        transform.position = new Vector3(
            lookAtPos.x + distance * Mathf.Sin(dp) * Mathf.Cos(da),
            lookAtPos.y + distance * Mathf.Cos(dp),
            lookAtPos.z + distance * Mathf.Sin(dp) * Mathf.Sin(da));
    }

    public float X
    {
        set
        {
            this.x = value;
        }
        get
        {
            return this.x;
        }
    }
    public float Y
    {
        set
        {
            this.y = value;
        }
        get
        {
            return this.y;
        }
    }
}