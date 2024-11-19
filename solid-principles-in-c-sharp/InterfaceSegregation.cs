using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solid_principles_in_c_sharp
{
    public interface IProgrammer
    {
        void WorkOnTask();
    }

    public interface ILead
    {
        void AssignTask();
        void CreateSubTask();
    }

    public class Programmer : IProgrammer
    {
        public void WorkOnTask()
        {
            //code to implement to work on the Task.
        }
    }
    public class Manager : ILead
    {
        public void AssignTask()
        {
            //Code to assign a Task
        }
        public void CreateSubTask()
        {
            //Code to create a sub taks from a task.
        }
    }

    public class TeamLead : IProgrammer, ILead
    {
        public void AssignTask()
        {
            //Code to assign a Task
        }
        public void CreateSubTask()
        {
            //Code to create a sub task from a task.
        }
        public void WorkOnTask()
        {
            //code to implement to work on the Task.
        }
    }
}
