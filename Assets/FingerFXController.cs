using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
// using OculusSampleFramework;

public class FingerFXController : MonoBehaviour
{
    [SerializeField]
    OVRSkeleton skeleton;
    [SerializeField]
    OVRSkeleton.BoneId boneToFollow;
    [SerializeField]
    float toggleOnDistance;
    [SerializeField]
    float toggleOffDistance;
    [SerializeField]
    VisualEffect visualEffect;
    [SerializeField]
    List<VisualEffectAsset> effects;

    private Transform myBoneTransform;
    private Transform thumbTransform;
    private float toggleOnDistanceSq;
    private float toggleOffDistanceSq;
    private int assetIndex;
    private bool trackThumb = false;
    private float counter = 0;
    private bool isPinching;

    // Start is called before the first frame update
    void Start()
    {
        foreach (OVRBone bone in skeleton.Bones)
        {
            if (bone.Id == boneToFollow)
                myBoneTransform = bone.Transform;
            else if (bone.Id == OVRSkeleton.BoneId.Hand_ThumbTip)
                thumbTransform = bone.Transform;
        }

        toggleOnDistanceSq = toggleOnDistance * toggleOnDistance;
        toggleOffDistanceSq = toggleOffDistance * toggleOffDistance;
        assetIndex = 0;
        isPinching = false;
        trackThumb = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if (trackThumb)
        //     transform.position = thumbTransform.position;
        // else
        transform.position = myBoneTransform.position;
        transform.rotation = myBoneTransform.rotation;

        // counter += Time.deltaTime;
        // if (counter > 0.5)
        // {
        //     trackThumb = !trackThumb;
        //     counter = 0;
        // }

        float d = (myBoneTransform.position - thumbTransform.position).sqrMagnitude;
        if (!isPinching)
        {
            if (d < toggleOnDistanceSq)
            {
                isPinching = true;
                assetIndex++;
                if (assetIndex > effects.Count)
                {
                    assetIndex = 0;
                    visualEffect.Stop();
                }
                else
                {
                    visualEffect.visualEffectAsset = effects[assetIndex - 1];
                    if (assetIndex == 1)
                        visualEffect.Play();
                }
            }
        }
        else
        {
            if (d > toggleOffDistanceSq)
            {
                isPinching = false;
            }
        }
    }
}
