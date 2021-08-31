using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class weatherControl : MonoBehaviour
{
    public Material[] mat;
    public string apiKey = "8ea31ca55842488825421b786d0a21c4";

    public string city;
    public bool useLatLng = false;
    public string latitude;
    public string longitude;
    public weatherControl wc;

    public void Start()
    {
        latitude = "32.498694";
        longitude = "74.549547";
        city = "sialkot";
        GetRealWeather();
    }
    
    public void GetRealWeather()
    {
        string uri = "api.openweathermap.org/data/2.5/weather?";
        if (useLatLng)
        {
            uri += "lat=" + latitude + "&lon=" + longitude + "&appid=" + apiKey;
        }
        else
        {
            uri += "q=" + city + "&appid=" + apiKey;
        }
        StartCoroutine(GetRequest(uri));
    }
    IEnumerator GetRequest(string uri)
    {
        var weatherAPI = new UnityWebRequest(uri)
        {
            downloadHandler = new DownloadHandlerBuffer()
        };
        yield return weatherAPI.SendWebRequest();
        if(weatherAPI.isNetworkError || weatherAPI.isHttpError)
        {
            print("fail getting data");
            yield break;
        }
        JSONNode weatherInfo = JSON.Parse(weatherAPI.downloadHandler.text);
        print(weatherInfo["weather"][0]["main"]);
        updateWeatherInGame(weatherInfo["weather"][0]["main"]);
    }
    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", 4*Time.time);
    }
    public void updateWeatherInGame(string main)
    {
        if(main == "Thunderstorm")
        {
            RenderSettings.skybox = mat[6];
        }
        else if (main == "Drizzle")
        {
            RenderSettings.skybox = mat[2];
        }
        else if (main == "Rain")
        {
            RenderSettings.skybox = mat[2];
        }
        else if (main == "Snow")
        {
            RenderSettings.skybox = mat[1];
        }
        else if (main == "Mist")
        {
            RenderSettings.skybox = mat[5];
        }
        else if (main == "Haze")
        {
            RenderSettings.skybox = mat[4];
        }
        else if (main == "Dust")
        {
            RenderSettings.skybox = mat[4];
        }
        else if (main == "Fog")
        {
            RenderSettings.skybox = mat[5];
        }
        else if (main == "Sand")
        {
            RenderSettings.skybox = mat[4];
        }
        else if (main == "Smoke")
        {
            RenderSettings.skybox = mat[4];
        }
        else if (main == "Ask")
        {
            RenderSettings.skybox = mat[4];
        }
        else if (main == "Squall")
        {
            RenderSettings.skybox = mat[1];
        }
        else if (main == "Tornado")
        {
            RenderSettings.skybox = mat[3];
        }
        else if (main == "Clear")
        {
            RenderSettings.skybox = mat[0];
        } else if (main == "Clouds")
        {
            RenderSettings.skybox = mat[2];
        }
    }
}
