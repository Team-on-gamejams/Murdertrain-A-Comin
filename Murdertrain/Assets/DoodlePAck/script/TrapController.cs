using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrapController : MonoBehaviour {
    public List<GameObject> trapAncor = new List<GameObject>();
    public List<UnityEvent> EventList = new List<UnityEvent>();
    // Use this for initialization
    void Start () {
		
	}
    private void OnTriggerEnter(Collider collision) {
        GameObject sd;        
        if (collision.gameObject.tag == "Char" && trapAncor.Count > 0) {
            Dragger rd = collision.gameObject.GetComponent<Dragger>();
            if (rd == null) return;
            collision.gameObject.tag = "Untagged";
            var obj = rd.objToMove;
            if (rd.ac != null) {
                rd.ac.Stop();
                Destroy(rd.ac);
            }
            Destroy(rd);
            float intDist = 500;
            GameObject curentAncor = null;
            foreach(var tra in trapAncor) {
                var curDist = Vector3.Distance(tra.transform.position, obj.transform.position);
                if (curDist < intDist) {
                    intDist = curDist;
                    curentAncor = tra;
                }
            }
            if (curentAncor == null) return;
            obj.transform.position = curentAncor.transform.position;
            Rigidbody rig = obj.GetComponent<Rigidbody>();
            rig.isKinematic = true;
            obj.SetParent(curentAncor.transform);
            trapAncor.Remove(curentAncor);
            foreach(var ev in EventList) {
                ev.Invoke();
            }
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
