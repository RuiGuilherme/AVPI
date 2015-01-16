﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAVPI
{
    public partial class frm_AddEdit_SpeakAction : Form
    {
       
        #region Globals
        
        private Action form_action;

        private int times_to_add;

        #endregion

        #region Globals : Fetchers
        
        public Action get_action()
        {
            return form_action;
        }
        
        public int get_times_to_add()
        {
            return times_to_add;
        }
        #endregion

        #region Constructors
        public frm_AddEdit_SpeakAction()
        {
            InitializeComponent();

            populate_fields();
        }
        public frm_AddEdit_SpeakAction(Action action)
        {
            InitializeComponent();

            this.form_action = action;

            populate_fields();
        }
        #endregion

        #region UI : Populate 
        private void populate_fields()
        {
            //default times to add is one time
            times_to_add = 1;

            txtTimesToAdd.Text = times_to_add.ToString();

            // Editing an existing action
            if (form_action != null)
            {

            }
            // New Action
            else
            {
                cbSpeechType.DataSource = VI_Action_Sequence.SpeechAction_Types;
                
            }

            //cbSpeechType
            //cb
        }
        #endregion

        #region UI : Press Events : Add/Edit : Cancel : Drop Down
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // TODO

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cbSpeechType_SelectedIndexChanged(object sender, EventArgs e)
        {
            refresh_comboboxes();
        }
        #endregion

        #region UI : Refresh
        private void refresh_comboboxes()
        {
            if (cbSpeechType.Text == "Speak")
            {
                cbSpeechValue.DropDownStyle = ComboBoxStyle.Simple;
                cbSpeechValue.Text = String.Empty;
            }
            else if (cbSpeechType.Text == "Speak_Data")
            {
                cbSpeechValue.DropDownStyle = ComboBoxStyle.DropDownList;
                cbSpeechValue.DataSource = GAVPI.vi_profile.ProfileDB.DB.Keys.ToList();
            }
            else
            {
                //unsupported type!
                MessageBox.Show("Warning : Unsupported speak action type!");
            }
        }
        #endregion

        #region UI : CheckBoxes : Multiple Add
        private void chckMultiAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (chckMultiAdd.Checked == true)
            {
                txtTimesToAdd.Enabled = true;
            }
            else
            {
                txtTimesToAdd.Enabled = false;
            }
        }
        #endregion
    }
}