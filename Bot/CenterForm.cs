using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bot
{
    public class CenterForm
    {
        private Form targetForm;
        private bool centeredOnce = false;

        // Конструктор, принимающий форму, которую нужно центрировать
        public CenterForm(Form form)
        {
            this.targetForm = form;

            // Подписка на события загрузки и показа формы
            this.targetForm.Load += TargetForm_Load;
            this.targetForm.Shown += TargetForm_Shown;
        }

        // Метод, вызываемый при загрузке формы
        private void TargetForm_Load(object sender, EventArgs e)
        {
            CenterToScreen(); // Центрируем форму один раз при загрузке
        }

        // Метод, вызываемый при показе формы
        private void TargetForm_Shown(object sender, EventArgs e)
        {
            if (!centeredOnce)
            {
                CenterToScreen(); // Центрируем форму
                centeredOnce = true; // Больше не центрируем, если форма уже показана
            }
        }

        // Метод для центрирования формы
        private void CenterToScreen()
        {
            Rectangle screenBounds = Screen.FromControl(targetForm).Bounds;
            targetForm.Location = new Point(
                (screenBounds.Width - targetForm.Width) / 2,
                (screenBounds.Height - targetForm.Height) / 2
            );
        }
    }
}