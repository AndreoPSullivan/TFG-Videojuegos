using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameController : MonoBehaviour
{
    LanguageManager lang = new LanguageManager();

    private int language = 0; 
    public TextMeshProUGUI selectChar;
    public TextMeshProUGUI tasks; 
     

    private float initTime;    
    private bool started = false;
    private int character = 0;

   
    [SerializeField] Image timeController;
    public float waitTime = 10.0f;


    [SerializeField] MeshRenderer[] paredes;
    [SerializeField] Material materialDep; 
    [SerializeField] GameObject filtroDep; 

    public enum TasksEnum
    { 
        None, Sleep, Eat, Clean, Switch   
    
    }

    private TasksEnum currentTask = TasksEnum.None; 

    // Start is called before the first frame update
    void Start()
    {
        selectChar.text = lang.getText(language*4, 0);
    }

    // Update is called once per frame
    void Update()
    {        
        
        if (started)
        {
            if (getCharacter() == 3)
            {
                timeController.fillAmount -= 1.0f / waitTime * Time.deltaTime;
            }
            else {

                timeController.fillAmount -= 1.0f / waitTime *2* Time.deltaTime;
            }


            if (Time.time > initTime + 30  && Time.time < initTime + 35) {
                currentTask = TasksEnum.Switch;
                addTask(4);
            }

        }

    }


   
    public void changeLanguage(int language) {
        this.language = language;
        this.Start(); 
    }


    public void startGame(int character)
    {
        initTime = Time.time;
       
        started = true;

        this.character = character; 

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

                foreach (MeshRenderer pared in paredes) {
                    pared.material = materialDep; 
                    
                }
                filtroDep.active = true; 

                startGameDepression();
                break;
        }
    }


    public int getCharacter() {
        return this.character; 
    }


    private void startGameTCA() {
                
    }

    private void startGameTAS() {
       
    }

    private void startGameDepression() {

    }

    public void addTask(int task) { 
        tasks.text = lang.getText(language*4, task);
    }


    public void addTask()
    {
        tasks.text = ""; 
    }

    public int getLanguage() {
        return this.language; 
    }

    public TasksEnum getCurrentTask() {
        return currentTask; 
    }

    public void setCurrentTask(TasksEnum currentTask) {
        this.currentTask = currentTask; 
    }
}
