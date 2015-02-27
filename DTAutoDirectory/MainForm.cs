using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;

namespace DTAutoDirectory
{
    public partial class MainForm : Form
    {
        private Dictionary<int, string> linkDict;

        public MainForm()
        {
            InitializeComponent();

            linkDict = new Dictionary<int, string>()
            {
                {1, "https://dev.csf.asu.edu:1000/projects/mapstory/wiki/Use_case_1_methods"},
                {2, "https://dev.csf.asu.edu:1000/projects/mapstory/wiki/Use_case_2_methods"},
                {3, "https://dev.csf.asu.edu:1000/projects/mapstory/wiki/Use_case_3_methods"},
                {4, "https://dev.csf.asu.edu:1000/projects/mapstory/wiki/Use_case_4_methods"},
                {5, "https://dev.csf.asu.edu:1000/projects/mapstory/wiki/Use_case_5_methods"},
                {10, "https://dev.csf.asu.edu:1000/projects/mapstory/wiki/Use_case_10_(Eras)_methods"}
            };
        }

        private void createDirectoryButton_Click(object sender, EventArgs e)
        {
            string driveName;

            if (inputsGood())
            {
                if ((driveName = checkConnection()) != String.Empty)
                {
                    string dirLoc = getDirectoryLoc(), dirToAddTo = driveName + dirLoc + "\\";

                    if (Directory.Exists(dirToAddTo))
                        checkCreateFiles(dirToAddTo);
                    else
                    {
                        dirToAddTo = driveName + "Projects\\MapStory\\" + dirLoc + "\\";

                        if (Directory.Exists(dirToAddTo))
                            checkCreateFiles(dirToAddTo);
                        else
                            MessageBox.Show("Directory: " + dirToAddTo + " was not found.", "Directory Not Found");
                    }
                }
            }
        }   //end createDirectoryButton_Click

        private bool inputsGood()
        {
            string messageBoxText = String.Empty;
            bool errFound = false;

            this.projectNameBox.BackColor = Color.White;
            this.useCaseSelectionBox.BackColor = Color.White;

            if (String.IsNullOrEmpty(this.projectNameBox.Text))
            {
                this.projectNameBox.BackColor = Color.Red;
                messageBoxText = "Enter a project name.";
                errFound = true;
            }

            if (this.useCaseSelectionBox.SelectedItem == null)
            {
                if (errFound)
                    messageBoxText = "Check your inputs.";
                else
                {
                    errFound = true;
                    messageBoxText = "Select a Use Case.";
                }
                this.useCaseSelectionBox.BackColor = Color.Red;
            }

            if (!validIssueNum())
            {
                if (errFound)
                    messageBoxText = "Check your inputs.";
                else
                {
                    errFound = true;
                    messageBoxText = "Enter an issue number.";
                }
            }

            if (errFound)
                MessageBox.Show(messageBoxText, "Input Error");

            return !errFound;
        }

        private string checkConnection()
        {
            DateTime now = System.DateTime.Now;
            DriveInfo[] drives = DriveInfo.GetDrives();

            for (int drive_idx = 0; drive_idx < drives.Length; drive_idx++)
            {
                try
                {
                    DriveInfo drive = drives[drive_idx];
                    if (drive.VolumeLabel == "dtpub$")
                    {
                        TimeSpan test = System.DateTime.Now - now;
                        double secs = test.TotalSeconds;
                        responseLabel.Text = secs.ToString();
                        return drive.Name;
                    }
                }
                catch (IOException e) { }
            }

            MessageBox.Show("Not connected to \\\\bijou.dt.asu.edu\\dtpub$\\projects\\Mapstory.\nPlease connect and try again.", "Not Connected");

       
            return String.Empty;
        }   //end checkConnection

        private string getDirectoryLoc()
        {
            return "Use Case " + getSelectedUseCase().ToString();
        }

        private void checkCreateFiles(string loc)
        {
            string projName = this.projectNameBox.Text.Replace(' ', '_');
            string projLoc = loc + issueNumberBox.Text + "_" + projName + "\\";

            if (!Directory.Exists(projLoc))
            {
                createfiles(projLoc, projName);
                showSuccessBox(projLoc, projName);
                //resetInputs();
            }
            else
            {
                DialogResult result = MessageBox.Show("Project: " + projName + " already exists.\nWould you like to overwrite the existing project?", "Project Already Exists", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    result = MessageBox.Show("Are you sure you want to delete the existing project: " + projName + "?", "Are You Sure?", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        Directory.Delete(projLoc, true);
                        createfiles(projLoc, projName);
                        showSuccessBox(projLoc, projName);
                    }
                    else
                        this.projectNameBox.BackColor = Color.Red;
                }
                else
                    this.projectNameBox.BackColor = Color.Red;

            }
        }
        private Int32 getSelectedUseCase()
        {
            return Int32.Parse(Regex.Match((string)this.useCaseSelectionBox.SelectedItem, @"\d+").Value);
        }

        private void createfiles(string projLoc, string projName)
        {
            DateTime now = System.DateTime.Now;
            Directory.CreateDirectory(projLoc + projName + "_DATA");
            Directory.CreateDirectory(projLoc + projName + "_DOC");
            Directory.CreateDirectory(projLoc + projName + "_SHP_SLD");

            File.WriteAllBytes(projLoc + projName + "_Map.mxd", Properties.Resources.blank_map);
            File.WriteAllBytes(projLoc + projName + "_Database.mdb", Properties.Resources.blank_database);
            File.Create(projLoc + projName + "_METADATA.txt").Close();
            TimeSpan span = DateTime.Now - now;
            double test = span.TotalSeconds;
            this.responseLabel.Text = test.ToString();
        }

        private void resetInputs()
        {
            this.projectNameBox.Text = String.Empty;
            this.projectNameBox.BackColor = Color.White;

            this.useCaseSelectionBox.BackColor = Color.White;
        }

        private void showSuccessBox(string projLoc, string projName)
        {
            DialogResult result = MessageBox.Show("Successfully created project: " + projName + ".\nWould you like to open your new project?", "Success!", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
                Process.Start(projLoc);

            projectNameBox.Text = String.Empty;
        }

        private void useCaseSelectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            linkLabel.Text = "Use Case " + getSelectedUseCase() +  " methods";

            if (!linkLabel.Visible) {
                if (useCaseSelectionBox.BackColor == Color.Red)
                    useCaseSelectionBox.BackColor = Color.White;

                linkLabel.Visible = true;
            }
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkDict[getSelectedUseCase()]);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(issueNumberBox.Text))
            {
                if (validIssueNum())
                {
                    if (!issueLinkLabel.Visible)
                        issueLinkLabel.Visible = true;

                    issueLinkLabel.Text = "Go to Issue #" + issueNumberBox.Text;
                }
                else
                {
                    if (issueLinkLabel.Visible)
                        issueLinkLabel.Visible = false;
                }
            }
            else
            {
                if (issueLinkLabel.Visible)
                    issueLinkLabel.Visible = false;
            }
        }

        private bool validIssueNum()
        {
            try
            {
                Int32.Parse(issueNumberBox.Text);

                if (issueNumberBox.BackColor == Color.Red)
                    issueNumberBox.BackColor = Color.White;

                return true;
            }
            catch (Exception e)
            {
                if (e is OverflowException || e is FormatException)
                {
                    Color test = issueNumberBox.BackColor;

                    issueNumberBox.BackColor = Color.Red;

                    return false;
                }
                else
                {
                    Debug.WriteLine(e.StackTrace);
                    return false;
                }
            }
        }

        private void issueLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (validIssueNum())
                Process.Start("https://dev.csf.asu.edu:1000/issues/" + Int32.Parse(issueNumberBox.Text));
        }

        private void projectNameBox_TextChanged(object sender, EventArgs e)
        {
            if (projectNameBox.BackColor == Color.Red)
                projectNameBox.BackColor = Color.White;
        }
    }   //end MainForm
}
