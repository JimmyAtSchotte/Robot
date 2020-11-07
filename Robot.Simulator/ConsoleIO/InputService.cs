using Robot.Tests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot.Simulator
{
    public class InputService : IInputService
    {
        public string ReadNextInput()
        {
            return Console.ReadLine();
        }
    }
}
