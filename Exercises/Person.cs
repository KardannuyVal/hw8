using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    enum Position
    {
        Customer,
        TeamLeader,
        Senior,
        Midlle,
        Junior
    }
    internal class Person
    {
        private string name { get; set; }
        private Position position { get; set; }
    
        private Task task { get; set; }
        public Person(string name, Position position)
        {
            this.name = name;
            this.position = position;
        }
        
        /// <summary>
        /// Добавляет задачу человеку
        /// </summary>
        /// <param name="task"></param>
        public void AddTask(Task task)
        {
            this.task = task;
        }
    }
}
