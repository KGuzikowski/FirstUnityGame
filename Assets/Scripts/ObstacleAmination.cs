using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAmination : MonoBehaviour
{
    Animator ChildAnimator;

    // Start is called before the first frame update
    void Start()
    {
        ChildAnimator = gameObject.transform.GetChild(0).GetComponent<Animator>();
        ChildAnimator.speed = 0.35f;
    }
}
