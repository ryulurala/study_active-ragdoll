using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private float positionY = 15.0f;
    private float positionZ = -15.0f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        transform.eulerAngles = new Vector3(35.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(target.transform.localPosition.x, positionY, target.transform.localPosition.z + positionZ);
    }
}
