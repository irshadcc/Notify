using System;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Runtime.CompilerServices;
using System.Drawing;
using System.IO;

namespace NotifyV1
{
    public partial class Ava : Form
    {
        public static bool isAwake = false;
        private static SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
        private static SpeechRecognitionEngine startListening = new SpeechRecognitionEngine();

        int timeout = 0;

        private static SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        public Ava()
        {
            isAwake = true;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeSynthesizer();
            InitializeRecognizer();

            string reply = "Hi, I am Ava \r\n What can i do for you ? \r\n";
            SetText(reply);
            textBox1.SelectionLength = 0;

            synthesizer.SpeakAsync(reply);

            recognizer.RecognizeAsync(RecognizeMode.Multiple);
   
        }

        private Grammar BuildGrammar()
        {
            Choices commands = new Choices(File.ReadAllLines(@"Commands.txt"));

            GrammarBuilder gbuilder = new GrammarBuilder(commands);
            return new Grammar(gbuilder);

        }

        private void InitializeSynthesizer()
        {
            synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
            synthesizer.Volume = 100;
            synthesizer.Rate = 1;
            synthesizer.SetOutputToDefaultAudioDevice();

            synthesizer.SpeakStarted += Synthesizer_SpeakStarted;
            synthesizer.SpeakCompleted += Synthesizer_SpeakCompleted;
        }

        private void InitializeRecognizer()
        {
            Grammar grammar = BuildGrammar();
            recognizer.LoadGrammarAsync(grammar);
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.SpeechRecognized += Recognizer_SpeechRecognized;
            recognizer.SpeechDetected += Recognizer_SpeechDetected;
            recognizer.SpeechRecognitionRejected += Recognizer_SpeechRecognitionRejected;
            grammar = BuildGrammar();
            startListening.LoadGrammarAsync(grammar);
            startListening.SetInputToDefaultAudioDevice();
            startListening.SpeechRecognized += StartListening_SpeechRecognized;

        }

        private void StartListening_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            if(speech == "hey ava")
            {
                this.Show();
                startListening.RecognizeAsyncCancel();
                string reply = "Hi, I am Ava \r\n What can i do for you ? \r\n";
                SetText(reply);
                synthesizer.SpeakAsync(reply);
                recognizer.RecognizeAsync(RecognizeMode.Multiple);

            }
        }

        private void Recognizer_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            synthesizer.SpeakAsync("I am sorry. I don't understand this command.");
            pictureBox1.Enabled = false;
        }

        private void Recognizer_SpeechDetected(object sender, SpeechDetectedEventArgs e)
        {
            pictureBox1.Enabled = true;
        }

        private void Synthesizer_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            //pictureBox1.Refresh();
            pictureBox1.Enabled = false;

        }

        private void Synthesizer_SpeakStarted(object sender, SpeakStartedEventArgs e)
        {
            pictureBox1.Enabled = true;
        }

        private void timerSpeak_Tick(object sender, EventArgs e)
        {
            if (timeout == 10)
            {
                recognizer.RecognizeAsyncCancel();
            }
            else if (timeout == 11)
            {
                timerSpeak.Stop();
                this.Hide();
                startListening.RecognizeAsync(RecognizeMode.Multiple);
                timeout = 0;
            }
        }

        private void SetText(string s)
        {
            textBox1.Clear();
            textBox1.Text = s;

        }

        private void OpenNotebooks()
        {
            System.Diagnostics.Process.Start("https://biblography-6adfa.web.app/");
        }

        private void AddNote()
        {
            //this.Hide();
            AddNote save_dialog = new AddNote();
            save_dialog.Show();
            //this.Show();
        }

        private void AddSnip()
        {
            ScreenCapture snippingTool = new ScreenCapture();
            this.Hide();
            if (snippingTool.SetCanvas())
            {
                Image snip = snippingTool.GetSnapShot();
                SaveNote save_dialog = new SaveNote(snip);
                save_dialog.ShowDialog();
                this.Show();
            }
            else
            {
                this.Show();
            }
        }

        public static void IamHere()
        {
            synthesizer.SpeakAsync("I am already here.");
        }
        
        private void Recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            timeout = 0;
            pictureBox1.Enabled = false;
            string reply, text;
            string result = e.Result.Text;

            if(result == "hey ava" || result == "hi ava" || result == "hello ava")
            {
                reply = "Hello, How can i help you ? \r\n";
                SetText(reply);
                synthesizer.SpeakAsync(reply);

            }
            else if(result == "who are you" || result == "what are you")
            {
                reply = "I am Ava \r\n Your bibliophile companion \r\n";
                SetText(reply);
                synthesizer.SpeakAsync(reply);

            }
            else if(result == "what is the time now")
            {
                DateTime now = DateTime.Now;
                reply = string.Format("It is {0}", now.ToString("h mm tt"));
                text = string.Format("It is {0}\r\n", now.ToString("h mm tt"));
                SetText(text);
                synthesizer.SpeakAsync(reply);

            }
            else if(result == "hide yourself")
            {
                reply = "Ok";
                SetText(reply);
                synthesizer.SpeakAsync(reply);
                this.WindowState = FormWindowState.Minimized;
                //this.Hide();
            }
            else if (result == "show yourself")
            {
                //this.Show();
                reply = "I am here";
                this.WindowState = FormWindowState.Normal;
                this.BringToFront();
                textBox1.SelectionLength = 0;
                SetText(reply);
                synthesizer.SpeakAsync(reply);

            }
            else if (result == "close notify" || result == "quit notify" || result == "exit notify")
            {
                reply = "Closing Notify";
                SetText(reply);
                synthesizer.Speak(reply);
                recognizer.RecognizeAsyncStop();
                Application.Exit();

            }
            else if (result == "bye" || result == "good bye" || result == "ok bye" || result == "bye ava")
            {
                reply = "Good bye.";
                SetText(reply);
                synthesizer.Speak(reply);
                recognizer.RecognizeAsyncStop();
                isAwake = false;
                this.Dispose();

            }
            else if (result == "thanks" || result == "thank you")
            {
                reply = "You're most welcome !";
                SetText(reply);
                synthesizer.SpeakAsync(reply);

            }
            else if (result == "add note")
            {
                this.WindowState = FormWindowState.Minimized;
                AddNote();
            }
            else if (result == "snip note")
            {
                AddSnip();
            }
            else if (result == "open notebook")
            {
                OpenNotebooks();
            }
            
        }


    }
}
