using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public GameObject player;
    
    private Vector3 offset = new Vector3(0f, 2f, -5f);

    void LateUpdate()
    {
        
        transform.position = player.transform.position + offset;
    }
}
