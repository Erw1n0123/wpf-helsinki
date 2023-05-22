using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelsinkiWPF
{
    internal class Eredmenyek
    {
        public Eredmenyek(string line)
        {
            helyezes = int.Parse(line.Split(' ')[0]);
            embred_db = int.Parse(line.Split(' ')[1]);
            sportag = line.Split(' ')[2];
            versenyszam = line.Split(' ')[3];
        }

        public int helyezes { get; }
        public int embred_db { get; }
        public string sportag { get; }
        public string versenyszam { get; }
    }
}
