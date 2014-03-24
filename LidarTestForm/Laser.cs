using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LidarTestForm
{
    class Laser
    {
        public bool PowerOn()
        {
            //do some stuff to power it on
            return true;
        }

        public bool PowerOff()
        {
            //do some stuff to turn it off
            return true;
        }

        public void BeginFiring()
        {
            Random r = new Random(100);
            new Task(() =>
            {
                
                while (true)
                {

                    int sleeptime = r.Next(100) * 5;
                    Thread.Sleep(sleeptime);
                    LidarShot.CoPol = new LidarReturn(sleeptime.ToString());
                }
            }).Start();
            new Task(() =>
            {
                
                while (true)
                {
                    r.Next();
                    r.Next();
                    int sleeptime = r.Next(100) * 5;
                    Thread.Sleep(sleeptime);
                    LidarShot.CrossPol = new LidarReturn(sleeptime.ToString());
                }
            }).Start();
        }
    }
}
