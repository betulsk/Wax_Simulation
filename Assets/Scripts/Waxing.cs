using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waxing : MonoBehaviour
{
    Coroutine WaxCor; //z 3.258---> 3.146

    IEnumerator waxEnumarator;
    

    private IEnumerator WaxCoordination()
    {

        yield return new WaitForSeconds(0.23f);        
        float z = (transform.position.z * 0.01f);         
        transform.position= transform.position - new Vector3(0, 0, z );

    }
}
