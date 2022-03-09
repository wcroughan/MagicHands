using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

public class PassthroughManager : MonoBehaviour
{
    [SerializeField]
    OVRPassthroughLayer passthroughLayer;
    [SerializeField]
    float hueChangeSpeed;


    private float counter = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime * hueChangeSpeed;
        while (counter > 1f)
            counter--;
        passthroughLayer.edgeColor = Color.HSVToRGB(counter, 1f, 1f);
        // passthroughLayer.SetColorMap
    }
}
