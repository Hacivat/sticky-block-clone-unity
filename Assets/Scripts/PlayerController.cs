using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 0;
    [SerializeField] float horizontalSpeed = 0;
    [SerializeField] GameObject collector = null;

    private enum State {NOT_MOVING, MOVING};
    private State state;
    
    private void Start()
    {
        state = State.NOT_MOVING;
    }

    private void Update()
    {
        if (state == State.MOVING) 
            transform.Translate(transform.forward * speed * Time.deltaTime);

        if (Input.GetMouseButton(0))
            transform.position += new Vector3(Input.GetAxis("Mouse X") * horizontalSpeed * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.transform.tag == "Platform") 
            state = State.MOVING;

        if (other.transform.tag == "CollectibleObject") {
            other.transform.parent = collector.transform; 
        }
    }
}
