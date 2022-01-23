using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaxStickControl : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 movementPos;
    public bool isMove;
    public Rigidbody rig;
    [SerializeField] private GameObject wax;
    Coroutine WaxCor; //z 3.258 ve 3.337 ---> 3.146
    IEnumerator waxEnumarator;

    public Animation anim;

    private void Start()
    {
        anim = wax.GetComponent<Animation>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Position();

        }
        if (isMove)
        {
            Stick();
        }
    }

    void Position()
    {
        Plane plane = new Plane(Vector3.back, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance;
        if (plane.Raycast(ray, out distance))
        {
            movementPos = ray.GetPoint(distance);
        }
        isMove = true;
    }
    void Stick()
    {
        transform.position = Vector3.MoveTowards(transform.position, movementPos, moveSpeed * Time.deltaTime);
        if (transform.position == movementPos)
        {
            isMove = false;
        }
    }




    private IEnumerator WaxCoordination()
    {
        if (wax.transform.position.z >= 3.124f)
        {
            Debug.Log("Start");
            yield return new WaitForSeconds(0.005f);
            Debug.Log("End");

            Debug.Log("First pos Z= " + wax.transform.position.z);
            float z = (wax.transform.position.z * 0.001f);
            Debug.Log("Z= " + z);
            wax.transform.position = wax.transform.position - new Vector3(0, 0, z);
            Debug.Log("Transform z: " + wax.transform.position.z);
        }
        yield return new WaitForSecondsRealtime(0.01f);

        if (wax.transform.position.z<= 3.12f)
        {
            // wax.GetComponent<Animator>().enabled=false;
            anim.Play("WaxBlend");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "WaxArea")
        {
            Debug.Log("Trigger");
            if (Input.GetMouseButton(0))
            {
                StartCoroutine(WaxCoordination());
            }

        }

    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "WaxArea")
    //    {
    //        Debug.Log("Trigger");
    //        if (Input.GetMouseButton(0))
    //        {
    //            StartCoroutine(WaxCoordination());
    //        }

    //    }

    //}
}
