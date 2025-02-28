using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SharpHook;
using SharpHook.Native;

namespace ScanFlashLink
{
    public partial class MainWindow : Window
    {
        private TcpListener _server;
        private EventSimulator _simulator;

        public MainWindow()
        {
            InitializeComponent();
            _simulator = new EventSimulator();
            StartServer();
        }

        private async void StartServer()
        {
            try
            {
                _server = new TcpListener(IPAddress.Any, 12345);
                _server.Start();
                AppendLog("Serveur démarré. En attente de connexions...");

                while (true)
                {
                    TcpClient client = await _server.AcceptTcpClientAsync();
                    _ = Task.Run(() => HandleClient(client));
                }
            }
            catch (Exception ex)
            {
                AppendLog($"Erreur serveur : {ex.Message}");
            }
        }

        private async void HandleClient(TcpClient client)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                string receivedCode = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

                AppendLog($"Code reçu : {receivedCode}");

                // Simuler la saisie clavier avec SharpHook
                SimulateKeystrokes(receivedCode);

                client.Close();
            }
            catch (Exception ex)
            {
                AppendLog($"Erreur client : {ex.Message}");
            }
        }

        private void SimulateKeystrokes(string text)
        {
            Task.Run(() =>
            {
                foreach (char c in text)
                {
                    SimulateKeyPress(c);
                }

                // Simuler la touche "Entrée" après le texte
                _simulator.SimulateKeyPress(KeyCode.VcEnter);
            });
        }

        private void SimulateKeyPress(char key)
        {
            KeyCode keyCode = ConvertCharToKeyCode(key);
            if (keyCode != KeyCode.VcUndefined)
            {
                _simulator.SimulateKeyPress(keyCode);
            }
        }

        private KeyCode ConvertCharToKeyCode(char key)
        {
            return key switch
            {
                '0' => KeyCode.Vc0,
                '1' => KeyCode.Vc1,
                '2' => KeyCode.Vc2,
                '3' => KeyCode.Vc3,
                '4' => KeyCode.Vc4,
                '5' => KeyCode.Vc5,
                '6' => KeyCode.Vc6,
                '7' => KeyCode.Vc7,
                '8' => KeyCode.Vc8,
                '9' => KeyCode.Vc9,

                'a' => KeyCode.VcA,
                'b' => KeyCode.VcB,
                'c' => KeyCode.VcC,
                'd' => KeyCode.VcD,
                'e' => KeyCode.VcE,
                'f' => KeyCode.VcF,
                'g' => KeyCode.VcG,
                'h' => KeyCode.VcH,
                'i' => KeyCode.VcI,
                'j' => KeyCode.VcJ,
                'k' => KeyCode.VcK,
                'l' => KeyCode.VcL,
                'm' => KeyCode.VcM,
                'n' => KeyCode.VcN,
                'o' => KeyCode.VcO,
                'p' => KeyCode.VcP,
                'q' => KeyCode.VcQ,
                'r' => KeyCode.VcR,
                's' => KeyCode.VcS,
                't' => KeyCode.VcT,
                'u' => KeyCode.VcU,
                'v' => KeyCode.VcV,
                'w' => KeyCode.VcW,
                'x' => KeyCode.VcX,
                'y' => KeyCode.VcY,
                'z' => KeyCode.VcZ,

                'A' => KeyCode.VcA,
                'B' => KeyCode.VcB,
                'C' => KeyCode.VcC,
                'D' => KeyCode.VcD,
                'E' => KeyCode.VcE,
                'F' => KeyCode.VcF,
                'G' => KeyCode.VcG,
                'H' => KeyCode.VcH,
                'I' => KeyCode.VcI,
                'J' => KeyCode.VcJ,
                'K' => KeyCode.VcK,
                'L' => KeyCode.VcL,
                'M' => KeyCode.VcM,
                'N' => KeyCode.VcN,
                'O' => KeyCode.VcO,
                'P' => KeyCode.VcP,
                'Q' => KeyCode.VcQ,
                'R' => KeyCode.VcR,
                'S' => KeyCode.VcS,
                'T' => KeyCode.VcT,
                'U' => KeyCode.VcU,
                'V' => KeyCode.VcV,
                'W' => KeyCode.VcW,
                'X' => KeyCode.VcX,
                'Y' => KeyCode.VcY,
                'Z' => KeyCode.VcZ,

                '-' => KeyCode.VcMinus,
                '=' => KeyCode.VcEquals,
                ' ' => KeyCode.VcSpace,
                '.' => KeyCode.VcPeriod,
                ',' => KeyCode.VcComma,
                '/' => KeyCode.VcSlash,
                '\\' => KeyCode.VcBackslash,
                ';' => KeyCode.VcSemicolon,

                _ => KeyCode.VcUndefined,
            };
        }

        private void AppendLog(string message)
        {
            Dispatcher.Invoke(() => txtLogs.AppendText($"{message}\n"));
        }
    }
}
