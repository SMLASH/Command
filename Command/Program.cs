using System;

namespace Command
{

    class TV
    {
        public void On()
        {
            Console.WriteLine("TV is ON");
        }

        public void Off()
        {
            Console.WriteLine("TV is OFF");
        }
    }

    interface ICommand
    {
        void Execute();
        void Undo();
    }

    class CommandOnTV : ICommand
    {
        TV tv;
        public CommandOnTV(TV tvSet)
        {
            tv = tvSet;
        }
        public void Execute()
        {
            tv.On();
        }

        public void Undo()
        {
            tv.Off();
        }
    }

    class Remote
    {
        ICommand _command;
        
        public void SetCommand(ICommand com)
        {
            _command = com;
        }
        
        public void PressButton()
        {
            if (_command != null)
            {
                _command.Execute();
            }
        }

        public void PressUndo()
        {
            if (_command != null)
            {
                _command.Undo();
            }
        }
    }
    

    

    class Program
    {
        static void Main(string[] args)
        {
            var tv = new TV();
            var remote = new Remote();
            var command = new CommandOnTV(tv);
            remote.SetCommand(command);
            remote.PressButton(); 
            remote.PressUndo();
        }
    }
}