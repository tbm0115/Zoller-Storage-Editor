<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
    Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Racks")
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
    Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
    Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuOpen = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuSave = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
    Me.mnuQuit = New System.Windows.Forms.ToolStripMenuItem()
    Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuRenameObject = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuEditWidth = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuEditDepth = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuEditHeight = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuEditLocationX = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuEditLocationY = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuEditLocationZ = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
    Me.mnuRefresh = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
    Me.OutliningToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuOutRack = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuOutShelf = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuOutCell = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuTools = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuSaveImage = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
    Me.mnuAdd = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuAddRange = New System.Windows.Forms.ToolStripMenuItem()
    Me.AlignToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuAlignHL = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuAlignHC = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuAlignHR = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuAlignVT = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuAlignVM = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuAlignVB = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuAutoRename = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuFill = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuFillWidth = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuFillDepth = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuFillHeight = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuNormalize = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuNormalizeHor = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuNormalizeVert = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuNormalizeDepth = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
    Me.mnuRemove = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuPreferences = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuSettings = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuHotkeys = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuF9 = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuF10 = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuF11 = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuF12 = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
    Me.mnuHotkeysSet = New System.Windows.Forms.ToolStripMenuItem()
    Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
    Me.statFile = New System.Windows.Forms.ToolStripStatusLabel()
    Me.statProg = New System.Windows.Forms.ToolStripProgressBar()
    Me.statStatus = New System.Windows.Forms.ToolStripStatusLabel()
    Me.spltWork = New System.Windows.Forms.SplitContainer()
    Me.trvStorage = New System.Windows.Forms.TreeView()
    Me.spltView = New System.Windows.Forms.SplitContainer()
    Me.picView = New System.Windows.Forms.PictureBox()
    Me.pnlDetails = New System.Windows.Forms.Panel()
    Me.grpLocation = New System.Windows.Forms.GroupBox()
    Me.numLocationZ = New System.Windows.Forms.NumericUpDown()
    Me.lblLocZ = New System.Windows.Forms.Label()
    Me.numLocationY = New System.Windows.Forms.NumericUpDown()
    Me.lblLocY = New System.Windows.Forms.Label()
    Me.numLocationX = New System.Windows.Forms.NumericUpDown()
    Me.lblLocX = New System.Windows.Forms.Label()
    Me.grpSize = New System.Windows.Forms.GroupBox()
    Me.btnFillHeight = New System.Windows.Forms.Button()
    Me.btnFilleDepth = New System.Windows.Forms.Button()
    Me.btnFillWidth = New System.Windows.Forms.Button()
    Me.numHeight = New System.Windows.Forms.NumericUpDown()
    Me.lblHeight = New System.Windows.Forms.Label()
    Me.numDepth = New System.Windows.Forms.NumericUpDown()
    Me.lblDepth = New System.Windows.Forms.Label()
    Me.numWidth = New System.Windows.Forms.NumericUpDown()
    Me.lblWidth = New System.Windows.Forms.Label()
    Me.txtObjectId = New System.Windows.Forms.TextBox()
    Me.lblObjectId = New System.Windows.Forms.Label()
    Me.cmbObjectType = New System.Windows.Forms.ComboBox()
    Me.lblObjectType = New System.Windows.Forms.Label()
    Me.MenuStrip1.SuspendLayout()
    Me.StatusStrip1.SuspendLayout()
    CType(Me.spltWork, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.spltWork.Panel1.SuspendLayout()
    Me.spltWork.Panel2.SuspendLayout()
    Me.spltWork.SuspendLayout()
    CType(Me.spltView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.spltView.Panel1.SuspendLayout()
    Me.spltView.Panel2.SuspendLayout()
    Me.spltView.SuspendLayout()
    CType(Me.picView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.pnlDetails.SuspendLayout()
    Me.grpLocation.SuspendLayout()
    CType(Me.numLocationZ, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.numLocationY, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.numLocationX, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.grpSize.SuspendLayout()
    CType(Me.numHeight, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.numDepth, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.numWidth, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'MenuStrip1
    '
    Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
    Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.EditToolStripMenuItem, Me.mnuTools, Me.mnuPreferences})
    Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
    Me.MenuStrip1.Name = "MenuStrip1"
    Me.MenuStrip1.Size = New System.Drawing.Size(782, 28)
    Me.MenuStrip1.TabIndex = 0
    Me.MenuStrip1.Text = "MenuStrip1"
    '
    'mnuFile
    '
    Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOpen, Me.mnuSave, Me.ToolStripSeparator1, Me.mnuQuit})
    Me.mnuFile.Name = "mnuFile"
    Me.mnuFile.Size = New System.Drawing.Size(44, 24)
    Me.mnuFile.Text = "File"
    '
    'mnuOpen
    '
    Me.mnuOpen.Name = "mnuOpen"
    Me.mnuOpen.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
    Me.mnuOpen.Size = New System.Drawing.Size(182, 26)
    Me.mnuOpen.Text = "Open..."
    '
    'mnuSave
    '
    Me.mnuSave.Name = "mnuSave"
    Me.mnuSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
    Me.mnuSave.Size = New System.Drawing.Size(182, 26)
    Me.mnuSave.Text = "Save"
    '
    'ToolStripSeparator1
    '
    Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
    Me.ToolStripSeparator1.Size = New System.Drawing.Size(179, 6)
    '
    'mnuQuit
    '
    Me.mnuQuit.Name = "mnuQuit"
    Me.mnuQuit.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
    Me.mnuQuit.Size = New System.Drawing.Size(182, 26)
    Me.mnuQuit.Text = "Quit"
    '
    'EditToolStripMenuItem
    '
    Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRenameObject, Me.mnuEditWidth, Me.mnuEditDepth, Me.mnuEditHeight, Me.mnuEditLocationX, Me.mnuEditLocationY, Me.mnuEditLocationZ, Me.ToolStripSeparator2, Me.mnuRefresh, Me.ToolStripSeparator4, Me.OutliningToolStripMenuItem})
    Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
    Me.EditToolStripMenuItem.Size = New System.Drawing.Size(47, 24)
    Me.EditToolStripMenuItem.Text = "Edit"
    '
    'mnuRenameObject
    '
    Me.mnuRenameObject.Name = "mnuRenameObject"
    Me.mnuRenameObject.ShortcutKeys = System.Windows.Forms.Keys.F2
    Me.mnuRenameObject.Size = New System.Drawing.Size(210, 26)
    Me.mnuRenameObject.Text = "Rename Object"
    '
    'mnuEditWidth
    '
    Me.mnuEditWidth.Name = "mnuEditWidth"
    Me.mnuEditWidth.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
    Me.mnuEditWidth.Size = New System.Drawing.Size(210, 26)
    Me.mnuEditWidth.Text = "&Width"
    '
    'mnuEditDepth
    '
    Me.mnuEditDepth.Name = "mnuEditDepth"
    Me.mnuEditDepth.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
    Me.mnuEditDepth.Size = New System.Drawing.Size(210, 26)
    Me.mnuEditDepth.Text = "&Depth"
    '
    'mnuEditHeight
    '
    Me.mnuEditHeight.Name = "mnuEditHeight"
    Me.mnuEditHeight.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
    Me.mnuEditHeight.Size = New System.Drawing.Size(210, 26)
    Me.mnuEditHeight.Text = "&Height"
    '
    'mnuEditLocationX
    '
    Me.mnuEditLocationX.Name = "mnuEditLocationX"
    Me.mnuEditLocationX.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
    Me.mnuEditLocationX.Size = New System.Drawing.Size(210, 26)
    Me.mnuEditLocationX.Text = "Location &X"
    '
    'mnuEditLocationY
    '
    Me.mnuEditLocationY.Name = "mnuEditLocationY"
    Me.mnuEditLocationY.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
    Me.mnuEditLocationY.Size = New System.Drawing.Size(210, 26)
    Me.mnuEditLocationY.Text = "Location &Y"
    '
    'mnuEditLocationZ
    '
    Me.mnuEditLocationZ.Name = "mnuEditLocationZ"
    Me.mnuEditLocationZ.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
    Me.mnuEditLocationZ.Size = New System.Drawing.Size(210, 26)
    Me.mnuEditLocationZ.Text = "Location &Z"
    '
    'ToolStripSeparator2
    '
    Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
    Me.ToolStripSeparator2.Size = New System.Drawing.Size(207, 6)
    '
    'mnuRefresh
    '
    Me.mnuRefresh.Name = "mnuRefresh"
    Me.mnuRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5
    Me.mnuRefresh.Size = New System.Drawing.Size(210, 26)
    Me.mnuRefresh.Text = "Refresh"
    '
    'ToolStripSeparator4
    '
    Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
    Me.ToolStripSeparator4.Size = New System.Drawing.Size(207, 6)
    '
    'OutliningToolStripMenuItem
    '
    Me.OutliningToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOutRack, Me.mnuOutShelf, Me.mnuOutCell})
    Me.OutliningToolStripMenuItem.Name = "OutliningToolStripMenuItem"
    Me.OutliningToolStripMenuItem.Size = New System.Drawing.Size(210, 26)
    Me.OutliningToolStripMenuItem.Text = "Outlining"
    '
    'mnuOutRack
    '
    Me.mnuOutRack.Name = "mnuOutRack"
    Me.mnuOutRack.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
    Me.mnuOutRack.Size = New System.Drawing.Size(376, 26)
    Me.mnuOutRack.Text = "Expand/Collapse to Racks/Cabinets"
    '
    'mnuOutShelf
    '
    Me.mnuOutShelf.Name = "mnuOutShelf"
    Me.mnuOutShelf.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
    Me.mnuOutShelf.Size = New System.Drawing.Size(376, 26)
    Me.mnuOutShelf.Text = "Expand/Collapse to Shelves/Drawers"
    '
    'mnuOutCell
    '
    Me.mnuOutCell.Name = "mnuOutCell"
    Me.mnuOutCell.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
    Me.mnuOutCell.Size = New System.Drawing.Size(376, 26)
    Me.mnuOutCell.Text = "Expand to Cells"
    '
    'mnuTools
    '
    Me.mnuTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSaveImage, Me.ToolStripSeparator3, Me.mnuAdd, Me.mnuAddRange, Me.AlignToolStripMenuItem, Me.mnuAutoRename, Me.mnuFill, Me.mnuNormalize, Me.ToolStripSeparator5, Me.mnuRemove})
    Me.mnuTools.Name = "mnuTools"
    Me.mnuTools.Size = New System.Drawing.Size(57, 24)
    Me.mnuTools.Text = "Tools"
    '
    'mnuSaveImage
    '
    Me.mnuSaveImage.Name = "mnuSaveImage"
    Me.mnuSaveImage.Size = New System.Drawing.Size(212, 26)
    Me.mnuSaveImage.Text = "Save Image..."
    '
    'ToolStripSeparator3
    '
    Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
    Me.ToolStripSeparator3.Size = New System.Drawing.Size(209, 6)
    '
    'mnuAdd
    '
    Me.mnuAdd.Name = "mnuAdd"
    Me.mnuAdd.ShortcutKeys = System.Windows.Forms.Keys.Insert
    Me.mnuAdd.Size = New System.Drawing.Size(212, 26)
    Me.mnuAdd.Text = "Add"
    '
    'mnuAddRange
    '
    Me.mnuAddRange.Name = "mnuAddRange"
    Me.mnuAddRange.ShortcutKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.Insert), System.Windows.Forms.Keys)
    Me.mnuAddRange.Size = New System.Drawing.Size(212, 26)
    Me.mnuAddRange.Text = "Add..."
    '
    'AlignToolStripMenuItem
    '
    Me.AlignToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAlignHL, Me.mnuAlignHC, Me.mnuAlignHR, Me.mnuAlignVT, Me.mnuAlignVM, Me.mnuAlignVB})
    Me.AlignToolStripMenuItem.Name = "AlignToolStripMenuItem"
    Me.AlignToolStripMenuItem.Size = New System.Drawing.Size(212, 26)
    Me.AlignToolStripMenuItem.Text = "Align"
    '
    'mnuAlignHL
    '
    Me.mnuAlignHL.Name = "mnuAlignHL"
    Me.mnuAlignHL.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.NumPad4), System.Windows.Forms.Keys)
    Me.mnuAlignHL.Size = New System.Drawing.Size(304, 26)
    Me.mnuAlignHL.Text = "Horizontal Left"
    '
    'mnuAlignHC
    '
    Me.mnuAlignHC.Name = "mnuAlignHC"
    Me.mnuAlignHC.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.NumPad5), System.Windows.Forms.Keys)
    Me.mnuAlignHC.Size = New System.Drawing.Size(304, 26)
    Me.mnuAlignHC.Text = "Horizontal Center"
    '
    'mnuAlignHR
    '
    Me.mnuAlignHR.Name = "mnuAlignHR"
    Me.mnuAlignHR.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.NumPad6), System.Windows.Forms.Keys)
    Me.mnuAlignHR.Size = New System.Drawing.Size(304, 26)
    Me.mnuAlignHR.Text = "Horizontal Right"
    '
    'mnuAlignVT
    '
    Me.mnuAlignVT.Name = "mnuAlignVT"
    Me.mnuAlignVT.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.NumPad8), System.Windows.Forms.Keys)
    Me.mnuAlignVT.Size = New System.Drawing.Size(304, 26)
    Me.mnuAlignVT.Text = "Vertical Top"
    '
    'mnuAlignVM
    '
    Me.mnuAlignVM.Name = "mnuAlignVM"
    Me.mnuAlignVM.Size = New System.Drawing.Size(304, 26)
    Me.mnuAlignVM.Text = "Vertical Middle"
    '
    'mnuAlignVB
    '
    Me.mnuAlignVB.Name = "mnuAlignVB"
    Me.mnuAlignVB.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.NumPad2), System.Windows.Forms.Keys)
    Me.mnuAlignVB.Size = New System.Drawing.Size(304, 26)
    Me.mnuAlignVB.Text = "Vertical Bottom"
    '
    'mnuAutoRename
    '
    Me.mnuAutoRename.Name = "mnuAutoRename"
    Me.mnuAutoRename.ShortcutKeys = System.Windows.Forms.Keys.F3
    Me.mnuAutoRename.Size = New System.Drawing.Size(212, 26)
    Me.mnuAutoRename.Text = "Auto-Rename"
    '
    'mnuFill
    '
    Me.mnuFill.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFillWidth, Me.mnuFillDepth, Me.mnuFillHeight})
    Me.mnuFill.Name = "mnuFill"
    Me.mnuFill.Size = New System.Drawing.Size(212, 26)
    Me.mnuFill.Text = "Fill"
    '
    'mnuFillWidth
    '
    Me.mnuFillWidth.Name = "mnuFillWidth"
    Me.mnuFillWidth.ShortcutKeys = CType(((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
    Me.mnuFillWidth.Size = New System.Drawing.Size(218, 26)
    Me.mnuFillWidth.Text = "Width"
    '
    'mnuFillDepth
    '
    Me.mnuFillDepth.Name = "mnuFillDepth"
    Me.mnuFillDepth.ShortcutKeys = CType(((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
    Me.mnuFillDepth.Size = New System.Drawing.Size(218, 26)
    Me.mnuFillDepth.Text = "Depth"
    '
    'mnuFillHeight
    '
    Me.mnuFillHeight.Name = "mnuFillHeight"
    Me.mnuFillHeight.ShortcutKeys = CType(((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
    Me.mnuFillHeight.Size = New System.Drawing.Size(218, 26)
    Me.mnuFillHeight.Text = "Height"
    '
    'mnuNormalize
    '
    Me.mnuNormalize.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNormalizeHor, Me.mnuNormalizeVert, Me.mnuNormalizeDepth})
    Me.mnuNormalize.Name = "mnuNormalize"
    Me.mnuNormalize.Size = New System.Drawing.Size(212, 26)
    Me.mnuNormalize.Text = "Normalize Children"
    '
    'mnuNormalizeHor
    '
    Me.mnuNormalizeHor.Name = "mnuNormalizeHor"
    Me.mnuNormalizeHor.ShortcutKeys = System.Windows.Forms.Keys.F6
    Me.mnuNormalizeHor.Size = New System.Drawing.Size(189, 26)
    Me.mnuNormalizeHor.Text = "Horizontally"
    '
    'mnuNormalizeVert
    '
    Me.mnuNormalizeVert.Name = "mnuNormalizeVert"
    Me.mnuNormalizeVert.ShortcutKeys = System.Windows.Forms.Keys.F7
    Me.mnuNormalizeVert.Size = New System.Drawing.Size(189, 26)
    Me.mnuNormalizeVert.Text = "Vertically"
    '
    'mnuNormalizeDepth
    '
    Me.mnuNormalizeDepth.Name = "mnuNormalizeDepth"
    Me.mnuNormalizeDepth.ShortcutKeys = System.Windows.Forms.Keys.F8
    Me.mnuNormalizeDepth.Size = New System.Drawing.Size(189, 26)
    Me.mnuNormalizeDepth.Text = "Depth"
    '
    'ToolStripSeparator5
    '
    Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
    Me.ToolStripSeparator5.Size = New System.Drawing.Size(209, 6)
    '
    'mnuRemove
    '
    Me.mnuRemove.Name = "mnuRemove"
    Me.mnuRemove.ShortcutKeys = System.Windows.Forms.Keys.Delete
    Me.mnuRemove.Size = New System.Drawing.Size(212, 26)
    Me.mnuRemove.Text = "Remove"
    '
    'mnuPreferences
    '
    Me.mnuPreferences.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSettings, Me.mnuHotkeys})
    Me.mnuPreferences.Name = "mnuPreferences"
    Me.mnuPreferences.Size = New System.Drawing.Size(97, 24)
    Me.mnuPreferences.Text = "Preferences"
    '
    'mnuSettings
    '
    Me.mnuSettings.Name = "mnuSettings"
    Me.mnuSettings.Size = New System.Drawing.Size(137, 26)
    Me.mnuSettings.Text = "Settings"
    Me.mnuSettings.Visible = False
    '
    'mnuHotkeys
    '
    Me.mnuHotkeys.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuF9, Me.mnuF10, Me.mnuF11, Me.mnuF12, Me.ToolStripSeparator6, Me.mnuHotkeysSet})
    Me.mnuHotkeys.Name = "mnuHotkeys"
    Me.mnuHotkeys.Size = New System.Drawing.Size(137, 26)
    Me.mnuHotkeys.Text = "Hotkeys"
    '
    'mnuF9
    '
    Me.mnuF9.Name = "mnuF9"
    Me.mnuF9.ShortcutKeys = System.Windows.Forms.Keys.F9
    Me.mnuF9.Size = New System.Drawing.Size(170, 26)
    Me.mnuF9.Text = "Activate"
    '
    'mnuF10
    '
    Me.mnuF10.Name = "mnuF10"
    Me.mnuF10.ShortcutKeys = System.Windows.Forms.Keys.F10
    Me.mnuF10.Size = New System.Drawing.Size(170, 26)
    Me.mnuF10.Text = "Activate"
    '
    'mnuF11
    '
    Me.mnuF11.Name = "mnuF11"
    Me.mnuF11.ShortcutKeys = System.Windows.Forms.Keys.F11
    Me.mnuF11.Size = New System.Drawing.Size(170, 26)
    Me.mnuF11.Text = "Activate"
    '
    'mnuF12
    '
    Me.mnuF12.Name = "mnuF12"
    Me.mnuF12.ShortcutKeys = System.Windows.Forms.Keys.F12
    Me.mnuF12.Size = New System.Drawing.Size(170, 26)
    Me.mnuF12.Text = "Activate"
    '
    'ToolStripSeparator6
    '
    Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
    Me.ToolStripSeparator6.Size = New System.Drawing.Size(167, 6)
    '
    'mnuHotkeysSet
    '
    Me.mnuHotkeysSet.Name = "mnuHotkeysSet"
    Me.mnuHotkeysSet.Size = New System.Drawing.Size(170, 26)
    Me.mnuHotkeysSet.Text = "Set..."
    '
    'StatusStrip1
    '
    Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
    Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statFile, Me.statProg, Me.statStatus})
    Me.StatusStrip1.Location = New System.Drawing.Point(0, 526)
    Me.StatusStrip1.Name = "StatusStrip1"
    Me.StatusStrip1.Size = New System.Drawing.Size(782, 29)
    Me.StatusStrip1.TabIndex = 1
    Me.StatusStrip1.Text = "StatusStrip1"
    '
    'statFile
    '
    Me.statFile.AutoSize = False
    Me.statFile.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
    Me.statFile.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
    Me.statFile.Name = "statFile"
    Me.statFile.Size = New System.Drawing.Size(300, 24)
    Me.statFile.Text = "File"
    Me.statFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'statProg
    '
    Me.statProg.AutoSize = False
    Me.statProg.Name = "statProg"
    Me.statProg.Size = New System.Drawing.Size(200, 23)
    '
    'statStatus
    '
    Me.statStatus.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
    Me.statStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
    Me.statStatus.Name = "statStatus"
    Me.statStatus.Size = New System.Drawing.Size(265, 24)
    Me.statStatus.Spring = True
    Me.statStatus.Text = "Info"
    Me.statStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'spltWork
    '
    Me.spltWork.Dock = System.Windows.Forms.DockStyle.Fill
    Me.spltWork.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
    Me.spltWork.IsSplitterFixed = True
    Me.spltWork.Location = New System.Drawing.Point(0, 28)
    Me.spltWork.Name = "spltWork"
    '
    'spltWork.Panel1
    '
    Me.spltWork.Panel1.Controls.Add(Me.trvStorage)
    Me.spltWork.Panel1.Padding = New System.Windows.Forms.Padding(3)
    '
    'spltWork.Panel2
    '
    Me.spltWork.Panel2.Controls.Add(Me.spltView)
    Me.spltWork.Panel2.Padding = New System.Windows.Forms.Padding(3)
    Me.spltWork.Size = New System.Drawing.Size(782, 498)
    Me.spltWork.SplitterDistance = 260
    Me.spltWork.TabIndex = 2
    '
    'trvStorage
    '
    Me.trvStorage.Dock = System.Windows.Forms.DockStyle.Fill
    Me.trvStorage.HideSelection = False
    Me.trvStorage.Location = New System.Drawing.Point(3, 3)
    Me.trvStorage.Name = "trvStorage"
    TreeNode1.Name = "nodRacks"
    TreeNode1.Text = "Racks"
    Me.trvStorage.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
    Me.trvStorage.Size = New System.Drawing.Size(254, 492)
    Me.trvStorage.TabIndex = 0
    '
    'spltView
    '
    Me.spltView.Dock = System.Windows.Forms.DockStyle.Fill
    Me.spltView.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
    Me.spltView.IsSplitterFixed = True
    Me.spltView.Location = New System.Drawing.Point(3, 3)
    Me.spltView.Name = "spltView"
    Me.spltView.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'spltView.Panel1
    '
    Me.spltView.Panel1.AutoScroll = True
    Me.spltView.Panel1.Controls.Add(Me.picView)
    Me.spltView.Panel1.Padding = New System.Windows.Forms.Padding(5)
    '
    'spltView.Panel2
    '
    Me.spltView.Panel2.Controls.Add(Me.pnlDetails)
    Me.spltView.Panel2.Padding = New System.Windows.Forms.Padding(5)
    Me.spltView.Size = New System.Drawing.Size(512, 492)
    Me.spltView.SplitterDistance = 255
    Me.spltView.TabIndex = 0
    Me.spltView.TabStop = False
    '
    'picView
    '
    Me.picView.BackColor = System.Drawing.Color.White
    Me.picView.Location = New System.Drawing.Point(125, -3)
    Me.picView.Name = "picView"
    Me.picView.Size = New System.Drawing.Size(250, 250)
    Me.picView.TabIndex = 0
    Me.picView.TabStop = False
    '
    'pnlDetails
    '
    Me.pnlDetails.AutoScroll = True
    Me.pnlDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.pnlDetails.Controls.Add(Me.grpLocation)
    Me.pnlDetails.Controls.Add(Me.grpSize)
    Me.pnlDetails.Controls.Add(Me.txtObjectId)
    Me.pnlDetails.Controls.Add(Me.lblObjectId)
    Me.pnlDetails.Controls.Add(Me.cmbObjectType)
    Me.pnlDetails.Controls.Add(Me.lblObjectType)
    Me.pnlDetails.Dock = System.Windows.Forms.DockStyle.Fill
    Me.pnlDetails.Enabled = False
    Me.pnlDetails.Location = New System.Drawing.Point(5, 5)
    Me.pnlDetails.Name = "pnlDetails"
    Me.pnlDetails.Size = New System.Drawing.Size(502, 223)
    Me.pnlDetails.TabIndex = 0
    '
    'grpLocation
    '
    Me.grpLocation.Controls.Add(Me.numLocationZ)
    Me.grpLocation.Controls.Add(Me.lblLocZ)
    Me.grpLocation.Controls.Add(Me.numLocationY)
    Me.grpLocation.Controls.Add(Me.lblLocY)
    Me.grpLocation.Controls.Add(Me.numLocationX)
    Me.grpLocation.Controls.Add(Me.lblLocX)
    Me.grpLocation.Location = New System.Drawing.Point(7, 140)
    Me.grpLocation.Name = "grpLocation"
    Me.grpLocation.Size = New System.Drawing.Size(233, 72)
    Me.grpLocation.TabIndex = 5
    Me.grpLocation.TabStop = False
    Me.grpLocation.Text = "Location"
    '
    'numLocationZ
    '
    Me.numLocationZ.Location = New System.Drawing.Point(155, 44)
    Me.numLocationZ.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
    Me.numLocationZ.Name = "numLocationZ"
    Me.numLocationZ.Size = New System.Drawing.Size(63, 22)
    Me.numLocationZ.TabIndex = 5
    '
    'lblLocZ
    '
    Me.lblLocZ.AutoSize = True
    Me.lblLocZ.Location = New System.Drawing.Point(155, 24)
    Me.lblLocZ.Name = "lblLocZ"
    Me.lblLocZ.Size = New System.Drawing.Size(17, 17)
    Me.lblLocZ.TabIndex = 4
    Me.lblLocZ.Text = "Z"
    '
    'numLocationY
    '
    Me.numLocationY.Location = New System.Drawing.Point(81, 44)
    Me.numLocationY.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
    Me.numLocationY.Name = "numLocationY"
    Me.numLocationY.Size = New System.Drawing.Size(63, 22)
    Me.numLocationY.TabIndex = 3
    '
    'lblLocY
    '
    Me.lblLocY.AutoSize = True
    Me.lblLocY.Location = New System.Drawing.Point(81, 24)
    Me.lblLocY.Name = "lblLocY"
    Me.lblLocY.Size = New System.Drawing.Size(17, 17)
    Me.lblLocY.TabIndex = 2
    Me.lblLocY.Text = "Y"
    '
    'numLocationX
    '
    Me.numLocationX.Location = New System.Drawing.Point(6, 44)
    Me.numLocationX.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
    Me.numLocationX.Name = "numLocationX"
    Me.numLocationX.Size = New System.Drawing.Size(63, 22)
    Me.numLocationX.TabIndex = 1
    '
    'lblLocX
    '
    Me.lblLocX.AutoSize = True
    Me.lblLocX.Location = New System.Drawing.Point(6, 24)
    Me.lblLocX.Name = "lblLocX"
    Me.lblLocX.Size = New System.Drawing.Size(17, 17)
    Me.lblLocX.TabIndex = 0
    Me.lblLocX.Text = "X"
    '
    'grpSize
    '
    Me.grpSize.Controls.Add(Me.btnFillHeight)
    Me.grpSize.Controls.Add(Me.btnFilleDepth)
    Me.grpSize.Controls.Add(Me.btnFillWidth)
    Me.grpSize.Controls.Add(Me.numHeight)
    Me.grpSize.Controls.Add(Me.lblHeight)
    Me.grpSize.Controls.Add(Me.numDepth)
    Me.grpSize.Controls.Add(Me.lblDepth)
    Me.grpSize.Controls.Add(Me.numWidth)
    Me.grpSize.Controls.Add(Me.lblWidth)
    Me.grpSize.Location = New System.Drawing.Point(7, 62)
    Me.grpSize.Name = "grpSize"
    Me.grpSize.Size = New System.Drawing.Size(233, 72)
    Me.grpSize.TabIndex = 4
    Me.grpSize.TabStop = False
    Me.grpSize.Text = "Size"
    '
    'btnFillHeight
    '
    Me.btnFillHeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnFillHeight.Location = New System.Drawing.Point(202, 24)
    Me.btnFillHeight.Name = "btnFillHeight"
    Me.btnFillHeight.Size = New System.Drawing.Size(23, 17)
    Me.btnFillHeight.TabIndex = 8
    Me.btnFillHeight.TabStop = False
    Me.btnFillHeight.UseVisualStyleBackColor = True
    '
    'btnFilleDepth
    '
    Me.btnFilleDepth.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnFilleDepth.Location = New System.Drawing.Point(123, 24)
    Me.btnFilleDepth.Name = "btnFilleDepth"
    Me.btnFilleDepth.Size = New System.Drawing.Size(23, 17)
    Me.btnFilleDepth.TabIndex = 7
    Me.btnFilleDepth.TabStop = False
    Me.btnFilleDepth.UseVisualStyleBackColor = True
    '
    'btnFillWidth
    '
    Me.btnFillWidth.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnFillWidth.Location = New System.Drawing.Point(46, 24)
    Me.btnFillWidth.Name = "btnFillWidth"
    Me.btnFillWidth.Size = New System.Drawing.Size(23, 17)
    Me.btnFillWidth.TabIndex = 6
    Me.btnFillWidth.TabStop = False
    Me.btnFillWidth.UseVisualStyleBackColor = True
    '
    'numHeight
    '
    Me.numHeight.Location = New System.Drawing.Point(155, 44)
    Me.numHeight.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
    Me.numHeight.Name = "numHeight"
    Me.numHeight.Size = New System.Drawing.Size(63, 22)
    Me.numHeight.TabIndex = 5
    '
    'lblHeight
    '
    Me.lblHeight.AutoSize = True
    Me.lblHeight.Location = New System.Drawing.Point(155, 24)
    Me.lblHeight.Name = "lblHeight"
    Me.lblHeight.Size = New System.Drawing.Size(49, 17)
    Me.lblHeight.TabIndex = 4
    Me.lblHeight.Text = "Height"
    '
    'numDepth
    '
    Me.numDepth.Location = New System.Drawing.Point(81, 44)
    Me.numDepth.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
    Me.numDepth.Name = "numDepth"
    Me.numDepth.Size = New System.Drawing.Size(63, 22)
    Me.numDepth.TabIndex = 3
    '
    'lblDepth
    '
    Me.lblDepth.AutoSize = True
    Me.lblDepth.Location = New System.Drawing.Point(81, 24)
    Me.lblDepth.Name = "lblDepth"
    Me.lblDepth.Size = New System.Drawing.Size(46, 17)
    Me.lblDepth.TabIndex = 2
    Me.lblDepth.Text = "Depth"
    '
    'numWidth
    '
    Me.numWidth.Location = New System.Drawing.Point(6, 44)
    Me.numWidth.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
    Me.numWidth.Name = "numWidth"
    Me.numWidth.Size = New System.Drawing.Size(63, 22)
    Me.numWidth.TabIndex = 1
    '
    'lblWidth
    '
    Me.lblWidth.AutoSize = True
    Me.lblWidth.Location = New System.Drawing.Point(6, 24)
    Me.lblWidth.Name = "lblWidth"
    Me.lblWidth.Size = New System.Drawing.Size(44, 17)
    Me.lblWidth.TabIndex = 0
    Me.lblWidth.Text = "Width"
    '
    'txtObjectId
    '
    Me.txtObjectId.Location = New System.Drawing.Point(99, 34)
    Me.txtObjectId.Name = "txtObjectId"
    Me.txtObjectId.Size = New System.Drawing.Size(141, 22)
    Me.txtObjectId.TabIndex = 3
    '
    'lblObjectId
    '
    Me.lblObjectId.AutoSize = True
    Me.lblObjectId.Location = New System.Drawing.Point(25, 37)
    Me.lblObjectId.Name = "lblObjectId"
    Me.lblObjectId.Size = New System.Drawing.Size(68, 17)
    Me.lblObjectId.TabIndex = 2
    Me.lblObjectId.Text = "Object Id:"
    '
    'cmbObjectType
    '
    Me.cmbObjectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cmbObjectType.Enabled = False
    Me.cmbObjectType.FormattingEnabled = True
    Me.cmbObjectType.Items.AddRange(New Object() {"Rack/Cabinet", "Shelf/Drawer", "Cell"})
    Me.cmbObjectType.Location = New System.Drawing.Point(100, 4)
    Me.cmbObjectType.Name = "cmbObjectType"
    Me.cmbObjectType.Size = New System.Drawing.Size(140, 24)
    Me.cmbObjectType.TabIndex = 1
    Me.cmbObjectType.TabStop = False
    '
    'lblObjectType
    '
    Me.lblObjectType.AutoSize = True
    Me.lblObjectType.Location = New System.Drawing.Point(4, 4)
    Me.lblObjectType.Name = "lblObjectType"
    Me.lblObjectType.Size = New System.Drawing.Size(89, 17)
    Me.lblObjectType.TabIndex = 0
    Me.lblObjectType.Text = "Object Type:"
    '
    'Form1
    '
    Me.AllowDrop = True
    Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(782, 555)
    Me.Controls.Add(Me.spltWork)
    Me.Controls.Add(Me.StatusStrip1)
    Me.Controls.Add(Me.MenuStrip1)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MainMenuStrip = Me.MenuStrip1
    Me.Name = "Form1"
    Me.Text = "Zoller Storage Editor"
    Me.MenuStrip1.ResumeLayout(False)
    Me.MenuStrip1.PerformLayout()
    Me.StatusStrip1.ResumeLayout(False)
    Me.StatusStrip1.PerformLayout()
    Me.spltWork.Panel1.ResumeLayout(False)
    Me.spltWork.Panel2.ResumeLayout(False)
    CType(Me.spltWork, System.ComponentModel.ISupportInitialize).EndInit()
    Me.spltWork.ResumeLayout(False)
    Me.spltView.Panel1.ResumeLayout(False)
    Me.spltView.Panel2.ResumeLayout(False)
    CType(Me.spltView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.spltView.ResumeLayout(False)
    CType(Me.picView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.pnlDetails.ResumeLayout(False)
    Me.pnlDetails.PerformLayout()
    Me.grpLocation.ResumeLayout(False)
    Me.grpLocation.PerformLayout()
    CType(Me.numLocationZ, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.numLocationY, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.numLocationX, System.ComponentModel.ISupportInitialize).EndInit()
    Me.grpSize.ResumeLayout(False)
    Me.grpSize.PerformLayout()
    CType(Me.numHeight, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.numDepth, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.numWidth, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
  Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
  Friend WithEvents spltWork As System.Windows.Forms.SplitContainer
  Friend WithEvents trvStorage As System.Windows.Forms.TreeView
  Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuOpen As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuSave As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents mnuQuit As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents spltView As System.Windows.Forms.SplitContainer
  Friend WithEvents picView As System.Windows.Forms.PictureBox
  Friend WithEvents statFile As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents pnlDetails As System.Windows.Forms.Panel
  Friend WithEvents statProg As System.Windows.Forms.ToolStripProgressBar
  Friend WithEvents statStatus As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents cmbObjectType As System.Windows.Forms.ComboBox
  Friend WithEvents lblObjectType As System.Windows.Forms.Label
  Friend WithEvents txtObjectId As System.Windows.Forms.TextBox
  Friend WithEvents lblObjectId As System.Windows.Forms.Label
  Friend WithEvents grpSize As System.Windows.Forms.GroupBox
  Friend WithEvents numHeight As System.Windows.Forms.NumericUpDown
  Friend WithEvents lblHeight As System.Windows.Forms.Label
  Friend WithEvents numDepth As System.Windows.Forms.NumericUpDown
  Friend WithEvents lblDepth As System.Windows.Forms.Label
  Friend WithEvents numWidth As System.Windows.Forms.NumericUpDown
  Friend WithEvents lblWidth As System.Windows.Forms.Label
  Friend WithEvents grpLocation As System.Windows.Forms.GroupBox
  Friend WithEvents numLocationZ As System.Windows.Forms.NumericUpDown
  Friend WithEvents lblLocZ As System.Windows.Forms.Label
  Friend WithEvents numLocationY As System.Windows.Forms.NumericUpDown
  Friend WithEvents lblLocY As System.Windows.Forms.Label
  Friend WithEvents numLocationX As System.Windows.Forms.NumericUpDown
  Friend WithEvents lblLocX As System.Windows.Forms.Label
  Friend WithEvents mnuTools As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuRenameObject As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuEditWidth As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuEditDepth As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuEditHeight As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuEditLocationX As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuEditLocationY As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuEditLocationZ As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents mnuRefresh As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuSaveImage As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents mnuAdd As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents AlignToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuAlignHL As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuAlignHC As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuAlignHR As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuAlignVT As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuAlignVM As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuAlignVB As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents OutliningToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuOutRack As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuOutShelf As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuOutCell As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuAddRange As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuAutoRename As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents mnuRemove As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents btnFillHeight As System.Windows.Forms.Button
  Friend WithEvents btnFilleDepth As System.Windows.Forms.Button
  Friend WithEvents btnFillWidth As System.Windows.Forms.Button
  Friend WithEvents mnuNormalize As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuNormalizeHor As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuNormalizeVert As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuFill As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuFillWidth As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuFillDepth As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuFillHeight As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuNormalizeDepth As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuPreferences As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuSettings As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuHotkeys As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuF9 As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuF10 As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuF11 As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuF12 As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents mnuHotkeysSet As System.Windows.Forms.ToolStripMenuItem

End Class
