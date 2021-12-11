using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ooplaba4._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            abc = new Model(50, 60, 70);
            abc.observers += new System.EventHandler(this.UpdateFromModel);
        }
        Model abc;
         

        private void numericUpDownA_ValueChanged(object sender, EventArgs e)
        {
            abc.SetValue(int.Parse(numericUpDownA.Value.ToString()),0);
        }

        private void numericUpDownB_ValueChanged(object sender, EventArgs e)
        {
            abc.SetValue(int.Parse(numericUpDownB.Value.ToString()), 1);

        }

        private void numericUpDownC_ValueChanged(object sender, EventArgs e)
        {
            abc.SetValue(int.Parse(numericUpDownC.Value.ToString()), 2);

        }

        private void textBoxA_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) 
            { 
            abc.SetValue(int.Parse(textBoxA.Text), 0);
            }

        }

        private void textBoxB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                abc.SetValue(int.Parse(textBoxB.Text), 1);
            }
        }

        private void textBoxC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                abc.SetValue(int.Parse(textBoxC.Text), 2);
            }
        }

        private void trackBarA_ValueChanged(object sender, EventArgs e)
        {
            abc.SetValue(int.Parse(trackBarA.Value.ToString()), 0);
        }

        private void trackBarB_ValueChanged(object sender, EventArgs e)
        {
            abc.SetValue(int.Parse(trackBarB.Value.ToString()), 1);

        }

        private void trackBarC_ValueChanged(object sender, EventArgs e)
        {
            abc.SetValue(int.Parse(trackBarC.Value.ToString()), 2);

        }
        private void UpdateFromModel(object sender, EventArgs e)
        {
            textBoxA.Text = abc.GetValue(0).ToString();
            textBoxB.Text = abc.GetValue(1).ToString();
            textBoxC.Text = abc.GetValue(2).ToString();
            trackBarA.Value = abc.GetValue(0);
            trackBarB.Value = abc.GetValue(1);
            trackBarC.Value = abc.GetValue(2);
            numericUpDownA.Value = Decimal.Parse(abc.GetValue(0).ToString());
            numericUpDownB.Value = Decimal.Parse(abc.GetValue(1).ToString());
            numericUpDownC.Value = Decimal.Parse(abc.GetValue(2).ToString());
           
        }
        class Model
        {
            private int[] value = {0,0,0};
            public System.EventHandler observers;
            public Model(int A,int B,int C)
            {
                this.value[0] = A;
                this.value[1] = B;
                this.value[2] = C;
            }
            public void SetValue(int value,int index)
            {
                if(index == 0)
                {
                    if (value > -1 && value < 101)
                    {
                        if (value > this.value[1] && value > this.value[2])
                        {
                            this.value[0] = value;
                            this.value[1] = value;
                            this.value[2] = value;
                        } 
                        else if(value > this.value[1])
                        {
                            this.value[0] = value;
                            this.value[1] = value;
                        }
                        else
                        {
                            this.value[0] = value;
                        }
                    }
                }
                else if(index == 1)
                {
                    if (value > this.value[0] && value < this.value[2])
                        this.value[1] = value;
                }
                else
                {
                    if (value > -1 && value < 101)
                    {
                        if (value < this.value[1] && value < this.value[0])
                        {
                            this.value[0] = value;
                            this.value[1] = value;
                            this.value[2] = value;
                        }
                        else if (value < this.value[1])
                        {
                            this.value[2] = value;
                            this.value[1] = value;
                        }
                        else
                        {
                            this.value[2] = value;
                        }
                    }
                }
                observers.Invoke(this, null);
            }
            public int GetValue(int index)
            {
                return value[index];
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                
        }
    }
}
