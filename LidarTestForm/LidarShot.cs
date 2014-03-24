using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LidarTestForm
{
    public class LidarShot
    {
        private static Queue<LidarReturn> copol_queue = new Queue<LidarReturn>();
        private static Queue<LidarReturn> crosspol_queue = new Queue<LidarReturn>();

        public static LidarReturn CoPol
        {
            get
            {
                if (copol_queue.Count > 0)
                {
                    return copol_queue.Peek();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                copol_queue.Enqueue((LidarReturn)value);

                if ((copol_queue.Count > 0) && (crosspol_queue.Count > 0))
                {
                    db.SaveLidarShot(copol_queue.Dequeue(), crosspol_queue.Dequeue());
                }
            }
        }

        public static LidarReturn CrossPol
        {
            get
            {
                if (crosspol_queue.Count > 0)
                {
                    return crosspol_queue.Peek();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                crosspol_queue.Enqueue((LidarReturn)value);

                if ((copol_queue.Count > 0) && (crosspol_queue.Count > 0)) // Apparently this isn't guaranteed...
                {
                    db.SaveLidarShot(copol_queue.Dequeue(), crosspol_queue.Dequeue());
                }
            }
        }
    }
}
