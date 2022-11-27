using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    internal class KNSLog
    {
        int counterUpdate = 0;
        private readonly string patch;

        public KNSLog(string patch)
        {
            this.patch = patch;
        }

        public void WriteActionInFile(string messageUpdate)
        {
            using (StreamWriter sw = new StreamWriter(patch, true))
            {
                sw.WriteLine($"<><><><><><><><><><><><><> Action: {counterUpdate + 1} <><><><><><><><><><><><><>\n");
                sw.WriteLine($"Time Update: {DateTime.Now.ToString()}\n");
                sw.WriteLine(messageUpdate);
                sw.WriteLine($"\n<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><");
            }
            counterUpdate++;
        }
    }
}
