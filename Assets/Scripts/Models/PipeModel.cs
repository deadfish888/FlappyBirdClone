using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    public class PipeModel
    {
        public int MoveSpeed { get; set; }

        public PipeModel(int moveSpeed)
        {
            MoveSpeed = moveSpeed;
        }
    }
}
