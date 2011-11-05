﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Nexus.Client.Util;

namespace Nexus.Client.Settings.UI
{
	/// <summary>
	/// A view allowing the editing of general settings.
	/// </summary>
	public partial class GeneralSettingsPage : UserControl, ISettingsGroupView
	{
		private bool booToolTipShown = false;

		#region Constructors

		/// <summary>
		/// A sinmple consturctor that initializes the object with the given values.
		/// </summary>
		/// <param name="p_gsgSettings">The settings group whose settings will be editable with this view.</param>
		public GeneralSettingsPage(GeneralSettingsGroup p_gsgSettings)
		{
			SettingsGroup = p_gsgSettings;
			InitializeComponent();

			foreach (GeneralSettingsGroup.FileAssociationSetting fasFileAssociation in p_gsgSettings.FileAssociations)
			{
				CheckBox ckbFileAssociation = new CheckBox();
				ckbFileAssociation.Tag = fasFileAssociation;
				ckbFileAssociation.Text = String.Format("Associate with {0} (*{1}) files", fasFileAssociation.Description, fasFileAssociation.Extension);
				ckbFileAssociation.AutoSize = true;
				BindingHelper.CreateFullBinding(ckbFileAssociation, () => ckbFileAssociation.Checked, fasFileAssociation, () => fasFileAssociation.IsAssociated);
				flpFileAssociations.Controls.Add(ckbFileAssociation);
			}
			BindingHelper.CreateFullBinding(ckbShellExtensions, () => ckbShellExtensions.Checked, p_gsgSettings, () => p_gsgSettings.AddShellExtensions);
			BindingHelper.CreateFullBinding(ckbAssociateURL, () => ckbAssociateURL.Checked, p_gsgSettings, () => p_gsgSettings.AssociateNxmUrl);

			BindingHelper.CreateFullBinding(ckbCheckForUpdates, () => ckbCheckForUpdates.Checked, p_gsgSettings, () => p_gsgSettings.CheckForUpdatesOnStartup);
			BindingHelper.CreateFullBinding(ckbAddMissingInfo, () => ckbAddMissingInfo.Checked, p_gsgSettings, () => p_gsgSettings.AddMissingModInfo);
			BindingHelper.CreateFullBinding(ckbCheckModVersions, () => ckbCheckModVersions.Checked, p_gsgSettings, () => p_gsgSettings.CheckForNewMods);
			BindingHelper.CreateFullBinding(ckbScanSubfolders, () => ckbScanSubfolders.Checked, p_gsgSettings, () => p_gsgSettings.ScanSubfoldersForMods);

			if (!p_gsgSettings.CanAssociateFiles)
			{
				gbxAssociations.Enabled = false;
				ttpTip.SetToolTip(gbxAssociations, String.Format("Run {0} as Administrator to change these settings.", p_gsgSettings.EnvironmentInfo.Settings.ModManagerName));
			}
		}

		#endregion

		#region ISettingsGroupView Members

		/// <summary>
		/// Gets the <see cref="SettingsGroup"/> whose settings will be editable with this view.
		/// </summary>
		/// <value>The <see cref="SettingsGroup"/> whose settings will be editable with this view.</value>
		public SettingsGroup SettingsGroup { get; private set; }

		#endregion

		#region Tool Tip

		/// <summary>
		/// Handles the <see cref="Control.MouseHover"/> event of the general settings flow panel.
		/// </summary>
		/// <remarks>
		/// This displays the tool tip for the file associations group box when it is disabled.
		/// </remarks>
		/// <param name="sender">The object that raised the event.</param>
		/// <param name="e">An <see cref="EventArgs"/> describing the event arguments.</param>
		private void flpGeneral_MouseHover(object sender, EventArgs e)
		{
			if (!gbxAssociations.Enabled && gbxAssociations.ClientRectangle.Contains(gbxAssociations.PointToClient(Cursor.Position)))
			{
				booToolTipShown = true;
				Point pntToolTipLocation = gbxAssociations.PointToClient(Cursor.Position);
				ttpTip.Show(ttpTip.GetToolTip(gbxAssociations), gbxAssociations, pntToolTipLocation.X, pntToolTipLocation.Y + Cursor.Current.Size.Height);
			}
		}

		/// <summary>
		/// Handles the <see cref="Control.MouseMove"/> event of the general settings flow panel.
		/// </summary>
		/// <remarks>
		/// This hides the tool tip for the file associations group box when appropriate.
		/// </remarks>
		/// <param name="sender">The object that raised the event.</param>
		/// <param name="e">An <see cref="MouseEventArgs"/> describing the event arguments.</param>
		private void flpGeneral_MouseMove(object sender, MouseEventArgs e)
		{
			if (booToolTipShown && !gbxAssociations.ClientRectangle.Contains(gbxAssociations.PointToClient(Cursor.Position)))
			{
				booToolTipShown = false;
				ttpTip.Hide(gbxAssociations);
			}
		}

		#endregion
	}
}