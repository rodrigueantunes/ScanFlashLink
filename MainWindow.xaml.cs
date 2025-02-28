using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Runtime.InteropServices;
using System.Threading;

namespace ScanFlashLink
{
    public partial class MainWindow : Window
    {
        private TcpListener _server;

        public MainWindow()
        {
            InitializeComponent();
            txtIpDisplay.Text = GetLocalIPAddress();
            StartServer();
        }

        private async void StartServer()
        {
            try
            {
                _server = new TcpListener(IPAddress.Any, 12345);
                _server.Start();
                AppendLog($"Serveur démarré sur {txtIpDisplay.Text}:12345. En attente de connexions...");

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
                using NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                string receivedCode = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

                // Ajouter dans txtLogs exactement comme reçu
                Dispatcher.Invoke(() => AppendLog(receivedCode));

                // Simuler la saisie clavier avec le texte EXACTEMENT comme affiché
                Dispatcher.Invoke(() => CopyPasteToActiveWindow(receivedCode));
            }
            catch (Exception ex)
            {
                AppendLog($"Erreur client : {ex.Message}");
            }
        }

        private void CopyPasteToActiveWindow(string text)
        {
            Task.Run(() =>
            {
                // Copier dans le presse-papiers depuis le thread principal
                Dispatcher.Invoke(() => Clipboard.SetText(text));

                // Attendre un court instant pour éviter les erreurs
                Thread.Sleep(100);

                // Simuler Ctrl+V (coller le texte dans la fenêtre active)
                SimulateKeyPress(KeyCode.LeftControl, KeyCode.V);
                Thread.Sleep(100);

                // Ajouter "Entrée" après la saisie
                SimulateKeyPress(KeyCode.Enter);
            });
        }

        private static void SimulateKeyPress(params KeyCode[] keys)
        {
            foreach (var key in keys)
            {
                keybd_event((byte)key, 0, 0, 0); // Appuie sur la touche
            }

            foreach (var key in keys)
            {
                keybd_event((byte)key, 0, 2, 0); // Relâchement de la touche
            }
        }

        private static string GetLocalIPAddress()
        {
            try
            {
                using Socket socket = new(AddressFamily.InterNetwork, SocketType.Dgram, 0);
                socket.Connect("8.8.8.8", 65530);
                return (socket.LocalEndPoint as IPEndPoint)?.Address.ToString() ?? "Non disponible";
            }
            catch
            {
                return "Non disponible";
            }
        }

        private void AppendLog(string message)
        {
            Dispatcher.Invoke(() => txtLogs.AppendText($"{message}\n"));
        }

        // Simuler un appui clavier bas niveau
        [DllImport("user32.dll", SetLastError = true)]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        private enum KeyCode : byte
        {
            Enter = 0x0D,
            LeftControl = 0xA2,
            V = 0x56
        }
    }
}
