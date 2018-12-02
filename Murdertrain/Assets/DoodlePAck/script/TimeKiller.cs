 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKiller : MonoBehaviour {
    private float time;
    private float timeToKill;
    // Use this for initialization
    void Start () {
        time = Time.time;
        timeToKill = Random.RandomRange(3f, 8f);

    }

    // Update is called once per frame
    void Update() {
        if ((Time.time - time) > 2) {
            Collider col = this.gameObject.GetComponent<Collider>();
            if (col != null) Destroy(col);
            Rigidbody rig = this.gameObject.GetComponent<Rigidbody>();
            if (rig != null) Destroy(rig);
        }
        if ((Time.time - time) > timeToKill) {
            Destroy(this.gameObject);
        }
    }
}
