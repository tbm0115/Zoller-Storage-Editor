Imports System.Xml, System.Xml.Serialization
Imports System.Runtime.CompilerServices, System.Reflection

Public Class Form1
  Public Event ObjectSelected(ByVal Obj As Object)
  Private _data As Data
  Private _racks As Rack()

  Private Sub mnuOpen_Click(sender As Object, e As EventArgs) Handles mnuOpen.Click

    '' Initialize Open File Dialog
    Dim opn As New OpenFileDialog
    opn.Title = "Select Zoller Storage file..."
    opn.Filter = "Zoller Export (*.xml)|*.xml"
    opn.CheckFileExists = True
    If opn.ShowDialog() = Windows.Forms.DialogResult.OK AndAlso IO.File.Exists(opn.FileName) Then
      LoadFile(opn.FileName)
    End If
  End Sub
  Private Sub LoadFile(ByVal FilePath As String)
    '' Clear form
    statFile.Text = String.Empty
    pnlDetails.Enabled = False

    statFile.Text = FilePath
    '' Initialize serializer
    Dim rt As New XmlRootAttribute()
    rt.ElementName = "Data"
    rt.IsNullable = True
    Dim ser As New XmlSerializer(GetType(Data), rt)
    '' Deserialize the selected file
    Try
      Using reader As IO.TextReader = New IO.StreamReader(statFile.Text)
        _data = ser.Deserialize(reader)
      End Using
      If Not IsNothing(_data) Then
        _racks = _data.GetRacks()
      Else
        statStatus.Text = "Data was empty!"
      End If
    Catch ex As Exception
      statStatus.Text = "Error: " & ex.Message
    End Try
    LoadTree()
  End Sub
  Private Sub LoadTree()
    trvStorage.BeginUpdate()
    trvStorage.Nodes.Clear()
    Application.DoEvents()
    If Not IsNothing(_racks) Then
      trvStorage.Nodes.Add("Racks [" & _racks.Length.ToString & "]")
      '' Add racks to TreeView
      For Each r As Rack In _racks
        Dim rn As New TreeNode(r.Id)
        rn.Tag = r '' Add object reference
        If Not IsNothing(r.Shelves) AndAlso r.Shelves.Length > 0 Then
          rn.Text += " [" & r.Shelves.Length.ToString & "]"
          '' Add shelves
          For Each s As Rack.Shelf In r.Shelves
            Dim sn As New TreeNode(s.Id)
            sn.Tag = s '' Add object reference
            If Not IsNothing(s.Cells) AndAlso s.Cells.Length > 0 Then
              sn.Text += " [" & s.Cells.Length.ToString & "]"
              '' Add cells
              For Each c As Rack.Shelf.Cell In s.Cells
                sn.Nodes.Add((New TreeNode(c.Id) With {.Tag = c}))
              Next
            End If
            rn.Nodes.Add(sn)
          Next
        End If
        trvStorage.Nodes(0).Nodes.Add(rn)
      Next
    End If
    trvStorage.ExpandAll()
    trvStorage.EndUpdate()
  End Sub
  Private Sub mnuSave_Click(sender As Object, e As EventArgs) Handles mnuSave.Click
    If Not String.IsNullOrEmpty(statFile.Text) Then
      Dim rt As New XmlRootAttribute()
      rt.ElementName = "Data"
      rt.IsNullable = True
      Dim ser As New XmlSerializer(GetType(Data), rt)
      Dim xw As XmlWriter = XmlWriter.Create(statFile.Text)
      ser.Serialize(xw, _data)
      xw.Close()
      statStatus.Text = "Saved!"
    Else
      statStatus.Text = "File must be loaded!"
    End If
  End Sub

  Private Sub Form1_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
    If e.Data.GetDataPresent(DataFormats.FileDrop) Then
      Debug.WriteLine("Receiving file(s):")
      Dim files As String() = e.Data.GetData(DataFormats.FileDrop)
      Dim blnGood As Boolean = True
      For Each fil As String In files
        If Not fil.ToLower.EndsWith(".xml") Then statStatus.Text = "XML Files Only!" : blnGood = False
        Debug.WriteLine(vbTab & fil)
      Next
      If blnGood Then e.Effect = DragDropEffects.Move
    End If
  End Sub
  Private Sub Form1_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
    If e.Data.GetDataPresent(DataFormats.FileDrop) Then
      Dim files As String() = e.Data.GetData(DataFormats.FileDrop)
      If Not IsNothing(files) Then
        If files.Length > 1 Then
          MessageBox.Show("Can only load 1 file at a time!", "Too Many Files", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf files.Length = 1 Then
          LoadFile(files(0))
        End If
      End If
    End If
  End Sub

  Private Sub Object_Selected(ByVal obj As Object) Handles Me.ObjectSelected
    pnlDetails.Enabled = False
    grpLocation.Enabled = False
    blnDrawing = True
    Dim typ As Type = obj.GetType()
    Select Case typ.Name
      Case "Rack"
        SelectedObject = obj
        pnlDetails.Enabled = True
        cmbObjectType.SelectedIndex = 0
        Dim r As Rack = obj
        txtObjectId.Text = r.Id
        numWidth.Value = r.Width
        numDepth.Value = r.Depth
        numHeight.Value = r.Height
        numLocationX.Value = 0
        numLocationY.Value = 0
        numLocationZ.Value = 0
        Draw(trvStorage.SelectedNode.Tag)
      Case "Shelf"
        SelectedObject = obj
        pnlDetails.Enabled = True
        grpLocation.Enabled = True
        cmbObjectType.SelectedIndex = 1
        Dim s As Rack.Shelf = obj
        txtObjectId.Text = s.Id
        numWidth.Value = s.Width
        numDepth.Value = s.Depth
        numHeight.Value = s.Height
        numLocationX.Value = s.LocationX
        numLocationY.Value = s.LocationY
        numLocationZ.Value = s.LocationZ
        Draw(trvStorage.SelectedNode.Parent.Tag)
        Draw(trvStorage.SelectedNode.Tag)
      Case "Cell"
        SelectedObject = obj
        pnlDetails.Enabled = True
        grpLocation.Enabled = True
        cmbObjectType.SelectedIndex = 2
        Dim c As Rack.Shelf.Cell = obj
        txtObjectId.Text = c.Id
        numWidth.Value = c.Width
        numDepth.Value = c.Depth
        numHeight.Value = c.Height
        numLocationX.Value = c.LocationX
        numLocationY.Value = c.LocationY
        numLocationZ.Value = c.LocationZ
        Draw(trvStorage.SelectedNode.Parent.Parent.Tag)
        Draw(trvStorage.SelectedNode.Parent.Tag)
    End Select
    blnDrawing = False
  End Sub

  Private Sub trvStorage_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trvStorage.AfterSelect
    If Not IsNothing(e.Node) AndAlso Not IsNothing(e.Node.Tag) Then
      RaiseEvent ObjectSelected(e.Node.Tag)
    End If
  End Sub

  Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
    Dim sz As Size = spltView.Panel1.ClientSize
    picView.Size = New Size(Math.Min(sz.Width, sz.Height), Math.Min(sz.Width, sz.Height))
    Dim margin As Integer = (sz.Width - picView.Size.Width) / 2
    picView.Left = margin

    Dim ps As Size = picView.Size
    Dim bs As Size = New Size(ps.Width / 2, ps.Height / 2)
    _Draw.FrontBound = New Rectangle(0, 0, bs.Width, bs.Height)
    _Draw.SideBound = New Rectangle(bs.Width, 0, bs.Width, bs.Height)
    _Draw.TopBound = New Rectangle(0, bs.Height, bs.Width, bs.Height)
    _Draw.CellBound = New Rectangle(bs.Width, bs.Height, bs.Width, bs.Height)
    DrawOnly()
  End Sub

  Private Sub DrawOnly()
    If Not IsNothing(SelectedObject) Then
      Select Case SelectedObject.GetType().Name
        Case "Rack"
          Draw(trvStorage.SelectedNode.Tag)
        Case "Shelf"
          Draw(trvStorage.SelectedNode.Parent.Tag)
        Case "Cell"
          Draw(trvStorage.SelectedNode.Parent.Parent.Tag)
      End Select
    End If
  End Sub

  Private Sub numWidth_ValueChanged(sender As Object, e As EventArgs) Handles numWidth.ValueChanged
    If Not blnDrawing And Not IsNothing(SelectedObject) Then
      If Not IsNothing(SelectedObject.Width) Then
        SelectedObject.Width = sender.Value
        DrawOnly()
      Else
        Debug.WriteLine("Width doesn't exist on selected object")
      End If
    End If
  End Sub
  Private Sub numDepth_ValueChanged(sender As Object, e As EventArgs) Handles numDepth.ValueChanged
    If Not blnDrawing And Not IsNothing(SelectedObject) Then
      If Not IsNothing(SelectedObject.Depth) Then
        SelectedObject.Depth = sender.Value
        DrawOnly()
      Else
        Debug.WriteLine("Depth doesn't exist on selected object")
      End If
    End If
  End Sub
  Private Sub numHeight_ValueChanged(sender As Object, e As EventArgs) Handles numHeight.ValueChanged
    If Not blnDrawing And Not IsNothing(SelectedObject) Then
      If Not IsNothing(SelectedObject.Height) Then
        SelectedObject.Height = sender.Value
        DrawOnly()
      Else
        Debug.WriteLine("Height doesn't exist on selected object")
      End If
    End If
  End Sub

  Private Sub txtObjectId_ValueChanged(sender As Object, e As EventArgs) Handles txtObjectId.TextChanged
    If Not blnDrawing And Not IsNothing(SelectedObject) Then
      If Not IsNothing(SelectedObject.Id) Then
        SelectedObject.Id = sender.Text
      Else
        Debug.WriteLine("Id doesn't exist on selected object")
      End If
    End If
  End Sub

  Private Sub numLocationX_ValueChanged(sender As Object, e As EventArgs) Handles numLocationX.ValueChanged
    If Not blnDrawing And Not IsNothing(SelectedObject) Then
      If Not IsNothing(SelectedObject.LocationX) Then
        SelectedObject.LocationX = sender.Value
        DrawOnly()
      Else
        Debug.WriteLine("LocationX doesn't exist on selected object")
      End If
    End If
  End Sub
  Private Sub numLocationY_ValueChanged(sender As Object, e As EventArgs) Handles numLocationY.ValueChanged
    If Not blnDrawing And Not IsNothing(SelectedObject) Then
      If Not IsNothing(SelectedObject.LocationY) Then
        SelectedObject.LocationY = sender.Value
        DrawOnly()
      Else
        Debug.WriteLine("LocationY doesn't exist on selected object")
      End If
    End If
  End Sub
  Private Sub numLocationZ_ValueChanged(sender As Object, e As EventArgs) Handles numLocationZ.ValueChanged
    If Not blnDrawing And Not IsNothing(SelectedObject) Then
      If Not IsNothing(SelectedObject.LocationZ) Then
        SelectedObject.LocationZ = sender.Value
        DrawOnly()
      Else
        Debug.WriteLine("LocationZ doesn't exist on selected object")
      End If
    End If
  End Sub

  Private Sub mnuObjectRename_Click(sender As Object, e As EventArgs) Handles mnuRenameObject.Click
    If Not IsNothing(SelectedObject) And Not IsNothing(SelectedObject.GetType().GetProperty("Id")) Then
      SelectedObject.Id = InputBox("Enter new Id:", "Change Object Id", SelectedObject.Id)
      txtObjectId.Text = SelectedObject.Id
      trvStorage.SelectedNode.Text = SelectedObject.Id
      Select Case SelectedObject.GetType().Name
        Case "Rack"
          If Not IsNothing(SelectedObject.Shelves) AndAlso SelectedObject.Shelves.Length > 0 Then
            trvStorage.SelectedNode.Text += " [" & SelectedObject.Shelves.Length.ToString & "]"
          End If
        Case "Shelf"
          If Not IsNothing(SelectedObject.Cells) AndAlso SelectedObject.Cells.Length > 0 Then
            trvStorage.SelectedNode.Text += " [" & SelectedObject.Cells.Length.ToString & "]"
          End If
      End Select
    End If
  End Sub
  Private Sub mnuAutoRename_Click(sender As Object, e As EventArgs) Handles mnuAutoRename.Click
    If Not IsNothing(SelectedObject) And Not IsNothing(SelectedObject.GetType().GetProperty("Id")) Then
      Select Case SelectedObject.GetType().Name
        Case "Rack"

        Case "Shelf"
          Dim shlf As Rack.Shelf = SelectedObject
          Dim rck As Rack = shlf.Parent
          Dim blnFound As Boolean = False
          For i = 0 To rck.Shelves.Length - 1 Step 1
            If rck.Shelves(i).LocationX = shlf.LocationX And
              rck.Shelves(i).LocationY = shlf.LocationY And
              rck.Shelves(i).LocationZ = shlf.LocationZ And
              rck.Shelves(i).Width = shlf.Width And
              rck.Shelves(i).Depth = shlf.Depth And
              rck.Shelves(i).Height = shlf.Height Then
              shlf.Id = IntegerToAlphebetical(rck.Shelves.Length - i)
              blnFound = True
              Exit For
            End If
          Next
          If blnFound Then
            If Not IsNothing(shlf.Cells) AndAlso shlf.Cells.Length > 0 Then
              trvStorage.SelectedNode.Text = shlf.Id & " [" & shlf.Cells.Length.ToString & "]"
            Else
              trvStorage.SelectedNode.Text = shlf.Id
            End If
            statStatus.Text = "Changed id to " & shlf.Id
          Else
            statStatus.Text = "Couldn't find shelf"
          End If
        Case "Cell"
          Dim cell As Rack.Shelf.Cell = SelectedObject
          Dim shlf As Rack.Shelf = cell.Parent
          Dim blnFound As Boolean = False
          For i = 0 To shlf.Cells.Length - 1 Step 1
            If shlf.Cells(i).LocationX = cell.LocationX And
              shlf.Cells(i).LocationY = cell.LocationY And
              shlf.Cells(i).LocationZ = cell.LocationZ And
              shlf.Cells(i).Width = cell.Width And
              shlf.Cells(i).Depth = cell.Depth And
              shlf.Cells(i).Height = cell.Height Then
              cell.Id = "P" & (i + 1).ToString
              blnFound = True
              Exit For
            End If
          Next
          If blnFound Then
            trvStorage.SelectedNode.Text = cell.Id
            statStatus.Text = "Changed id to " & cell.Id
          Else
            statStatus.Text = "Couldn't find cell"
          End If
      End Select
    End If
  End Sub

  Private Sub mnuEditWidth_Click(sender As Object, e As EventArgs) Handles mnuEditWidth.Click
    numWidth.Focus()
    numWidth.Select()
  End Sub
  Private Sub mnuEditDepth_Click(sender As Object, e As EventArgs) Handles mnuEditDepth.Click
    If pnlDetails.Enabled Then
      numDepth.Focus()
      numDepth.Select()
    End If
  End Sub
  Private Sub mnuEditHeight_Click(sender As Object, e As EventArgs) Handles mnuEditHeight.Click
    If pnlDetails.Enabled Then
      numHeight.Focus()
      numHeight.Select()
    End If
  End Sub
  Private Sub mnuEditLocationX_Click(sender As Object, e As EventArgs) Handles mnuEditLocationX.Click
    If pnlDetails.Enabled Then
      numLocationX.Focus()
      numLocationX.Select()
    End If
  End Sub
  Private Sub mnuEditLocationY_Click(sender As Object, e As EventArgs) Handles mnuEditLocationY.Click
    If pnlDetails.Enabled AndAlso grpLocation.Enabled Then
      numLocationY.Focus()
      numLocationY.Select()
    End If
  End Sub
  Private Sub mnuEditLocationZ_Click(sender As Object, e As EventArgs) Handles mnuEditLocationZ.Click
    If pnlDetails.Enabled AndAlso grpLocation.Enabled Then
      numLocationZ.Focus()
      numLocationZ.Select()
    End If
  End Sub

  Private Sub mnuRefresh_Click(sender As Object, e As EventArgs) Handles mnuRefresh.Click
    DrawOnly()
  End Sub

  Private Sub mnuSaveImage_Click(sender As Object, e As EventArgs) Handles mnuSaveImage.Click
    Dim sav As New SaveFileDialog()
    sav.Title = "Choose where to save the image"
    sav.Filter = "PNG|*.png"
    sav.OverwritePrompt = True
    sav.ShowDialog()

    picView.Image.Save(sav.FileName, Imaging.ImageFormat.Png)
    Process.Start(sav.FileName)
  End Sub

  Private _picMouseDown As Boolean = False
  Private Sub picView_MouseDown(sender As Object, e As MouseEventArgs) Handles picView.MouseDown
    _picMouseDown = True
  End Sub
  Private Sub picView_MouseMove(sender As Object, e As MouseEventArgs) Handles picView.MouseMove
    If _picMouseDown And Not IsNothing(picView.Image) Then
      picView.Image.Save(My.Computer.FileSystem.SpecialDirectories.Temp & "\ZollerStorageEditor_Img.PNG", Imaging.ImageFormat.Png)
      Dim dataObj As New DataObject(DataFormats.FileDrop, New String() {My.Computer.FileSystem.SpecialDirectories.Temp & "\ZollerStorageEditor_Img.PNG"})
      picView.DoDragDrop(dataObj, DragDropEffects.Move)
    End If
    _picMouseDown = False
  End Sub

  Private Sub mnuAlignHL_Click(sender As Object, e As EventArgs) Handles mnuAlignHL.Click
    If Not IsNothing(trvStorage.SelectedNode) AndAlso Not IsNothing(trvStorage.SelectedNode.Tag) Then
      Select Case trvStorage.SelectedNode.Tag.GetType().Name
        'Case "Rack"
        Case "Shelf"
          trvStorage.SelectedNode.Tag.LocationX = 0
        Case "Cell"
          trvStorage.SelectedNode.Tag.LocationX = 0
        Case Else
          statStatus.Text = "Only works on Shelf/Drawer and Cell"
      End Select
      Object_Selected(trvStorage.SelectedNode.Tag)
      statStatus.Text = "Aligned Horizontally Left"
    Else
      statStatus.Text = "Select an object to align!"
    End If
  End Sub
  Private Sub mnuAlignHC_Click(sender As Object, e As EventArgs) Handles mnuAlignHC.Click
    If Not IsNothing(trvStorage.SelectedNode) AndAlso Not IsNothing(trvStorage.SelectedNode.Tag) Then
      Select Case trvStorage.SelectedNode.Tag.GetType().Name
        'Case "Rack"
        Case "Shelf"
          Dim shlf As Rack.Shelf = trvStorage.SelectedNode.Tag
          shlf.LocationX = (shlf.Parent.Width / 2) - (shlf.Width / 2)
        Case "Cell"
          Dim cell As Rack.Shelf.Cell = trvStorage.SelectedNode.Tag
          cell.LocationX = (cell.Parent.Width / 2) - (cell.Width / 2)
        Case Else
          statStatus.Text = "Only works on Shelf/Drawer and Cell"
      End Select
      Object_Selected(trvStorage.SelectedNode.Tag)
      statStatus.Text = "Aligned Horizontally Centered"
    Else
      statStatus.Text = "Select an object to align!"
    End If
  End Sub
  Private Sub mnuAlignHR_Click(sender As Object, e As EventArgs) Handles mnuAlignHR.Click
    If Not IsNothing(trvStorage.SelectedNode) AndAlso Not IsNothing(trvStorage.SelectedNode.Tag) Then
      Select Case trvStorage.SelectedNode.Tag.GetType().Name
        'Case "Rack"
        Case "Shelf"
          Dim shlf As Rack.Shelf = trvStorage.SelectedNode.Tag
          shlf.LocationX = shlf.Parent.Width - shlf.Width
        Case "Cell"
          Dim cell As Rack.Shelf.Cell = trvStorage.SelectedNode.Tag
          cell.LocationX = cell.Parent.Width - cell.Width
        Case Else
          statStatus.Text = "Only works on Shelf/Drawer and Cell"
      End Select
      Object_Selected(trvStorage.SelectedNode.Tag)
      statStatus.Text = "Aligned Horizontally Right"
    Else
      statStatus.Text = "Select an object to align!"
    End If
  End Sub
  Private Sub mnuAlignVT_Click(sender As Object, e As EventArgs) Handles mnuAlignVT.Click
    If Not IsNothing(trvStorage.SelectedNode) AndAlso Not IsNothing(trvStorage.SelectedNode.Tag) Then
      Select Case trvStorage.SelectedNode.Tag.GetType().Name
        'Case "Rack"
        Case "Shelf"
          Dim shlf As Rack.Shelf = trvStorage.SelectedNode.Tag
          shlf.LocationZ = shlf.Parent.Height - shlf.Height
        Case "Cell"
          Dim cell As Rack.Shelf.Cell = trvStorage.SelectedNode.Tag
          cell.LocationY = cell.Parent.Depth - cell.Depth
        Case Else
          statStatus.Text = "Only works on Shelf/Drawer and Cell"
      End Select
      Object_Selected(trvStorage.SelectedNode.Tag)
      statStatus.Text = "Aligned Vertically Top"
    Else
      statStatus.Text = "Select an object to align!"
    End If
  End Sub
  Private Sub mnuAlignVM_Click(sender As Object, e As EventArgs) Handles mnuAlignVM.Click
    If Not IsNothing(trvStorage.SelectedNode) AndAlso Not IsNothing(trvStorage.SelectedNode.Tag) Then
      Select Case trvStorage.SelectedNode.Tag.GetType().Name
        'Case "Rack"
        Case "Shelf"
          Dim shlf As Rack.Shelf = trvStorage.SelectedNode.Tag
          shlf.LocationZ = (shlf.Parent.Height / 2) - (shlf.Height / 2)
        Case "Cell"
          Dim cell As Rack.Shelf.Cell = trvStorage.SelectedNode.Tag
          cell.LocationY = (cell.Parent.Depth / 2) - (cell.Depth / 2)
        Case Else
          statStatus.Text = "Only works on Shelf/Drawer and Cell"
      End Select
      Object_Selected(trvStorage.SelectedNode.Tag)
      statStatus.Text = "Aligned Vertically Middle"
    Else
      statStatus.Text = "Select an object to align!"
    End If
  End Sub
  Private Sub mnuAlignVB_Click(sender As Object, e As EventArgs) Handles mnuAlignVB.Click
    If Not IsNothing(trvStorage.SelectedNode) AndAlso Not IsNothing(trvStorage.SelectedNode.Tag) Then
      Select Case trvStorage.SelectedNode.Tag.GetType().Name
        'Case "Rack"
        Case "Shelf"
          Dim shlf As Rack.Shelf = trvStorage.SelectedNode.Tag
          shlf.LocationZ = 0
        Case "Cell"
          Dim cell As Rack.Shelf.Cell = trvStorage.SelectedNode.Tag
          cell.LocationY = 0
        Case Else
          statStatus.Text = "Only works on Shelf/Drawer and Cell"
      End Select
      Object_Selected(trvStorage.SelectedNode.Tag)
      statStatus.Text = "Aligned Vertically Bottom"
    Else
      statStatus.Text = "Select an object to align!"
    End If
  End Sub

  Private Sub mnuAdd_Click(sender As Object, e As EventArgs) Handles mnuAdd.Click
    If Not IsNothing(trvStorage.SelectedNode) AndAlso Not IsNothing(trvStorage.SelectedNode.Tag) Then
      Select Case trvStorage.SelectedNode.Tag.GetType().Name
        Case "Rack"
          Dim rck As Rack = trvStorage.SelectedNode.Tag
          rck.Add()
        Case "Shelf"

          'Case "Cell"
        Case Else
          statStatus.Text = "Only works on Rack/Cabinet and Shelf/Drawer"
      End Select
      Object_Selected(trvStorage.SelectedNode.Tag)
    ElseIf Not IsNothing(trvStorage.SelectedNode) Then
      '' Add new rack

    End If
  End Sub
  Private Sub mnuAddRange_Click(sender As Object, e As EventArgs) Handles mnuAddRange.Click
    If Not IsNothing(trvStorage.SelectedNode) AndAlso Not IsNothing(trvStorage.SelectedNode.Tag) Then
      Dim ar As New AddRange(trvStorage.SelectedNode.Tag)
      If ar.ShowDialog() = Windows.Forms.DialogResult.OK Then
        Dim cnt, tot As Integer
        If Not ar.ParentObject.GetType().Name = "Cell" Then
          Dim storages As StoragePlaceRef() = ar.GetStorages()
          If Not IsNothing(storages) Then
            For Each obj As StoragePlaceRef In storages
              Dim sl As New StorageLocation
              Dim ss As New StorageSize
              Integer.TryParse(obj.LocationX, sl.X)
              Integer.TryParse(obj.LocationY, sl.Y)
              Integer.TryParse(obj.LocationZ, sl.Z)
              Integer.TryParse(obj.LengthX, ss.Width)
              Integer.TryParse(obj.LengthY, ss.Depth)
              Integer.TryParse(obj.LengthZ, ss.Height)

              ar.ParentObject.Add(sl, ss)
              cnt += 1
            Next
            If cnt > 0 Then
              LoadTree()
              statStatus.Text = "Done! Added " & (cnt - tot).ToString & " objects."
            Else
              statStatus.Text = "Storage generation turned up empty!"
            End If
          Else
            Debug.WriteLine("Storages was found empty")
            statStatus.Text = "Dialog storage generation turned up empty!"
          End If
        Else
          statStatus.Text = "Cannot add objects to Cell!"
        End If
      Else
        statStatus.Text = "Cancelled"
      End If
    Else
      statStatus.Text = "A Rack/Cabinet, Shelf/Drawer, or Cell must be selected!"
    End If
  End Sub

  Private Sub mnuOutRack_Click(sender As Object, e As EventArgs) Handles mnuOutRack.Click
    trvStorage.SelectedNode = trvStorage.Nodes(0)
    trvStorage.BeginUpdate()
    trvStorage.Nodes(0).Expand()
    For Each rn As TreeNode In trvStorage.Nodes(0).Nodes
      If Not IsNothing(rn.Nodes) Then
        For Each sn As TreeNode In rn.Nodes
          If Not IsNothing(sn.Nodes) Then
            For Each cn As TreeNode In sn.Nodes
              cn.Collapse()
            Next
          End If
          sn.Collapse()
        Next
      End If
      rn.Collapse()
    Next
    trvStorage.EndUpdate()
    statStatus.Text = "Collapsed/Expanded Rack(s)"
  End Sub
  Private Sub mnuOutShelf_Click(sender As Object, e As EventArgs) Handles mnuOutShelf.Click
    trvStorage.SelectedNode = trvStorage.Nodes(0)
    trvStorage.BeginUpdate()
    For Each rn As TreeNode In trvStorage.Nodes(0).Nodes
      rn.Expand()
      If Not IsNothing(rn.Nodes) Then
        For Each sn As TreeNode In rn.Nodes
          If Not IsNothing(sn.Nodes) Then
            For Each cn As TreeNode In sn.Nodes
              cn.Collapse()
            Next
          End If
          sn.Collapse()
        Next
      End If
    Next
    trvStorage.EndUpdate()
    statStatus.Text = "Collapsed/Expanded Shelves"
  End Sub
  Private Sub mnuOutCell_Click(sender As Object, e As EventArgs) Handles mnuOutCell.Click
    trvStorage.SelectedNode = trvStorage.Nodes(0)
    trvStorage.ExpandAll()
    statStatus.Text = "Collapsed/Expanded Cell(s)"
  End Sub

  Private Sub mnuRemove_Click(sender As Object, e As EventArgs) Handles mnuRemove.Click
    If Not IsNothing(trvStorage.SelectedNode) AndAlso Not IsNothing(trvStorage.SelectedNode.Tag) Then
      If MessageBox.Show("Are your sure you wish to remove '" & trvStorage.SelectedNode.Text & "'?", "Verify", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        Select Case trvStorage.SelectedNode.Tag.GetType().Name
          Case "Rack"
            Dim rck As Rack = trvStorage.SelectedNode.Tag
            Dim storIndex As Integer = -1
            Dim rackIndex As Integer = -1
            For i = 0 To _data.Storage.Length - 1 Step 1
              If _data.Storage(i).StorageId = rck.Id And
                _data.Storage(i).Width = rck.Width And
                _data.Storage(i).Depth = rck.Depth And
                _data.Storage(i).Height = rck.Height Then
                storIndex = i
                Exit For
              End If
            Next
            For i = 0 To _racks.Length - 1 Step 1
              If _racks(i).Id = rck.Id And
                _racks(i).Width = rck.Width And
                _racks(i).Depth = rck.Depth And
                _racks(i).Height = rck.Height Then
                rackIndex = i
                Exit For
              End If
            Next
            If storIndex >= 0 And rackIndex >= 0 Then
              Dim slst As New List(Of Storage)
              slst.AddRange(_data.Storage)
              slst.RemoveAt(storIndex)
              _data.Storage = slst.ToArray()
              Dim rlst As New List(Of Rack)
              rlst.AddRange(_racks)
              rlst.RemoveAt(rackIndex)
              _racks = rlst.ToArray()
              statStatus.Text = "Successfully removed"
            Else
              statStatus.Text = "Couldn't find rack!"
            End If
          Case "Shelf"
            Dim shlf As Rack.Shelf = trvStorage.SelectedNode.Tag
            shlf.Parent.Remove(shlf)
          Case "Cell"
            Dim cell As Rack.Shelf.Cell = trvStorage.SelectedNode.Tag
            cell.Parent.Remove(cell)
        End Select
        LoadTree()
      Else
        statStatus.Text = "Cancelled removal"
      End If
    Else
      statStatus.Text = "Select an object!"
    End If
  End Sub

  Private Sub btnFillWidth_Click(sender As Object, e As EventArgs) Handles btnFillWidth.Click
    mnuFillWidth_Click(mnuFillWidth, Nothing)
  End Sub
  Private Sub btnFilleDepth_Click(sender As Object, e As EventArgs) Handles btnFilleDepth.Click
    mnuFillDepth_Click(mnuFillDepth, Nothing)
  End Sub
  Private Sub btnFillHeight_Click(sender As Object, e As EventArgs) Handles btnFillHeight.Click
    mnuFillHeight_Click(mnuFillHeight, Nothing)
  End Sub

  Private Sub mnuNormalizeHor_Click(sender As Object, e As EventArgs) Handles mnuNormalizeHor.Click
    If Not IsNothing(trvStorage.SelectedNode) AndAlso Not IsNothing(trvStorage.SelectedNode.Tag) Then
      Select Case trvStorage.SelectedNode.Tag.GetType().Name
        Case "Rack"
          Dim rck As Rack = trvStorage.SelectedNode.Tag
          If Not IsNothing(rck.Shelves) AndAlso rck.Shelves.Length > 0 Then
            Dim tot As Integer = rck.Shelves.Length
            Dim w As Integer = rck.Width / tot
            Dim pos As Integer = 0
            For Each shlf As Rack.Shelf In rck.Shelves
              shlf.Width = w
              shlf.LocationX = pos
              pos += w
            Next
          Else
            statStatus.Text = "No children found to normalize!"
          End If
        Case "Shelf"
          Dim shlf As Rack.Shelf = trvStorage.SelectedNode.Tag
          If Not IsNothing(shlf.Cells) AndAlso shlf.Cells.Length > 0 Then
            Dim tot As Integer = shlf.Cells.Length
            Dim w As Integer = shlf.Width / tot
            Dim pos As Integer = 0
            For Each cell As Rack.Shelf.Cell In shlf.Cells
              cell.Width = w
              cell.LocationX = pos
              pos += w
            Next
          Else
            statStatus.Text = "No children found to normalize!"
          End If
        Case Else
          statStatus.Text = "Can only normalize children of Racks/Shelves!"
      End Select
    Else
      statStatus.Text = "Select an object to normalize its children"
    End If
    DrawOnly()
  End Sub
  Private Sub mnuNormalizeVert_Click(sender As Object, e As EventArgs) Handles mnuNormalizeVert.Click
    If Not IsNothing(trvStorage.SelectedNode) AndAlso Not IsNothing(trvStorage.SelectedNode.Tag) Then
      Select Case trvStorage.SelectedNode.Tag.GetType().Name
        Case "Rack"
          Dim rck As Rack = trvStorage.SelectedNode.Tag
          If Not IsNothing(rck.Shelves) AndAlso rck.Shelves.Length > 0 Then
            Dim tot As Integer = rck.Shelves.Length
            Dim h As Integer = rck.Height / tot
            Dim pos As Integer = 0
            For Each shlf As Rack.Shelf In rck.Shelves
              shlf.Height = h
              shlf.LocationZ = pos
              pos += h
            Next
          Else
            statStatus.Text = "No children found to normalize!"
          End If
        Case "Shelf"
          Dim shlf As Rack.Shelf = trvStorage.SelectedNode.Tag
          If Not IsNothing(shlf.Cells) AndAlso shlf.Cells.Length > 0 Then
            Dim tot As Integer = shlf.Cells.Length
            Dim h As Integer = shlf.Height / tot
            Dim pos As Integer = 0
            For Each cell As Rack.Shelf.Cell In shlf.Cells
              cell.Height = h
              cell.LocationZ = pos
              pos += h
            Next
          Else
            statStatus.Text = "No children found to normalize!"
          End If
        Case Else
          statStatus.Text = "Can only normalize children of Racks/Shelves!"
      End Select
    Else
      statStatus.Text = "Select an object to normalize its children"
    End If
    DrawOnly()
  End Sub
  Private Sub mnuNormalizeDepth_Click(sender As Object, e As EventArgs) Handles mnuNormalizeDepth.Click
    If Not IsNothing(trvStorage.SelectedNode) AndAlso Not IsNothing(trvStorage.SelectedNode.Tag) Then
      Select Case trvStorage.SelectedNode.Tag.GetType().Name
        Case "Rack"
          Dim rck As Rack = trvStorage.SelectedNode.Tag
          If Not IsNothing(rck.Shelves) AndAlso rck.Shelves.Length > 0 Then
            Dim tot As Integer = rck.Shelves.Length
            Dim d As Integer = rck.Depth / tot
            Dim pos As Integer = 0
            For Each shlf As Rack.Shelf In rck.Shelves
              shlf.Depth = d
              shlf.LocationY = pos
              pos += d
            Next
          Else
            statStatus.Text = "No children found to normalize!"
          End If
        Case "Shelf"
          Dim shlf As Rack.Shelf = trvStorage.SelectedNode.Tag
          If Not IsNothing(shlf.Cells) AndAlso shlf.Cells.Length > 0 Then
            Dim tot As Integer = shlf.Cells.Length
            Dim d As Integer = shlf.Depth / tot
            Dim pos As Integer = 0
            For Each cell As Rack.Shelf.Cell In shlf.Cells
              cell.Depth = d
              cell.LocationY = pos
              pos += d
            Next
          Else
            statStatus.Text = "No children found to normalize!"
          End If
        Case Else
          statStatus.Text = "Can only normalize children of Racks/Shelves!"
      End Select
    Else
      statStatus.Text = "Select an object to normalize its children"
    End If
    DrawOnly()
  End Sub

  Private Sub mnuFillWidth_Click(sender As Object, e As EventArgs) Handles mnuFillWidth.Click
    If Not IsNothing(trvStorage.SelectedNode) AndAlso Not IsNothing(trvStorage.SelectedNode.Tag) Then
      If trvStorage.SelectedNode.Tag.GetType().Name = "Shelf" Or trvStorage.SelectedNode.Tag.GetType().Name = "Cell" Then
        Dim obj As Object = trvStorage.SelectedNode.Tag
        obj.LocationX = 0
        obj.Width = obj.Parent.Width
        Object_Selected(obj)
        statStatus.Text = "Filled Width"
        DrawOnly()
      End If
    End If
  End Sub
  Private Sub mnuFillDepth_Click(sender As Object, e As EventArgs) Handles mnuFillDepth.Click
    If Not IsNothing(trvStorage.SelectedNode) AndAlso Not IsNothing(trvStorage.SelectedNode.Tag) Then
      If trvStorage.SelectedNode.Tag.GetType().Name = "Shelf" Or trvStorage.SelectedNode.Tag.GetType().Name = "Cell" Then
        Dim obj As Object = trvStorage.SelectedNode.Tag
        obj.LocationY = 0
        obj.Depth = obj.Parent.Depth
        Object_Selected(obj)
        statStatus.Text = "Filled Depth"
        DrawOnly()
      End If
    End If
  End Sub
  Private Sub mnuFillHeight_Click(sender As Object, e As EventArgs) Handles mnuFillHeight.Click
    If Not IsNothing(trvStorage.SelectedNode) AndAlso Not IsNothing(trvStorage.SelectedNode.Tag) Then
      If trvStorage.SelectedNode.Tag.GetType().Name = "Shelf" Or trvStorage.SelectedNode.Tag.GetType().Name = "Cell" Then
        Dim obj As Object = trvStorage.SelectedNode.Tag
        obj.LocationZ = 0
        obj.Height = obj.Parent.Height
        Object_Selected(obj)
        statStatus.Text = "Filled Height"
        DrawOnly()
      End If
    End If
  End Sub

  Private Sub mnuSettings_Click(sender As Object, e As EventArgs) Handles mnuSettings.Click

  End Sub
  Private Sub mnuHotkeysSet_Click(sender As Object, e As EventArgs) Handles mnuHotkeysSet.Click
    Dim hk As New SetHotkeys()
    hk.ShowDialog()
  End Sub

  Private Sub mnuF9_Click(sender As Object, e As EventArgs) Handles mnuF9.Click
    RunHotkey(My.Settings.F9Keys)
  End Sub
  Private Sub mnuF10_Click(sender As Object, e As EventArgs) Handles mnuF10.Click
    RunHotkey(My.Settings.F10Keys)
  End Sub
  Private Sub mnuF11_Click(sender As Object, e As EventArgs) Handles mnuF11.Click
    RunHotkey(My.Settings.F11Keys)
  End Sub
  Private Sub mnuF12_Click(sender As Object, e As EventArgs) Handles mnuF12.Click
    RunHotkey(My.Settings.F12Keys)
  End Sub
  Private Sub RunHotkey(ByVal Arr As Specialized.StringCollection)
    If Not IsNothing(Arr) AndAlso Arr.Count > 0 Then
      For i = 0 To Arr.Count - 1 Step 1
        If Arr.Item(i) = "{APPHOLD}" Then
          Application.DoEvents()
        Else
          SendKeys.Send(Arr.Item(i))
        End If
      Next
    End If
  End Sub

End Class
Public Module StorageFunctions
  Public _Draw As New DrawSettings With {.Pen = New Pen(Brushes.Black, 1.5F)}
  Public blnDrawing As Boolean = False
  Public SelectedObject As Object

  Public Class DrawSettings
    Public FrontBound As Rectangle
    Public SideBound As Rectangle
    Public TopBound As Rectangle
    Public CellBound As Rectangle
    Public Pen As Pen
    Public Brush As New Drawing2D.HatchBrush(Drawing2D.HatchStyle.Percent10, Color.Black, Color.Transparent)
    Public FrontRatio As DrawRatio
    Public SideRatio As DrawRatio
    Public TopRatio As DrawRatio
    Public Font As New Font("Arial", 7.0F, FontStyle.Regular)

    Public Function GetGraphics(Optional ByVal Clear As Boolean = False) As Graphics
      If Clear Then
        Dim bmp As New Bitmap(Form1.picView.Size.Width, Form1.picView.Size.Height)
        Form1.picView.Image = bmp
      End If
      Return Graphics.FromImage(Form1.picView.Image)
    End Function
    Public Class DrawRatio
      Public Property X As Double
      Public Property Y As Double
      Public Overrides Function ToString() As String
        Return "{X=" & X.ToString & ", Y=" & Y.ToString & "}"
      End Function
      Public Sub New(ByVal valX As Double, ByVal valY As Double)
        X = valX
        Y = valY
      End Sub
    End Class
  End Class

  <Extension()> Public Sub Draw(ByVal Rack As Rack)
    _Draw.GetGraphics(True)
    
    _Draw.FrontRatio = New DrawSettings.DrawRatio(0, 0)
    _Draw.SideRatio = New DrawSettings.DrawRatio(0, 0)
    _Draw.TopRatio = New DrawSettings.DrawRatio(0, 0)
    If Rack.Width >= Rack.Height And Rack.Width >= Rack.Depth Then
      _Draw.FrontRatio.X = 1
      _Draw.FrontRatio.Y = Rack.Height / Rack.Width
      _Draw.SideRatio.X = Rack.Depth / Rack.Width
      _Draw.SideRatio.Y = Rack.Height / Rack.Width
      _Draw.TopRatio.X = 1
      _Draw.TopRatio.Y = Rack.Depth / Rack.Width
      Form1.statStatus.Text = "Width"
    ElseIf Rack.Height >= Rack.Width And Rack.Height >= Rack.Depth Then
      _Draw.FrontRatio.X = Rack.Width / Rack.Height
      _Draw.FrontRatio.Y = 1
      _Draw.SideRatio.X = Rack.Depth / Rack.Height
      _Draw.SideRatio.Y = 1
      _Draw.TopRatio.X = Rack.Width / Rack.Height
      _Draw.TopRatio.Y = Rack.Depth / Rack.Height
      Form1.statStatus.Text = "Height"
    Else
      _Draw.FrontRatio.X = Rack.Width / Rack.Depth
      _Draw.FrontRatio.Y = Rack.Height / Rack.Depth
      _Draw.SideRatio.X = 1
      _Draw.SideRatio.Y = Rack.Height / Rack.Depth
      _Draw.TopRatio.X = Rack.Width / Rack.Depth
      _Draw.TopRatio.Y = 1
      Form1.statStatus.Text = "Depth"
    End If
    Try
      Draw_Front(Rack)
      Draw_Side(Rack)
      Draw_Top(Rack)
    Catch ex As Exception
      Form1.statStatus.Text = "Error: " & ex.Message
    End Try
  End Sub
  Private Sub Draw_Front(ByVal Rack As Rack)
    Dim st As Drawing2D.GraphicsState
    Dim padSize As New Size(_Draw.FrontBound.Width * 0.8, _Draw.FrontBound.Height * 0.8)
    Dim ratX, ratY As Double
    ratX = _Draw.FrontRatio.X
    ratY = _Draw.FrontRatio.Y
    Dim orig As New Point()
    orig.X = (_Draw.FrontBound.X + (_Draw.FrontBound.Width * 0.1))
    orig.Y = ((_Draw.FrontBound.Y + _Draw.FrontBound.Height) - (_Draw.FrontBound.Height * 0.1))
    Using g As Graphics = _Draw.GetGraphics()
      '' Set Origin
      st = g.Save()
      g.TranslateTransform(orig.X, orig.Y)
      g.RotateTransform(180)
      g.ScaleTransform(-1, 1)
      '' Draw bounds
      g.FillRectangle(Brushes.WhiteSmoke, New Rectangle(0, 0, CInt(padSize.Width * ratX), CInt(padSize.Height * ratY)))
      g.DrawRectangle(_Draw.Pen, New Rectangle(0, 0, CInt(padSize.Width * ratX), CInt(padSize.Height * ratY)))
      DrawDimension(g, New Size(padSize.Width * ratX, padSize.Height * ratY), Rack.Height, False)
      '' Draw Shelves
      If Not IsNothing(Rack.Shelves) AndAlso Rack.Shelves.Length > 0 Then
        For Each s As Rack.Shelf In Rack.Shelves
          Dim rect As New Rectangle((padSize.Width * ((s.LocationX / Rack.Width) * ratX)),
                                    (padSize.Height * ((s.LocationZ / Rack.Height) * ratY)),
                                    (padSize.Width * ((s.Width / Rack.Width) * ratX)),
                                    (padSize.Height * ((s.Height / Rack.Height) * ratY)))
          If (SelectedObject.GetType().Name = "Shelf" AndAlso (SelectedObject.Id = s.Id And SelectedObject.LocationX = s.LocationX And SelectedObject.LocationY = s.LocationY And SelectedObject.LocationZ = s.LocationZ)) Or
              (SelectedObject.GetType().Name = "Cell" AndAlso (Form1.trvStorage.SelectedNode.Parent.Tag.Id = s.Id And Form1.trvStorage.SelectedNode.Parent.Tag.LocationX = s.LocationX And Form1.trvStorage.SelectedNode.Parent.Tag.LocationY = s.LocationY And Form1.trvStorage.SelectedNode.Parent.Tag.LocationZ = s.LocationZ)) Then
            g.FillRectangle(Brushes.DarkCyan, rect)
            g.DrawRectangle(_Draw.Pen, rect)
          Else
            g.FillRectangle(_Draw.Brush, rect)
            g.DrawRectangle(_Draw.Pen, rect)
          End If
        Next
      Else
        Form1.statStatus.Text = "Rack is empty"
      End If
      g.Restore(st)
      '' Draw Labels outside bounds
      g.DrawString("Front", _Draw.Font, Brushes.Black, New Point(_Draw.FrontBound.X + (_Draw.FrontBound.Width / 2), _Draw.FrontBound.Y))
      g.DrawString("Rack/Cabinet: " & Rack.Id, _Draw.Font, Brushes.Black, New Point(_Draw.FrontBound.X + (_Draw.FrontBound.Width / 2) - (g.MeasureString("Rack/Cabinet: " & Rack.Id, _Draw.Font).Width / 2), _Draw.FrontBound.Y + 9))
    End Using
  End Sub
  Private Sub Draw_Side(ByVal Rack As Rack)
    Dim st As Drawing2D.GraphicsState
    Dim padSize As New Size(_Draw.SideBound.Width * 0.8, _Draw.SideBound.Height * 0.8)
    Dim ratX, ratY As Double
    ratX = _Draw.SideRatio.X
    ratY = _Draw.SideRatio.Y
    Dim orig As New Point()
    orig.X = (_Draw.SideBound.X + (_Draw.SideBound.Width * 0.1))
    orig.Y = ((_Draw.SideBound.Y + _Draw.SideBound.Height) - (_Draw.SideBound.Height * 0.1))
    Using g As Graphics = _Draw.GetGraphics()
      '' Set Origin
      st = g.Save()
      g.TranslateTransform(orig.X, orig.Y)
      g.RotateTransform(180)
      g.ScaleTransform(-1, 1)
      '' Draw bounds
      g.FillRectangle(Brushes.WhiteSmoke, New Rectangle(0, 0, CInt(padSize.Width * ratX), CInt(padSize.Height * ratY)))
      g.DrawRectangle(_Draw.Pen, New Rectangle(0, 0, CInt(padSize.Width * ratX), CInt(padSize.Height * ratY)))
      '' Draw Shelves
      If Not IsNothing(Rack.Shelves) AndAlso Rack.Shelves.Length > 0 Then
        For Each s As Rack.Shelf In Rack.Shelves
          Dim rect As New Rectangle((padSize.Width * ((s.LocationY / Rack.Depth) * ratX)),
                                    (padSize.Height * ((s.LocationZ / Rack.Height) * ratY)),
                                    (padSize.Width * ((s.Depth / Rack.Depth) * ratX)),
                                    (padSize.Height * ((s.Height / Rack.Height) * ratY)))
          If (SelectedObject.GetType().Name = "Shelf" AndAlso (SelectedObject.Id = s.Id And SelectedObject.LocationX = s.LocationX And SelectedObject.LocationY = s.LocationY And SelectedObject.LocationZ = s.LocationZ)) Or
              (SelectedObject.GetType().Name = "Cell" AndAlso (Form1.trvStorage.SelectedNode.Parent.Tag.Id = s.Id And Form1.trvStorage.SelectedNode.Parent.Tag.LocationX = s.LocationX And Form1.trvStorage.SelectedNode.Parent.Tag.LocationY = s.LocationY And Form1.trvStorage.SelectedNode.Parent.Tag.LocationZ = s.LocationZ)) Then
            g.FillRectangle(Brushes.DarkCyan, rect)
            g.DrawRectangle(_Draw.Pen, rect)
          Else
            g.FillRectangle(_Draw.Brush, rect)
            g.DrawRectangle(_Draw.Pen, rect)
          End If
        Next
      Else
        Form1.statStatus.Text = "Rack is empty"
      End If
      g.Restore(st)
      g.DrawString("Side", New Font("Arial", 7), Brushes.Black, New Point(_Draw.SideBound.X + (_Draw.SideBound.Width / 2), _Draw.SideBound.Y))
    End Using
  End Sub
  Private Sub Draw_Top(ByVal Rack As Rack)
    Dim st As Drawing2D.GraphicsState
    Dim padSize As New Size(_Draw.TopBound.Width * 0.8, _Draw.TopBound.Height * 0.8)
    Dim ratX, ratY As Double
    ratX = _Draw.TopRatio.X
    ratY = _Draw.TopRatio.Y
    Dim orig As New Point()
    orig.X = (_Draw.TopBound.X + (_Draw.TopBound.Width * 0.1))
    orig.Y = ((_Draw.TopBound.Y + _Draw.TopBound.Height) - (_Draw.TopBound.Height * 0.1))
    Using g As Graphics = _Draw.GetGraphics()
      '' Set Origin
      st = g.Save()
      g.TranslateTransform(orig.X, orig.Y)
      g.RotateTransform(180)
      g.ScaleTransform(-1, 1)
      '' Draw bounds
      g.FillRectangle(Brushes.WhiteSmoke, New Rectangle(0, 0, CInt(padSize.Width * ratX), CInt(padSize.Height * ratY)))
      g.DrawRectangle(_Draw.Pen, New Rectangle(0, 0, CInt(padSize.Width * ratX), CInt(padSize.Height * ratY)))
      DrawDimension(g, New Size(padSize.Width * ratX, padSize.Height * ratY), Rack.Width.ToString, True)
      DrawDimension(g, New Size(padSize.Width * ratX, padSize.Height * ratY), Rack.Depth.ToString, False)
      '' Draw Shelves
      If Not IsNothing(Rack.Shelves) AndAlso Rack.Shelves.Length > 0 Then
        For Each s As Rack.Shelf In Rack.Shelves
          Dim rect As New Rectangle((padSize.Width * ((s.LocationX / Rack.Width) * ratX)),
                                    (padSize.Height * ((s.LocationY / Rack.Depth) * ratY)),
                                    (padSize.Width * ((s.Width / Rack.Width) * ratX)),
                                    (padSize.Height * ((s.Depth / Rack.Depth) * ratY)))
          If (SelectedObject.GetType().Name = "Shelf" AndAlso (SelectedObject.Id = s.Id And SelectedObject.LocationX = s.LocationX And SelectedObject.LocationY = s.LocationY And SelectedObject.LocationZ = s.LocationZ)) Or
              (SelectedObject.GetType().Name = "Cell" AndAlso (Form1.trvStorage.SelectedNode.Parent.Tag.Id = s.Id And Form1.trvStorage.SelectedNode.Parent.Tag.LocationX = s.LocationX And Form1.trvStorage.SelectedNode.Parent.Tag.LocationY = s.LocationY And Form1.trvStorage.SelectedNode.Parent.Tag.LocationZ = s.LocationZ)) Then
            g.FillRectangle(Brushes.DarkCyan, rect)
            g.DrawRectangle(_Draw.Pen, rect)
          Else
            g.FillRectangle(_Draw.Brush, rect)
            g.DrawRectangle(_Draw.Pen, rect)
          End If
        Next
      Else
        Form1.statStatus.Text = "Rack is empty"
      End If
      g.Restore(st)
      g.DrawString("Top", New Font("Arial", 7), Brushes.Black, New Point(_Draw.TopBound.X + (_Draw.TopBound.Width / 2), _Draw.TopBound.Y))
    End Using
  End Sub
  <Extension()> Public Sub Draw(ByVal Shelf As Rack.Shelf)
    Dim st As Drawing2D.GraphicsState
    If Not IsNothing(Shelf.Cells) AndAlso Shelf.Cells.Length > 0 Then
      Using g As Graphics = _Draw.GetGraphics()
        st = g.Save()
        Dim shlfSize As New Size(_Draw.CellBound.Width * 0.8, _Draw.CellBound.Height * 0.8)
        Dim shlfRat As DrawSettings.DrawRatio
        If Shelf.Width >= Shelf.Depth Then
          shlfRat = New DrawSettings.DrawRatio(1, (Shelf.Depth / Shelf.Width))
        Else
          shlfRat = New DrawSettings.DrawRatio((Shelf.Width / Shelf.Depth), 1)
        End If
        '' Set secondary origin
        g.TranslateTransform((_Draw.CellBound.X + (_Draw.CellBound.Width * 0.1)),
                             ((_Draw.CellBound.Y + _Draw.CellBound.Height) - (_Draw.CellBound.Height * 0.1)))
        g.RotateTransform(180)
        g.ScaleTransform(-1, 1)
        '' Draw Shelf/Drawer in 4th quadrant
        g.FillRectangle(Brushes.WhiteSmoke, 0, 0, CInt(shlfSize.Width * shlfRat.X), CInt(shlfSize.Height * shlfRat.Y))
        g.DrawRectangle(_Draw.Pen, 0, 0, CInt(shlfSize.Width * shlfRat.X), CInt(shlfSize.Height * shlfRat.Y))
        DrawDimension(g, New Size(shlfSize.Width * shlfRat.X, shlfSize.Height * shlfRat.Y), Shelf.Width.ToString, True)
        DrawDimension(g, New Size(shlfSize.Width * shlfRat.X, shlfSize.Height * shlfRat.Y), Shelf.Depth.ToString, False)
        '' Draw Cells
        For Each c As Rack.Shelf.Cell In Shelf.Cells
          Dim rect As New Rectangle((shlfSize.Width * ((c.LocationX / Shelf.Width) * shlfRat.X)),
                                    (shlfSize.Height * ((c.LocationY / Shelf.Depth) * shlfRat.Y)),
                                    (shlfSize.Width * ((c.Width / Shelf.Width) * shlfRat.X)),
                                    (shlfSize.Height * ((c.Depth / Shelf.Depth) * shlfRat.Y)))
          If SelectedObject.GetType().Name = "Cell" AndAlso (SelectedObject.Id = c.Id And SelectedObject.LocationX = c.LocationX And SelectedObject.LocationY = c.LocationY And SelectedObject.LocationZ = c.LocationZ) Then
            g.FillRectangle(Brushes.DarkCyan, rect)
            g.DrawRectangle(_Draw.Pen, rect)
          Else
            g.FillRectangle(_Draw.Brush, rect)
            g.DrawRectangle(_Draw.Pen, rect)
          End If
        Next
        '' Restore Rack origin
        g.Restore(st)
        g.DrawString("Cell(s)", _Draw.Font, Brushes.Black, New Point(_Draw.CellBound.X + (_Draw.CellBound.Width / 2), _Draw.CellBound.Y))
        g.DrawString("Shelf/Drawer: " & Shelf.Id, _Draw.Font, Brushes.Black, New Point(_Draw.CellBound.X + (_Draw.CellBound.Width / 2) - (g.MeasureString("Shelf/Drawer: " & Shelf.Id, _Draw.Font).Width / 2), _Draw.CellBound.Y + 9))
      End Using
    End If
  End Sub

  Private Sub DrawDimension(ByVal Graphics As Graphics, ByVal Size As Size, ByVal Value As String, ByVal IsHorizontal As Boolean)
    Dim gs As Drawing2D.GraphicsState = Graphics.Save()
    If IsHorizontal Then
      Graphics.DrawLine(_Draw.Pen, New Point(0, -3), New Point(0, -(Size.Height * 0.1)))
      Graphics.DrawLine(_Draw.Pen, New Point(0, -3 - ((Size.Height * 0.1) / 2)), New Point(Size.Width * 0.35, -3 - ((Size.Height * 0.1) / 2)))
      Graphics.DrawLine(_Draw.Pen, New Point(Size.Width, -3), New Point(Size.Width, -(Size.Height * 0.1)))
      Graphics.DrawLine(_Draw.Pen, New Point(Size.Width * 0.65, -3 - ((Size.Height * 0.1) / 2)), New Point(Size.Width, -3 - ((Size.Height * 0.1) / 2)))

      Graphics.TranslateTransform((Size.Width / 2) - (Graphics.MeasureString(Value, _Draw.Font).Width / 2), -3 - (Graphics.MeasureString(Value, _Draw.Font).Height / 2))
      Graphics.RotateTransform(180)
      Graphics.ScaleTransform(-1, 1)
      Graphics.DrawString(Value, _Draw.Font, Brushes.Black, New Point(0, 0))
    Else
      Graphics.DrawLine(_Draw.Pen, New Point(-3, 0), New Point(-(Size.Width * 0.1), 0))
      Graphics.DrawLine(_Draw.Pen, New Point(-3 - ((Size.Width * 0.1) / 2), 0), New Point(-3 - ((Size.Width * 0.1) / 2), Size.Height * 0.35))
      Graphics.DrawLine(_Draw.Pen, New Point(-3, Size.Height), New Point(-(Size.Width * 0.1), Size.Height))
      Graphics.DrawLine(_Draw.Pen, New Point(-3 - ((Size.Width * 0.1) / 2), Size.Height * 0.65), New Point(-3 - ((Size.Width * 0.1) / 2), Size.Height))
      
      Graphics.TranslateTransform(-3 - (Graphics.MeasureString(Value, _Draw.Font).Width), (Size.Height / 2) + (Graphics.MeasureString(Value, _Draw.Font).Height / 2))
      Graphics.RotateTransform(180)
      Graphics.ScaleTransform(-1, 1)
      Graphics.DrawString(Value, _Draw.Font, Brushes.Black, New Point(0, 0))
    End If
    Graphics.Restore(gs)
  End Sub

  Public Function IntegerToAlphebetical(ByVal val As Integer) As String
    Return RecursiveIntToAlph(val)
  End Function
  Private Function RecursiveIntToAlph(ByVal val As Integer, Optional ByVal RecursiveString As String = "") As String
    If (val > 26) Then
      If (val \ 26) > 26 Then
        RecursiveString = "Z" + RecursiveString
        val -= 26 ^ 2
      Else
        RecursiveString += Chr(64 + (val \ 26))
        val -= (26 * (val \ 26))
      End If
      RecursiveString = RecursiveIntToAlph(val, RecursiveString)
    ElseIf val > 0 Then
      RecursiveString += Chr(64 + val)
    End If
    Return RecursiveString
  End Function

  <Extension> Public Function IsNothingOrEmpty(ByVal Ref As StoragePlaceRef()) As Boolean
    If Not IsNothing(Ref) Then
      Return Ref.Length = 0
    Else
      Return True
    End If
  End Function
End Module
<Serializable(), XmlRoot("Data")> _
Public Class Data
  <XmlElement("Storage")> Public Property Storage As Storage()

  Public Function GetRacks() As Rack()
    Dim lstRack As New List(Of Rack)
    If Not IsNothing(Storage) Then
      For Each st As Storage In Storage
        lstRack.Add(st.GetRack())
      Next
    End If
    Return lstRack.ToArray()
  End Function
End Class
<Serializable(), XmlRoot("Storage")> _
Public Class Storage
  <XmlElement("StorageId")> Public Property StorageId As String
  <XmlElement("StorageName")> Public Property StorageName As String
  <XmlElement("Width")> Public Property Width As String
  <XmlElement("Height")> Public Property Height As String
  <XmlElement("Depth")> Public Property Depth As String
  <XmlElement("ExternalSystemControl")> Public Property ExternalSystemControl As String
  <XmlElement("Type")> Public Property Type As String
  <XmlElement("CirculationControl")> Public Property CirculationControl As String
  <XmlElement("IsStockOrderNeeded")> Public Property IsStockOrderNeeded As String
  <XmlElement("DatasetState")> Public Property DatasetState As String
  <XmlElement("StoragePlace")> Public Property StoragePlace As StoragePlace

  Public Function GetRack() As Rack
    Dim rck As New Rack(Me) ' With {.Id = StorageId, .Width = Width, .Depth = Depth, .Height = Height}
    If Not IsNothing(StoragePlace) AndAlso Not IsNothing(StoragePlace.StoragePlaceRef) AndAlso Not IsNothing(StoragePlace.StoragePlaceRef.StoragePlaceList) Then
      If Not IsNothing(StoragePlace.StoragePlaceRef.StoragePlaceList.StoragePlaceRef) AndAlso StoragePlace.StoragePlaceRef.StoragePlaceList.StoragePlaceRef.Length > 0 Then
        Dim stRack As StoragePlaceRef = StoragePlace.StoragePlaceRef.StoragePlaceList.StoragePlaceRef(0).StoragePlaceRef
        Dim lstShelf As New List(Of Rack.Shelf)
        '' Shelves
        For Each srShelf As StoragePlaceRef In stRack.StoragePlaceList.StoragePlaceRef
          srShelf = srShelf.StoragePlaceRef
          Dim shlf As New Rack.Shelf(srShelf) With {.Parent = rck}
          If Not IsNothing(srShelf.StoragePlaceList) AndAlso Not IsNothing(srShelf.StoragePlaceList.StoragePlaceRef) AndAlso srShelf.StoragePlaceList.StoragePlaceRef.Length > 0 Then
            Dim lstCells As New List(Of Rack.Shelf.Cell)
            '' Cells
            For Each srCell As StoragePlaceRef In srShelf.StoragePlaceList.StoragePlaceRef
              srCell = srCell.StoragePlaceRef
              Dim cell As New Rack.Shelf.Cell(srCell) With {.Parent = shlf}
              lstCells.Add(cell)
            Next
            shlf.Cells = lstCells.ToArray()
          End If
          lstShelf.Add(shlf)
        Next
        rck.Shelves = lstShelf.ToArray()
      End If
    End If
    Return rck
  End Function

  Public Sub CompileDefaults()

  End Sub
End Class
<Serializable(), XmlRoot("StoragePlace")> _
Public Class StoragePlace
  <XmlElement("StoragePlaceBaseId")> Public Property StoragePlaceBaseId As String
  <XmlElement("Description")> Public Property Description As String
  <XmlElement("StoragePlaceRef")> Public Property StoragePlaceRef As StoragePlaceRef
End Class
<Serializable(), XmlRoot("StoragePlaceList")> _
Public Class StoragePlaceList
  <XmlElement("StoragePlaceRef")> Public Property StoragePlaceRef As StoragePlaceRef()
End Class
<Serializable(), XmlRoot("StoragePlaceRef")> _
Public Class StoragePlaceRef
  <XmlElement("StoragePlaceListId")> Public Property StoragePlaceListId As String
  <XmlElement("Description")> Public Property Description As String
  <XmlElement("StoragePlaceObjId")> Public Property StoragePlaceObjId As String
  <XmlElement("StoragePlaceList")> Public Property StoragePlaceList As StoragePlaceList
  <XmlElement("StoragePlaceRef")> Public Property StoragePlaceRef As StoragePlaceRef
  <XmlElement("WeightMax")> Public Property WeightMax As String
  <XmlElement("LocationX")> Public Property LocationX As String
  <XmlElement("LocationY")> Public Property LocationY As String
  <XmlElement("LocationZ")> Public Property LocationZ As String
  <XmlElement("LengthX")> Public Property LengthX As String
  <XmlElement("LengthY")> Public Property LengthY As String
  <XmlElement("LengthZ")> Public Property LengthZ As String

  Public Overrides Function Equals(obj As Object) As Boolean
    If obj.GetType().Name = "StoragePlaceRef" Then
      If obj.LocationX = Me.LocationX And
        obj.LocationY = Me.LocationY And
        obj.LocationZ = Me.LocationZ And
        obj.LengthX = Me.LengthX And
        obj.LengthY = Me.LengthY And
        obj.LengthZ = Me.LengthZ Then
        Return True
      Else
        Return False
      End If
    Else
      Return False
    End If
  End Function
End Class
<Serializable, XmlRoot("StorageBookingList")> _
Public Class StorageBookingList
  <XmlElement("StorageBooking")> Public Property StorageBookings As StorageBooking()
End Class
<Serializable, XmlRoot("StorageBooking")> _
Public Class StorageBooking
  <XmlElement("AutoCounter")> Public Property AutoCounter As String
  <XmlElement("DTTicks")> Public Property DTTicks As String
  <XmlElement("DT")> Public Property DT As String
  <XmlElement("DTExpectedReturn")> Public Property DTExpectedReturn As String
  <XmlElement("UserName")> Public Property UserName As String
  <XmlElement("ObjTypeId")> Public Property ObjTypeId As String
  <XmlElement("ObjTypeTxt")> Public Property ObjTypeTxt As String
  <XmlElement("ObjId")> Public Property ObjId As String
  <XmlElement("ObjTxt")> Public Property ObjTxt As String
  <XmlElement("ObjDesc")> Public Property ObjDesc As String
  <XmlElement("ObjPos")> Public Property ObjPos As String
  <XmlElement("ObjInv")> Public Property ObjInv As String
  <XmlElement("ObjInvCounter")> Public Property ObjInvCounter As String
  <XmlElement("ObjInvStatus")> Public Property ObjInvStatus As String
  <XmlElement("ObjInvTxt")> Public Property ObjInvTxt As String
  <XmlElement("IsRowVisible")> Public Property IsRowVisible As String
  <XmlElement("ObjUseClassTypeId")> Public Property ObjUseClassTypeId As String
  <XmlElement("ObjUseClassTypeTxt")> Public Property ObjUseClassTypeTxt As String
  <XmlElement("Status")> Public Property Status As String
  <XmlElement("StatusType")> Public Property StatusType As String
  <XmlElement("Dissolved")> Public Property Dissolved As String
  <XmlElement("MachineObjId")> Public Property MachineObjId As String
  <XmlElement("StorageObjId")> Public Property StorageObjId As String
  <XmlElement("StorageObjTxt")> Public Property StorageObjTxt As String
  <XmlElement("StorageObjDesc")> Public Property StorageObjDesc As String
  <XmlElement("StorageType")> Public Property StorageType As String
  <XmlElement("StorageTypeGrindingStack")> Public Property StorageTypeGrindingStack As String
  <XmlElement("StorageTypeGrinding")> Public Property StorageTypeGrinding As String
  <XmlElement("StoragePos")> Public Property StoragePos As String
  <XmlElement("StoragePlace")> Public Property StoragePlace As String
  <XmlElement("StoragePlaceObjId")> Public Property StoragePlaceObjId As String
  <XmlElement("StoragePlaceContentType")> Public Property StoragePlaceContentType As String
  <XmlElement("StorageQuantityMin")> Public Property StorageQuantityMin As String
  <XmlElement("StorageQuantityMax")> Public Property StorageQuantityMax As String
  <XmlElement("Quantity")> Public Property Quantity As String
  <XmlElement("QuantityBooked")> Public Property QuantityBooked As String
  <XmlElement("StorageBookingComment")> Public Property StorageBookingComment As String
  <XmlElement("CirculationObjId")> Public Property CirculationObjId As String
  <XmlElement("CirculationObjLevel")> Public Property CirculationObjLevel As String
  <XmlElement("UseJobObjId")> Public Property UseJobObjId As String
  <XmlElement("UseJobObjTxt")> Public Property UseJobObjTxt As String
  <XmlElement("UseJobObjDesc")> Public Property UseJobObjDesc As String
  <XmlElement("UseJobComment")> Public Property UseJobComment As String
  <XmlElement("UseDepartmentObjId")> Public Property UseDepartmentObjId As String
  <XmlElement("UseDepartmentObjTxt")> Public Property UseDepartmentObjTxt As String
  <XmlElement("UseDepartmentObjDesc")> Public Property UseDepartmentObjDesc As String
  <XmlElement("UseDepartmentComment")> Public Property UseDepartmentComment As String
  <XmlElement("UseMachineObjId")> Public Property UseMachineObjId As String
  <XmlElement("UseMachineObjTxt")> Public Property UseMachineObjTxt As String
  <XmlElement("UseMachineObjDesc")> Public Property UseMachineObjDesc As String
  <XmlElement("UseMachineComment")> Public Property UseMachineComment As String
  <XmlElement("UseEmployeesObjId")> Public Property UseEmployeesObjId As String
  <XmlElement("UseEmployeesObjTxt")> Public Property UseEmployeesObjTxt As String
  <XmlElement("UseEmployeesObjDesc")> Public Property UseEmployeesObjDesc As String
  <XmlElement("UseEmployeesComment")> Public Property UseEmployeesComment As String
  <XmlElement("UseCostCenterObjTypeId")> Public Property UseCostCenterObjTypeId As String
  <XmlElement("UseCostCenterObjTypeTxt")> Public Property UseCostCenterObjTypeTxt As String
  <XmlElement("UseCostCenterObjId")> Public Property UseCostCenterObjId As String
  <XmlElement("UseCostCenterObjTxt")> Public Property UseCostCenterObjTxt As String
  <XmlElement("UseCostCenterObjDesc")> Public Property UseCostCenterObjDesc As String
  <XmlElement("UseCostCenterComment")> Public Property UseCostCenterComment As String
  <XmlElement("UseGrindingStackObjId")> Public Property UseGrindingStackObjId As String
  <XmlElement("UseGrindingStackObjTxt")> Public Property UseGrindingStackObjTxt As String
  <XmlElement("UseGrindingStackObjDesc")> Public Property UseGrindingStackObjDesc As String
  <XmlElement("UseGrindingStackComment")> Public Property UseGrindingStackComment As String
  <XmlElement("UseGrindingStackQuantityMax")> Public Property UseGrindingStackQuantityMax As String
  <XmlElement("UseGrindingObjTypeId")> Public Property UseGrindingObjTypeId As String
  <XmlElement("UseGrindingObjTypeTxt")> Public Property UseGrindingObjTypeTxt As String
  <XmlElement("UseGrindingObjId")> Public Property UseGrindingObjId As String
  <XmlElement("UseGrindingObjTxt")> Public Property UseGrindingObjTxt As String
  <XmlElement("UseGrindingObjDesc")> Public Property UseGrindingObjDesc As String
  <XmlElement("UseGrindingComment")> Public Property UseGrindingComment As String
  <XmlElement("UseGrindingReferenceId")> Public Property UseGrindingReferenceId As String
  <XmlElement("GrindingCycleAct")> Public Property GrindingCycleAct As String
  <XmlElement("GrindingCycleMax")> Public Property GrindingCycleMax As String
  <XmlElement("UseCustomObjTypeId")> Public Property UseCustomObjTypeId As String
  <XmlElement("UseCustomObjTypeTxt")> Public Property UseCustomObjTypeTxt As String
  <XmlElement("UseCustomObjId")> Public Property UseCustomObjId As String
  <XmlElement("UseCustomObjTxt")> Public Property UseCustomObjTxt As String
  <XmlElement("UseCustomObjDesc")> Public Property UseCustomObjDesc As String
  <XmlElement("UseCustomComment")> Public Property UseCustomComment As String
  <XmlElement("UsePartObjId")> Public Property UsePartObjId As String
  <XmlElement("UsePartObjTxt")> Public Property UsePartObjTxt As String
  <XmlElement("UsePartObjDesc")> Public Property UsePartObjDesc As String
  <XmlElement("QuantityInventory")> Public Property QuantityInventory As String
  <XmlElement("TS_TableData")> Public Property TS_TableData As String
End Class

Public Class Rack
  Private Event PropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)

  Private _StorageRef As Storage
  Private _Id As String
  Private _Width, _Depth, _Height As Double
  Private _Shelves As Shelf()

  Public Property Id As String
    Get
      Return _Id
    End Get
    Set(value As String)
      RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Id", _Id, value))
      _Id = value
    End Set
  End Property
  Public Property Width As Double
    Get
      Return _Width
    End Get
    Set(value As Double)
      RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Width", _Width, value))
      _Width = value
    End Set
  End Property
  Public Property Depth As Double
    Get
      Return _Depth
    End Get
    Set(value As Double)
      RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Depth", _Depth, value))
      _Depth = value
    End Set
  End Property
  Public Property Height As Double
    Get
      Return _Height
    End Get
    Set(value As Double)
      RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Height", _Height, value))
      _Height = value
    End Set
  End Property
  Public Property Shelves As Shelf()
    Get
      Return _Shelves
    End Get
    Set(value As Shelf())
      RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Shelves", _Shelves, value))
      _Shelves = value
    End Set
  End Property
  Default Public Property Item(ByVal Index As Integer) As Shelf
    Get
      If Not IsNothing(_Shelves) Then
        If Index > -1 And Index < _Shelves.Length Then
          Return _Shelves(Index)
        Else
          Throw New IndexOutOfRangeException()
        End If
      Else
        Throw New NullReferenceException()
      End If
    End Get
    Set(value As Shelf)
      If Not IsNothing(_Shelves) Then
        If Index > -1 And Index < _Shelves.Length Then
          _Shelves(Index) = value
        Else
          Throw New IndexOutOfRangeException()
        End If
      Else
        Throw New NullReferenceException()
      End If
    End Set
  End Property
  Public ReadOnly Property StorageRef As Storage
    Get
      Return _StorageRef
    End Get
  End Property

  Public Class Shelf
    Private Event PropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)

    Private _StorageRef As StoragePlaceRef
    Private _Id As String
    Private _LocationX, _LocationY, _LocationZ, _Width, _Depth, _Height As Double
    Private _Cells As Cell()

    Public Property Id As String
      Get
        Return _Id
      End Get
      Set(value As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Id", _Id, value))
        _Id = value
      End Set
    End Property
    Public Property LocationX As Double
      Get
        Return _LocationX
      End Get
      Set(value As Double)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("LocationX", _LocationX, value))
        _LocationX = value
      End Set
    End Property
    Public Property LocationY As Double
      Get
        Return _LocationY
      End Get
      Set(value As Double)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("LocationY", _LocationY, value))
        _LocationY = value
      End Set
    End Property
    Public Property LocationZ As Double
      Get
        Return _LocationZ
      End Get
      Set(value As Double)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("LocationZ", _LocationZ, value))
        _LocationZ = value
      End Set
    End Property
    Public Property Width As Double
      Get
        Return _Width
      End Get
      Set(value As Double)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Width", _Width, value))
        _Width = value
      End Set
    End Property
    Public Property Depth As Double
      Get
        Return _Depth
      End Get
      Set(value As Double)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Depth", _Depth, value))
        _Depth = value
      End Set
    End Property
    Public Property Height As Double
      Get
        Return _Height
      End Get
      Set(value As Double)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Height", _Height, value))
        _Height = value
      End Set
    End Property
    Public Property Cells As Cell()
      Get
        Return _Cells
      End Get
      Set(value As Cell())
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Cells", _Cells, value))
        _Cells = value
      End Set
    End Property
    Default Public Property Item(ByVal Index As Integer) As Cell
      Get
        If Not IsNothing(_Cells) Then
          If Index > -1 And Index < _Cells.Length Then
            Return _Cells(Index)
          Else
            Throw New IndexOutOfRangeException()
          End If
        Else
          Throw New NullReferenceException()
        End If
      End Get
      Set(value As Cell)
        If Not IsNothing(_Cells) Then
          If Index > -1 And Index < _Cells.Length Then
            _Cells(Index) = value
          Else
            Throw New IndexOutOfRangeException()
          End If
        Else
          Throw New NullReferenceException()
        End If
      End Set
    End Property
    Public ReadOnly Property StorageRef As StoragePlaceRef
      Get
        Return _StorageRef
      End Get
    End Property
    Public Property Parent As Rack

    Public Class Cell
      Private Event PropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)

      Private _StorageRef As StoragePlaceRef
      Private _Id As String
      Private _LocationX, _LocationY, _LocationZ, _Width, _Depth, _Height As Double

      Public Property Id As String
        Get
          Return _Id
        End Get
        Set(value As String)
          RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Id", _Id, value))
          _Id = value
        End Set
      End Property
      Public Property LocationX As Double
        Get
          Return _LocationX
        End Get
        Set(value As Double)
          RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("LocationX", _LocationX, value))
          _LocationX = value
        End Set
      End Property
      Public Property LocationY As Double
        Get
          Return _LocationY
        End Get
        Set(value As Double)
          RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("LocationY", _LocationY, value))
          _LocationY = value
        End Set
      End Property
      Public Property LocationZ As Double
        Get
          Return _LocationZ
        End Get
        Set(value As Double)
          RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("LocationZ", _LocationZ, value))
          _LocationZ = value
        End Set
      End Property
      Public Property Width As Double
        Get
          Return _Width
        End Get
        Set(value As Double)
          RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Width", _Width, value))
          _Width = value
        End Set
      End Property
      Public Property Depth As Double
        Get
          Return _Depth
        End Get
        Set(value As Double)
          RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Depth", _Depth, value))
          _Depth = value
        End Set
      End Property
      Public Property Height As Double
        Get
          Return _Height
        End Get
        Set(value As Double)
          RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Height", _Height, value))
          _Height = value
        End Set
      End Property
      Public ReadOnly Property StorageRef As StoragePlaceRef
        Get
          Return _StorageRef
        End Get
      End Property
      Public Property Parent As Shelf

      Public Sub New(ByVal Ref As StoragePlaceRef)
        _StorageRef = Ref
        _Id = _StorageRef.Description
        'Parent = Ref
        Integer.TryParse(_StorageRef.LocationX, _LocationX)
        Integer.TryParse(_StorageRef.LocationY, _LocationY)
        Integer.TryParse(_StorageRef.LocationZ, _LocationZ)
        Integer.TryParse(_StorageRef.LengthX, _Width)
        Integer.TryParse(_StorageRef.LengthY, _Depth)
        Integer.TryParse(_StorageRef.LengthZ, _Height)
        AddHandler PropertyChanged, AddressOf PropChanged
      End Sub

      Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
        Select Case e.Name
          Case "Id"
            _StorageRef.Description = e.NewValue
          Case "LocationX"
            _StorageRef.LocationX = e.NewValue
          Case "LocationY"
            _StorageRef.LocationY = e.NewValue
          Case "LocationZ"
            _StorageRef.LocationZ = e.NewValue
          Case "Width"
            _StorageRef.LengthX = e.NewValue
          Case "Depth"
            _StorageRef.LengthY = e.NewValue
          Case "Height"
            _StorageRef.LengthZ = e.NewValue
        End Select
      End Sub
    End Class

    Public Sub New(ByVal Ref As StoragePlaceRef)
      _StorageRef = Ref
      _Id = _StorageRef.Description
      Integer.TryParse(_StorageRef.LocationX, _LocationX)
      Integer.TryParse(_StorageRef.LocationY, _LocationY)
      Integer.TryParse(_StorageRef.LocationZ, _LocationZ)
      Integer.TryParse(_StorageRef.LengthX, _Width)
      Integer.TryParse(_StorageRef.LengthY, _Depth)
      Integer.TryParse(_StorageRef.LengthZ, _Height)
      AddHandler PropertyChanged, AddressOf PropChanged
    End Sub

    Public Sub Add(Optional ByVal loc As StorageLocation = Nothing, Optional ByVal sz As StorageSize = Nothing)
      Dim mainPlaceRef As StoragePlaceRef
      Dim subRef1 As StoragePlaceRef
      mainPlaceRef = New StoragePlaceRef
      subRef1 = New StoragePlaceRef
      If IsNothing(Me.StorageRef.StoragePlaceList) Then
        Me.StorageRef.StoragePlaceList = New StoragePlaceList
      End If
      Dim lst1 As New List(Of StoragePlaceRef)
      If Not IsNothing(Me.StorageRef.StoragePlaceList) AndAlso Not IsNothing(Me.StorageRef.StoragePlaceList.StoragePlaceRef) Then
        lst1.AddRange(Me.StorageRef.StoragePlaceList.StoragePlaceRef)
      End If
      mainPlaceRef.StoragePlaceListId = lst1.Count.ToString
      subRef1.Description = "New Cell(" & lst1.Count.ToString & ")"
      subRef1.WeightMax = 1000
      If IsNothing(loc) Then
        loc = New StorageLocation
        loc.X = 0
        loc.Y = 0
        loc.Z = 0
      End If
      subRef1.LocationX = loc.X
      subRef1.LocationY = loc.Y
      subRef1.LocationZ = loc.Z
      If IsNothing(sz) Then
        sz = New StorageSize
        sz.Width = Me.Width
        sz.Depth = Me.Depth
        sz.Height = CInt((Me.Height) / (lst1.Count + 1))
      End If
      subRef1.LengthX = sz.Width
      subRef1.LengthY = sz.Depth
      subRef1.LengthZ = sz.Height
      mainPlaceRef.StoragePlaceRef = subRef1
      lst1.Add(mainPlaceRef)
      Me.StorageRef.StoragePlaceList.StoragePlaceRef = lst1.ToArray()
      If Not IsNothing(_Cells) Then
        ReDim Preserve _Cells(_Cells.Length)
      Else
        ReDim _Cells(0)
      End If
      _Cells(_Cells.Length - 1) = New Cell(subRef1) With {.Parent = Me}
    End Sub
    Public Sub Remove(ByVal Index As Integer)
      If IsNothing(_Cells) Then Throw New NullReferenceException()
      If Index < 0 Or Index >= _Cells.Length Then Throw New IndexOutOfRangeException()

      Dim blnSuccess As Boolean = False
      '' Fill Storage list
      Dim lst1 As New List(Of StoragePlaceRef)
      If Not IsNothing(Me.StorageRef) Then
        If Not IsNothing(Me.StorageRef.StoragePlaceList) Then
          lst1.AddRange(Me.StorageRef.StoragePlaceList.StoragePlaceRef)
        End If
      Else
        Debug.WriteLine("SubRef1 is nothing")
      End If
      '' Get/Compare shelves
      Dim cell As Cell = Me(Index)
      If Not IsNothing(cell) Then
        Dim storIndex As Integer = -1
        For i = 0 To lst1.Count - 1 Step 1
          If lst1(i).StoragePlaceRef.Description = cell.Id And
            lst1(i).StoragePlaceRef.LocationX = cell.LocationX And
            lst1(i).StoragePlaceRef.LocationY = cell.LocationY And
            lst1(i).StoragePlaceRef.LocationZ = cell.LocationZ And
            lst1(i).StoragePlaceRef.LengthX = cell.Width And
            lst1(i).StoragePlaceRef.LengthY = cell.Depth And
            lst1(i).StoragePlaceRef.LengthZ = cell.Height Then
            storIndex = i
            Exit For
          End If
        Next
        If storIndex >= 0 Then
          lst1.RemoveAt(storIndex)
          Dim cells As New List(Of Cell)
          cells.AddRange(_Cells)
          cells.RemoveAt(Index)
          _Cells = cells.ToArray()
          blnSuccess = True
        End If
      Else
        Throw New NullReferenceException()
      End If
    End Sub
    Public Sub Remove(ByVal obj As Cell)
      Remove(IndexOf(obj))
    End Sub

    Public Function IndexOf(ByVal obj As Cell) As Integer
      If Not IsNothing(_Cells) Then
        For i = 0 To _Cells.Length - 1 Step 1
          If _Cells(i).Id = obj.Id And
            _Cells(i).LocationX = obj.LocationX And
            _Cells(i).LocationY = obj.LocationY And
            _Cells(i).LocationZ = obj.LocationZ And
            _Cells(i).Width = obj.Width And
            _Cells(i).Depth = obj.Depth And
            _Cells(i).Height = obj.Height Then
            Return i
          End If
        Next
      End If
      Return -1
    End Function

    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      Select Case e.Name
        Case "Id"
          _StorageRef.Description = e.NewValue
        Case "LocationX"
          _StorageRef.LocationX = e.NewValue
        Case "LocationY"
          _StorageRef.LocationY = e.NewValue
        Case "LocationZ"
          _StorageRef.LocationZ = e.NewValue
        Case "Width"
          _StorageRef.LengthX = e.NewValue
        Case "Depth"
          _StorageRef.LengthY = e.NewValue
        Case "Height"
          _StorageRef.LengthZ = e.NewValue
        Case "Cells"
          'Debug.WriteLine("Fuck that!")
      End Select
    End Sub
  End Class

  Public Sub New(ByVal Ref As Storage)
    _StorageRef = Ref
    _Id = _StorageRef.StorageId
    Integer.TryParse(_StorageRef.Width, _Width)
    Integer.TryParse(_StorageRef.Depth, _Depth)
    Integer.TryParse(_StorageRef.Height, _Height)

    AddHandler PropertyChanged, AddressOf PropChanged
  End Sub

  Public Sub Add(Optional ByVal loc As StorageLocation = Nothing, Optional ByVal sz As StorageSize = Nothing)
    Dim mainPlaceRef As StoragePlaceRef
    Dim subRef1 As StoragePlaceRef
    If IsNothing(StorageRef.StoragePlace.StoragePlaceRef.StoragePlaceList) Then
      mainPlaceRef = New StoragePlaceRef
      mainPlaceRef.StoragePlaceListId = 0
      subRef1 = New StoragePlaceRef
      mainPlaceRef.StoragePlaceRef = subRef1
      StorageRef.StoragePlace.StoragePlaceRef.StoragePlaceList = New StoragePlaceList With {.StoragePlaceRef = {mainPlaceRef}}
    ElseIf IsNothing(StorageRef.StoragePlace.StoragePlaceRef.StoragePlaceList.StoragePlaceRef) Then
      mainPlaceRef = New StoragePlaceRef
      mainPlaceRef.StoragePlaceListId = 0
      subRef1 = New StoragePlaceRef
      mainPlaceRef.StoragePlaceRef = subRef1
      StorageRef.StoragePlace.StoragePlaceRef.StoragePlaceList.StoragePlaceRef = {mainPlaceRef}
    Else
      mainPlaceRef = StorageRef.StoragePlace.StoragePlaceRef.StoragePlaceList.StoragePlaceRef(0)
      If IsNothing(mainPlaceRef.StoragePlaceRef) Then
        subRef1 = New StoragePlaceRef
        mainPlaceRef.StoragePlaceRef = subRef1
      Else
        subRef1 = mainPlaceRef.StoragePlaceRef
      End If
    End If
    Dim lst1 As New List(Of StoragePlaceRef)
    If Not IsNothing(subRef1) Then
      If Not IsNothing(subRef1.StoragePlaceList) Then
        lst1.AddRange(subRef1.StoragePlaceList.StoragePlaceRef)
      End If
    Else
      Debug.WriteLine("SubRef1 is nothing")
    End If
    Dim shlfMainRef As New StoragePlaceRef
    shlfMainRef.StoragePlaceListId = lst1.Count.ToString
    Dim shlfSubRef As New StoragePlaceRef
    shlfSubRef.Description = "New Shelf"
    shlfSubRef.WeightMax = 1000
    If IsNothing(loc) Then
      loc = New StorageLocation
      loc.X = 0
      loc.Y = 0
      loc.Z = 0
    End If
    shlfSubRef.LocationX = loc.X
    shlfSubRef.LocationY = loc.Y
    shlfSubRef.LocationZ = loc.Z
    If IsNothing(sz) Then
      sz = New StorageSize
      sz.Width = Me.Width
      sz.Depth = Me.Depth
      sz.Height = CInt((Me.Height) / (lst1.Count + 1))
    End If
    shlfSubRef.LengthX = sz.Width
    shlfSubRef.LengthY = sz.Depth
    shlfSubRef.LengthZ = sz.Height
    shlfMainRef.StoragePlaceRef = shlfSubRef
    lst1.Add(shlfMainRef)
    If IsNothing(subRef1.StoragePlaceList) Then
      subRef1.StoragePlaceList = New StoragePlaceList
    End If
    subRef1.StoragePlaceList.StoragePlaceRef = lst1.ToArray()
    If Not IsNothing(_Shelves) Then
      ReDim Preserve _Shelves(_Shelves.Length)
    Else
      ReDim _Shelves(0)
    End If
    _Shelves(_Shelves.Length - 1) = New Shelf(shlfSubRef) With {.Parent = Me}
  End Sub
  Public Sub Remove(ByVal Index As Integer)
    If IsNothing(_Shelves) Then Throw New NullReferenceException()
    If Index < 0 Or Index >= _Shelves.Length Then Throw New IndexOutOfRangeException()

    Dim blnSuccess As Boolean = False
    Dim mainPlaceRef As StoragePlaceRef
    Dim subRef1 As StoragePlaceRef
    '' Assign reference to list
    mainPlaceRef = StorageRef.StoragePlace.StoragePlaceRef.StoragePlaceList.StoragePlaceRef(0)
    If IsNothing(mainPlaceRef.StoragePlaceRef) Then
      subRef1 = New StoragePlaceRef
      mainPlaceRef.StoragePlaceRef = subRef1
    Else
      subRef1 = mainPlaceRef.StoragePlaceRef
    End If
    '' Fill Storage list
    Dim lst1 As New List(Of StoragePlaceRef)
    If Not IsNothing(subRef1) Then
      If Not IsNothing(subRef1.StoragePlaceList) Then
        lst1.AddRange(subRef1.StoragePlaceList.StoragePlaceRef)
      End If
    Else
      Debug.WriteLine("SubRef1 is nothing")
    End If
    '' Get/Compare shelves
    Dim shlf As Shelf = Me(Index)
    If Not IsNothing(shlf) Then
      Dim storIndex As Integer = -1
      For i = 0 To lst1.Count - 1 Step 1
        If lst1(i).StoragePlaceRef.Description = shlf.Id And
          lst1(i).StoragePlaceRef.LocationX = shlf.LocationX And
          lst1(i).StoragePlaceRef.LocationY = shlf.LocationY And
          lst1(i).StoragePlaceRef.LocationZ = shlf.LocationZ And
          lst1(i).StoragePlaceRef.LengthX = shlf.Width And
          lst1(i).StoragePlaceRef.LengthY = shlf.Depth And
          lst1(i).StoragePlaceRef.LengthZ = shlf.Height Then
          storIndex = i
          Exit For
        End If
      Next
      If storIndex >= 0 Then
        lst1.RemoveAt(storIndex)
        Dim shlfs As New List(Of Shelf)
        shlfs.AddRange(_Shelves)
        shlfs.RemoveAt(Index)
        _Shelves = shlfs.ToArray()
        blnSuccess = True
      End If
    Else
      Throw New NullReferenceException()
    End If
  End Sub
  Public Sub Remove(ByVal obj As Shelf)
    Remove(IndexOf(obj))
  End Sub

  Public Function IndexOf(ByVal obj As Shelf) As Integer
    If Not IsNothing(_Shelves) Then
      For i = 0 To _Shelves.Length - 1 Step 1
        If _Shelves(i).Id = obj.Id And
          _Shelves(i).LocationX = obj.LocationX And
          _Shelves(i).LocationY = obj.LocationY And
          _Shelves(i).LocationZ = obj.LocationZ And
          _Shelves(i).Width = obj.Width And
          _Shelves(i).Depth = obj.Depth And
          _Shelves(i).Height = obj.Height Then
          Return i
        End If
      Next
    End If
    Return -1
  End Function

  Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
    Select Case e.Name
      Case "Id"
        _StorageRef.StorageId = e.NewValue
      Case "Width"
        _StorageRef.Width = e.NewValue
      Case "Depth"
        _StorageRef.Depth = e.NewValue
      Case "Height"
        _StorageRef.Height = e.NewValue
      Case "Shelves"
        'Debug.WriteLine("Fuck that!")
    End Select
  End Sub
End Class
Public Class StorageLocation
  Public Property X As Integer
  Public Property Y As Integer
  Public Property Z As Integer
End Class
Public Class StorageSize
  Public Property Width As Integer
  Public Property Depth As Integer
  Public Property Height As Integer
End Class
Public Class PropertyChangedEventArgs
  Public Property Name As String
  Public Property OldValue As Object
  Public Property NewValue As Object

  Public Overrides Function ToString() As String
    Dim out As String = "{Name=" & Me.Name & ", OldValue= "
    If IsNothing(Me.OldValue) Then
      out += "[Empty]"
    Else
      out += OldValue.ToString
    End If
    out += ", NewValue= "
    If IsNothing(Me.NewValue) Then
      out += "[Empty]"
    Else
      out += NewValue.ToString
    End If
    out += "}"
    Return out
  End Function

  Public Sub New(ByVal pName As String, ByVal oVal As Object, ByVal nVal As Object)
    Me.Name = pName
    Me.OldValue = oVal
    Me.NewValue = nVal
  End Sub
End Class