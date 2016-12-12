using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(FieldOfView2D))]
public class FieldOfView2DEditor : Editor {

	void OnSceneGUI() {
        FieldOfView2D fov = (FieldOfView2D)target;
        Handles.color = Color.green;
        Handles.DrawWireArc(fov.transform.position, Vector3.forward, Vector3.right, 360, fov.viewRadius);

        Vector3 viewAngleA = fov.DirFromAngle(-fov.viewAngle / 2, false);
        Vector3 viewAngleB = fov.DirFromAngle(fov.viewAngle / 2, false);
		Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleA * fov.viewRadius * Mathf.Sign(fov.transform.localScale.x));
		Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleB * fov.viewRadius * Mathf.Sign(fov.transform.localScale.x));

        Handles.color = Color.red;
        foreach(Transform visibleTarget in fov.visibleTargets) {
			if (visibleTarget) {
				Handles.DrawLine (fov.transform.position, visibleTarget.transform.position);
			}
        }
    }
}
