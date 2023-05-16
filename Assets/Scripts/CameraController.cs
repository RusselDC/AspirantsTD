using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool move = true;
    public float panspeed = 30f;
    public float panBorderthickness = 10f;
    public float scrollspeed = 5f;
    public float minY = 10f,maxY = 80f;
    public float minZ = 0f, maxZ = 50f;

    
    // Update is called once per frame
    void Update()
    {       
            if(GameManager.isgameDone)
            {
                this.enabled = false;
                return;
            }
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                move = !move;
            }
            if(!move)
            {
                return;
            }
            if(Input.GetKey(KeyCode.W)|| Input.mousePosition.y>= Screen.height - panBorderthickness )
            {
                transform.Translate(Vector3.forward * panspeed * Time.fixedDeltaTime, Space.World);
            }
            if(Input.GetKey(KeyCode.S)|| Input.mousePosition.y<= panBorderthickness )
            {
                transform.Translate(Vector3.back * panspeed * Time.fixedDeltaTime, Space.World);
            }
            if(Input.GetKey(KeyCode.D)|| Input.mousePosition.x>= Screen.width - panBorderthickness )
            {
                transform.Translate(Vector3.right * panspeed * Time.fixedDeltaTime, Space.World);
            }
            if(Input.GetKey(KeyCode.A)|| Input.mousePosition.y<= panBorderthickness )
            {
                transform.Translate(Vector3.left * panspeed * Time.fixedDeltaTime, Space.World);
            }
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            Vector3 pos = transform.position;
            pos.y -= scroll * 1000 * scrollspeed * Time.fixedDeltaTime;
            pos.y = Mathf.Clamp(pos.y,minY,maxY);
            pos.z = Mathf.Clamp(pos.z,minZ,maxZ);

            transform.position = pos;
    }
    
}
