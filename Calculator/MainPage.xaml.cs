using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Calculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        double prevValue = 0;
        String operationPerformed = "";
        bool checkReplace = true;
        bool checkOperator = false;
        bool checkDot = false;

       public MainPage()
        {
            this.InitializeComponent();
        }

        private void button_click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (checkReplace)
            {
                TextBlockChange.Text = String.Empty;
                TextBlockChange.Text += button.Content;
                checkReplace = false;
                if (Double.Parse(TextBlockChange.Text) - Math.Floor(Double.Parse(TextBlockChange.Text)) > 0)
                {
                    checkDot = true;
                }
                else
                {
                    checkDot = false;
                }
            }
            else if(!checkReplace)
            {
                TextBlockChange.Text += button.Content;
                if (Double.Parse(TextBlockChange.Text) - Math.Floor(Double.Parse(TextBlockChange.Text)) > 0)
                {
                    checkDot = true;
                }
                else
                {
                    checkDot = false;
                }
            }            
        }

        private void dot_click(object sender, RoutedEventArgs e)
        {
            if(!checkDot)
            {
                TextBlockChange.Text += ".";
                checkDot = true;
                checkReplace = false;
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            TextBlockChange.Text = "0";
            checkReplace = true;
            checkOperator = false;
            checkDot = false;
        }

        private void operator_click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if(!checkOperator)
            {
                prevValue = Double.Parse(TextBlockChange.Text);
                operationPerformed = (String)button.Content;
                checkReplace = true;
                checkOperator = true;
            }
            else if(checkOperator&&checkReplace)
            {
                prevValue = Double.Parse(TextBlockChange.Text);
                operationPerformed = (String)button.Content;
            }
            else if(checkOperator&&!checkReplace)
            {
                switch (operationPerformed)
                {
                    case "+":
                        TextBlockChange.Text = (prevValue + Double.Parse(TextBlockChange.Text)).ToString();
                        break;
                    case "-":
                        TextBlockChange.Text = (prevValue - Double.Parse(TextBlockChange.Text)).ToString();
                        break;
                    case "*":
                        TextBlockChange.Text = (prevValue * Double.Parse(TextBlockChange.Text)).ToString();
                        break;
                    case "/":
                        TextBlockChange.Text = (prevValue / Double.Parse(TextBlockChange.Text)).ToString();
                        break;
                    default:
                        TextBlockChange.Text = "Error";
                        break;
                }
                prevValue = Double.Parse(TextBlockChange.Text);
                operationPerformed = (String)button.Content;
                checkReplace = true;
            }
            if (Double.Parse(TextBlockChange.Text) - Math.Floor(Double.Parse(TextBlockChange.Text)) > 0)
            {
                checkDot = true;
            }
            else
            {
                checkDot = false;
            }
        }

        private void SymEqu_Click(object sender, RoutedEventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    TextBlockChange.Text = (prevValue + Double.Parse(TextBlockChange.Text)).ToString();
                    break;
                case "-":
                    TextBlockChange.Text = (prevValue - Double.Parse(TextBlockChange.Text)).ToString();
                    break;
                case "*":
                    TextBlockChange.Text = (prevValue * Double.Parse(TextBlockChange.Text)).ToString();
                    break;
                case "/":
                    TextBlockChange.Text = (prevValue / Double.Parse(TextBlockChange.Text)).ToString();
                    break;
                default:
                    TextBlockChange.Text = "Error";
                    break;
            }
            checkOperator = false;
            checkReplace = true;
            if (Double.Parse(TextBlockChange.Text)-Math.Floor(Double.Parse(TextBlockChange.Text)) >0)
            {
                checkDot = true;
            }
            else
            {
                checkDot = false;
            }
        }
    }
}