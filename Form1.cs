using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace Temperature_Converter2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static class Conversion
        {
            public static int conversiontype;
            public static decimal input;
            public static decimal FtoC(decimal input)
            {
                return (input - 32) / System.Convert.ToDecimal(1.8);
            }
            public static decimal CtoF(decimal input)
            {
                return (input * System.Convert.ToDecimal(1.8) + 32);
            }
            public static decimal FtoK(decimal input)
            {
                return (input - 32) / System.Convert.ToDecimal(1.8) + System.Convert.ToDecimal(273.15);
            }
            public static decimal CtoK(decimal input)
            {
                return (input + System.Convert.ToDecimal(273.15));
            }
            public static decimal KtoC(decimal input)
            {
                return (input - System.Convert.ToDecimal(273.15));
            }
            public static decimal KtoF(decimal input)
            {
                return (input - System.Convert.ToDecimal(273.15) * System.Convert.ToDecimal(1.8)) + 32;
            }
        }
        private bool ValidInput()
        {
            if (!string.IsNullOrEmpty(Input.Text))
            {
                Conversion.input = System.Convert.ToDecimal(Input.Text);
                if (Regex.IsMatch(Conversion.input.ToString(), "^-?[0-9]{0,6}([.,][0-9]{1,2})?$"))
                {
                    return true;
                }
            }
            return false;
        }
        private void Convert_Click(object sender, EventArgs e)
        {
            if (ValidInput())
            {
                switch (Conversion.conversiontype)
                {
                    case 1:                    
                        {
                            Output.AppendText("Converting..." + Environment.NewLine);
                            Output.AppendText("Result: " + Conversion.input + "°F" + " = " + decimal.Truncate(Conversion.FtoC(System.Convert.ToDecimal(Conversion.input))) + "°C" + Environment.NewLine);
                            break;
                        }
                    case 2:
                        {
                            Output.AppendText("Converting..." + Environment.NewLine);
                            Output.AppendText("Result: " + Conversion.input + "°C" + " = " + decimal.Truncate(Conversion.CtoF(System.Convert.ToDecimal(Conversion.input))) + "°F" + Environment.NewLine);
                            break;
                        }
                    case 3:
                        {
                            Output.AppendText("Converting..." + Environment.NewLine);
                            Output.AppendText("Result: " + Conversion.input + "°F" + " = " + decimal.Truncate(Conversion.FtoK(System.Convert.ToDecimal(Conversion.input))) + "K" + Environment.NewLine);
                            break;
                        }
                    case 4:
                        {
                            Output.AppendText("Converting..." + Environment.NewLine);
                            Output.AppendText("Result: " + Conversion.input + "°C" + " = " + decimal.Truncate(Conversion.CtoK(System.Convert.ToDecimal(Conversion.input))) + "K" + Environment.NewLine);
                            break;
                        }
                    case 5:
                        {
                            Output.AppendText("Converting..." + Environment.NewLine);
                            Output.AppendText("Result: " + Conversion.input + "K" + " = " + decimal.Truncate(Conversion.KtoC(System.Convert.ToDecimal(Conversion.input))) + "°C" + Environment.NewLine);
                            break;
                        }
                    case 6:
                        {
                            Output.AppendText("Converting..." + Environment.NewLine);
                            Output.AppendText("Result: " + Conversion.input + "K" + " = " + decimal.Truncate(Conversion.KtoF(System.Convert.ToDecimal(Conversion.input))) + "°F" + Environment.NewLine);
                            break;
                        }
                }
            }
            else
            {
                MessageBox.Show("Please Enter A Valid Value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearOutput_Click(object sender, EventArgs e)
        {
            Output.Text = string.Empty;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Conversion.conversiontype = 1;
                Output.AppendText("Current Conversion: Fahrenheit to Celsius" + Environment.NewLine);
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                Conversion.conversiontype = 2;
                Output.AppendText("Current Conversion: Celsius to Fahrenheit" + Environment.NewLine);
            }
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                Conversion.conversiontype = 3;
                Output.AppendText("Current Conversion: Fahrenheit to Kelvin" + Environment.NewLine);
            }
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                Conversion.conversiontype = 4;
                Output.AppendText("Current Conversion: Celsius to Kelvin" + Environment.NewLine);
            }
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                Conversion.conversiontype = 5;
                Output.AppendText("Current Conversion: Kelvin to Celsius" + Environment.NewLine);
            }
        }
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                Conversion.conversiontype = 6;
                Output.AppendText("Current Conversion: Kelvin to Fahrenheit" + Environment.NewLine);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Output.AppendText("Idle..." + Environment.NewLine);
        }
    }
}
