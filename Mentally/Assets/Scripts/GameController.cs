using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameController : MonoBehaviour
{
    LanguageManager lang = new LanguageManager();

    int language = 0; 
    public TextMeshProUGUI selectChar;
    private static float dayDuration = 5;
    private float nextDay = 5;
    private static float timeSwitchLight = 1;
    private bool started = false; 

    [SerializeField]
    Light light;

    [SerializeField]
    Light light2;

    [SerializeField]
    Light light3;

    [SerializeField]
    Material luz; 

    private float initTime;
    private float today = 1;
    private float dayTime;
    private float nightTime;
    private bool _switchOffLight = false;
    private bool _switchOnLight = false;

    // Start is called before the first frame update
    void Start()
    {
        selectChar.text = lang.getText(language, 0);
        today = 1;
    }

    // Update is called once per frame
    void Update()
    {        
        if (Time.time >= nightTime && started) {           
            today++;
            nightTime = dayDuration * today;            
            _switchOffLight = true; 
        }
        if (Time.time >= dayTime && started) {
            dayTime = dayDuration + dayDuration * today; 
            _switchOnLight = true;         
        }
        if (_switchOffLight)
        {
            switchOffLight(); 
        }
        if (_switchOnLight)
        {
            switchOnLight();
        }




    }


    private void switchOffLight() {
        double nextUpd = 0f;
        while ((light.intensity >= 0 || light2.intensity >= 0 || light3.intensity >= 0) && Time.time > nextUpd)
        {
            nextUpd = Time.time + timeSwitchLight;
            light.intensity -= 0.02f;
            light2.intensity -= 0.02f;
            light3.intensity -= 0.02f;
            luz.DisableKeyword("_EMISSION");
        }

        if (light.intensity <= 0 && light2.intensity >= 0 && light3.intensity >= 0)
        {
            _switchOffLight = false;
        }
    }


    private void switchOnLight() {
        double nextUpd = 0f;
        while ((light.intensity <= 2 || light2.intensity <= 3 || light3.intensity <= 3) && Time.time > nextUpd)
        {
            nextUpd = Time.time + timeSwitchLight;
            light.intensity += 0.02f;
            light2.intensity += 0.02f;
            light3.intensity += 0.02f;
            luz.EnableKeyword("_EMISSION");
        }
        if (light.intensity >= 2 && light2.intensity >= 3 && light3.intensity >= 3)
        {
            _switchOnLight = false;
        }
    }
    public void changeLanguage(int language) {
        this.language = language;
        this.Start(); 
    }


    public void startGame(int character)
    {
        initTime = Time.time;
        dayTime += initTime + dayDuration; 
        nightTime += initTime; 
        started = true; 

        switch (character){          
            //TCA
            case 1:
                startGameTCA();                
                break;
            //TAS
            case 2:
                startGameTAS();
                break;
            //Depression
            default:
                startGameDepression();
                break;
        }
    }


    private void startGameTCA() {
                
    }

    private void startGameTAS() {
       
    }

    private void startGameDepression() {

    }
}
