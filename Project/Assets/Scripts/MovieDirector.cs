using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

using IBM.Watson.DeveloperCloud.Utilities;

public class MovieDirector : MonoBehaviour {

    public GameObject videoObject;

    public List<PlayableDirector> playableDirectors;

    public double startTime;

    public double endTime;

    public int uiPanelIndex;

    private VideoPlayer videoPlayer;

    // Use this for initialization
    void Start ()
    {
        if (videoObject != null)
        {
            videoPlayer = videoObject.GetComponent<VideoPlayer>();
            videoPlayer.time = startTime;
            videoPlayer.Play();
        }

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
                if (videoPlayer != null)
                {
                    videoPlayer.Stop();
                }
                playableDirector.Stop();
            }

            if (playableDirector.state != PlayState.Playing) {
                Debug.Log("Unloading scene : " + SceneManager.GetActiveScene().name);
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
                if (uiPanelIndex > 0)
                {
                    MenuChoice.menuChoice.SetMenuIdx(uiPanelIndex);
                    SceneManager.LoadScene("UI", LoadSceneMode.Single);
                }
            }
        }
    }
}
