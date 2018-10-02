﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WGP;
using WGP.SFDynamicObject;
using SFML.System;
using SFML.Graphics;

namespace AnimMaker_v2
{
    public partial class KeysListProperties : UserControl
    {
        public KeysListProperties()
        {
            InitializeComponent();

            if (Program.selection != null)
            {
                var keys = (List<Animation.Key>)Program.selection;

                int count = 1;
                foreach (var key in keys)
                {
                    keysList.Items.Add(count.ToString("00") + " : " + key.Position.AsSeconds().ToString("F"));
                    count++;
                }
            }
        }

        private void keysList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var keys = Program.selectedKeys;
            Program.selection = keys[int.Parse(keysList.Items[keysList.SelectedIndex].ToString().Substring(0, 2)) - 1];

            Program.form.UpdateProp();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.selectedKeys.Add(new Animation.Key() { Position = Program.DynamicObject.CurrentTime, Transform = new Transformable() });

            Program.form.UpdateProp();
        }
    }
}
