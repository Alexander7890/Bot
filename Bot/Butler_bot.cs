using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Windows.Forms;

namespace Bot
{
    public partial class Butler_bot : Form
    {
        private Process _javaProcess;
        public Butler_bot()
        {
            InitializeComponent();
            // Застосування ефекту заокруглення до існуючих кнопок
            var roundEffect1 = new ButtonRoundEffect(button1, 20);
            var roundEffect2 = new ButtonRoundEffect(button2, 20);
            // Підписка на подію закриття форми
            this.FormClosing += FormClos;

            // Застосування центрування форми
            CenterForm centerForm = new CenterForm(this);
        }

        // Обробник події закриття форми
        private void FormClos(object sender, FormClosingEventArgs e)
        {
            // Завершити роботу програми
            System.Windows.Forms.Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Новый путь к JAR-файлу
                string jarFilePath = "C:\\Users\\sasha\\source\\repos\\Bot\\Bot\\Start_Bot\\Bot1-1.0-SNAPSHOT-jar-with-dependencies.jar";

                // Запускаем файл через Java
                var startInfo = new ProcessStartInfo
                {
                    FileName = "java",
                    Arguments = $"-jar \"{jarFilePath}\"",
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                _javaProcess = Process.Start(startInfo);
                MessageBox.Show("Bot запущен!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при запуске Bot: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Находим и принудительно завершаем все процессы Java
                var javaProcesses = Process.GetProcessesByName("java");
                foreach (var process in javaProcesses)
                {
                    process.Kill();
                }

                MessageBox.Show("Процессы Java остановлены.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при остановке Java: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Butler_bot_Load(object sender, EventArgs e)
        {

        }
    }
}
