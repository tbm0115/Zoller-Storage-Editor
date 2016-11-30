<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetHotkeys
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SetHotkeys))
    Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
    Me.OK_Button = New System.Windows.Forms.Button()
    Me.Cancel_Button = New System.Windows.Forms.Button()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.tabHotkeys = New System.Windows.Forms.TabControl()
    Me.tabF9 = New System.Windows.Forms.TabPage()
    Me.lstF9 = New System.Windows.Forms.ListBox()
    Me.tabF10 = New System.Windows.Forms.TabPage()
    Me.lstF10 = New System.Windows.Forms.ListBox()
    Me.tabF11 = New System.Windows.Forms.TabPage()
    Me.lstF11 = New System.Windows.Forms.ListBox()
    Me.tabF12 = New System.Windows.Forms.TabPage()
    Me.lstF12 = New System.Windows.Forms.ListBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.drpKeys = New System.Windows.Forms.ComboBox()
    Me.btnAdd = New System.Windows.Forms.Button()
    Me.btnAddApp = New System.Windows.Forms.Button()
    Me.btnRemove = New System.Windows.Forms.Button()
    Me.chkHoldShift = New System.Windows.Forms.CheckBox()
    Me.chkHoldAlt = New System.Windows.Forms.CheckBox()
    Me.chkHoldCtrl = New System.Windows.Forms.CheckBox()
    Me.btnClearList = New System.Windows.Forms.Button()
    Me.TableLayoutPanel1.SuspendLayout()
    Me.tabHotkeys.SuspendLayout()
    Me.tabF9.SuspendLayout()
    Me.tabF10.SuspendLayout()
    Me.tabF11.SuspendLayout()
    Me.tabF12.SuspendLayout()
    Me.SuspendLayout()
    '
    'TableLayoutPanel1
    '
    Me.TableLayoutPanel1.ColumnCount = 2
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
    Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
    Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
    Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 346)
    Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
    Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    Me.TableLayoutPanel1.RowCount = 1
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.Size = New System.Drawing.Size(580, 42)
    Me.TableLayoutPanel1.TabIndex = 0
    '
    'OK_Button
    '
    Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.OK_Button.Location = New System.Drawing.Point(100, 7)
    Me.OK_Button.Margin = New System.Windows.Forms.Padding(4)
    Me.OK_Button.Name = "OK_Button"
    Me.OK_Button.Size = New System.Drawing.Size(89, 28)
    Me.OK_Button.TabIndex = 0
    Me.OK_Button.Text = "OK"
    '
    'Cancel_Button
    '
    Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Cancel_Button.Location = New System.Drawing.Point(390, 7)
    Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4)
    Me.Cancel_Button.Name = "Cancel_Button"
    Me.Cancel_Button.Size = New System.Drawing.Size(89, 28)
    Me.Cancel_Button.TabIndex = 1
    Me.Cancel_Button.Text = "Cancel"
    '
    'TextBox1
    '
    Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Top
    Me.TextBox1.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox1.Location = New System.Drawing.Point(0, 0)
    Me.TextBox1.Multiline = True
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.ReadOnly = True
    Me.TextBox1.Size = New System.Drawing.Size(580, 104)
    Me.TextBox1.TabIndex = 2
    Me.TextBox1.Text = resources.GetString("TextBox1.Text")
    '
    'tabHotkeys
    '
    Me.tabHotkeys.Controls.Add(Me.tabF9)
    Me.tabHotkeys.Controls.Add(Me.tabF10)
    Me.tabHotkeys.Controls.Add(Me.tabF11)
    Me.tabHotkeys.Controls.Add(Me.tabF12)
    Me.tabHotkeys.Location = New System.Drawing.Point(13, 111)
    Me.tabHotkeys.Name = "tabHotkeys"
    Me.tabHotkeys.SelectedIndex = 0
    Me.tabHotkeys.Size = New System.Drawing.Size(277, 228)
    Me.tabHotkeys.TabIndex = 3
    '
    'tabF9
    '
    Me.tabF9.Controls.Add(Me.lstF9)
    Me.tabF9.Location = New System.Drawing.Point(4, 25)
    Me.tabF9.Name = "tabF9"
    Me.tabF9.Padding = New System.Windows.Forms.Padding(3)
    Me.tabF9.Size = New System.Drawing.Size(269, 199)
    Me.tabF9.TabIndex = 0
    Me.tabF9.Text = "F9"
    Me.tabF9.UseVisualStyleBackColor = True
    '
    'lstF9
    '
    Me.lstF9.FormattingEnabled = True
    Me.lstF9.ItemHeight = 16
    Me.lstF9.Location = New System.Drawing.Point(7, 7)
    Me.lstF9.Name = "lstF9"
    Me.lstF9.Size = New System.Drawing.Size(256, 180)
    Me.lstF9.TabIndex = 0
    '
    'tabF10
    '
    Me.tabF10.Controls.Add(Me.lstF10)
    Me.tabF10.Location = New System.Drawing.Point(4, 25)
    Me.tabF10.Name = "tabF10"
    Me.tabF10.Padding = New System.Windows.Forms.Padding(3)
    Me.tabF10.Size = New System.Drawing.Size(269, 199)
    Me.tabF10.TabIndex = 1
    Me.tabF10.Text = "F10"
    Me.tabF10.UseVisualStyleBackColor = True
    '
    'lstF10
    '
    Me.lstF10.FormattingEnabled = True
    Me.lstF10.ItemHeight = 16
    Me.lstF10.Location = New System.Drawing.Point(6, 9)
    Me.lstF10.Name = "lstF10"
    Me.lstF10.Size = New System.Drawing.Size(256, 180)
    Me.lstF10.TabIndex = 1
    '
    'tabF11
    '
    Me.tabF11.Controls.Add(Me.lstF11)
    Me.tabF11.Location = New System.Drawing.Point(4, 25)
    Me.tabF11.Name = "tabF11"
    Me.tabF11.Padding = New System.Windows.Forms.Padding(3)
    Me.tabF11.Size = New System.Drawing.Size(269, 199)
    Me.tabF11.TabIndex = 2
    Me.tabF11.Text = "F11"
    Me.tabF11.UseVisualStyleBackColor = True
    '
    'lstF11
    '
    Me.lstF11.FormattingEnabled = True
    Me.lstF11.ItemHeight = 16
    Me.lstF11.Location = New System.Drawing.Point(6, 9)
    Me.lstF11.Name = "lstF11"
    Me.lstF11.Size = New System.Drawing.Size(256, 180)
    Me.lstF11.TabIndex = 1
    '
    'tabF12
    '
    Me.tabF12.Controls.Add(Me.lstF12)
    Me.tabF12.Location = New System.Drawing.Point(4, 25)
    Me.tabF12.Name = "tabF12"
    Me.tabF12.Padding = New System.Windows.Forms.Padding(3)
    Me.tabF12.Size = New System.Drawing.Size(269, 199)
    Me.tabF12.TabIndex = 3
    Me.tabF12.Text = "F12"
    Me.tabF12.UseVisualStyleBackColor = True
    '
    'lstF12
    '
    Me.lstF12.FormattingEnabled = True
    Me.lstF12.ItemHeight = 16
    Me.lstF12.Location = New System.Drawing.Point(6, 9)
    Me.lstF12.Name = "lstF12"
    Me.lstF12.Size = New System.Drawing.Size(256, 180)
    Me.lstF12.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(311, 139)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(39, 17)
    Me.Label1.TabIndex = 4
    Me.Label1.Text = "Keys"
    '
    'drpKeys
    '
    Me.drpKeys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.drpKeys.FormattingEnabled = True
    Me.drpKeys.Items.AddRange(New Object() {"F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12", "Del", "Ins", "Tab", "Enter", "Esc", "Home", "End", "Page Up", "Page Down", "Down Arrow", "Up Arrow", "Left Arrow", "Right Arrow", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"})
    Me.drpKeys.Location = New System.Drawing.Point(356, 136)
    Me.drpKeys.Name = "drpKeys"
    Me.drpKeys.Size = New System.Drawing.Size(203, 24)
    Me.drpKeys.TabIndex = 5
    '
    'btnAdd
    '
    Me.btnAdd.Location = New System.Drawing.Point(479, 243)
    Me.btnAdd.Name = "btnAdd"
    Me.btnAdd.Size = New System.Drawing.Size(80, 25)
    Me.btnAdd.TabIndex = 6
    Me.btnAdd.Text = "Add Key"
    Me.btnAdd.UseVisualStyleBackColor = True
    '
    'btnAddApp
    '
    Me.btnAddApp.Location = New System.Drawing.Point(323, 243)
    Me.btnAddApp.Name = "btnAddApp"
    Me.btnAddApp.Size = New System.Drawing.Size(156, 25)
    Me.btnAddApp.TabIndex = 7
    Me.btnAddApp.Text = "Add Application Hold"
    Me.btnAddApp.UseVisualStyleBackColor = True
    '
    'btnRemove
    '
    Me.btnRemove.Location = New System.Drawing.Point(296, 289)
    Me.btnRemove.Name = "btnRemove"
    Me.btnRemove.Size = New System.Drawing.Size(80, 46)
    Me.btnRemove.TabIndex = 8
    Me.btnRemove.Text = "Remove Key"
    Me.btnRemove.UseVisualStyleBackColor = True
    '
    'chkHoldShift
    '
    Me.chkHoldShift.AutoSize = True
    Me.chkHoldShift.Location = New System.Drawing.Point(323, 193)
    Me.chkHoldShift.Name = "chkHoldShift"
    Me.chkHoldShift.Size = New System.Drawing.Size(91, 21)
    Me.chkHoldShift.TabIndex = 9
    Me.chkHoldShift.Text = "Hold Shift"
    Me.chkHoldShift.UseVisualStyleBackColor = True
    '
    'chkHoldAlt
    '
    Me.chkHoldAlt.AutoSize = True
    Me.chkHoldAlt.Location = New System.Drawing.Point(323, 219)
    Me.chkHoldAlt.Name = "chkHoldAlt"
    Me.chkHoldAlt.Size = New System.Drawing.Size(79, 21)
    Me.chkHoldAlt.TabIndex = 10
    Me.chkHoldAlt.Text = "Hold Alt"
    Me.chkHoldAlt.UseVisualStyleBackColor = True
    '
    'chkHoldCtrl
    '
    Me.chkHoldCtrl.AutoSize = True
    Me.chkHoldCtrl.Location = New System.Drawing.Point(323, 166)
    Me.chkHoldCtrl.Name = "chkHoldCtrl"
    Me.chkHoldCtrl.Size = New System.Drawing.Size(84, 21)
    Me.chkHoldCtrl.TabIndex = 11
    Me.chkHoldCtrl.Text = "Hold Ctrl"
    Me.chkHoldCtrl.UseVisualStyleBackColor = True
    '
    'btnClearList
    '
    Me.btnClearList.Location = New System.Drawing.Point(390, 289)
    Me.btnClearList.Name = "btnClearList"
    Me.btnClearList.Size = New System.Drawing.Size(77, 46)
    Me.btnClearList.TabIndex = 12
    Me.btnClearList.Text = "Clear List"
    Me.btnClearList.UseVisualStyleBackColor = True
    '
    'SetHotkeys
    '
    Me.AcceptButton = Me.OK_Button
    Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.CancelButton = Me.Cancel_Button
    Me.ClientSize = New System.Drawing.Size(580, 388)
    Me.Controls.Add(Me.btnClearList)
    Me.Controls.Add(Me.chkHoldCtrl)
    Me.Controls.Add(Me.chkHoldAlt)
    Me.Controls.Add(Me.chkHoldShift)
    Me.Controls.Add(Me.btnRemove)
    Me.Controls.Add(Me.btnAddApp)
    Me.Controls.Add(Me.btnAdd)
    Me.Controls.Add(Me.drpKeys)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.tabHotkeys)
    Me.Controls.Add(Me.TextBox1)
    Me.Controls.Add(Me.TableLayoutPanel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.Margin = New System.Windows.Forms.Padding(4)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "SetHotkeys"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "SetHotkeys"
    Me.TableLayoutPanel1.ResumeLayout(False)
    Me.tabHotkeys.ResumeLayout(False)
    Me.tabF9.ResumeLayout(False)
    Me.tabF10.ResumeLayout(False)
    Me.tabF11.ResumeLayout(False)
    Me.tabF12.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents OK_Button As System.Windows.Forms.Button
  Friend WithEvents Cancel_Button As System.Windows.Forms.Button
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents tabHotkeys As System.Windows.Forms.TabControl
  Friend WithEvents tabF9 As System.Windows.Forms.TabPage
  Friend WithEvents tabF10 As System.Windows.Forms.TabPage
  Friend WithEvents tabF11 As System.Windows.Forms.TabPage
  Friend WithEvents tabF12 As System.Windows.Forms.TabPage
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents drpKeys As System.Windows.Forms.ComboBox
  Friend WithEvents btnAdd As System.Windows.Forms.Button
  Friend WithEvents btnAddApp As System.Windows.Forms.Button
  Friend WithEvents btnRemove As System.Windows.Forms.Button
  Friend WithEvents lstF9 As System.Windows.Forms.ListBox
  Friend WithEvents lstF10 As System.Windows.Forms.ListBox
  Friend WithEvents lstF11 As System.Windows.Forms.ListBox
  Friend WithEvents lstF12 As System.Windows.Forms.ListBox
  Friend WithEvents chkHoldShift As System.Windows.Forms.CheckBox
  Friend WithEvents chkHoldAlt As System.Windows.Forms.CheckBox
  Friend WithEvents chkHoldCtrl As System.Windows.Forms.CheckBox
  Friend WithEvents btnClearList As System.Windows.Forms.Button

End Class
