
namespace TuppersFormula
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.radioButtonDraw = new System.Windows.Forms.RadioButton();
            this.radioButtonErase = new System.Windows.Forms.RadioButton();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.labelWait = new System.Windows.Forms.Label();
            this.buttonNegate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonLoadFormula = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonRandomNumber = new System.Windows.Forms.Button();
            this.buttonFlipX = new System.Windows.Forms.Button();
            this.buttonFlipY = new System.Windows.Forms.Button();
            this.radioButtonRectangleDraw = new System.Windows.Forms.RadioButton();
            this.radioButtonRectangleErase = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(15, 231);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(848, 136);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Location = new System.Drawing.Point(15, 34);
            this.textBoxNumber.Multiline = true;
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(848, 100);
            this.textBoxNumber.TabIndex = 1;
            this.textBoxNumber.Text = "0";
            this.textBoxNumber.TextChanged += new System.EventHandler(this.NumberChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Graph";
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelError.ForeColor = System.Drawing.Color.White;
            this.labelError.Location = new System.Drawing.Point(12, 148);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(179, 13);
            this.labelError.TabIndex = 4;
            this.labelError.Text = "Should be a positive integer number!";
            // 
            // radioButtonDraw
            // 
            this.radioButtonDraw.AutoSize = true;
            this.radioButtonDraw.Checked = true;
            this.radioButtonDraw.Location = new System.Drawing.Point(54, 206);
            this.radioButtonDraw.Name = "radioButtonDraw";
            this.radioButtonDraw.Size = new System.Drawing.Size(50, 17);
            this.radioButtonDraw.TabIndex = 6;
            this.radioButtonDraw.TabStop = true;
            this.radioButtonDraw.Text = "Draw";
            this.radioButtonDraw.UseVisualStyleBackColor = true;
            this.radioButtonDraw.CheckedChanged += new System.EventHandler(this.DrawingStyleCheckedChanged);
            // 
            // radioButtonErase
            // 
            this.radioButtonErase.AutoSize = true;
            this.radioButtonErase.Location = new System.Drawing.Point(110, 206);
            this.radioButtonErase.Name = "radioButtonErase";
            this.radioButtonErase.Size = new System.Drawing.Size(52, 17);
            this.radioButtonErase.TabIndex = 7;
            this.radioButtonErase.Text = "Erase";
            this.radioButtonErase.UseVisualStyleBackColor = true;
            this.radioButtonErase.CheckedChanged += new System.EventHandler(this.DrawingStyleCheckedChanged);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // labelWait
            // 
            this.labelWait.AutoSize = true;
            this.labelWait.BackColor = System.Drawing.SystemColors.Control;
            this.labelWait.ForeColor = System.Drawing.Color.Blue;
            this.labelWait.Location = new System.Drawing.Point(12, 161);
            this.labelWait.Name = "labelWait";
            this.labelWait.Size = new System.Drawing.Size(144, 13);
            this.labelWait.TabIndex = 8;
            this.labelWait.Text = "Waiting for the end of input...";
            // 
            // buttonNegate
            // 
            this.buttonNegate.Location = new System.Drawing.Point(15, 379);
            this.buttonNegate.Name = "buttonNegate";
            this.buttonNegate.Size = new System.Drawing.Size(93, 23);
            this.buttonNegate.TabIndex = 9;
            this.buttonNegate.Text = "Negate Graph";
            this.buttonNegate.UseVisualStyleBackColor = true;
            this.buttonNegate.Click += new System.EventHandler(this.buttonNegate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(752, 379);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Move Graph";
            // 
            // buttonLeft
            // 
            this.buttonLeft.Location = new System.Drawing.Point(709, 407);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(46, 23);
            this.buttonLeft.TabIndex = 11;
            this.buttonLeft.Text = "←";
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.Click += new System.EventHandler(this.buttonLeft_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Location = new System.Drawing.Point(761, 395);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(46, 23);
            this.buttonUp.TabIndex = 12;
            this.buttonUp.Text = "↑";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonRight
            // 
            this.buttonRight.Location = new System.Drawing.Point(813, 407);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(46, 23);
            this.buttonRight.TabIndex = 13;
            this.buttonRight.Text = "→";
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.Click += new System.EventHandler(this.buttonRight_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.Location = new System.Drawing.Point(761, 424);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(46, 23);
            this.buttonDown.TabIndex = 14;
            this.buttonDown.Text = "↓";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonLoadFormula
            // 
            this.buttonLoadFormula.Location = new System.Drawing.Point(733, 203);
            this.buttonLoadFormula.Name = "buttonLoadFormula";
            this.buttonLoadFormula.Size = new System.Drawing.Size(130, 23);
            this.buttonLoadFormula.TabIndex = 15;
            this.buttonLoadFormula.Text = "Load Tupper\'s Formula";
            this.buttonLoadFormula.UseVisualStyleBackColor = true;
            this.buttonLoadFormula.Click += new System.EventHandler(this.buttonLoadFormula_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(15, 424);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(93, 23);
            this.buttonClear.TabIndex = 16;
            this.buttonClear.Text = "Clear Graph";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonRandomNumber
            // 
            this.buttonRandomNumber.Location = new System.Drawing.Point(713, 7);
            this.buttonRandomNumber.Name = "buttonRandomNumber";
            this.buttonRandomNumber.Size = new System.Drawing.Size(150, 21);
            this.buttonRandomNumber.TabIndex = 17;
            this.buttonRandomNumber.Text = "Generate Random Number";
            this.buttonRandomNumber.UseVisualStyleBackColor = true;
            this.buttonRandomNumber.Click += new System.EventHandler(this.buttonRandomNumber_Click);
            // 
            // buttonFlipX
            // 
            this.buttonFlipX.Location = new System.Drawing.Point(136, 379);
            this.buttonFlipX.Name = "buttonFlipX";
            this.buttonFlipX.Size = new System.Drawing.Size(94, 23);
            this.buttonFlipX.TabIndex = 18;
            this.buttonFlipX.Text = "Flip Horizontally";
            this.buttonFlipX.UseVisualStyleBackColor = true;
            this.buttonFlipX.Click += new System.EventHandler(this.buttonFlipX_Click);
            // 
            // buttonFlipY
            // 
            this.buttonFlipY.Location = new System.Drawing.Point(136, 408);
            this.buttonFlipY.Name = "buttonFlipY";
            this.buttonFlipY.Size = new System.Drawing.Size(94, 23);
            this.buttonFlipY.TabIndex = 19;
            this.buttonFlipY.Text = "Flip Vertically";
            this.buttonFlipY.UseVisualStyleBackColor = true;
            this.buttonFlipY.Click += new System.EventHandler(this.buttonFlipY_Click);
            // 
            // radioButtonRectangleDraw
            // 
            this.radioButtonRectangleDraw.AutoSize = true;
            this.radioButtonRectangleDraw.Location = new System.Drawing.Point(168, 206);
            this.radioButtonRectangleDraw.Name = "radioButtonRectangleDraw";
            this.radioButtonRectangleDraw.Size = new System.Drawing.Size(102, 17);
            this.radioButtonRectangleDraw.TabIndex = 20;
            this.radioButtonRectangleDraw.Text = "Rectangle Draw";
            this.radioButtonRectangleDraw.UseVisualStyleBackColor = true;
            this.radioButtonRectangleDraw.CheckedChanged += new System.EventHandler(this.DrawingStyleCheckedChanged);
            // 
            // radioButtonRectangleErase
            // 
            this.radioButtonRectangleErase.AutoSize = true;
            this.radioButtonRectangleErase.Location = new System.Drawing.Point(276, 206);
            this.radioButtonRectangleErase.Name = "radioButtonRectangleErase";
            this.radioButtonRectangleErase.Size = new System.Drawing.Size(104, 17);
            this.radioButtonRectangleErase.TabIndex = 21;
            this.radioButtonRectangleErase.Text = "Rectangle Erase";
            this.radioButtonRectangleErase.UseVisualStyleBackColor = true;
            this.radioButtonRectangleErase.CheckedChanged += new System.EventHandler(this.DrawingStyleCheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 459);
            this.Controls.Add(this.radioButtonRectangleErase);
            this.Controls.Add(this.radioButtonRectangleDraw);
            this.Controls.Add(this.buttonFlipY);
            this.Controls.Add(this.buttonFlipX);
            this.Controls.Add(this.buttonRandomNumber);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonLoadFormula);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonNegate);
            this.Controls.Add(this.labelWait);
            this.Controls.Add(this.radioButtonErase);
            this.Controls.Add(this.radioButtonDraw);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "TuppersFormula";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.RadioButton radioButtonDraw;
        private System.Windows.Forms.RadioButton radioButtonErase;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label labelWait;
        private System.Windows.Forms.Button buttonNegate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonLoadFormula;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonRandomNumber;
        private System.Windows.Forms.Button buttonFlipX;
        private System.Windows.Forms.Button buttonFlipY;
        private System.Windows.Forms.RadioButton radioButtonRectangleDraw;
        private System.Windows.Forms.RadioButton radioButtonRectangleErase;
    }
}

