using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounciness3 : MonoBehaviour
{
    public Vector3 vecEndPos;
    bool OnBounce=false;


    public List<List<Vector3>> listResultVectors = new List<List<Vector3>>();

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
                rig.velocity = Vector3.zero;
            }
            else
            {
                LaucherProjecttile();
                OnBounce = true;
            }

        }


    }



    #region 역탄도

    void LaucherProjecttile()
    {
        //Vector3 Vo = CalculateVelcoity(target.position, transform.position, 1f);
        Vector3 Vo = CalculateVelcoityVector(vecEndPos, this.transform.position, fTime);
        Rigidbody rigidbody = this.GetComponent<Rigidbody>();
        rigidbody.velocity = Vo;
        //rigidbody.AddForce(Vo);
        //setTrajectoryPoints(transform.position, Vo);
        DrawPath(Vo);
    }

    //출처: https://foo897.tistory.com/24
    //이 방법은 목표 벡터와 원점의 시작점이 필요합니다.
    //time : 비행시간
    Vector3 CalculateVelcoity(Vector3 target, Vector3 origin, float time)
    {
        //define the distance x and y first
        Vector3 distance = target - origin;
        Vector3 distanceXZ = distance; //x와z의 평면이면 기본적으로 거리와 같은 벡터
        distanceXZ.y = 0f;//y는 0으로 설정

        //create a float the represent our distance
        float Sy = distance.y;//세로 높이의 거리를 지정
        float Sxz = distanceXZ.magnitude;

        //속도 계산
        float Vxz = Sxz / time;
        float Vy = (Sy / time) + (fRat * Mathf.Abs(Physics.gravity.y) * time);//최대 높이값 계산

        //계산으로 인해 두축의 초기 속도 가지고 새로운 벡터를 만들수 있음
        Vector3 result = distanceXZ.normalized;
        result *= Vxz;
        result.y = Vy;
        return result;
    }

    public float fTime = 1.0f;
    public float fRat = 0.5f;

    Vector3 CalculateVelcoityVector(Vector3 vTarget, Vector3 vPos, float time)
    {
        Vector3 vDist = vTarget - vPos;//거리계산
        //사용하지않을시 높이차이에 의한 높이 게임만들기
        Vector3 vDistXZ = vDist; vDistXZ.y = 0; //y축이 영향을 주지않도록 제거한 벡터
        //s벡터를 이용하지않으면 1사분면으로만 날아감 -> 여기에서 속도값을 양수화하지않으면 곱으로 인해 속도계산시 항상 양수가된다.
        //float fDistX = Mathf.Sqrt(vDist.x * vDist.x);
        //Vector3 vS = new Vector3(Mathf.Abs(vDistXZ.x), vDist.y, Math.Abs(vDistXZ.z)); //bule
        Vector3 vS = new Vector3(vDistXZ.magnitude, vDist.y, vDistXZ.magnitude); //bule
        Vector3 vVelocity = vS / time;// 속력
        //시간당 중력에 따른거리계산. 최대높이값이 중간지점이므로 중력의 절반을 구한다. 시간이 클수록 사각이 늘어난다.
        vVelocity.y += (fRat * Mathf.Abs(Physics.gravity.y) * time); //최대높이// magenta


        Vector3 vResult = vDistXZ.normalized; //yellow
        //원래 xy축의 방향에 기존의 속도에따른 비율을 적용시키고,
        vResult.x = vResult.x * vVelocity.x;
        vResult.z = vResult.z * vVelocity.z;
        vResult.y = vVelocity.y;//y는 중력에의해서 작동하므로 그대로 사용한다.

        List<Vector3> listVectors = new List<Vector3>();
        listVectors.Add(vPos);
        listVectors.Add(vTarget);
        listVectors.Add(vDist);
        listVectors.Add(vS);
        listVectors.Add(vVelocity);
        listVectors.Add(vResult);

        listResultVectors.Add(listVectors);

        return vResult;
    }

    void DrawPath(Vector3 velocity)
    {
        Vector3 previousDrawPoint = this.transform.position;
        int resolution = 30;
        //lineRenderer.positionCount = resolution;
        for (int i = 1; i <= resolution; i++)
        {
            //float simulationTime = i / (float)resolution * launchData.timeToTarget;
            float simulationTime = i / (float)resolution * fTime;

            Vector3 displacement = velocity * simulationTime + Vector3.up * Physics.gravity.y * simulationTime * simulationTime / 2f;
            Vector3 drawPoint = this.transform.position + displacement;
            //DebugExtension.DebugPoint(drawPoint, 1, 1000f);//유니티 에셋스토어 Debug Extension
            Debug.DrawLine(previousDrawPoint, drawPoint, Color.green);
            //lineRenderer.SetPosition(i - 1, drawPoint);
            previousDrawPoint = drawPoint;
        }
    }

    #endregion




}
