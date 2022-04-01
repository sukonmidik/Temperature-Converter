using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace Temperature_Convertor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static decimal temperature;
        private bool ValidInput(decimal input)
        {
            var matches = Regex.Matches(tempinput.Text, "^-?[0-9]{1,4}([.,][0-9]{1,2})?$");
            foreach (Match match in matches )
            {
                return true;
            }
            return false;
        }
        private decimal ConvertTemp(decimal input)
        {
            if (radioButton1.Checked)
            {
                // F > C
                input = (input - 32) * 5 / 9;
                MessageBox.Show(temperature.ToString() +"°F" + " = " + decimal.Truncate(input * 100) / 100 + "°C", "Calculation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return input;
            }
            else if (radioButton2.Checked)
            {
                // C > F
                input = (input * Convert.ToDecimal(1.8) + 32);
                MessageBox.Show(temperature.ToString() + "°C" + " = " + decimal.Truncate(input * 100) / 100 + "°F", "Calculation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return input;
            }
            return 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                temperature = Convert.ToDecimal(tempinput.Text);
                if (ValidInput(temperature))
                {
                    ConvertTemp(temperature);
                }
                else
                {
                    MessageBox.Show("Please Enter A Value Between -9999.99 To 9999.99", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Select A Conversion Method.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
