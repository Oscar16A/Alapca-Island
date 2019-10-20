using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour
{
    public Camera pixelPerfectCamera;
    public float transitionSpeed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        print("player");
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, -1);
        pixelPerfectCamera.transform.position = Vector3.MoveTowards(pixelPerfectCamera.transform.position, newPosition, transitionSpeed);
    }
}
