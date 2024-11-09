using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bot
{
    public class ButtonRoundEffect
    {
        private Button targetButton;
        private int borderRadius;

        // Конструктор для подключения эффекта к кнопке
        public ButtonRoundEffect(Button button, int radius = 30)
        {
            this.targetButton = button;
            this.borderRadius = radius;

            // Подключаемся к событию рисования
            this.targetButton.Paint += TargetButton_Paint;
        }

        // Свойство для изменения радиуса скругления
        public int BorderRadius
        {
            get => borderRadius;
            set
            {
                borderRadius = value;
                targetButton.Invalidate(); // Перерисовываем кнопку при изменении радиуса
            }
        }

        private void TargetButton_Paint(object sender, PaintEventArgs e)
        {
            // Создание графического пути для скруглённых углов
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(new Rectangle(0, 0, borderRadius, borderRadius), 180, 90);
                path.AddArc(new Rectangle(targetButton.Width - borderRadius, 0, borderRadius, borderRadius), 270, 90);
                path.AddArc(new Rectangle(targetButton.Width - borderRadius, targetButton.Height - borderRadius, borderRadius, borderRadius), 0, 90);
                path.AddArc(new Rectangle(0, targetButton.Height - borderRadius, borderRadius, borderRadius), 90, 90);
                path.CloseFigure();

                targetButton.Region = new Region(path); // Применяем форму к кнопке

                // Заполнение фона кнопки
                using (SolidBrush brush = new SolidBrush(targetButton.BackColor))
                {
                    e.Graphics.FillPath(brush, path);
                }

                // Отрисовка текста
                TextRenderer.DrawText(e.Graphics, targetButton.Text, targetButton.Font, targetButton.ClientRectangle, targetButton.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }
    }
}
