using Robot.Tests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot.Simulator
{
    public class OutputService : IOutputService
    {
        public void Output(string output)
        {
            Console.WriteLine(output);
        }
    }
}
