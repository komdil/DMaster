using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OceanAirdrop
{
    public class ScrollingMarqueeText
    {
        public Form m_parentForm = null;
        public Label m_textToScroll = null;
        public string m_textToDisplay = "";

        public List<string> m_listTextToDisplay = new List<string>();

        int m_listIndexDisplaying = 0;
        Timer scrollTimer;

        public void StartScrollingText(Form formLabelOn, Label displayLabel, string textToDisplay)
        {
            m_parentForm = formLabelOn;
            m_textToScroll = displayLabel;
            m_textToDisplay = textToDisplay;

            displayLabel.Text = textToDisplay;
            scrollTimer = new Timer();
            scrollTimer.Interval = 20;
            scrollTimer.Tick += ScrollTimer_Tick;
            scrollTimer.Start();
        }

        public void StopTimer()
        {
            scrollTimer.Tick -= ScrollTimer_Tick;
            scrollTimer.Stop();
        }

        private void ScrollTimer_Tick(object sender, EventArgs e)
        {
            MoveTextToLeft();
        }

        public void ClearTextToDisplay()
        {
            m_listTextToDisplay.Clear();
        }

        public void AddTextToDisplay(string textToDisplay)
        {
            m_listTextToDisplay.Add(textToDisplay);
        }

        private void MoveTextToLeft()
        {
            // Step 01: Find out the wrap point for this text
            int textSize = GetTextSize(m_textToScroll);
            int wrapPoint = ConvetPositiveNumToNegativeNum(textSize);

            int newXLocation = m_textToScroll.Location.X;
            if (newXLocation <= wrapPoint)
            {
                newXLocation = m_parentForm.Width + 1;

                // Can update label text here as we have fully shown this version.
                m_textToScroll.Text = FetNextTextToDisplay(); // m_textToDisplay;
            }
            else
                newXLocation = m_textToScroll.Location.X - 1;

            // move the front of the label off the form to the left to simulate the text moving
            m_textToScroll.Location = new Point(newXLocation, 0);

            // Ensure the size of the label sticks to the end of the form.
            m_textToScroll.Size = new Size(m_textToScroll.Size.Width + 1, m_textToScroll.Size.Height);
        }

        private int ConvetPositiveNumToNegativeNum(int num)
        {
            return num * -1;
        }

        private int GetTextSize(Label labelText)
        {
            int MaxPossibleScreenWidth = 6000; // when form is at maximum! 
            SizeF size;
            using (Graphics g = m_parentForm.CreateGraphics())
            {
                size = g.MeasureString(labelText.Text, labelText.Font, MaxPossibleScreenWidth);
            }

            return Convert.ToInt32(size.Width);

        }

        private string FetNextTextToDisplay()
        {
            if (m_listIndexDisplaying >= m_listTextToDisplay.Count)
                m_listIndexDisplaying = 0;

            return m_listTextToDisplay[m_listIndexDisplaying++];
        }
    }
}
