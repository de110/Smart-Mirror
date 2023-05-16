using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Net.Json;
using System;
using Newtonsoft.Json.Linq;
public class weather : MonoBehaviour
{
    string Zero;
    public Text ScriptTxt, DateTxt,TimeTxt;
    public string serviceKey = "servicekey"; // 받아온 키
    // public string nx = "63"; // 위도
    // public string ny = "110"; // 경도
    // public string baseDate = "20200605";// 조회하고 싶은 날짜
    // public string baseTime = "0900";// 조회하고 싶은 시간
    // public string type = "json"; // json;
    string weatherTemp = "0.0"; // 현재 시간 기온
    // 정보 모아서 URL 정보 만들기
    // public string urlStr = "http://apis.data.go.kr/1360000/VilageFcstInfoService/getVilageFcst?" + "serviceKey=" + serviceKey + "&base_date=" + baseDate + "&base_time=" + baseTime + "&nx" +nx +"&ny" +ny + "&_type= " + type;
    string urlStr = "http://apis.data.go.kr/1360000/VilageFcstInfoService/getUltraSrtNcst?serviceKey=aZ8tJthg1tO6GeatSxZNcM4JNnEqAuuGtaKfzfQVFZ%2FTxuwWmPDDkZiBBfLfov%2Fiiugwii5W9RNkHzLMmUUUJQ%3D%3D&pageNo=1&numOfRows=10&dataType=JSON&base_date=20200626&base_time=0500&nx=63&ny=110&";

    string JSON_Name;
    string JSON_Temperature;
    float temperature;
    
    // Start is called before the first frame update
    IEnumerator GetWeatherInfo()
    {
        UnityWebRequest www = new UnityWebRequest(urlStr); // 웹통신
        www.downloadHandler = new DownloadHandlerBuffer(); // 날씨 정보 받아오기, 핸들러: 가장 단순, 대부분의 사례 처리, 배열 또는 텍스트 문자열로 버퍼링된 데이터에 액세스 할 수 있음.

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            yield break;
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            JObject Obj = JObject.Parse(www.downloadHandler.text);

            // Json String(문자열 데이터) to Object(객체화)로 반환
            JObject responseObj = Obj["response"].ToObject<JObject>();
            JObject bodyObj = responseObj["body"].ToObject<JObject>();
            JObject itemsObj = bodyObj["items"].ToObject<JObject>();
            JArray jsonArr = itemsObj["item"].ToObject<JArray>();

            JObject weather;
            String fcstDate = ""; // 예측 일자
            String fcstTime = ""; // 예측 시각
            String t1h = ""; // 기온
            String REH = "";
            String category;
            String obsrValue;
            for (int i = 0; i < jsonArr.Count; i++)
            {
                weather = (JObject)jsonArr[i];
                fcstDate = (String)weather["baseDate"];
                fcstTime = (String)weather["baseTime"];
                category = (String)weather["category"];
                obsrValue = (String)weather["obsrValue"];
                Debug.Log(i+"번째 category: " + category);
                Debug.Log("obsrValue :" + obsrValue);

                if (i == 1)
                    REH = obsrValue;

                if (i == 3)
                    t1h = obsrValue;

            }
            //ScriptTxt.text = "온도: "+ t1h + " 습도: "+ REH;
            ScriptTxt.text = t1h;
            ScriptTxt.SetNativeSize();

            DateTxt.text = fcstDate;
            TimeTxt.text = fcstTime;

            clothing.wt = true;

        }
    }

    void Start()
    {
        ScriptTxt = gameObject.GetComponent<Text>();
        StartCoroutine(GetWeatherInfo());
    }
    void Update()
    {
    }
}
