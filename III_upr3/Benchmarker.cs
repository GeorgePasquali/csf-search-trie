using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace III_upr3
{
    class Benchmarker
    {
        private TextBox outputScreen;
        private Stopwatch stopWatch;

        public Benchmarker(TextBox screen)
        {
            outputScreen = screen;
        }

        public void StartBenchmark()
        {
            stopWatch = new Stopwatch();
            stopWatch.Start();
        }

        public void EndBenchmark()
        {
            stopWatch.Stop();


            outputScreen.Clear();

            outputScreen.Text = stopWatch.Elapsed.TotalMilliseconds.ToString();
        }
    }
}
