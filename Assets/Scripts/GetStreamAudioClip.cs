﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Voice.PUN;

public class GetStreamAudioClip : MonoBehaviour
{
    public AudioSource streamAudioSrc;
    public GameObject speaker;
    public AudioPeer audioPeer;
    public AudioSource localAudioSrc;
    public StreamAudio streamAudio;
    public bool isMyAudioFile;
    

    // Start is called before the first frame update
    void Start()
    {
        audioPeer = GetComponent<AudioPeer>();
        localAudioSrc = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check if a local file is playing.
        if (audioPeer.localAudioPlaying == false)
        {

            if (speaker == null)
            {
                speaker = GameObject.FindGameObjectWithTag("speaker");
                if (speaker != null)
                {
                    streamAudioSrc = speaker.GetComponent<AudioSource>();
                }
            }

            if (speaker != null)
            {
                if (streamAudioSrc.isPlaying == true && localAudioSrc.clip == null)
                {
                    audioPeer.audioClip = streamAudioSrc.clip;
                    //localAudioSrc.mute = true;
                    audioPeer.audioSwitchedOn = true;

                    if (streamAudio.isStreaming == false)
                    {
                        localAudioSrc.mute = true;
                    }
                }
            }
        }

       
    }
}
