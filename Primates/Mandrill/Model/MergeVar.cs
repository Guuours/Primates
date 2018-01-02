using System.Collections.Generic;

namespace Primates.Mandrill.Model
{
    public class MergeVar
    {
        public string rcpt { get; set; }

        public List<Var> vars { get; set; }
    }
}
