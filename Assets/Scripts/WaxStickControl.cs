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
    [SerializeField] private GameObject hair;
    Coroutine WaxCor; //z 3.258 ve 3.337 ---> 3.146
    IEnumerator waxEnumarator;


    private void Start()
    {
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
            float z = (wax.transform.position.z * 0.001f);            
            wax.transform.position = wax.transform.position - new Vector3(0, 0, z);            
            if (wax.transform.position.z <= 3.13f)
            {
                try
                {
                    AnimatorController._instance.IsPlay();
                    GameObject[] hairs = GameObject.FindGameObjectsWithTag("Hair");
                    foreach (GameObject hair in hairs)
                        Destroy(hair);

                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine("error"+ ex.Message);
                    throw;
                }
                
            }
        }
        yield return new WaitForSecondsRealtime(0.01f);

        
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


    
}
