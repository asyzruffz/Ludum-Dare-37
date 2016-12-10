using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldOfView2D : MonoBehaviour {

    public float viewRadius = 1;
    [Range(0, 360)]
    public float viewAngle = 45;
	public float checkingTimeInterval = 0.2f;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    public List<Transform> visibleTargets = new List<Transform>();

    void Start() {
		StartCoroutine("FindTargetsWithDelay", checkingTimeInterval);
    }

    IEnumerator FindTargetsWithDelay(float delay) {
        while (true) {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    public void FindVisibleTargets() {
        visibleTargets.Clear();
		Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++) {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
			if (Vector3.Angle(transform.right * Mathf.Sign(transform.localScale.x), dirToTarget) < viewAngle / 2) {
                float dstToTarget = Vector3.Distance(transform.position, target.position);
				if (!Physics2D.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask)) {
                    visibleTargets.Add(target);
                }
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal) {
        if (!angleIsGlobal) {
            angleInDegrees += transform.eulerAngles.z;
        }
		return new Vector3(Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0);
    }

    public bool HasTarget() {
        return visibleTargets.Count > 0;
    }
}
