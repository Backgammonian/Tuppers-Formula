using System;
using System.Numerics;
using System.Windows.Forms;

namespace TuppersFormula
{
    public partial class Form1 : Form
    {
        private readonly TuppersFormulaSolver _solver;
        private readonly RandomHelper _randomHelper;
        private readonly Grid _grid;
        private DrawingStyle _style;
        private bool _mouseDown;
     
        public Form1()
        {
            InitializeComponent();

            var initialNumber = new BigInteger(0);
            _solver = new TuppersFormulaSolver(initialNumber);
            textBoxNumber.Text = initialNumber + "";
            _randomHelper = new RandomHelper();
            var horizontalScale = pictureBox.Width / Constants.GridWidth;
            var verticalScale = pictureBox.Height / Constants.GridHeight;
            _grid = new Grid(Constants.GridWidth, Constants.GridHeight, horizontalScale, verticalScale);
            _grid.GridUpdated += (s, e) => pictureBox.Image = e.Bitmap;
            UpdateGrid();

            _mouseDown = false;
            _style = DrawingStyle.Draw;
            labelError.Visible = false;
            labelWait.Visible = false;
        }

        private void EnableButtons()
        {
            radioButtonDraw.Enabled = true;
            radioButtonErase.Enabled = true;
            radioButtonRectangleDraw.Enabled = true;
            radioButtonRectangleErase.Enabled = true;
            buttonNegate.Enabled = true;
            buttonRight.Enabled = true;
            buttonLeft.Enabled = true;
            buttonUp.Enabled = true;
            buttonDown.Enabled = true;
            buttonLoadFormula.Enabled = true;
            buttonClear.Enabled = true;
            buttonRandomNumber.Enabled = true;
            buttonFlipX.Enabled = true;
            buttonFlipY.Enabled = true;
        }

        private void DisableButtons()
        {
            radioButtonDraw.Enabled = false;
            radioButtonErase.Enabled = false;
            radioButtonRectangleDraw.Enabled = false;
            radioButtonRectangleErase.Enabled = false;
            buttonNegate.Enabled = false;
            buttonRight.Enabled = false;
            buttonLeft.Enabled = false;
            buttonUp.Enabled = false;
            buttonDown.Enabled = false;
            buttonLoadFormula.Enabled = false;
            buttonClear.Enabled = false;
            buttonRandomNumber.Enabled = false;
            buttonFlipX.Enabled = false;
            buttonFlipY.Enabled = false;
        }

        private void DisableInputWhileWorkingWithGraph()
        {
            textBoxNumber.Enabled = false;
            DisableButtons();
        }

        private void EnableInputWhenDoneWorkingWithGraph()
        {
            textBoxNumber.Enabled = true;
            EnableButtons();
        }

        private void DisableGraphInputWhileWorkingWithNumber()
        {
            pictureBox.Enabled = false;
            labelWait.Visible = true;
            DisableButtons();
        }

        private void EnableGraphInputWhenDoneWorkingWithNumber()
        {
            pictureBox.Enabled = true;
            labelWait.Visible = false;
            EnableButtons();
        }

        private void DrawingStyleCheckedChanged(object sender, EventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton.Checked)
            {
                switch (radioButton.Text)
                {
                    case "Draw":
                        _style = DrawingStyle.Draw;
                        break;

                    case "Erase":
                        _style = DrawingStyle.Erase;
                        break;

                    case "Rectangle Draw":
                        _style = DrawingStyle.RectangleDraw;
                        break;

                    case "Rectangle Erase":
                        _style = DrawingStyle.RectangleErase;
                        break;

                    default:
                        _style = DrawingStyle.None;
                        break;
                }
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {   
            switch (e.Button)
            {
                case MouseButtons.Left:
                    _mouseDown = true;
                    _grid.AddChosenCell(e.X, e.Y, _style);
                    DisableInputWhileWorkingWithGraph();
                    break;
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    _mouseDown = false;
                    _grid.ApplyChosenCells(_style);
                    _grid.ClearChosenCells();
                    UpdateNumber();
                    EnableInputWhenDoneWorkingWithGraph();
                    break;
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mouseDown)
            {
                _grid.AddChosenCell(e.X, e.Y, _style);
            }
        }

        private void UpdateNumber()
        {
            var binaryFormat = _grid.GetBinaryFormat();
            var bigIntegerFormat = binaryFormat.BinaryToBigInteger();
            var result = bigIntegerFormat * 17;

            textBoxNumber.SetText(result + "");
        }

        private void NumberChanged(object sender, EventArgs e)
        {
            timer.Stop();
            DisableGraphInputWhileWorkingWithNumber();
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            UpdateGrid();
            EnableGraphInputWhenDoneWorkingWithNumber();
        }

        private void UpdateGrid()
        {
            labelError.Visible = false;

            if (!BigInteger.TryParse(textBoxNumber.Text, out BigInteger number))
            {
                labelError.Visible = true;
                return;
            }

            if (number < 0)
            {
                labelError.Visible = true;
                return;
            }

            _solver.K = number;
            var result = _solver.GetResult();

            _grid.UpdateGridFromMatrix(result);
        }

        private void buttonNegate_Click(object sender, EventArgs e)
        {
            _grid.NegateCells();
            UpdateNumber();
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            _grid.MoveCells(Direction.Up);
            UpdateNumber();
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            _grid.MoveCells(Direction.Down);
            UpdateNumber();
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            _grid.MoveCells(Direction.Right);
            UpdateNumber();
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            _grid.MoveCells(Direction.Left);
            UpdateNumber();
        }

        private void buttonLoadFormula_Click(object sender, EventArgs e)
        {
            textBoxNumber.SetText(Constants.TuppersFormula + "");
            UpdateGrid();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to clear the graph?", 
                "Clear Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes)
            {
                _grid.ClearGrid();
                UpdateNumber();
            }
        }

        private void buttonRandomNumber_Click(object sender, EventArgs e)
        {
            var numberOfBits = _randomHelper.Next(0, Constants.GridHeight * Constants.GridWidth);
            var number = _randomHelper.GetNBitsLongRandomBigInteger(numberOfBits);
            textBoxNumber.SetText(number + "");
            UpdateGrid();
        }

        private void buttonFlipX_Click(object sender, EventArgs e)
        {
            _grid.FlipGrid(FlipType.Horizontally);
            UpdateNumber();
        }

        private void buttonFlipY_Click(object sender, EventArgs e)
        {
            _grid.FlipGrid(FlipType.Vertically);
            UpdateNumber();
        }
    }
}
