using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounciness : MonoBehaviour
{

    //Camera cam;
    public GameObject prefabBullet;
    public Transform target;
    public Transform shootPoint;

    public List<List<Vector3>> listResultVectors = new List<List<Vector3>>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region �ݻ簢




    #endregion


    #region ��ź��

    //void LaucherProjecttile()
    //{
    //    //Vector3 Vo = CalculateVelcoity(target.position, transform.position, 1f);
    //    Vector3 Vo = CalculateVelcoityVector(vecMousePos, shootPoint.transform.position, fTime);
    //    GameObject obj = Instantiate(prefabBullet, shootPoint.position, Quaternion.identity);
    //    Rigidbody rigidbody = obj.GetComponent<Rigidbody>();
    //    rigidbody.velocity = Vo;
    //    //rigidbody.AddForce(Vo);
    //    //setTrajectoryPoints(transform.position, Vo);
    //    DrawPath(Vo);
    //}

    ////��ó: https://foo897.tistory.com/24
    ////�� ����� ��ǥ ���Ϳ� ������ �������� �ʿ��մϴ�.
    ////time : ����ð�
    //Vector3 CalculateVelcoity(Vector3 target, Vector3 origin, float time)
    //{
    //    //define the distance x and y first
    //    Vector3 distance = target - origin;
    //    Vector3 distanceXZ = distance; //x��z�� ����̸� �⺻������ �Ÿ��� ���� ����
    //    distanceXZ.y = 0f;//y�� 0���� ����

    //    //create a float the represent our distance
    //    float Sy = distance.y;//���� ������ �Ÿ��� ����
    //    float Sxz = distanceXZ.magnitude;

    //    //�ӵ� ���
    //    float Vxz = Sxz / time;
    //    float Vy = (Sy / time) + (fRat * Mathf.Abs(Physics.gravity.y) * time);//�ִ� ���̰� ���

    //    //������� ���� ������ �ʱ� �ӵ� ������ ���ο� ���͸� ����� ����
    //    Vector3 result = distanceXZ.normalized;
    //    result *= Vxz;
    //    result.y = Vy;
    //    return result;
    //}

    //public float fTime = 1.0f;
    //public float fRat = 0.5f;

    //Vector3 CalculateVelcoityVector(Vector3 vTarget, Vector3 vPos, float time)
    //{
    //    Vector3 vDist = vTarget - vPos;//�Ÿ����
    //    //������������� �������̿� ���� ���� ���Ӹ����
    //    Vector3 vDistXZ = vDist; vDistXZ.y = 0; //y���� ������ �����ʵ��� ������ ����
    //    //s���͸� �̿����������� 1��и����θ� ���ư� -> ���⿡�� �ӵ����� ���ȭ���������� ������ ���� �ӵ����� �׻� ������ȴ�.
    //    //float fDistX = Mathf.Sqrt(vDist.x * vDist.x);
    //    //Vector3 vS = new Vector3(Mathf.Abs(vDistXZ.x), vDist.y, Math.Abs(vDistXZ.z)); //bule
    //    Vector3 vS = new Vector3(vDistXZ.magnitude, vDist.y, vDistXZ.magnitude); //bule
    //    Vector3 vVelocity = vS / time;// �ӷ�
    //    //�ð��� �߷¿� �����Ÿ����. �ִ���̰��� �߰������̹Ƿ� �߷��� ������ ���Ѵ�. �ð��� Ŭ���� �簢�� �þ��.
    //    vVelocity.y += (fRat * Mathf.Abs(Physics.gravity.y) * time); //�ִ����// magenta


    //    Vector3 vResult = vDistXZ.normalized; //yellow
    //    //���� xy���� ���⿡ ������ �ӵ������� ������ �����Ű��,
    //    vResult.x = vResult.x * vVelocity.x;
    //    vResult.z = vResult.z * vVelocity.z;
    //    vResult.y = vVelocity.y;//y�� �߷¿����ؼ� �۵��ϹǷ� �״�� ����Ѵ�.

    //    List<Vector3> listVectors = new List<Vector3>();
    //    listVectors.Add(vPos);
    //    listVectors.Add(vTarget);
    //    listVectors.Add(vDist);
    //    listVectors.Add(vS);
    //    listVectors.Add(vVelocity);
    //    listVectors.Add(vResult);

    //    listResultVectors.Add(listVectors);

    //    return vResult;
    //}

    //void DrawPath(Vector3 velocity)
    //{
    //    Vector3 previousDrawPoint = shootPoint.transform.position;
    //    int resolution = 30;
    //    //lineRenderer.positionCount = resolution;
    //    for (int i = 1; i <= resolution; i++)
    //    {
    //        //float simulationTime = i / (float)resolution * launchData.timeToTarget;
    //        float simulationTime = i / (float)resolution * fTime;

    //        Vector3 displacement = velocity * simulationTime + Vector3.up * Physics.gravity.y * simulationTime * simulationTime / 2f;
    //        Vector3 drawPoint = shootPoint.transform.position + displacement;
    //        //DebugExtension.DebugPoint(drawPoint, 1, 1000f);//����Ƽ ���½���� Debug Extension
    //        Debug.DrawLine(previousDrawPoint, drawPoint, Color.green);
    //        //lineRenderer.SetPosition(i - 1, drawPoint);
    //        previousDrawPoint = drawPoint;
    //    }
    //}

    #endregion


}
