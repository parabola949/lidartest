using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LidarTestForm
{
    class db
    {
        public static void SaveLidarShot(LidarReturn co, LidarReturn cross)
        {
            MessageBox.Show("Shot Saved\n" + co.Data + cross.Data);
        }
    }
}
