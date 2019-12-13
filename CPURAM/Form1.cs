using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPURAM
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        PerformanceCounter pCPU = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        List<float> cpuList = new List<float>();
        public Form1()
        {
            InitializeComponent();
            cpuList.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            float ram = pRAM.NextValue();
            float cpu = pCPU.NextValue();
            metroProgressBarRAM.Value = (int)ram;
            metroProgressBarCPU.Value = (int)cpu;
            if (cpuList.Count >= 100)
                cpuList.RemoveAt(0);
            cpuList.Add(cpu);
            chart1.Series["CPU"].Points.DataBindY(cpuList);
            chart1.ChartAreas[0].AxisY.Maximum = 100;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
