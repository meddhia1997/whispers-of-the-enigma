using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Quest : MonoBehaviour
{

     [Serializable]
     public class Task
     {
        public string Description { get; set; }
        public bool Completed { get; set; }
        public  int CurrentProgress=0;
        public int Target;
        public Hint hint;
        public Item item;
        
       
        public void Evaluate()
        {
            CurrentProgress++;
            if (CurrentProgress >= Target)
            {
                Complete();
            }
        }

        public void Complete()
        {

            Completed = true;
            hint.DisableHint();
        }


    }
    public List<Task> Tasks;
    public string Description; 
    public float Radius;
    public bool finished;
    public bool ActiveQuest;
    public GameObject player;
    public UiManager uiManager;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
       // Debug.Log(Vector3.Distance(this.transform.position, player.transform.position));
        if (Vector3.Distance(this.transform.position, player.transform.position) <= Radius)
        {
            ActiveQuest = true;
           // Debug.Log(ActiveQuest);
        }else if(Vector3.Distance(this.transform.position, player.transform.position)> Radius && ActiveQuest)
        {
            ActiveQuest=false;
           var completedTasksCount= Tasks.Count(t => t.Completed = false);
            switch (completedTasksCount)
            {
                case >1:
                    uiManager.showHint("I think i should explore this area more");
                    break;
                case 1:
                    Task t=Tasks.Find(t => t.Completed = false);
                    t.hint.displayHint();
                    break;
                default:
                    this.enabled = false;
                    break;
            }

        }
        
    }

    public void checkTasks()
    {
        finished = Tasks.All(t => t.Completed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }

    public void completedTask(int index)
    {
        Tasks[index].Evaluate();
        Debug.Log("Triggred" + index);
    }


}
