using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DirectorTimeline : MonoBehaviour
{

    private PlayableDirector director;

    private Player player;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        director = GetComponent<PlayableDirector>();
        director.played += Director_Played;
        director.stopped += Director_Stopped;
    }

    private void Director_Stopped(PlayableDirector obj)
    {
        player.TimelineEnd();
    }

    private void Director_Played(PlayableDirector obj)
    {
        player.TimelineStart();
    }

    public void Pause()
    {
        director.Pause();
    }
}
