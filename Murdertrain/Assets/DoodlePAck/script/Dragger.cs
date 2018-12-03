using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dragger : MonoBehaviour {
    private Vector3 screenPoint;
    private Vector3 offset;
    public Camera cam;
    private bool isMove = false;
    public Transform objToMove;
    public Plane plane;    

    private Vector3 cursorPosition;
    private Vector3 markerOfset;
    private Rigidbody rBod;
    private float maxy = 3;
    private float cury = 0;
    private Collider col;
    public AudioSource ac;
    
    void Start(){
        cam = Camera.main;
        plane = new Plane(Vector3.up, Vector3.zero);
        
        rBod = objToMove.GetComponent<Rigidbody>();
        markerOfset = objToMove.position - transform.position;
        col = transform.GetComponent<Collider>();
        
    }
    void OnMouseDown()
    {
        if (plane.Equals(null)) return;
        cury = 0;
        plane.SetNormalAndPosition(Vector3.up, Vector3.zero+new Vector3(0,objToMove.position.y,0));        
        rBod.isKinematic = true;
        screenPoint = cam.WorldToScreenPoint(objToMove.transform.position);
        //offset = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        offset = objToMove.transform.position - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        isMove = true;
        ac = TraineAudioController.instant.PlaySoud(TraineAudioController.SoundPack.Joy);
    }

    void OnMouseDrag()
    {
        
        /*Vector3 cursorPoint = new Vector3(Input.mousePosition.x, 0 , Input.mousePosition.y);
        cursorPosition = cursorPoint + offset;*/
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        cursorPosition = cam.ScreenToWorldPoint(cursorPoint) + offset;

        //cursorPosition = new Vector3(cursorPosition.x, 0, cursorPosition.z);
        //transform.position = cursorPosition;
    }

    private void OnTriggerEnter(Collider other)
    {       
        if (other.gameObject.CompareTag("Killer"))
        {            
            Destroy(objToMove.gameObject);
            if (ac != null) {
                ac.Stop();
                Destroy(ac);
            }
            Destroy(this);
        }
    }
    void LateUpdate(){
        if (objToMove == null) return;
        transform.position = objToMove.position + markerOfset;
        if (!isMove) return;        
        //Plane plane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance;
        if (objToMove.position.y < maxy) {
           cury += 4f * Time.deltaTime;            
        }
        //Plane plane = new Plane(Vector3.up, Vector3.zero);
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance)) {
            Vector3 pointalongplane = ray.origin + (ray.direction * distance);
            objToMove.position = pointalongplane + new Vector3(0, cury, 0); ;
        }
        
        /*
        transform.position = objToMove.position + markerOfset;
        if (!isMove) return;
        if (objToMove.position.y < maxy) {
            cury += 2f * Time.deltaTime;
            objToMove.position = objToMove.position + new Vector3(0, cury, 0);
            cursorPosition.y = objToMove.position.y;
        }
        cursorPosition.y = objToMove.position.y;
        objToMove.position = cursorPosition;
        offset += new Vector3(-3f * Time.deltaTime, 0, 0);*/

    }

    void OnMouseUp()    {
        cury = 0;
        if (ac != null) {
            ac.Stop();
            Destroy(ac);
        }
        rBod.isKinematic = false;
        isMove = false;
    }
}
