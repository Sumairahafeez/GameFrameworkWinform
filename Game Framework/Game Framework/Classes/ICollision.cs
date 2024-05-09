using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Framework.Classes
{
    public interface ICollision
    {
        string DetectCollision(Actions action);
    }
}
