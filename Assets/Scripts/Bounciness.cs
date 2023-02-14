using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounciness : MonoBehaviour
{


    public Vector3 vecIncidence;
    public Vector3 vecReflect;
    bool OnBounce=false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawLine(this.transform.position,vecReflect);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            Rigidbody rig = GetComponent<Rigidbody>();
            if (OnBounce)
            {
                rig.velocity=Vector3.zero;
                Destroy(this.gameObject,3f);
            }
            else
            {
                vecReflect = Vector3.Reflect(vecIncidence, Vector3.up);
                rig.velocity = vecReflect;
                OnBounce = true;
            }
            
        }


    }


    #region �ݻ簢




    #endregion


}
