using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTwirlController : MonoBehaviour
{
    [SerializeField]
    OVRSkeleton skeleton;
    [SerializeField]
    OVRSkeleton.BoneId boneToFollow;
    [SerializeField]
    Vector3 offset;
    [SerializeField]
    float spinSpeed;

    private Transform myBoneTransform;

    // Start is called before the first frame update
    void Start()
    {
        foreach (OVRBone bone in skeleton.Bones)
        {
            if (bone.Id == boneToFollow)
                myBoneTransform = bone.Transform;
        }
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = myBoneTransform.position + offset;
        // transform.rotation = myBoneTransform.rotation;
        transform.RotateAroundLocal(transform.up, Time.deltaTime * spinSpeed);

    }
}
