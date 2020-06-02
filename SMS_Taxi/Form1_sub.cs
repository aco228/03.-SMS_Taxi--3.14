using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace SMS_Taxi
{
    class Form1_sub
    {
        public Form1_sub() { }

        public void aco_saveLista(ListView listView1)
        {
            TextWriter tw = File.CreateText("save.CONFIGX");
            int i = 0;
            int c = listView1.Items.Count;
            //MessageBox.Show(listView1.Items[i].SubItems[0].Text + "#" + listView1.Items[i].SubItems[1].Text + "#" + listView1.Items[i].SubItems[2].Text + "#" + listView1.Items[i].SubItems[3].Text + "#" + listView1.Items[i].SubItems[4].Text + "#" + listView1.Items[i].SubItems[5].Text);
            for (; ; )
            {
                if (i == c)
                {
                    tw.Close();
                    break;
                }
                else
                {
                    tw.WriteLine(listView1.Items[i].SubItems[0].Text + "#" + listView1.Items[i].SubItems[1].Text + "#" + listView1.Items[i].SubItems[2].Text + "#" + listView1.Items[i].SubItems[3].Text + "#" + listView1.Items[i].SubItems[4].Text + "#" + listView1.Items[i].SubItems[5].Text);
                    i++;
                }
            }
        }
    }
}
