using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    enum Status
    {
        Project,
        Execution,
        Closed
    }
    internal class Project
    {
        private string description { get; set; }
        private DateTime deadline { get; set; }
        private Person customer { get; set; }
        private Person team_leader { get; set; }
        private List<Task> tasks { get; set; }

        private Status status;
        public Status Status 
        { 
            get 
            { 
                return status; 
            }
        }
        public Project(string description, DateTime deadline, Person customer, Person team_leader)
        {
            this.description = description;
            this.deadline = deadline;
            this.customer = customer;     
            this.team_leader = team_leader;
            tasks = new List<Task>();
            status = Status.Project;
        }

        /// <summary>
        /// Добавляет задачу проекту
        /// </summary>
        /// <param name="task"></param>
        public void AddTask(Task task)
        {
            tasks.Add(task);
        }
        /// <summary>
        /// Убирает задачу
        /// </summary>
        /// <param name="task"></param>
        public void RemoveTask(Task task)
        {
            tasks.Remove(task);
        }
        /// <summary>
        /// Меняет статус проекта на начатый
        /// </summary>
        public void StartProject()
        {
            status = Status.Execution;
        }
        /// <summary>
        /// Меняет статус проекта на законченный
        /// </summary>
        public void CloseProject()
        {
            status = Status.Closed;
        }
        /// <summary>
        /// Проверяет законченный проект или нет
        /// </summary>
        /// <returns></returns>
        public bool IsCompleted()
        {
            foreach (Task task in tasks)
            {
                if(task.Status != TaskStatus.Completed)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
