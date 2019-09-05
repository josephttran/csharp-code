using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PillReminderUI
{
    public partial class ReminderWindow : Form
    {
        BindingList<PillModel> medications = new BindingList<PillModel>();
        BindingList<PillModel> pillsToTake = new BindingList<PillModel>();

        public ReminderWindow()
        {
            InitializeComponent();
            allPillsListBox.DataSource = medications;
            allPillsListBox.DisplayMember = "PillInfo";

            PopulateDummyData();
            ShowPillsToTake();
        }

        private void TakePill_Click(object sender, EventArgs e)
        {
            PillModel selectedPill = (PillModel) pillsToTakeListBox.SelectedItem;

            if (selectedPill != null)
            {
                selectedPill.LastTaken = DateTime.Now;
            }
        }

        private List<PillModel> SortMedications(List<PillModel> list)
        {
            IEnumerable<PillModel> newList = from PillModel pillModel in list
                                             orderby pillModel.TimeToTake
                                             select pillModel;

            return newList.ToList<PillModel>();
        }

        private void ShowPillsToTake()
        {
            pillsToTakeListBox.DataSource = pillsToTake;
            pillsToTakeListBox.DisplayMember = "PillInfo";
        }

        private void RefreshPillsToTake_Click(object sender, EventArgs e)
        {
            List<PillModel> filteredMedications = FilterMedications(medications.ToList());
            List<PillModel> filteredSortedMedications = SortMedications(filteredMedications);

            pillsToTake.Clear();

            foreach (PillModel medication in filteredSortedMedications)
            {
                pillsToTake.Add(medication);
            }
        }

        private void PopulateDummyData()
        {
            medications.Add(new PillModel { PillName = "The white one", TimeToTake = DateTime.ParseExact("0:15 am", "h:mm tt", null, System.Globalization.DateTimeStyles.AssumeLocal) });
            medications.Add(new PillModel { PillName = "The big one", TimeToTake = DateTime.Parse("8:00 am") });
            medications.Add(new PillModel { PillName = "The red ones", TimeToTake = DateTime.Parse("11:45 pm") });
            medications.Add(new PillModel { PillName = "The oval one", TimeToTake = DateTime.Parse("0:27 am") });
            medications.Add(new PillModel { PillName = "The round ones", TimeToTake = DateTime.Parse("6:15 pm") });
        }
        private List<PillModel> FilterMedications(List<PillModel> list)
        {
            return list.Where(pillModel => pillModel.LastTaken < DateTime.Today && pillModel.TimeToTake < DateTime.Now).ToList<PillModel>();
        }
    }
}
