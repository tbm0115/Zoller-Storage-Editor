Imports System.Windows.Forms

Public Class AddRange
  Public Property StorageStart As StorageLocation
  Public Property StorageSize As StorageSize
  Public Property StorageLayout As LayoutType
  Public Property StorageSteps As StorageLocation
  Public Property StorageStepOrder As StepOrder
  Public Property StorageStepCount As StorageLocation

  Public Property ParentObject As Object

  Public Enum LayoutType
    Linear
    Grid
  End Enum
  Public Enum StepOrder
    XYZ
    XZY
    YXZ
    YZX
    ZXY
    ZYX
  End Enum

  Public Sub New(ByVal sender As Object)
    InitializeComponent()

    If sender.GetType().Name = "Rack" Or sender.GetType().Name = "Shelf" Then
      ParentObject = sender
      If ParentObject.GetType.Name = "Rack" Then
        lblParentLocation.Visible = False
      Else
        lblParentLocation.Visible = True
        lblParentLocation.Text = "{X=" & ParentObject.LocationX.ToString & ", Y=" & ParentObject.LocationY.ToString & ", Z=" & ParentObject.LocationZ.ToString & "}"
      End If
      lblParentSize.Text = "{W=" & ParentObject.Width.ToString & ", D=" & ParentObject.Depth.ToString & ", H=" & ParentObject.Height.ToString & "}"

    Else
      MessageBox.Show("You can only add mutliple objects to either a Rack/Cabinet or Shelf/Drawer!", "Invalid Parent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Me.DialogResult = System.Windows.Forms.DialogResult.Abort
      grpStart.Enabled = False
      grpSize.Enabled = False
      grpStep.Enabled = False
      grpTranslationType.Enabled = False
      grpStepOrder.Enabled = False
      OK_Button.Enabled = False
      Exit Sub
    End If
  End Sub

  Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
    Me.StorageStart = New StorageLocation With {.X = numStartX.Value, .Y = numStartY.Value, .Z = numStartZ.Value}
    '' Check object size
    If numSizeX.Value > 0 And numSizeY.Value > 0 And numSizeZ.Value > 0 Then
      Me.StorageSize = New StorageSize With {.Width = numSizeX.Value, .Depth = numSizeY.Value, .Height = numSizeZ.Value}
    Else
      MessageBox.Show("Object must be 3-Dimensional!" & vbLf & "Please adjust all three size lengths greater than zero.", "3D Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      If numSizeX.Value = 0 Then numSizeX.Focus()
      If numSizeY.Value = 0 Then numSizeY.Focus()
      If numSizeZ.Value = 0 Then numSizeZ.Focus()
      Exit Sub
    End If
    '' Check step order, step counts and step distances
    Select Case drpStep1.SelectedItem.ToString
      Case "X"
        Select Case drpStep2.SelectedItem.ToString
          Case "Y"
            Me.StorageStepOrder = StepOrder.XYZ
          Case "Z"
            Me.StorageStepOrder = StepOrder.XZY
        End Select
      Case "Y"
        Select Case drpStep2.SelectedItem.ToString
          Case "X"
            Me.StorageStepOrder = StepOrder.YXZ
          Case "Z"
            Me.StorageStepOrder = StepOrder.YZX
        End Select
      Case "Z"
        Select Case drpStep2.SelectedItem.ToString
          Case "X"
            Me.StorageStepOrder = StepOrder.ZXY
          Case "Y"
            Me.StorageStepOrder = StepOrder.ZYX
        End Select
    End Select
    If IsNothing(Me.StorageStepOrder) Then
      MessageBox.Show("Step Order not defined!" & vbLf & "Please finish specifying which order the steps should be taken.", "Order Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      drpStep1.Focus()
      Exit Sub
    ElseIf numStep1Times.Value > 0 Or numStep2Times.Value > 0 Or numStep3Times.Value > 0 Then
      Me.StorageStepCount = New StorageLocation
      Select Case drpStep1.SelectedItem.ToString
        Case "X"
          Me.StorageStepCount.X = numStep1Times.Value
        Case "Y"
          Me.StorageStepCount.Y = numStep1Times.Value
        Case "Z"
          Me.StorageStepCount.Z = numStep1Times.Value
      End Select
      Select Case drpStep2.SelectedItem.ToString
        Case "X"
          Me.StorageStepCount.X = numStep2Times.Value
        Case "Y"
          Me.StorageStepCount.Y = numStep2Times.Value
        Case "Z"
          Me.StorageStepCount.Z = numStep2Times.Value
      End Select
      Select Case txtStep3.Text.ToString
        Case "X"
          Me.StorageStepCount.X = numStep3Times.Value
        Case "Y"
          Me.StorageStepCount.Y = numStep3Times.Value
        Case "Z"
          Me.StorageStepCount.Z = numStep3Times.Value
      End Select
    Else
      MessageBox.Show("Cannot add zero times!" & vbLf & "Please increase any step direction at least once.", "Add Count", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      numStep1Times.Focus()
      Exit Sub
    End If
    If numStepX.Value > 0 Or numStepY.Value > 0 Or numStepZ.Value > 0 Then
      Me.StorageSteps = New StorageLocation With {.X = numStepX.Value, .Y = numStepY.Value, .Z = numStepZ.Value}
    Else
      MessageBox.Show("Some form of motion must be done!" & vbLf & "Please increase the step distance of at least one direction.", "No Motion Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      numStepX.Focus()
      Exit Sub
    End If
    '' Check bounds of results against parent X, Y, then Z
    Dim val, out As Double
    val = (Me.StorageStart.X + ((Me.StorageSize.Width + (Me.StorageSteps.X - Me.StorageSize.Width)) * Me.StorageStepCount.X))
    If val > ParentObject.Width Then
      out = val - ParentObject.Width
      MessageBox.Show("Overflow detected!" & vbLf & "Add range projected to exceed X bounds by " & (out).ToString & " units." & vbLf & val.ToString & "!<" & ParentObject.Width.ToString, "Overflow Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Exit Sub
    End If
    val = (Me.StorageStart.Y + ((Me.StorageSize.Depth + (Me.StorageSteps.Y - Me.StorageSize.Depth)) * Me.StorageStepCount.Y))
    If val > ParentObject.Depth Then
      out = val - ParentObject.Depth
      MessageBox.Show("Overflow detected!" & vbLf & "Add range projected to exceed Y bounds by " & (out).ToString & " units." & vbLf & val.ToString & "!<" & ParentObject.Depth.ToString, "Overflow Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Exit Sub
    End If
    val = (Me.StorageStart.Z + ((Me.StorageSize.Height + (Me.StorageSteps.Z - Me.StorageSize.Height)) * Me.StorageStepCount.Z))
    If val > ParentObject.Height Then
      out = val - ParentObject.Height
      MessageBox.Show("Overflow detected!" & vbLf & "Add range projected to exceed Z bounds by " & (out).ToString & " units." & vbLf & val.ToString & "!<" & ParentObject.Height.ToString, "Overflow Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Exit Sub
    End If

    Me.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.Close()
  End Sub

  Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Close()
  End Sub

  Private Sub drpStep1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpStep1.SelectedIndexChanged
    drpStep2.Items.Clear()
    txtStep3.Clear()
    If Not IsNothing(drpStep1.SelectedItem) Then
      For Each s As String In drpStep1.Items
        If Not s = drpStep1.SelectedItem.ToString Then
          drpStep2.Items.Add(s)
        End If
      Next
    End If
    drpStep2.SelectedIndex = 0
    Me.StorageStepOrder = Nothing
  End Sub
  Private Sub drpStep2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpStep2.SelectedIndexChanged
    txtStep3.Clear()
    If Not IsNothing(drpStep2.SelectedItem) Then
      For Each s As String In drpStep2.Items
        If Not s = drpStep2.SelectedItem.ToString Then
          txtStep3.Text = s
        End If
      Next
    End If
  End Sub

  Private Sub radLinear_CheckedChanged(sender As Object, e As EventArgs) Handles radLinear.CheckedChanged
    lblDir2.Enabled = False
    drpStep2.Enabled = False
    drpStep2.SelectedIndex = -1
    numStep2Times.Enabled = False
    lblDir3.Enabled = False
    txtStep3.Enabled = False
    txtStep3.Clear()
    numStep3Times.Enabled = False
    Me.StorageLayout = LayoutType.Linear
  End Sub
  Private Sub radGrid_CheckedChanged(sender As Object, e As EventArgs) Handles radGrid.CheckedChanged
    lblDir2.Enabled = True
    drpStep2.Enabled = True
    numStep2Times.Enabled = True
    lblDir3.Enabled = True
    txtStep3.Enabled = True
    numStep3Times.Enabled = True
    Me.StorageLayout = LayoutType.Grid
  End Sub

  Public Function GetStorages() As StoragePlaceRef()
    If Me.DialogResult = Windows.Forms.DialogResult.OK Then
      Select Case Me.StorageLayout
        Case LayoutType.Linear
          If Me.StorageStepOrder.ToString.StartsWith("X") Then
            Return GetStoragesX()
          ElseIf Me.StorageStepOrder.ToString.StartsWith("Y") Then
            Return GetStoragesY()
          ElseIf Me.StorageStepOrder.ToString.StartsWith("Z") Then
            Return GetStoragesZ()
          Else
            Debug.WriteLine("Couldn't determine order style " & Me.StorageStepOrder.ToString)
          End If
        Case LayoutType.Grid
          Return MergeStorageMatrix()
        Case Else
          Debug.WriteLine("Couldn't determine Layout style")
      End Select
    End If
  End Function
  Private Function GetStoragesX() As StoragePlaceRef()
    Dim lst As New List(Of StoragePlaceRef)
    Dim curPos As New StorageLocation With {.X = Me.StorageStart.X, .Y = Me.StorageStart.Y, .Z = Me.StorageStart.Z}
    Dim spr As StoragePlaceRef
    If Me.StorageStepCount.X > 0 Then
      For i = 0 To Me.StorageStepCount.X - 1 Step 1
        spr = New StoragePlaceRef
        spr.LocationX = curPos.X
        spr.LocationY = curPos.Y
        spr.LocationZ = curPos.Z
        spr.LengthX = Me.StorageSize.Width
        spr.LengthY = Me.StorageSize.Depth
        spr.LengthZ = Me.StorageSize.Height
        lst.Add(spr)
        curPos.X += Me.StorageSteps.X
      Next
    End If
    Return lst.ToArray()
  End Function
  Private Function GetStoragesY() As StoragePlaceRef()
    Dim lst As New List(Of StoragePlaceRef)
    Dim curPos As New StorageLocation With {.X = Me.StorageStart.X, .Y = Me.StorageStart.Y, .Z = Me.StorageStart.Z}
    Dim spr As StoragePlaceRef
    If Me.StorageStepCount.Y > 0 Then
      For i = 0 To Me.StorageStepCount.Y - 1 Step 1
        spr = New StoragePlaceRef
        spr.LocationX = curPos.X
        spr.LocationY = curPos.Y
        spr.LocationZ = curPos.Z
        spr.LengthX = Me.StorageSize.Width
        spr.LengthY = Me.StorageSize.Depth
        spr.LengthZ = Me.StorageSize.Height
        lst.Add(spr)
        curPos.Y += Me.StorageSteps.Y
      Next
    End If
    Return lst.ToArray()
  End Function
  Private Function GetStoragesZ() As StoragePlaceRef()
    Dim lst As New List(Of StoragePlaceRef)
    Dim curPos As New StorageLocation With {.X = Me.StorageStart.X, .Y = Me.StorageStart.Y, .Z = Me.StorageStart.Z}
    Dim spr As StoragePlaceRef
    If Me.StorageStepCount.Z > 0 Then
      For i = 0 To Me.StorageStepCount.Z - 1 Step 1
        spr = New StoragePlaceRef
        spr.LocationX = curPos.X
        spr.LocationY = curPos.Y
        spr.LocationZ = curPos.Z
        spr.LengthX = Me.StorageSize.Width
        spr.LengthY = Me.StorageSize.Depth
        spr.LengthZ = Me.StorageSize.Height
        lst.Add(spr)
        curPos.Z += Me.StorageSteps.Z
      Next
    End If
    Return lst.ToArray()
  End Function
  Private Function MergeStorageMatrix() As StoragePlaceRef()
    Dim firstRound As StoragePlaceRef()
    Dim tot As StoragePlaceRef()
    Dim x, y, z As StoragePlaceRef()
    x = GetStoragesX()
    y = GetStoragesY()
    z = GetStoragesZ()
    Select Case Me.StorageStepOrder
      Case StepOrder.XYZ
        If IsNothingOrEmpty(x) And IsNothingOrEmpty(y) Then
          Debug.WriteLine("Cannot create 2D array without at least one first round of merge.")
        ElseIf IsNothingOrEmpty(x) Then
          firstRound = y
        ElseIf IsNothingOrEmpty(y) Then
          firstRound = x
        Else
          firstRound = MergeXtoY(x, y)
        End If
        If IsNothingOrEmpty(z) And IsNothingOrEmpty(firstRound) Then
          Debug.WriteLine("Cannot create 2D/3D array without at least one second round of merge.")
        ElseIf IsNothingOrEmpty(z) Then
          tot = firstRound
        ElseIf IsNothingOrEmpty(firstRound) Then
          tot = z
        Else
          tot = MergeYtoZ(firstRound, z)
        End If
      Case StepOrder.XZY
        If IsNothingOrEmpty(x) And IsNothingOrEmpty(z) Then
          Debug.WriteLine("Cannot create 2D array without at least one first round of merge.")
        ElseIf IsNothingOrEmpty(x) Then
          firstRound = z
        ElseIf IsNothingOrEmpty(z) Then
          firstRound = x
        Else
          firstRound = MergeXtoZ(x, z)
        End If
        If IsNothingOrEmpty(y) And IsNothingOrEmpty(firstRound) Then
          Debug.WriteLine("Cannot create 2D/3D array without at least one second round of merge.")
        ElseIf IsNothingOrEmpty(y) Then
          tot = firstRound
        ElseIf IsNothingOrEmpty(firstRound) Then
          tot = y
        Else
          tot = MergeZtoY(y, firstRound)
        End If
      Case StepOrder.YXZ
        If IsNothingOrEmpty(x) And IsNothingOrEmpty(y) Then
          Debug.WriteLine("Cannot create 2D array without at least one first round of merge.")
        ElseIf IsNothingOrEmpty(x) Then
          firstRound = y
        ElseIf IsNothingOrEmpty(y) Then
          firstRound = x
        Else
          firstRound = MergeYtoX(x, y)
        End If
        If IsNothingOrEmpty(z) And IsNothingOrEmpty(firstRound) Then
          Debug.WriteLine("Cannot create 2D/3D array without at least one second round of merge.")
        ElseIf IsNothingOrEmpty(z) Then
          tot = firstRound
        ElseIf IsNothingOrEmpty(firstRound) Then
          tot = z
        Else
          tot = MergeXtoZ(firstRound, z)
        End If
      Case StepOrder.YZX
        If IsNothingOrEmpty(z) And IsNothingOrEmpty(y) Then
          Debug.WriteLine("Cannot create 2D array without at least one first round of merge.")
        ElseIf IsNothingOrEmpty(z) Then
          firstRound = y
        ElseIf IsNothingOrEmpty(y) Then
          firstRound = z
        Else
          firstRound = MergeYtoZ(y, z)
        End If
        If IsNothingOrEmpty(x) And IsNothingOrEmpty(firstRound) Then
          Debug.WriteLine("Cannot create 2D/3D array without at least one second round of merge.")
        ElseIf IsNothingOrEmpty(x) Then
          tot = firstRound
        ElseIf IsNothingOrEmpty(firstRound) Then
          tot = x
        Else
          tot = MergeZtoX(x, firstRound)
        End If
      Case StepOrder.ZXY
        If IsNothingOrEmpty(x) And IsNothingOrEmpty(z) Then
          Debug.WriteLine("Cannot create 2D array without at least one first round of merge.")
        ElseIf IsNothingOrEmpty(x) Then
          firstRound = z
        ElseIf IsNothingOrEmpty(z) Then
          firstRound = x
        Else
          firstRound = MergeZtoX(x, z)
        End If
        If IsNothingOrEmpty(y) And IsNothingOrEmpty(firstRound) Then
          Debug.WriteLine("Cannot create 2D/3D array without at least one second round of merge.")
        ElseIf IsNothingOrEmpty(y) Then
          tot = firstRound
        ElseIf IsNothingOrEmpty(firstRound) Then
          tot = y
        Else
          tot = MergeXtoY(firstRound, y)
        End If
      Case StepOrder.ZYX
        If IsNothingOrEmpty(z) And IsNothingOrEmpty(y) Then
          Debug.WriteLine("Cannot create 2D array without at least one first round of merge.")
        ElseIf IsNothingOrEmpty(z) Then
          firstRound = y
        ElseIf IsNothingOrEmpty(y) Then
          firstRound = z
        Else
          firstRound = MergeZtoY(y, z)
        End If
        If IsNothingOrEmpty(x) And IsNothingOrEmpty(firstRound) Then
          Debug.WriteLine("Cannot create 2D/3D array without at least one second round of merge.")
        ElseIf IsNothingOrEmpty(x) Then
          tot = firstRound
        ElseIf IsNothingOrEmpty(firstRound) Then
          tot = x
        Else
          tot = MergeYtoX(x, firstRound)
        End If
    End Select
    'Debug.WriteLine("FirstRound: " & firstRound.Length.ToString & " objects")
    Return tot
  End Function
  Private Function MergeXtoY(ByVal StorageX As StoragePlaceRef(), ByVal StorageY As StoragePlaceRef()) As StoragePlaceRef()
    Dim lst As New List(Of StoragePlaceRef)
    Dim spr As StoragePlaceRef
    If Not IsNothing(StorageX) And Not IsNothing(StorageY) Then
      For i = 0 To StorageY.Length - 1 Step 1
        For j = 0 To StorageX.Length - 1 Step 1
          spr = New StoragePlaceRef
          spr.LocationX = StorageX(j).LocationX
          spr.LocationY = StorageY(i).LocationY
          spr.LocationZ = StorageX(j).LocationZ
          spr.LengthX = StorageX(j).LengthX
          spr.LengthY = StorageX(j).LengthY
          spr.LengthZ = StorageX(j).LengthZ
          lst.Add(spr)
        Next
      Next
    End If
    Return lst.ToArray()
  End Function
  Private Function MergeYtoX(ByVal StorageX As StoragePlaceRef(), ByVal StorageY As StoragePlaceRef()) As StoragePlaceRef()
    Dim lst As New List(Of StoragePlaceRef)
    Dim spr As StoragePlaceRef
    If Not IsNothing(StorageX) And Not IsNothing(StorageY) Then
      For i = 0 To StorageX.Length - 1 Step 1
        For j = 0 To StorageY.Length - 1 Step 1
          spr = New StoragePlaceRef
          spr.LocationX = StorageX(i).LocationX
          spr.LocationY = StorageY(j).LocationY
          spr.LocationZ = StorageY(j).LocationZ
          spr.LengthX = StorageY(j).LengthX
          spr.LengthY = StorageY(j).LengthY
          spr.LengthZ = StorageY(j).LengthZ
          lst.Add(spr)
        Next
      Next
    End If
    Return lst.ToArray()
  End Function
  Private Function MergeXtoZ(ByVal StorageX As StoragePlaceRef(), ByVal StorageZ As StoragePlaceRef()) As StoragePlaceRef()
    Dim lst As New List(Of StoragePlaceRef)
    Dim spr As StoragePlaceRef
    If Not IsNothing(StorageX) And Not IsNothing(StorageZ) Then
      For i = 0 To StorageZ.Length - 1 Step 1
        For j = 0 To StorageX.Length - 1 Step 1
          spr = New StoragePlaceRef
          spr.LocationX = StorageX(j).LocationX
          spr.LocationY = StorageX(j).LocationY
          spr.LocationZ = StorageZ(i).LocationZ
          spr.LengthX = StorageX(j).LengthX
          spr.LengthY = StorageX(j).LengthY
          spr.LengthZ = StorageX(j).LengthZ
          lst.Add(spr)
        Next
      Next
    End If
    Return lst.ToArray()
  End Function
  Private Function MergeZtoX(ByVal StorageX As StoragePlaceRef(), ByVal StorageZ As StoragePlaceRef()) As StoragePlaceRef()
    Dim lst As New List(Of StoragePlaceRef)
    Dim spr As StoragePlaceRef
    If Not IsNothing(StorageX) And Not IsNothing(StorageZ) Then
      For i = 0 To StorageX.Length - 1 Step 1
        For j = 0 To StorageZ.Length - 1 Step 1
          spr = New StoragePlaceRef
          spr.LocationX = StorageX(i).LocationX
          spr.LocationY = StorageZ(j).LocationY
          spr.LocationZ = StorageZ(j).LocationZ
          spr.LengthX = StorageZ(j).LengthX
          spr.LengthY = StorageZ(j).LengthY
          spr.LengthZ = StorageZ(j).LengthZ
          lst.Add(spr)
        Next
      Next
    End If
    Return lst.ToArray()
  End Function
  Private Function MergeYtoZ(ByVal StorageY As StoragePlaceRef(), ByVal StorageZ As StoragePlaceRef()) As StoragePlaceRef()
    Dim lst As New List(Of StoragePlaceRef)
    Dim spr As StoragePlaceRef
    If Not IsNothing(StorageY) And Not IsNothing(StorageZ) Then
      For i = 0 To StorageZ.Length - 1 Step 1
        For j = 0 To StorageY.Length - 1 Step 1
          spr = New StoragePlaceRef
          spr.LocationX = StorageY(j).LocationX
          spr.LocationY = StorageY(j).LocationY
          spr.LocationZ = StorageZ(i).LocationZ
          spr.LengthX = StorageY(j).LengthX
          spr.LengthY = StorageY(j).LengthY
          spr.LengthZ = StorageY(j).LengthZ
          lst.Add(spr)
        Next
      Next
    End If
    Return lst.ToArray()
  End Function
  Private Function MergeZtoY(ByVal StorageY As StoragePlaceRef(), ByVal StorageZ As StoragePlaceRef()) As StoragePlaceRef()
    Dim lst As New List(Of StoragePlaceRef)
    Dim spr As StoragePlaceRef
    If Not IsNothing(StorageY) And Not IsNothing(StorageZ) Then
      For i = 0 To StorageY.Length - 1 Step 1
        For j = 0 To StorageZ.Length - 1 Step 1
          spr = New StoragePlaceRef
          spr.LocationX = StorageZ(j).LocationX
          spr.LocationY = StorageY(i).LocationY
          spr.LocationZ = StorageZ(j).LocationZ
          spr.LengthX = StorageZ(j).LengthX
          spr.LengthY = StorageZ(j).LengthY
          spr.LengthZ = StorageZ(j).LengthZ
          lst.Add(spr)
        Next
      Next
    End If
    Return lst.ToArray()
  End Function

End Class
