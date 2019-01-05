using BoulderDash2019.Controllers;
using BoulderDash2019.Models;
using BoulderDash2019.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019
{
    class Program
    {
        static void Main(string[] args)
        {
            LevelController levelcontroller = new LevelController();
            levelcontroller.loadInfo();
        }
    }
}
