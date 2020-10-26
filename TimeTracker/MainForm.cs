using OceanAirdrop;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using TimeTracker.Data;
using TimeTracker.Dialogs;

namespace TimeTracker
{
    public partial class MainForm : Form
    {
        public static MainForm m_handle = null;

        private Timer m_timer;
        System.Diagnostics.Stopwatch m_stopWatch = null;

        public TimerType m_currentTimer = null;

        // http://stackoverflow.com/questions/7970580/c-sharp-countdown-timer
        private Timer m_unpauseTimer;
        DateTime m_unpauseEndTime;

        DateTime m_dateTimeLastWriteToDB = DateTime.MinValue;
        DateTime m_dateTimeUpdateTotalTimes = DateTime.MinValue;

        ScrollingMarqueeText m_scroll = null;

        public bool m_isPaused = false;


        public TimerType CurrentTimer { get; set; }
        public MainForm(TimerType timerType) : this()
        {
            CurrentTimer = timerType;
        }

        public MainForm()
        {
            InitializeComponent();

            m_handle = this;
            this.FormClosing += MainForm_FormClosing;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_scroll.StopTimer();
        }

        private void labelCurrentTimer_Click(object sender, EventArgs e)
        {
        }

        private void SetWindowTitle()
        {
            string appName = "Time Tracker";

            DateTime lastWriteTime = new FileInfo(Assembly.GetExecutingAssembly().Location).LastWriteTime;
            string buildDate = string.Format("Build Date: {0}", lastWriteTime);

            this.Text = string.Format("{0} ({1})", appName, buildDate);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetWindowTitle();
            SetTodayText();

            LocalSqllite.CreateNewSQLLiteDatabase();

            UpdateTotalTimeWorkedToday();
            StartTimer();

            buttonPauseTimer.Enabled = false;

            m_scroll = new ScrollingMarqueeText();
            m_scroll.StartScrollingText(this, labelScrollText, "    ");

            UpdateScrollingText();
        }

        private void StartTimer()
        {
            try
            {
                if (m_timer != null)
                    m_timer.Stop();

                m_timer = new Timer();
                m_timer.Tick += new EventHandler(TimerEvent);
                m_timer.Interval = 1000;
                m_timer.Enabled = true;
                m_timer.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void StopTimer()
        {
            try
            {
                if (m_timer != null)
                    m_timer.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void StartUnpauseTimer()
        {
            try
            {
                if (m_unpauseTimer != null)
                    m_unpauseTimer.Stop();

                m_unpauseTimer = new Timer();
                m_unpauseTimer.Tick += new EventHandler(UnPauseTimerEvent);
                m_unpauseTimer.Interval = 1000;
                m_unpauseTimer.Enabled = true;
                m_unpauseTimer.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void StopUnpauseTimer()
        {
            try
            {
                if (m_unpauseTimer != null)
                {
                    m_unpauseTimer.Enabled = false;
                    m_unpauseTimer.Stop();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SetTodayText()
        {
            labelCurrentDate.Text = string.Format("Today is: " + DateTime.Now.ToString("dddd dd MMMM yyyy") + ".");
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            try
            {
                // call this function here if user keeps the app open over night!
                SetTodayText();

                if (m_stopWatch == null)
                    return;

                if (m_currentTimer == null)
                    return;

                //labelCurrentTimer.Text = string.Format("{0} hrs : {1} mins : {2} secs", m_stopWatch.Elapsed.Hours.ToString("00"), m_stopWatch.Elapsed.Minutes.ToString("00"), m_stopWatch.Elapsed.Seconds.ToString("00"));
                labelCurrentTimer.Text = string.Format("{0}h : {1}m : {2}s", m_stopWatch.Elapsed.Hours.ToString("00"), m_stopWatch.Elapsed.Minutes.ToString("00"), m_stopWatch.Elapsed.Seconds.ToString("00"));

                UpdateDatabaseTimeRecord(false);

                UpdateScrollingText();
                UpdateTotalTimeWorkedToday();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        void UpdateDatabaseTimeRecord(bool bOverrideTimeCheck)
        {
            try
            {
                if (m_currentTimer == null || m_stopWatch == null)
                    return;

                if (bOverrideTimeCheck == false)
                {
                    TimeSpan span = DateTime.Now - m_dateTimeLastWriteToDB;

                    const int intervalTimeMins = 1;
                    if (span.TotalMinutes < intervalTimeMins)
                    {
                        labelStatus.Text = "Ready..";
                        // only update the database every 1 minue
                        return;
                    }
                }

                labelStatus.Text = "Updating database..";

                string sql = DBHelper.GenerateUpdateTimeRecordSQL(m_currentTimer, m_stopWatch.Elapsed);
                LocalSqllite.ExecSQLCommand(sql);

                m_dateTimeLastWriteToDB = DateTime.Now;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        string TimeSpanToFriendlyString(TimeSpan ts)
        {
            return string.Format("{0}:{1}:{2}", ts.Hours.ToString("00"), ts.Minutes.ToString("00"), ts.Seconds.ToString("00"));
        }

        private void UnPauseTimerEvent(object sender, EventArgs e)
        {
            try
            {
                TimeSpan remainingTime = m_unpauseEndTime - DateTime.Now;
                if (remainingTime < TimeSpan.Zero)
                {
                    this.buttonPauseTimer.Text = "Pause Current\nTimer";
                    StopUnpauseTimer();

                    buttonPauseTimer_Click(null, null);
                }
                else
                {
                    this.buttonPauseTimer.Text = string.Format("UnPausing in\n{0}", TimeSpanToFriendlyString(remainingTime));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private void buttonStartTimer_Click(object sender, EventArgs e)
        {
            UpdateDatabaseTimeRecord(true);
            UpdateScrollingText();

            if (CurrentTimer == null)
            {
                TimeSelection dlg = new TimeSelection();

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (dlg.m_selected == null)
                        return;

                    buttonStopCurentTimer_Click(null, null);

                    m_currentTimer = dlg.m_selected;

                    string sql = DBHelper.GenerateInsertTimeRecordSQL(m_currentTimer);
                    m_currentTimer.db_id = LocalSqllite.ExecSQLCommandScalar(sql);

                    // Create new stopwatch.
                    m_stopWatch = System.Diagnostics.Stopwatch.StartNew();

                    m_isPaused = false;

                    labelTimerDescription.Text = m_currentTimer.desc;

                    buttonPauseTimer.Enabled = true;
                }
            }
            else
            {
                buttonStopCurentTimer_Click(null, null);

                m_currentTimer = CurrentTimer;

                string sql = DBHelper.GenerateInsertTimeRecordSQL(m_currentTimer);
                m_currentTimer.db_id = LocalSqllite.ExecSQLCommandScalar(sql);

                // Create new stopwatch.
                m_stopWatch = System.Diagnostics.Stopwatch.StartNew();

                m_isPaused = false;

                labelTimerDescription.Text = m_currentTimer.desc;

                buttonPauseTimer.Enabled = true;
            }
        }

        private void StartUnpauseTimer(int unpauseTimeMins)
        {
            m_unpauseEndTime = DateTime.Now.AddMinutes(unpauseTimeMins);
            StartUnpauseTimer();
        }

        private void buttonPauseTimer_Click(object sender, EventArgs e)
        {
            if (m_stopWatch == null)
                return;

            if (m_isPaused == false)
            {
                UnpauseTimer dlg = new UnpauseTimer();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    UpdateDatabaseTimeRecord(true);
                    UpdateScrollingText();

                    // lets pause the timer
                    this.buttonPauseTimer.Image = global::TimeTracker.Properties.Resources.start;
                    m_stopWatch.Stop();

                    this.buttonPauseTimer.Text = "Restart Current\nTimer";

                    if (dlg.m_unpauseMins != -1)
                        StartUnpauseTimer(dlg.m_unpauseMins);

                    // State change has occured! Lets flip the bool
                    m_isPaused = !m_isPaused;
                }
            }
            else
            {
                StopUnpauseTimer();

                // lets start the timer
                this.buttonPauseTimer.Image = global::TimeTracker.Properties.Resources.pause;
                m_stopWatch.Start();

                this.buttonPauseTimer.Text = "Pause Current\nTimer";

                // State change has occured! Lets flip the bool
                m_isPaused = !m_isPaused;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetupTimer dlg = new SetupTimer();
            dlg.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonStopCurentTimer_Click(object sender, EventArgs e)
        {
            if (m_stopWatch == null)
                return;

            m_stopWatch.Stop();
        }

        string TotalMinsToFriendlyTime(double nMinsWorked)
        {
            string sqlFriendlyTime = string.Format("SELECT time({0} * 60, 'unixepoch');", nMinsWorked);

            string friendlyTime = LocalSqllite.ExecSQLCommandScalar(sqlFriendlyTime);

            return friendlyTime;
        }

        public void UpdateTotalTimeWorkedToday()
        {
            try
            {
                string sqlMinsWorked = string.Format("select  ifnull(sum(mins_accrued),0) from time_sheet where date = '{0}'", DBHelper.DateToDBDate(DateTime.Now));

                string minsWorked = LocalSqllite.ExecSQLCommandScalar(sqlMinsWorked);

                double nMinsWorked = Convert.ToDouble(minsWorked);

                string friendlyTime = TotalMinsToFriendlyTime(nMinsWorked);

                string text = "Keep up the good work!";
                if (nMinsWorked < 60)
                {
                    // under an hour
                    text = "Ouch!! Just starting out!! Keep at it!";
                }
                if (nMinsWorked > 120)
                {
                    // over 2 hours
                    text = "Building up momentum!";
                }
                if (nMinsWorked > 240)
                {
                    // over 2 hours
                    text = "Its downhill from here!";
                }
                if (nMinsWorked > 420)
                {
                    // over 2 hours
                    text = "Almost there!!";
                }
                if (nMinsWorked > 449)
                {
                    // over 2 hours
                    text = "Youve done it!! GO HOME!";
                }
                if (nMinsWorked > 500)
                {
                    // over 2 hours
                    text = "Your a superstar!!";
                }
                if (nMinsWorked > 530)
                {
                    // over 2 hours
                    text = "Now your just showing off!!";
                }

                labelTotalTimeToday.Text = string.Format("You have worked {0} today. {1}", friendlyTime, text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private bool GetWeekBeginningAndEnd(out string monday, out string sunday)
        {
            bool success = true;
            monday = sunday = "";

            try
            {
                int delta = DayOfWeek.Monday - DateTime.Now.DayOfWeek;
                DateTime mondayDT = DateTime.Now.AddDays(delta);
                DateTime sundayDT = mondayDT.AddDays(6);

                monday = DBHelper.DateToDBDate(mondayDT);
                sunday = DBHelper.DateToDBDate(sundayDT);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                success = false;
            }

            return success;
        }

        public void UpdateScrollingText()
        {

            try
            {
                TimeSpan span = DateTime.Now - m_dateTimeUpdateTotalTimes;

                // only call this function once per minute.
                const int intervalTimeMins = 1;
                if (span.TotalMinutes < intervalTimeMins)
                {
                    return;
                }

                m_scroll.ClearTextToDisplay();

                string sqlMinsWorked = string.Format("select ifnull(sum(mins_accrued),0) from time_sheet where date = '{0}'", DBHelper.DateToDBDate(DateTime.Now));
                string minsWorked = LocalSqllite.ExecSQLCommandScalar(sqlMinsWorked);

                string friendlyTime = TotalMinsToFriendlyTime(Convert.ToDouble(minsWorked));

                m_scroll.AddTextToDisplay(string.Format("*** Total time worked today: {0} ***", friendlyTime));

                string monday, sunday;
                if (GetWeekBeginningAndEnd(out monday, out sunday) == true)
                {
                    string sqlWeek = string.Format("select ifnull(sum(mins_accrued),0) from time_sheet where Date >= Datetime('{0}') and Date <= Datetime('{1}')", monday, sunday);
                    minsWorked = LocalSqllite.ExecSQLCommandScalar(sqlWeek);

                    friendlyTime = TotalMinsToFriendlyTime(Convert.ToDouble(minsWorked));
                    m_scroll.AddTextToDisplay(string.Format("*** Total time worked this week: {0} ***", friendlyTime));
                }

                // SELECT date('now','start of month') -- Get Start date of the month
                // SELECT date('now','start of month','+1 month','-1 day'); -- Get End date of month
                string sqlMinsWorkedMonth = "select ifnull(sum(mins_accrued),0) from time_sheet WHERE Date >= date('now','start of month') AND Date <= date('now','start of month','+1 month','-1 day');";
                string minsWorkedMonth = LocalSqllite.ExecSQLCommandScalar(sqlMinsWorkedMonth);

                friendlyTime = TotalMinsToFriendlyTime(Convert.ToDouble(minsWorkedMonth));
                m_scroll.AddTextToDisplay(string.Format("*** Total time worked this month: {0} ***", friendlyTime));

                m_dateTimeUpdateTotalTimes = DateTime.Now;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void buttonDisplayTimeSheetData_Click(object sender, EventArgs e)
        {
            UpdateDatabaseTimeRecord(true);

            SelectReportType reptDlg = new SelectReportType();
            reptDlg.ShowDialog();
        }

        private void buttonAppSettings_Click(object sender, EventArgs e)
        {
            AppSettings dlg = new AppSettings();
            dlg.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateDatabaseTimeRecord(true);
        }

        private void buttonManualEntry_Click(object sender, EventArgs e)
        {
            UpdateScrollingText();
            ReportDetailed dlg = new ReportDetailed();
            dlg.m_mode = ReportMode.EditMode;
            dlg.Show();
        }

        private void pictureBoxAbout_Click(object sender, EventArgs e)
        {
            AboutBoxForm dlg = new AboutBoxForm();
            dlg.ShowDialog();
        }
    }
}
