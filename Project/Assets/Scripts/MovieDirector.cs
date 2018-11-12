using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class MovieDirector : MonoBehaviour {

    public GameObject videoObject;

    public List<PlayableDirector> playableDirectors;

    public List<TimelineAsset> timelines;

    public double startTime;

    private VideoPlayer videoPlayer;

    private TimelineAsset timelineController;

    // Use this for initialization
    void Start ()
    {
        videoPlayer = videoObject.GetComponent<VideoPlayer>();
       // timelineController = timelineObject.GetComponent<TimelineAsset>();

        videoPlayer.time = startTime;
        videoPlayer.Play();
        foreach (PlayableDirector playableDirector in playableDirectors)
        {
            playableDirector.time = startTime;
            playableDirector.Play();
        }
    }
	
	// Update is called once per frame
	void Update () 
    {
		
	}
}
