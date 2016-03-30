﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Resources;

namespace FEFTwiddler
{
    public partial class Form1 : Form
    {
        private Model.ChapterSave _chapterSave;
        private Model.Character _selectedCharacter;

        public Form1()
        {
            InitializeComponent();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _chapterSave = Model.ChapterSave.FromPath(openFileDialog1.FileName);

                listBox1.DisplayMember = "CharacterID";
                listBox1.ValueMember = "BinaryPosition"; // Sure, why not
                listBox1.Items.Clear();
                foreach (var character in _chapterSave.Characters)
                {
                    listBox1.Items.Add(character);
                }

                PopulatePickers();
                LoadChapterData();
                BindEventHandlers();

                tabControl1.Enabled = true;

                listBox1.SelectedIndex = 0;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var character = (Model.Character)listBox1.SelectedItem;
            //var character = (from c in _chapterSave.Characters
            //                 where c.BinaryPosition == characterId
            //                 select c).FirstOrDefault();
            _selectedCharacter = character;
            LoadCharacter(character);
        }

        private void BindEventHandlers()
        {
            numGold.ValueChanged += delegate (object sender, EventArgs e) { _chapterSave.Gold = (uint)((NumericUpDown)sender).Value; };

            numAmber.ValueChanged += delegate (object sender, EventArgs e) { _chapterSave.MaterialQuantity_Amber = (byte)((NumericUpDown)sender).Value; };
            numBeans.ValueChanged += delegate (object sender, EventArgs e) { _chapterSave.MaterialQuantity_Beans = (byte)((NumericUpDown)sender).Value; };
            numBerries.ValueChanged += delegate (object sender, EventArgs e) { _chapterSave.MaterialQuantity_Berries = (byte)((NumericUpDown)sender).Value; };
            numCabbage.ValueChanged += delegate (object sender, EventArgs e) { _chapterSave.MaterialQuantity_Cabbage = (byte)((NumericUpDown)sender).Value; };
            numCoral.ValueChanged += delegate (object sender, EventArgs e) { _chapterSave.MaterialQuantity_Coral = (byte)((NumericUpDown)sender).Value; };
            numCrystal.ValueChanged += delegate (object sender, EventArgs e) { _chapterSave.MaterialQuantity_Crystal = (byte)((NumericUpDown)sender).Value; };
            numDaikon.ValueChanged += delegate (object sender, EventArgs e) { _chapterSave.MaterialQuantity_Daikon = (byte)((NumericUpDown)sender).Value; };
            numEmerald.ValueChanged += delegate (object sender, EventArgs e) { _chapterSave.MaterialQuantity_Emerald = (byte)((NumericUpDown)sender).Value; };
            numFish.ValueChanged += delegate (object sender, EventArgs e) { _chapterSave.MaterialQuantity_Fish = (byte)((NumericUpDown)sender).Value; };
            numJade.ValueChanged += delegate (object sender, EventArgs e) { _chapterSave.MaterialQuantity_Jade = (byte)((NumericUpDown)sender).Value; };
            numLapis.ValueChanged += delegate (object sender, EventArgs e) { _chapterSave.MaterialQuantity_Lapis = (byte)((NumericUpDown)sender).Value; };
            numMeat.ValueChanged += delegate (object sender, EventArgs e) { _chapterSave.MaterialQuantity_Meat = (byte)((NumericUpDown)sender).Value; };
            numMilk.ValueChanged += delegate (object sender, EventArgs e) { _chapterSave.MaterialQuantity_Milk = (byte)((NumericUpDown)sender).Value; };
            numOnyx.ValueChanged += delegate (object sender, EventArgs e) { _chapterSave.MaterialQuantity_Onyx = (byte)((NumericUpDown)sender).Value; };
            numPeaches.ValueChanged += delegate (object sender, EventArgs e) { _chapterSave.MaterialQuantity_Peaches = (byte)((NumericUpDown)sender).Value; };
            numPearl.ValueChanged += delegate (object sender, EventArgs e) { _chapterSave.MaterialQuantity_Pearl = (byte)((NumericUpDown)sender).Value; };
            numQuartz.ValueChanged += delegate (object sender, EventArgs e) { _chapterSave.MaterialQuantity_Quartz = (byte)((NumericUpDown)sender).Value; };
            numRice.ValueChanged += delegate (object sender, EventArgs e) { _chapterSave.MaterialQuantity_Rice = (byte)((NumericUpDown)sender).Value; };
            numRuby.ValueChanged += delegate (object sender, EventArgs e) { _chapterSave.MaterialQuantity_Ruby = (byte)((NumericUpDown)sender).Value; };
            numSapphire.ValueChanged += delegate (object sender, EventArgs e) { _chapterSave.MaterialQuantity_Sapphire = (byte)((NumericUpDown)sender).Value; };
            numTopaz.ValueChanged += delegate (object sender, EventArgs e) { _chapterSave.MaterialQuantity_Topaz = (byte)((NumericUpDown)sender).Value; };
            numWheat.ValueChanged += delegate (object sender, EventArgs e) { _chapterSave.MaterialQuantity_Wheat = (byte)((NumericUpDown)sender).Value; };
        }

        private void LoadChapterData()
        {
            lblAvatarName.Text = Utils.TypeConverter.ToString(_chapterSave.AvatarName);

            numGold.Value = _chapterSave.Gold;

            numAmber.Value = _chapterSave.MaterialQuantity_Amber;
            numBeans.Value = _chapterSave.MaterialQuantity_Beans;
            numBerries.Value = _chapterSave.MaterialQuantity_Berries;
            numCabbage.Value = _chapterSave.MaterialQuantity_Cabbage;
            numCoral.Value = _chapterSave.MaterialQuantity_Coral;
            numCrystal.Value = _chapterSave.MaterialQuantity_Crystal;
            numDaikon.Value = _chapterSave.MaterialQuantity_Daikon;
            numEmerald.Value = _chapterSave.MaterialQuantity_Emerald;
            numFish.Value = _chapterSave.MaterialQuantity_Fish;
            numJade.Value = _chapterSave.MaterialQuantity_Jade;
            numLapis.Value = _chapterSave.MaterialQuantity_Lapis;
            numMeat.Value = _chapterSave.MaterialQuantity_Meat;
            numMilk.Value = _chapterSave.MaterialQuantity_Milk;
            numOnyx.Value = _chapterSave.MaterialQuantity_Onyx;
            numPeaches.Value = _chapterSave.MaterialQuantity_Peaches;
            numPearl.Value = _chapterSave.MaterialQuantity_Pearl;
            numQuartz.Value = _chapterSave.MaterialQuantity_Quartz;
            numRice.Value = _chapterSave.MaterialQuantity_Rice;
            numRuby.Value = _chapterSave.MaterialQuantity_Ruby;
            numSapphire.Value = _chapterSave.MaterialQuantity_Sapphire;
            numTopaz.Value = _chapterSave.MaterialQuantity_Topaz;
            numWheat.Value = _chapterSave.MaterialQuantity_Wheat;
        }

        private void LoadCharacter(Model.Character character)
        {
            lblName.Text = character.CharacterID.ToString();
            cmbClass.Text = character.ClassID.ToString();
            numLevel.Value = character.Level;
            numExperience.Value = character.Experience;

            chkDead.Checked = character.IsDead;
            chkEinherjar.Checked = character.IsEinherjar;
            chkRecruited.Checked = character.IsRecruited;

            cmbSkill1.Text = character.EquippedSkill_1.ToString();
            pictSkill1.Image = GetSkillImage(character.EquippedSkill_1);
            cmbSkill2.Text = character.EquippedSkill_2.ToString();
            pictSkill2.Image = GetSkillImage(character.EquippedSkill_2);
            cmbSkill3.Text = character.EquippedSkill_3.ToString();
            pictSkill3.Image = GetSkillImage(character.EquippedSkill_3);
            cmbSkill4.Text = character.EquippedSkill_4.ToString();
            pictSkill4.Image = GetSkillImage(character.EquippedSkill_4);
            cmbSkill5.Text = character.EquippedSkill_5.ToString();
            pictSkill5.Image = GetSkillImage(character.EquippedSkill_5);

            //EnableControls();
        }

        private void PopulatePickers()
        {
            cmbClass.DataSource = Enum.GetValues(typeof(Enums.Class));
            cmbSkill1.DataSource = Enum.GetValues(typeof(Enums.Skill));
            cmbSkill2.DataSource = Enum.GetValues(typeof(Enums.Skill));
            cmbSkill3.DataSource = Enum.GetValues(typeof(Enums.Skill));
            cmbSkill4.DataSource = Enum.GetValues(typeof(Enums.Skill));
            cmbSkill5.DataSource = Enum.GetValues(typeof(Enums.Skill));
        }

        private Bitmap GetSkillImage(Enums.Skill skillId)
        {
            var id = ((byte)skillId).ToString();
            if (id.Length == 1) id = "0" + id;
            var img = Properties.Resources.ResourceManager.GetObject("fe15skill_" + id);

            return (Bitmap)img;
        }

        private void EnableControls()
        {
            cmbClass.Enabled = true;
            numLevel.Enabled = true;
            numExperience.Enabled = true;
            cmbSkill1.Enabled = true;
            cmbSkill2.Enabled = true;
            cmbSkill3.Enabled = true;
            cmbSkill4.Enabled = true;
            cmbSkill5.Enabled = true;
        }

        private void cmbSkill1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Enums.Skill skillId;
            //if (Enum.TryParse(cmbSkill1.Text, out skillId))
            //{
            //    _selectedCharacter.EquippedSkill_1 = skillId;
            //    pictSkill1.Image = GetSkillImage(_selectedCharacter.EquippedSkill_1);
            //}
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_chapterSave == null)
            {
                MessageBox.Show("No file is loaded");
                return;
            }

            _chapterSave.Write();

            MessageBox.Show("File saved. Hope you made a backup!");
        }

        private void btnAllSkillsNoNpc_Click(object sender, EventArgs e)
        {
            foreach (var character in _chapterSave.Characters)
            {
                character.LearnAllNonNpcSkills();
            }
        }

        private void btnGiveEternalSeals_Click(object sender, EventArgs e)
        {
            foreach (var character in _chapterSave.Characters)
            {
                character.EternalSealsUsed = 16;
            }
        }

        private void btnMaxWeaponExp_Click(object sender, EventArgs e)
        {
            foreach (var character in _chapterSave.Characters)
            {
                character.SRankAllWeapons();
            }
        }

        private void btnMaxMaterials_Click(object sender, EventArgs e)
        {
            byte max = 99;
            numAmber.Value = max;
            numBeans.Value = max;
            numBerries.Value = max;
            numCabbage.Value = max;
            numCoral.Value = max;
            numCrystal.Value = max;
            numDaikon.Value = max;
            numEmerald.Value = max;
            numFish.Value = max;
            numJade.Value = max;
            numLapis.Value = max;
            numMeat.Value = max;
            numMilk.Value = max;
            numOnyx.Value = max;
            numPeaches.Value = max;
            numPearl.Value = max;
            numQuartz.Value = max;
            numRice.Value = max;
            numRuby.Value = max;
            numSapphire.Value = max;
            numTopaz.Value = max;
            numWheat.Value = max;
        }

        private void btnMaxGold_Click(object sender, EventArgs e)
        {
            numGold.Value = 999999;
        }
    }
}
