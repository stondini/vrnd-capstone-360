/**
* Copyright 2015 IBM Corp. All Rights Reserved.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*      http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*
*/

using UnityEngine;
using IBM.Watson.DeveloperCloud.Services.TextToSpeech.v1;
using IBM.Watson.DeveloperCloud.Logging;
using IBM.Watson.DeveloperCloud.Utilities;
using System.Collections;
using System.Collections.Generic;
using IBM.Watson.DeveloperCloud.Connection;

public class Dialog : MonoBehaviour
{
    private static string _serviceUrl = "https://stream-fra.watsonplatform.net/text-to-speech/api";
    private static string _iamApikey = "-jxtxMp9xdTRDOe5WxoITlk0RgVdCmpsESVDUABSvBjtJ";

    private static TextToSpeech _service = null;
    private static bool loaded = false;

    public bool alice;

    public string text;

    private bool played;

    private bool _synthesizeTested;

    void Start()
    {
        played = false;
        if (_service == null)
        {
            LogSystem.InstallDefaultReactors();
            Runnable.Run(CreateService());
        }
    }

    private void FixedUpdate()
    {
        if (gameObject.activeInHierarchy && !played && (_service != null)) {
            played = true;
            // Debug.Log("FixedUpdate");
            Runnable.Run(Speech());
        }
    }

    private IEnumerator CreateService()
    {
        Debug.Log("Loading Watson Service");

        //  Authenticate using iamApikey
        TokenOptions tokenOptions = new TokenOptions()
        {
            IamApiKey = _iamApikey,
            IamUrl = null
        };

        //  Create credential and instantiate service
        Credentials credentials = new Credentials(tokenOptions, _serviceUrl);
        //  Wait for tokendata
        while (!credentials.HasIamTokenData())
            yield return WaitForInit();

        _service = new TextToSpeech(credentials);

        if (loaded)
        {
            Debug.Log("Watson Service Loaded : _service=" + (_service == null ? "null" : _service.ToString()));
        }
    }

    public IEnumerator WaitForInit() {
        yield return new WaitForSeconds(3.0f);
        loaded = (_service != null);
    }
   
    public IEnumerator Speech()
    {
        _service.Voice = alice ? VoiceType.en_US_Allison : VoiceType.en_US_Michael;
        _service.ToSpeech(HandleToSpeechCallback, OnFail, text, true);
        while (!_synthesizeTested)
            yield return null;
    }

    void HandleToSpeechCallback(AudioClip clip, Dictionary<string, object> customData = null)
    {
        Debug.Log("TEXT TO SPEECH - HandleToSpeechCallback");
        PlayClip(clip);
    }

    private void PlayClip(AudioClip clip)
    {
        if (Application.isPlaying && clip != null)
        {
            GameObject audioObject = new GameObject("AudioObject");
            AudioSource source = audioObject.AddComponent<AudioSource>();
            source.spatialBlend = 0.0f;
            source.loop = false;
            source.clip = clip;
            source.Play();

            Destroy(audioObject, clip.length);

            _synthesizeTested = true;
        }
    }

    private void OnFail(RESTConnector.Error error, Dictionary<string, object> customData)
    {
        Log.Error("ExampleTextToSpeech.OnFail()", "Error received: {0}", error.ToString());
    }
}
