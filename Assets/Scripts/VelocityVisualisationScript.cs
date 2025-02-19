using System;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(Rigidbody))]
public class VelocityVisualisationScript: MonoBehaviour
{
        private LineRenderer lr;
        private Rigidbody rb;

        private void Start()
        {
                lr = GetComponent<LineRenderer>();
                rb = GetComponent<Rigidbody>();
                lr.useWorldSpace = true;
        }

        private void LateUpdate()
        {
                lr.SetPosition(0, transform.position);
                lr.SetPosition(1, transform.position + rb.linearVelocity);
        }
}