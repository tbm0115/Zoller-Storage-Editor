<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddRange
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
    Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
    Me.OK_Button = New System.Windows.Forms.Button()
    Me.Cancel_Button = New System.Windows.Forms.Button()
    Me.grpStart = New System.Windows.Forms.GroupBox()
    Me.lblParentLocation = New System.Windows.Forms.Label()
    Me.numStartZ = New System.Windows.Forms.NumericUpDown()
    Me.numStartY = New System.Windows.Forms.NumericUpDown()
    Me.numStartX = New System.Windows.Forms.NumericUpDown()
    Me.lblStartZ = New System.Windows.Forms.Label()
    Me.lblStartY = New System.Windows.Forms.Label()
    Me.lblStartX = New System.Windows.Forms.Label()
    Me.grpSize = New System.Windows.Forms.GroupBox()
    Me.lblParentSize = New System.Windows.Forms.Label()
    Me.numSizeZ = New System.Windows.Forms.NumericUpDown()
    Me.numSizeY = New System.Windows.Forms.NumericUpDown()
    Me.numSizeX = New System.Windows.Forms.NumericUpDown()
    Me.lblSizeZ = New System.Windows.Forms.Label()
    Me.lblSizeY = New System.Windows.Forms.Label()
    Me.lblSizeX = New System.Windows.Forms.Label()
    Me.grpTranslationType = New System.Windows.Forms.GroupBox()
    Me.radGrid = New System.Windows.Forms.RadioButton()
    Me.radLinear = New System.Windows.Forms.RadioButton()
    Me.grpStep = New System.Windows.Forms.GroupBox()
    Me.numStepZ = New System.Windows.Forms.NumericUpDown()
    Me.numStepY = New System.Windows.Forms.NumericUpDown()
    Me.numStepX = New System.Windows.Forms.NumericUpDown()
    Me.lblStepZ = New System.Windows.Forms.Label()
    Me.lblStepY = New System.Windows.Forms.Label()
    Me.lblStepX = New System.Windows.Forms.Label()
    Me.grpStepOrder = New System.Windows.Forms.GroupBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.numStep3Times = New System.Windows.Forms.NumericUpDown()
    Me.numStep2Times = New System.Windows.Forms.NumericUpDown()
    Me.numStep1Times = New System.Windows.Forms.NumericUpDown()
    Me.txtStep3 = New System.Windows.Forms.TextBox()
    Me.drpStep2 = New System.Windows.Forms.ComboBox()
    Me.drpStep1 = New System.Windows.Forms.ComboBox()
    Me.lblDir3 = New System.Windows.Forms.Label()
    Me.lblDir2 = New System.Windows.Forms.Label()
    Me.lblDir1 = New System.Windows.Forms.Label()
    Me.TableLayoutPanel1.SuspendLayout()
    Me.grpStart.SuspendLayout()
    CType(Me.numStartZ, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.numStartY, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.numStartX, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.grpSize.SuspendLayout()
    CType(Me.numSizeZ, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.numSizeY, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.numSizeX, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.grpTranslationType.SuspendLayout()
    Me.grpStep.SuspendLayout()
    CType(Me.numStepZ, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.numStepY, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.numStepX, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.grpStepOrder.SuspendLayout()
    CType(Me.numStep3Times, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.numStep2Times, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.numStep1Times, System.ComponentModel.ISupportInitialize).BeginInit()
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
    Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 319)
    Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
    Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    Me.TableLayoutPanel1.RowCount = 1
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.Size = New System.Drawing.Size(430, 39)
    Me.TableLayoutPanel1.TabIndex = 5
    '
    'OK_Button
    '
    Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.OK_Button.Location = New System.Drawing.Point(63, 5)
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
    Me.Cancel_Button.Location = New System.Drawing.Point(278, 5)
    Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4)
    Me.Cancel_Button.Name = "Cancel_Button"
    Me.Cancel_Button.Size = New System.Drawing.Size(89, 28)
    Me.Cancel_Button.TabIndex = 1
    Me.Cancel_Button.Text = "Cancel"
    '
    'grpStart
    '
    Me.grpStart.Controls.Add(Me.lblParentLocation)
    Me.grpStart.Controls.Add(Me.numStartZ)
    Me.grpStart.Controls.Add(Me.numStartY)
    Me.grpStart.Controls.Add(Me.numStartX)
    Me.grpStart.Controls.Add(Me.lblStartZ)
    Me.grpStart.Controls.Add(Me.lblStartY)
    Me.grpStart.Controls.Add(Me.lblStartX)
    Me.grpStart.Location = New System.Drawing.Point(13, 3)
    Me.grpStart.Name = "grpStart"
    Me.grpStart.Size = New System.Drawing.Size(200, 130)
    Me.grpStart.TabIndex = 0
    Me.grpStart.TabStop = False
    Me.grpStart.Text = "Start Point"
    '
    'lblParentLocation
    '
    Me.lblParentLocation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblParentLocation.Location = New System.Drawing.Point(6, 16)
    Me.lblParentLocation.Name = "lblParentLocation"
    Me.lblParentLocation.Size = New System.Drawing.Size(183, 23)
    Me.lblParentLocation.TabIndex = 4
    Me.lblParentLocation.Text = "Parent Point:"
    '
    'numStartZ
    '
    Me.numStartZ.Location = New System.Drawing.Point(94, 101)
    Me.numStartZ.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
    Me.numStartZ.Name = "numStartZ"
    Me.numStartZ.Size = New System.Drawing.Size(92, 22)
    Me.numStartZ.TabIndex = 2
    '
    'numStartY
    '
    Me.numStartY.Location = New System.Drawing.Point(94, 71)
    Me.numStartY.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
    Me.numStartY.Name = "numStartY"
    Me.numStartY.Size = New System.Drawing.Size(92, 22)
    Me.numStartY.TabIndex = 1
    '
    'numStartX
    '
    Me.numStartX.Location = New System.Drawing.Point(94, 42)
    Me.numStartX.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
    Me.numStartX.Name = "numStartX"
    Me.numStartX.Size = New System.Drawing.Size(92, 22)
    Me.numStartX.TabIndex = 0
    '
    'lblStartZ
    '
    Me.lblStartZ.AutoSize = True
    Me.lblStartZ.Location = New System.Drawing.Point(7, 103)
    Me.lblStartZ.Name = "lblStartZ"
    Me.lblStartZ.Size = New System.Drawing.Size(80, 17)
    Me.lblStartZ.TabIndex = 2
    Me.lblStartZ.Text = "Z-Location:"
    '
    'lblStartY
    '
    Me.lblStartY.AutoSize = True
    Me.lblStartY.Location = New System.Drawing.Point(7, 73)
    Me.lblStartY.Name = "lblStartY"
    Me.lblStartY.Size = New System.Drawing.Size(80, 17)
    Me.lblStartY.TabIndex = 1
    Me.lblStartY.Text = "Y-Location:"
    '
    'lblStartX
    '
    Me.lblStartX.AutoSize = True
    Me.lblStartX.Location = New System.Drawing.Point(8, 44)
    Me.lblStartX.Name = "lblStartX"
    Me.lblStartX.Size = New System.Drawing.Size(80, 17)
    Me.lblStartX.TabIndex = 0
    Me.lblStartX.Text = "X-Location:"
    '
    'grpSize
    '
    Me.grpSize.Controls.Add(Me.lblParentSize)
    Me.grpSize.Controls.Add(Me.numSizeZ)
    Me.grpSize.Controls.Add(Me.numSizeY)
    Me.grpSize.Controls.Add(Me.numSizeX)
    Me.grpSize.Controls.Add(Me.lblSizeZ)
    Me.grpSize.Controls.Add(Me.lblSizeY)
    Me.grpSize.Controls.Add(Me.lblSizeX)
    Me.grpSize.Location = New System.Drawing.Point(219, 3)
    Me.grpSize.Name = "grpSize"
    Me.grpSize.Size = New System.Drawing.Size(200, 130)
    Me.grpSize.TabIndex = 1
    Me.grpSize.TabStop = False
    Me.grpSize.Text = "Size"
    '
    'lblParentSize
    '
    Me.lblParentSize.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblParentSize.Location = New System.Drawing.Point(11, 16)
    Me.lblParentSize.Name = "lblParentSize"
    Me.lblParentSize.Size = New System.Drawing.Size(183, 23)
    Me.lblParentSize.TabIndex = 3
    Me.lblParentSize.Text = "Parent Size:"
    '
    'numSizeZ
    '
    Me.numSizeZ.Location = New System.Drawing.Point(94, 101)
    Me.numSizeZ.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
    Me.numSizeZ.Name = "numSizeZ"
    Me.numSizeZ.Size = New System.Drawing.Size(92, 22)
    Me.numSizeZ.TabIndex = 2
    '
    'numSizeY
    '
    Me.numSizeY.Location = New System.Drawing.Point(94, 71)
    Me.numSizeY.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
    Me.numSizeY.Name = "numSizeY"
    Me.numSizeY.Size = New System.Drawing.Size(92, 22)
    Me.numSizeY.TabIndex = 1
    '
    'numSizeX
    '
    Me.numSizeX.Location = New System.Drawing.Point(94, 42)
    Me.numSizeX.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
    Me.numSizeX.Name = "numSizeX"
    Me.numSizeX.Size = New System.Drawing.Size(92, 22)
    Me.numSizeX.TabIndex = 0
    '
    'lblSizeZ
    '
    Me.lblSizeZ.AutoSize = True
    Me.lblSizeZ.Location = New System.Drawing.Point(7, 103)
    Me.lblSizeZ.Name = "lblSizeZ"
    Me.lblSizeZ.Size = New System.Drawing.Size(70, 17)
    Me.lblSizeZ.TabIndex = 2
    Me.lblSizeZ.Text = "Z-Length:"
    '
    'lblSizeY
    '
    Me.lblSizeY.AutoSize = True
    Me.lblSizeY.Location = New System.Drawing.Point(7, 73)
    Me.lblSizeY.Name = "lblSizeY"
    Me.lblSizeY.Size = New System.Drawing.Size(70, 17)
    Me.lblSizeY.TabIndex = 1
    Me.lblSizeY.Text = "Y-Length:"
    '
    'lblSizeX
    '
    Me.lblSizeX.AutoSize = True
    Me.lblSizeX.Location = New System.Drawing.Point(8, 44)
    Me.lblSizeX.Name = "lblSizeX"
    Me.lblSizeX.Size = New System.Drawing.Size(70, 17)
    Me.lblSizeX.TabIndex = 1
    Me.lblSizeX.Text = "X-Length:"
    '
    'grpTranslationType
    '
    Me.grpTranslationType.Controls.Add(Me.radGrid)
    Me.grpTranslationType.Controls.Add(Me.radLinear)
    Me.grpTranslationType.Location = New System.Drawing.Point(13, 139)
    Me.grpTranslationType.Name = "grpTranslationType"
    Me.grpTranslationType.Size = New System.Drawing.Size(406, 49)
    Me.grpTranslationType.TabIndex = 2
    Me.grpTranslationType.TabStop = False
    Me.grpTranslationType.Text = "Translation Options"
    '
    'radGrid
    '
    Me.radGrid.AutoSize = True
    Me.radGrid.Checked = True
    Me.radGrid.Location = New System.Drawing.Point(255, 21)
    Me.radGrid.Name = "radGrid"
    Me.radGrid.Size = New System.Drawing.Size(56, 21)
    Me.radGrid.TabIndex = 1
    Me.radGrid.TabStop = True
    Me.radGrid.Text = "Grid"
    Me.radGrid.UseVisualStyleBackColor = True
    '
    'radLinear
    '
    Me.radLinear.AutoSize = True
    Me.radLinear.Location = New System.Drawing.Point(50, 21)
    Me.radLinear.Name = "radLinear"
    Me.radLinear.Size = New System.Drawing.Size(69, 21)
    Me.radLinear.TabIndex = 0
    Me.radLinear.Text = "Linear"
    Me.radLinear.UseVisualStyleBackColor = True
    '
    'grpStep
    '
    Me.grpStep.Controls.Add(Me.numStepZ)
    Me.grpStep.Controls.Add(Me.numStepY)
    Me.grpStep.Controls.Add(Me.numStepX)
    Me.grpStep.Controls.Add(Me.lblStepZ)
    Me.grpStep.Controls.Add(Me.lblStepY)
    Me.grpStep.Controls.Add(Me.lblStepX)
    Me.grpStep.Location = New System.Drawing.Point(13, 194)
    Me.grpStep.Name = "grpStep"
    Me.grpStep.Size = New System.Drawing.Size(200, 120)
    Me.grpStep.TabIndex = 3
    Me.grpStep.TabStop = False
    Me.grpStep.Text = "Step Distance(s)"
    '
    'numStepZ
    '
    Me.numStepZ.Location = New System.Drawing.Point(93, 79)
    Me.numStepZ.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
    Me.numStepZ.Name = "numStepZ"
    Me.numStepZ.Size = New System.Drawing.Size(92, 22)
    Me.numStepZ.TabIndex = 2
    '
    'numStepY
    '
    Me.numStepY.Location = New System.Drawing.Point(93, 49)
    Me.numStepY.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
    Me.numStepY.Name = "numStepY"
    Me.numStepY.Size = New System.Drawing.Size(92, 22)
    Me.numStepY.TabIndex = 1
    '
    'numStepX
    '
    Me.numStepX.Location = New System.Drawing.Point(93, 20)
    Me.numStepX.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
    Me.numStepX.Name = "numStepX"
    Me.numStepX.Size = New System.Drawing.Size(92, 22)
    Me.numStepX.TabIndex = 0
    '
    'lblStepZ
    '
    Me.lblStepZ.AutoSize = True
    Me.lblStepZ.Location = New System.Drawing.Point(31, 81)
    Me.lblStepZ.Name = "lblStepZ"
    Me.lblStepZ.Size = New System.Drawing.Size(55, 17)
    Me.lblStepZ.TabIndex = 2
    Me.lblStepZ.Text = "Z-Step:"
    '
    'lblStepY
    '
    Me.lblStepY.AutoSize = True
    Me.lblStepY.Location = New System.Drawing.Point(31, 51)
    Me.lblStepY.Name = "lblStepY"
    Me.lblStepY.Size = New System.Drawing.Size(55, 17)
    Me.lblStepY.TabIndex = 1
    Me.lblStepY.Text = "Y-Step:"
    '
    'lblStepX
    '
    Me.lblStepX.AutoSize = True
    Me.lblStepX.Location = New System.Drawing.Point(32, 22)
    Me.lblStepX.Name = "lblStepX"
    Me.lblStepX.Size = New System.Drawing.Size(55, 17)
    Me.lblStepX.TabIndex = 0
    Me.lblStepX.Text = "X-Step:"
    '
    'grpStepOrder
    '
    Me.grpStepOrder.Controls.Add(Me.Label3)
    Me.grpStepOrder.Controls.Add(Me.Label2)
    Me.grpStepOrder.Controls.Add(Me.Label1)
    Me.grpStepOrder.Controls.Add(Me.numStep3Times)
    Me.grpStepOrder.Controls.Add(Me.numStep2Times)
    Me.grpStepOrder.Controls.Add(Me.numStep1Times)
    Me.grpStepOrder.Controls.Add(Me.txtStep3)
    Me.grpStepOrder.Controls.Add(Me.drpStep2)
    Me.grpStepOrder.Controls.Add(Me.drpStep1)
    Me.grpStepOrder.Controls.Add(Me.lblDir3)
    Me.grpStepOrder.Controls.Add(Me.lblDir2)
    Me.grpStepOrder.Controls.Add(Me.lblDir1)
    Me.grpStepOrder.Location = New System.Drawing.Point(219, 194)
    Me.grpStepOrder.Name = "grpStepOrder"
    Me.grpStepOrder.Size = New System.Drawing.Size(200, 120)
    Me.grpStepOrder.TabIndex = 4
    Me.grpStepOrder.TabStop = False
    Me.grpStepOrder.Text = "Step Order/Counts"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(154, 81)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(45, 17)
    Me.Label3.TabIndex = 11
    Me.Label3.Text = "times."
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(154, 51)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(45, 17)
    Me.Label2.TabIndex = 10
    Me.Label2.Text = "times,"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(154, 22)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(45, 17)
    Me.Label1.TabIndex = 9
    Me.Label1.Text = "times,"
    '
    'numStep3Times
    '
    Me.numStep3Times.Location = New System.Drawing.Point(111, 79)
    Me.numStep3Times.Name = "numStep3Times"
    Me.numStep3Times.Size = New System.Drawing.Size(37, 22)
    Me.numStep3Times.TabIndex = 8
    '
    'numStep2Times
    '
    Me.numStep2Times.Location = New System.Drawing.Point(111, 49)
    Me.numStep2Times.Name = "numStep2Times"
    Me.numStep2Times.Size = New System.Drawing.Size(37, 22)
    Me.numStep2Times.TabIndex = 7
    '
    'numStep1Times
    '
    Me.numStep1Times.Location = New System.Drawing.Point(111, 20)
    Me.numStep1Times.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
    Me.numStep1Times.Name = "numStep1Times"
    Me.numStep1Times.Size = New System.Drawing.Size(37, 22)
    Me.numStep1Times.TabIndex = 6
    Me.numStep1Times.Value = New Decimal(New Integer() {1, 0, 0, 0})
    '
    'txtStep3
    '
    Me.txtStep3.Location = New System.Drawing.Point(63, 78)
    Me.txtStep3.Name = "txtStep3"
    Me.txtStep3.ReadOnly = True
    Me.txtStep3.Size = New System.Drawing.Size(42, 22)
    Me.txtStep3.TabIndex = 5
    '
    'drpStep2
    '
    Me.drpStep2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.drpStep2.Enabled = False
    Me.drpStep2.FormattingEnabled = True
    Me.drpStep2.Location = New System.Drawing.Point(63, 48)
    Me.drpStep2.Name = "drpStep2"
    Me.drpStep2.Size = New System.Drawing.Size(42, 24)
    Me.drpStep2.TabIndex = 4
    '
    'drpStep1
    '
    Me.drpStep1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.drpStep1.FormattingEnabled = True
    Me.drpStep1.Items.AddRange(New Object() {"X", "Y", "Z"})
    Me.drpStep1.Location = New System.Drawing.Point(63, 19)
    Me.drpStep1.Name = "drpStep1"
    Me.drpStep1.Size = New System.Drawing.Size(42, 24)
    Me.drpStep1.TabIndex = 3
    '
    'lblDir3
    '
    Me.lblDir3.AutoSize = True
    Me.lblDir3.Location = New System.Drawing.Point(7, 81)
    Me.lblDir3.Name = "lblDir3"
    Me.lblDir3.Size = New System.Drawing.Size(51, 17)
    Me.lblDir3.TabIndex = 2
    Me.lblDir3.Text = "then in"
    '
    'lblDir2
    '
    Me.lblDir2.AutoSize = True
    Me.lblDir2.Location = New System.Drawing.Point(8, 51)
    Me.lblDir2.Name = "lblDir2"
    Me.lblDir2.Size = New System.Drawing.Size(51, 17)
    Me.lblDir2.TabIndex = 1
    Me.lblDir2.Text = "then in"
    '
    'lblDir1
    '
    Me.lblDir1.AutoSize = True
    Me.lblDir1.Location = New System.Drawing.Point(8, 22)
    Me.lblDir1.Name = "lblDir1"
    Me.lblDir1.Size = New System.Drawing.Size(52, 17)
    Me.lblDir1.TabIndex = 0
    Me.lblDir1.Text = "Step in"
    '
    'AddRange
    '
    Me.AcceptButton = Me.OK_Button
    Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.CancelButton = Me.Cancel_Button
    Me.ClientSize = New System.Drawing.Size(430, 358)
    Me.Controls.Add(Me.grpStepOrder)
    Me.Controls.Add(Me.grpStep)
    Me.Controls.Add(Me.grpTranslationType)
    Me.Controls.Add(Me.grpSize)
    Me.Controls.Add(Me.grpStart)
    Me.Controls.Add(Me.TableLayoutPanel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.Margin = New System.Windows.Forms.Padding(4)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "AddRange"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Add Range"
    Me.TableLayoutPanel1.ResumeLayout(False)
    Me.grpStart.ResumeLayout(False)
    Me.grpStart.PerformLayout()
    CType(Me.numStartZ, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.numStartY, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.numStartX, System.ComponentModel.ISupportInitialize).EndInit()
    Me.grpSize.ResumeLayout(False)
    Me.grpSize.PerformLayout()
    CType(Me.numSizeZ, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.numSizeY, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.numSizeX, System.ComponentModel.ISupportInitialize).EndInit()
    Me.grpTranslationType.ResumeLayout(False)
    Me.grpTranslationType.PerformLayout()
    Me.grpStep.ResumeLayout(False)
    Me.grpStep.PerformLayout()
    CType(Me.numStepZ, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.numStepY, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.numStepX, System.ComponentModel.ISupportInitialize).EndInit()
    Me.grpStepOrder.ResumeLayout(False)
    Me.grpStepOrder.PerformLayout()
    CType(Me.numStep3Times, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.numStep2Times, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.numStep1Times, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents OK_Button As System.Windows.Forms.Button
  Friend WithEvents Cancel_Button As System.Windows.Forms.Button
  Private WithEvents grpStart As System.Windows.Forms.GroupBox
  Private WithEvents numStartZ As System.Windows.Forms.NumericUpDown
  Private WithEvents numStartY As System.Windows.Forms.NumericUpDown
  Private WithEvents numStartX As System.Windows.Forms.NumericUpDown
  Private WithEvents lblStartZ As System.Windows.Forms.Label
  Private WithEvents lblStartY As System.Windows.Forms.Label
  Private WithEvents lblStartX As System.Windows.Forms.Label
  Private WithEvents grpSize As System.Windows.Forms.GroupBox
  Private WithEvents numSizeZ As System.Windows.Forms.NumericUpDown
  Private WithEvents numSizeY As System.Windows.Forms.NumericUpDown
  Private WithEvents numSizeX As System.Windows.Forms.NumericUpDown
  Private WithEvents lblSizeZ As System.Windows.Forms.Label
  Private WithEvents lblSizeY As System.Windows.Forms.Label
  Private WithEvents lblSizeX As System.Windows.Forms.Label
  Private WithEvents grpTranslationType As System.Windows.Forms.GroupBox
  Private WithEvents radLinear As System.Windows.Forms.RadioButton
  Private WithEvents radGrid As System.Windows.Forms.RadioButton
  Private WithEvents grpStep As System.Windows.Forms.GroupBox
  Private WithEvents numStepZ As System.Windows.Forms.NumericUpDown
  Private WithEvents numStepY As System.Windows.Forms.NumericUpDown
  Private WithEvents numStepX As System.Windows.Forms.NumericUpDown
  Private WithEvents lblStepZ As System.Windows.Forms.Label
  Private WithEvents lblStepY As System.Windows.Forms.Label
  Private WithEvents lblStepX As System.Windows.Forms.Label
  Private WithEvents grpStepOrder As System.Windows.Forms.GroupBox
  Private WithEvents lblDir3 As System.Windows.Forms.Label
  Private WithEvents lblDir2 As System.Windows.Forms.Label
  Private WithEvents lblDir1 As System.Windows.Forms.Label
  Private WithEvents drpStep1 As System.Windows.Forms.ComboBox
  Private WithEvents drpStep2 As System.Windows.Forms.ComboBox
  Private WithEvents txtStep3 As System.Windows.Forms.TextBox
  Private WithEvents numStep3Times As System.Windows.Forms.NumericUpDown
  Private WithEvents numStep2Times As System.Windows.Forms.NumericUpDown
  Private WithEvents numStep1Times As System.Windows.Forms.NumericUpDown
  Private WithEvents Label3 As System.Windows.Forms.Label
  Private WithEvents Label2 As System.Windows.Forms.Label
  Private WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents lblParentSize As System.Windows.Forms.Label
  Friend WithEvents lblParentLocation As System.Windows.Forms.Label

End Class
