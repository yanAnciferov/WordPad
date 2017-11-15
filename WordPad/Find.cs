using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPad
{
    public delegate bool FindEvent(object sender, FindEventArgs eventArgs);

    public delegate bool FindReplaceEvent(object sender, FindReplaceEventArgs eventArgs);
    public class FindEventArgs : EventArgs
    {
        public bool IsOnlyFullWord { get; set; }
        public bool IsWithRegister { get; set; }
        public string FindValue { get; set; }
    }

    public class FindReplaceEventArgs : FindEventArgs
    {
        public string ReplaceValue { get; set; }
    }
}
