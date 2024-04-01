using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Algoritm;
using Microsoft.Win32;


namespace WpfApp1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow 
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(txtMessage.Text) && !string.IsNullOrWhiteSpace(txtKey.Text) && !string.IsNullOrWhiteSpace(txtKey2.Text))
        {
            string input = txtKey.Text;
            string input2 = txtKey2.Text;
            string message = txtMessage.Text;
            int[] key2 = new int[26];
            int[] key = new int[26];
            
            if (input2.Contains(",") && input.Contains(","))
            {
                key2 = Convert(input2);
                key = Convert(input);
                key = StaticMethod.CombineKeys(key, key2);
                Cesar cesar1 = new Cesar(message, key);
                string criptoMessage = cesar1.Cripto();
                MessageBox.Show("Mesajul criptat: " + criptoMessage);
                txtDecodedMessage.Text = criptoMessage;
            } 
            else if (input.Contains(","))
            {
                key = Convert(input);
                if (int.TryParse(input2, out int key5))
                {
                    key2 = new int[] { key5 };
                   key = StaticMethod.CombineKeys(key, key2);
                    Cesar cesar1 = new Cesar(txtMessage.Text, key);
                    string criptoMessage = cesar1.Cripto();
                    MessageBox.Show("Mesajul criptat: " + criptoMessage);
                    txtDecodedMessage.Text = criptoMessage;
                }
                else
                {
                    Cesar cesar1 = new Cesar(txtMessage.Text, key,input2);
                    string criptoMessage = cesar1.Cripto();
                    MessageBox.Show("Mesajul criptat: " + criptoMessage);
                    txtDecodedMessage.Text = criptoMessage;
                }
                
            }
            else if (input2.Contains(","))
            {
                key = Convert(input2);
                if (int.TryParse(input, out int key5))
                {
                    key2 = new int[] { key5 };
                   
                    key = StaticMethod.CombineKeys(key, key2);
                    Cesar cesar1 = new Cesar(txtMessage.Text, key);
                    string criptoMessage = cesar1.Cripto();
                    MessageBox.Show("Mesajul criptat: " + criptoMessage);
                    txtDecodedMessage.Text = criptoMessage;
                }
                else
                {
                    Cesar cesar1 = new Cesar(txtMessage.Text, key,input);
                    string criptoMessage = cesar1.Cripto();
                    MessageBox.Show("Mesajul criptat: " + criptoMessage);
                    txtDecodedMessage.Text = criptoMessage;
                }
            }
            else if (!int.TryParse(input, out int k) && !int.TryParse(input2, out int k2))
            {
                key = StaticMethod.ConverKey(input);
                Cesar cesar1 = new Cesar(txtMessage.Text, key, input);
                string criptoMessage = cesar1.Cripto();
                MessageBox.Show("Mesajul criptat: " + criptoMessage);
                txtDecodedMessage.Text = criptoMessage;
                
            }
            else
            {
                if (int.TryParse(input, out int key1) && int.TryParse(input2,out int key3))
                {
                    key = new int[] { key1 };
                    key2 = new int[] { key3 };
                    key = StaticMethod.CombineKeys(key, key2);
                    Cesar cesar1 = new Cesar(txtMessage.Text, key);
                    string criptoMessage = cesar1.Cripto();
                    MessageBox.Show("Mesajul criptat: " + criptoMessage);
                    txtDecodedMessage.Text = criptoMessage;
                }
                
                if (int.TryParse(input, out int key4))
                {
                    key = new int[] { key4 };
                    Cesar cesar1 = new Cesar(txtMessage.Text, key, input2);
                    string criptoMessage = cesar1.Cripto();
                    MessageBox.Show("Mesajul criptat: " + criptoMessage);
                    txtDecodedMessage.Text = criptoMessage;
                }
                else if (int.TryParse(input2, out int key5))
                {
                    key2 = new int[] { key5 };
                    key = StaticMethod.ConverKey(input);
                    key = StaticMethod.CombineKeys(key, key2);
                    Cesar cesar1 = new Cesar(txtMessage.Text, key);
                    string criptoMessage = cesar1.Cripto();
                    MessageBox.Show("Mesajul criptat: " + criptoMessage);
                    txtDecodedMessage.Text = criptoMessage;
                    
                }
        }
        }
        else if (!string.IsNullOrWhiteSpace(txtMessage.Text) && !string.IsNullOrWhiteSpace(txtKey.Text))
        {
            string input = txtKey.Text;
            string message = txtMessage.Text;
            int[] key = new int[26];

            if (input.Contains(","))
            {

                key = Convert(input);
                    Cesar cesar = new Cesar(txtMessage.Text, key);
                    string criptoMessage2 = cesar.Cripto();
                    MessageBox.Show("Mesajul criptat: " + criptoMessage2);
                    txtDecodedMessage.Text = criptoMessage2;
                
            }
            else if (int.TryParse(input, out int k))
            {
                key = new int[] { k };
                Cesar cesar1 = new Cesar(message, key);
                string criptoMessage = cesar1.Cripto();
                MessageBox.Show("Mesajul criptat: " + criptoMessage);
                txtDecodedMessage.Text = criptoMessage;
                
            }

            else
            
            {
                
                key = StaticMethod.ConverKey(input);
                Cesar cesar1 = new Cesar(message, key);
                string criptoMessage = cesar1.Cripto();
                MessageBox.Show("Mesajul criptat: " + criptoMessage);
                txtDecodedMessage.Text = criptoMessage;
            }
        }
            else
        {
            MessageBox.Show("Inputul mesajului si cel putin prima cheie trebuie completate.");
        }
   
    }

    private int[] Convert(string intput2)
    {
       
       
            string[] segments = intput2.Split(',');
            int[] key2 = new int[segments.Length];
            bool validInput = true;
            for (int i = 0; i < segments.Length; i++)
            {
                if (int.TryParse(segments[i], out int number))
                {
                    key2[i] = number;
                }
              
            }
            
        

        return key2;
        }

        
        
    
    
  
    private void Mesage(object sender, TextChangedEventArgs e)
    {
        TextBox textBox = (TextBox)sender;
        string text = textBox.Text;
        
    }

    private void Key(object sender, TextChangedEventArgs e)
    {
        TextBox textBox = (TextBox)sender;
        string text = textBox.Text;

       
    }



        private void txtDecodedMessage_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(txtMessage.Text) && !string.IsNullOrWhiteSpace(txtKey.Text) && !string.IsNullOrWhiteSpace(txtKey2.Text))
        {
            string input = txtKey.Text;
            string input2 = txtKey2.Text;
            string message = txtMessage.Text;
            int[] key2 = new int[26];
            int[] key = new int[26];
            
            if (input2.Contains(",") && input.Contains(","))
            {
                key2 = Convert(input2);
                key = Convert(input);
                key = StaticMethod.CombineKeys(key, key2);
                Cesar cesar1 = new Cesar(message, key);
                string criptoMessage = cesar1.Decripto();
                MessageBox.Show("Mesajul decriptat: " + criptoMessage);
                txtDecodedMessage.Text = criptoMessage;

            }
            
            else if (input.Contains(","))
            {
                key = Convert(input);
                if (int.TryParse(input2, out int key5))
                {
                    key2 = new int[] { key5 };
                    key = StaticMethod.CombineKeys(key, key2);
                    Cesar cesar1 = new Cesar(txtMessage.Text, key);
                    string criptoMessage = cesar1.Decripto();
                    MessageBox.Show("Mesajul criptat: " + criptoMessage);
                    txtDecodedMessage.Text = criptoMessage;
                }
                else
                {
                    Cesar cesar1 = new Cesar(txtMessage.Text, key,input2);
                    string criptoMessage = cesar1.Decripto();
                    MessageBox.Show("Mesajul criptat: " + criptoMessage);
                    txtDecodedMessage.Text = criptoMessage;
                }
                
            }
            else if (input2.Contains(","))
            {
                key = Convert(input2);
                if (int.TryParse(input, out int key5))
                {
                    key2 = new int[] { key5 };
                   
                    key = StaticMethod.CombineKeys(key, key2);
                    Cesar cesar1 = new Cesar(txtMessage.Text, key);
                    string criptoMessage = cesar1.Decripto();
                    MessageBox.Show("Mesajul criptat: " + criptoMessage);
                    txtDecodedMessage.Text = criptoMessage;
                }
                else
                {
                    Cesar cesar1 = new Cesar(txtMessage.Text, key,input);
                    string criptoMessage = cesar1.Decripto();
                    MessageBox.Show("Mesajul criptat: " + criptoMessage);
                    txtDecodedMessage.Text = criptoMessage;
                }
            }
            else if (!int.TryParse(input, out int k) && !int.TryParse(input2, out int k2))
            {
                Cesar cesar1 = new Cesar(txtMessage.Text, input, input2);
                string criptoMessage = cesar1.Decripto();
                MessageBox.Show("Mesajul decriptat: " + criptoMessage);
                txtDecodedMessage.Text = criptoMessage;
            }
            else
            {
                if (int.TryParse(input, out int key1) && int.TryParse(input2,out int key3))
                {
                    key = new int[] { key1 };
                    key2 = new int[] { key3 };
                    key = StaticMethod.CombineKeys(key, key2);
                    Cesar cesar1 = new Cesar(txtMessage.Text, key);
                    string criptoMessage = cesar1.Decripto();
                    MessageBox.Show("Mesajul decriptat: " + criptoMessage);
                    txtDecodedMessage.Text = criptoMessage;
                }
                else if (int.TryParse(input, out int key4) )
                {
                    key = new int[] { key4 };
                    // key2 = StaticMethod.ConverKey(input2);
                    // key = StaticMethod.CombineKeys(key, key2);
                    Cesar cesar1 = new Cesar(txtMessage.Text, key,input2);
                    string criptoMessage = cesar1.Decripto();
                    MessageBox.Show("Mesajul criptat: " + criptoMessage);
                    txtDecodedMessage.Text = criptoMessage;
                }
                else if (int.TryParse(input2, out int key5))
                {
                    key2 = new int[] { key5 };
                    key = StaticMethod.ConverKey(input);
                    key = StaticMethod.CombineKeys(key, key2);
                    Cesar cesar1 = new Cesar(txtMessage.Text, key);
                    string criptoMessage = cesar1.Decripto();
                    MessageBox.Show("Mesajul decriptat: " + criptoMessage);
                    txtDecodedMessage.Text = criptoMessage;
                    
                }
                else if (!int.TryParse(input2, out  key5))
                {
                    
                    
                    Cesar cesar1 = new Cesar(txtMessage.Text, key,input2);
                    string criptoMessage = cesar1.Decripto();
                    MessageBox.Show("Mesajul decriptat: " + criptoMessage);
                    txtDecodedMessage.Text = criptoMessage;
                    
                }
                    else if (!int.TryParse(input, out  key4))
                {
                    
                    
                    Cesar cesar1 = new Cesar(txtMessage.Text, key,input);
                    string criptoMessage = cesar1.Decripto();
                    MessageBox.Show("Mesajul decriptat: " + criptoMessage);
                    txtDecodedMessage.Text = criptoMessage;
                
                
                
         }
        }
        }
        else if (!string.IsNullOrWhiteSpace(txtMessage.Text) && !string.IsNullOrWhiteSpace(txtKey.Text))
        {
            string input = txtKey.Text;
            string message = txtMessage.Text;
            int[] key = new int[26];

            if (input.Contains(","))
            {

                key = Convert(input);
                Cesar cesar = new Cesar(txtMessage.Text, key);
                string criptoMessage2 = cesar.Decripto();
                MessageBox.Show("Mesajul decriptat: " + criptoMessage2);
                txtDecodedMessage.Text = criptoMessage2;
                
            }
            else if (int.TryParse(input, out int k))
            {
                key = new int[] { k };
                Cesar cesar1 = new Cesar(message, key);
                string criptoMessage = cesar1.Decripto();
                MessageBox.Show("Mesajul decriptat: " + criptoMessage);
                txtDecodedMessage.Text = criptoMessage;
                
            }

            else
            
            {
                // Inputul conține caractere non-numerice, deci utilizăm constructorul corespunzător
                key = StaticMethod.ConverKey(input);
                Cesar cesar1 = new Cesar(message, key);
                string criptoMessage = cesar1.Decripto();
                MessageBox.Show("Mesajul decriptat: " + criptoMessage);
                txtDecodedMessage.Text = criptoMessage;
            }
        }

            
        
        else
        {
            MessageBox.Show("Inputul mesajului si cel putin prima cheie trebuie completate.");
        }
    }



    private void Image_MouseDown(object sender, MouseButtonEventArgs e)
    {
        MessageBox.Show("Мяу🐱");
    }
    private void Coffee(object sender, MouseButtonEventArgs e)
    {
        MessageBox.Show("Это первая чашка,честно😇☕");
    }
    
    
    //Fisiere 
    private void btnOpenFile_Click(object sender, RoutedEventArgs e)
    {
       
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                txtFilePath.Text = openFileDialog.FileName;
                string fileContent = File.ReadAllText(openFileDialog.FileName);
                
                txtMessage.Text = fileContent;
            }
        }
    private void btnModifyFile_Click(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(txtDecodedMessage.Text) && !string.IsNullOrEmpty(txtFilePath.Text))
        {
            File.WriteAllText(txtFilePath.Text, txtDecodedMessage.Text);
            MessageBox.Show("Mesajul a fost scris în fișier.");
        }
        else
        {
            MessageBox.Show("Asigurați-vă că ați selectat un fișier și că aveți un mesaj pentru a scrie în fișier.");
        }
    }
    }












