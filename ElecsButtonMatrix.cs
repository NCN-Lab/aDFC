using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OnlineSpikeDetection
{
    public class ElecsButtonMatrix
    {
        int nLines;
        int nCols;
        int[] sides;
        int x_corner; // 30
        int y_corner; // 90

        Button[] allButtons;
        CheckBox[] allChecks;
      //  bool all = false;

        Color lockedColor;
        Color unlockedColor;

        public ElecsButtonMatrix(int x, int y)
        {
            nLines = 16;
            nCols = 16;
            x_corner = x;
            y_corner = y;
            sides = new int[] { 36, 36 };
        }

        public ElecsButtonMatrix(int x, int y,int nlines, int ncols)
        {
            x_corner = x;
            y_corner = y;
            nLines = nlines;
            nCols = ncols;
            x_corner = x;
            y_corner = y;
            sides = new int[] { 36, 36 };
        }

        public ElecsButtonMatrix(int x, int y, int nlines, int ncols, int side)
        {
            nLines = nlines;
            nCols = ncols;
            x_corner = 30;
            y_corner = 90;
            sides = new int[] { side, side };
        }

        public ElecsButtonMatrix(int x, int y, int nlines, int ncols, int side, Color locked, Color unlocked)
        {
            nLines = nlines;
            nCols = ncols;
            x_corner = 30;
            y_corner = 90;
            sides = new int[] { side, side };
            lockedColor = locked;
            unlockedColor = unlocked;
        }


        public ElecsButtonMatrix(int x, int y, int nlines, int ncols, int side, EventHandler Btn_Click, Control.ControlCollection Controls)
        {
            nLines = nlines;
            nCols = ncols;
            x_corner = 30;
            y_corner = 90;
            sides = new int[] { side, side };

            CreateElectrodeButtons(Btn_Click, Controls);
        }


        public ElecsButtonMatrix(int x, int y, int nlines, int ncols, int side, EventHandler Btn_Click, EventHandler Box_Click,  Control.ControlCollection Controls)
        {
            nLines = nlines;
            nCols = ncols;
            x_corner = 30;
            y_corner = 90;
            sides = new int[] { side, side };

            CreateElectrodeButtons(Btn_Click, Controls);
            CreateCheckBoxes(Box_Click, Controls);
        }

        public ElecsButtonMatrix(int x, int y, int nlines, int ncols, int side, EventHandler Btn_Click,  Control.ControlCollection Controls, Color locked, Color unlocked)
        {
            nLines = nlines;
            nCols = ncols;
            x_corner = x;
            y_corner = y;
            sides = new int[] { side, side };

            lockedColor = locked;
            unlockedColor = unlocked;

            CreateElectrodeButtons(Btn_Click, Controls);
        }


        public ElecsButtonMatrix(int x, int y, int nlines, int ncols, int side, EventHandler Btn_Click, EventHandler Box_Click, Control.ControlCollection Controls, Color locked, Color unlocked)
        {
            nLines = nlines;
            nCols = ncols;
            x_corner = 30;
            y_corner = 90;
            sides = new int[] { side, side };

            lockedColor = locked;
            unlockedColor = unlocked;

            CreateElectrodeButtons(Btn_Click, Controls);
            CreateCheckBoxes(Box_Click, Controls);
        }



        private Button[] CreateElectrodeButtons(EventHandler Btn_Click, Control.ControlCollection Controls)
        {

            allButtons = new Button[nLines * nCols - 4];
            var elecLabels = main.electrodeLabels;

            int pos_ind = 0;
            int elec_i = 0;

            for (int col = 0; col < nCols; col++)
            {
                for (int line = 0; line < nLines; line++)
                {
                    if (pos_ind != 0 && pos_ind != 15 && pos_ind != 255 && pos_ind != 240)
                    {
                        Button btn = new Button();

                        btn.Left = col * sides[0] + x_corner;
                        btn.Top = line * sides[1] + y_corner;
                        btn.Width = sides[0];
                        btn.Height = sides[1];
                        btn.Name = elec_i.ToString();
                        btn.Text = elecLabels[elec_i].label;
                        btn.Click += Btn_Click;
                        btn.BackColor = lockedColor;
                        btn.Font = new Font(btn.Font.FontFamily, 7);

                        allButtons[elec_i] = btn;
                        Controls.Add(allButtons[elec_i]);
                         
                        elec_i++;
                    }
                    pos_ind++;
                }
            }

            return allButtons;
        }


        public void unlockSelectedButton(List<int> elec_inds)
        {
            for (int i = 0; i < elec_inds.Count; i++)
            {
                allButtons[elec_inds[i]].BackColor = unlockedColor;
            }
        }

        public void lockSelectedButton(List<int> elec_inds)
        {
            for (int i = 0; i < elec_inds.Count; i++)
            {
                allButtons[elec_inds[i]].BackColor = lockedColor;
            }
        }

        public void ChangeAllButtonsColors(Color color)
        {
            int nelecs = allButtons.Length;

            for (int i = 0; i < nelecs; i++)
            {
                allButtons[i].BackColor = color;
            }
        }


        public void ChangeButtonsColors(int[] elec_inds, Color color)
        {
            int nelecs = elec_inds.Length;

            for (int i = 0; i< nelecs; i++)
            {
                allButtons[elec_inds[i]].BackColor = color;
            }
        }

        public void ChangeButtonColors(int elec_ind, Color color)
        {      
                allButtons[elec_ind].BackColor = color;
        }


        private CheckBox[] CreateCheckBoxes(EventHandler Box_CheckedChanged, Control.ControlCollection Controls)
        {

            int ind = 0;
            allChecks = new CheckBox[nLines + nCols];
            string letters = "ABCDEFGHJKLMNOPR";

            for (int line = 0; line < nLines; line++)
            {
                CheckBox box = new CheckBox();

                box.Left = x_corner - 20;
                box.Top = line * sides[0] + y_corner;
                box.Width = sides[0];
                box.Height = sides[1];
                if (line < 9)
                    box.Name = "num_0" + (line + 1).ToString();
                else
                    box.Name = "num_" + (line + 1).ToString();

                // box.Checked = true;
                box.Checked = false;
                box.CheckedChanged += Box_CheckedChanged;

                allChecks[ind] = box;
                Controls.Add(allChecks[ind]);
                ind++;
            }

            for (int col = 0; col < nCols; col++)
            {
                CheckBox box = new CheckBox();

                box.Left = col * sides[1] + x_corner + 12;
                box.Top = (nLines) * sides[1] + y_corner + 5;
                box.Width = sides[0];
                box.Height = sides[1];
                box.Checked = false;
                box.CheckedChanged += Box_CheckedChanged;
                box.Name = "col_" + letters[col];
                allChecks[ind] = box;
                Controls.Add(allChecks[ind]);
                ind++;
            }

            return allChecks;
        }

        public Button[] Get_allButtons()
        {
            return allButtons;
        }


        public CheckBox[] Get_allChecks()
        {
            return allChecks;
        }

        public Color Get_LockedColor()
        {
            return lockedColor;
        }

        public Color Get_UnlockedColor()
        {
            return unlockedColor;
        }

    }
}
