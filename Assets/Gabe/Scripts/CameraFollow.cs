using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    private Vector3 velocity;
    float x;
    float y;

    public GameObject player;

    public bool bounds;
    public Vector3 minCam_pos;
    public Vector3 maxCam_pos;
    float height_offset;
    float width_offset;
    float xPos;
    float yPos;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        height_offset = GetComponent<Camera>().orthographicSize;
        width_offset = height_offset * GetComponent<Camera>().aspect;
    }


    void FixedUpdate()
    {

      if (Mathf.Abs(player.transform.position.x - transform.position.x) > 2)
      {
        xPos = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, Time.deltaTime*20);
      }
      if (Mathf.Abs(player.transform.position.y - transform.position.y) > 2)
      {
        yPos = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, Time.deltaTime*20);
      }


        transform.position = new Vector3(xPos, yPos, transform.position.z);

        if (bounds)
        {
           transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCam_pos.x, maxCam_pos.x),
                                           Mathf.Clamp(transform.position.y, minCam_pos.y, maxCam_pos.y),
                                           Mathf.Clamp(transform.position.z, minCam_pos.z, maxCam_pos.z));
        }
    }
}
