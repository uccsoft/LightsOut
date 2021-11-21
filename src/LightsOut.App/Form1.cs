﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightsOut.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            LightsOutApiClient lightsOutApiClient = new LightsOutApiClient("localhost", "5000");
            var gameSettings = await lightsOutApiClient.GetGameSettings(1);
        }
    }
}
