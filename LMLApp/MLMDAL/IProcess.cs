using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMLApp
{
    interface IProcess
    {
        /// <summary>
        /// Invoke for Insert/Update/Delete/Select
        /// </summary>
        void invoke();
    }
}
