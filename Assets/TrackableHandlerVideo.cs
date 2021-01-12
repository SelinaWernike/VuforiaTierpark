using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Vuforia;

public class TrackableHandlerVideo : DefaultTrackableEventHandler
{
    public VideoPlayer video;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start(); 
    }

    protected override void   OnTrackingFound() {
        video.Play();
    }

    protected override void OnTrackingLost() {

        if(video) {
            video.Stop();
        }
    }
}
