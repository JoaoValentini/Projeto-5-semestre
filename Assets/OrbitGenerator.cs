using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitGenerator : MonoBehaviour
{
    particleFollowPath pPath;
    Vector3 _axis;
    float _radius;
    float _rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        pPath = GetComponent<particleFollowPath>();
        //SetOrbitValues();
    }

 

    public void SetOrbitValues(Transform _center)
    {
        _axis = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        _radius = Random.Range(0.2f, 0.35f);
        _rotationSpeed = Random.Range(80f, 230f);
        PutInOrbit(_axis, _radius, _rotationSpeed, _center);
    }
    public void SetOrbitValues(Transform _center,float speed)
    {
        _axis = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        _radius = Random.Range(0.2f, 0.35f);
        _rotationSpeed = speed;
        PutInOrbit(_axis, _radius, _rotationSpeed, _center);
    }
    public void SetOrbitValues(Transform _center,float radius,float speed)
    {
        _axis = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        _radius = radius;
        _rotationSpeed = speed;
        PutInOrbit(_axis, _radius, _rotationSpeed, _center);
    }

    void PutInOrbit(Vector3 pAxis, float pRadius, float pSpeed, Transform center)
    {
        
        pPath.axis = pAxis;
        pPath.rotationSpeed = pSpeed;
        pPath.radius = pRadius;
        pPath.center = center;
      //  pPath.SetTransformPosition(center);
    }

}
