using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class MovieDirector : MonoBehaviour {

    public GameObject videoObject;

    public List<PlayableDirector> playableDirectors;

    public List<TimelineAsset> timelines;

    public double startTime;

    public double endTime;

    private VideoPlayer videoPlayer;

    private TimelineAsset timelineController;

    // Use this for initialization
    void Start ()
    {
        videoPlayer = videoObject.GetComponent<VideoPlayer>();
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

    void FixedUpdate()
    {
        foreach (PlayableDirector playableDirector in playableDirectors)
        {
            if (playableDirector.time >= endTime) {
                videoPlayer.Stop();
                playableDirector.Stop();
            }

            if (playableDirector.state != PlayState.Playing) {
                Debug.Log("Outside Scene ended, loading Inside Scene.");
                SceneManager.UnloadSceneAsync("OutsideScene");
                SceneManager.LoadScene("InsideScene", LoadSceneMode.Single);
            }
        }
    }
}
