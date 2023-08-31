using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShotString : MonoBehaviour
{
    [SerializeField]
    private Transform left;

    [SerializeField]
    private Transform right;

    [SerializeField]
    public Transform centre;

    
    private LineRenderer slingShotString;
    // Start is called before the first frame update
    void Start()
    {
       slingShotString = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        slingShotString.SetPositions(new Vector3[3]{ left.position, centre.position, right.position});
    }
}
